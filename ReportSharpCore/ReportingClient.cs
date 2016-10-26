using ReportSharpCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ReportSharpCore.Model;
using ReportSharpCore.Helper;
using Windows.Storage;

namespace ReportSharpCore
{
    public class ReportingClient
    {
        public async Task<StorageFile> RenderToFileAsync(StorageFolder folder, string filename, IEnumerable<IReportGroup> groups, PageOptions.PageSize _pageSize = null, PageOptions.PageOrientation _pageOrientation = PageOptions.PageOrientation.Portrait, HtmlOptions _reportOptions = null, IEnumerable<IReportElement> PreTableElements = null, IEnumerable<IReportElement> PostTableElements = null)
        {
            return await Task.Run(async() =>
            {
                var _report = await RenderToStringAsync(groups, _pageSize, _pageOrientation, _reportOptions, PreTableElements, PostTableElements);
                var file = await folder.TryGetItemAsync(filename) as StorageFile;
                if (file == null)
                    file = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(file, _report);
                return file;
            });
        }

        public async Task<string> RenderToStringAsync(IEnumerable<IReportGroup> groups, PageOptions.PageSize _pageSize = null, PageOptions.PageOrientation _pageOrientation = PageOptions.PageOrientation.Portrait, HtmlOptions _reportOptions = null, IEnumerable<IReportElement> PreTableElements = null, IEnumerable<IReportElement> PostTableElements = null)
        {
            return await Task.Run(async () =>
            {
                _pageSize = _pageSize == null ? PageOptions.A4 : _pageSize;
                var _width = _pageOrientation == PageOptions.PageOrientation.Portrait ? _pageSize.Width.ToString() + "mm" : _pageSize.Height.ToString() + "mm";
                _reportOptions = _reportOptions == null ? new HtmlOptions { Width = _width, Margin = "auto" } : _reportOptions;
                StringBuilder report = new StringBuilder();
                report.AppendFormat(@"
                <!DOCTYPE html>
                <html>
                <head>
                  <title> Report </title>
                  <meta charset = 'utf-8'>
                  <meta name = 'viewport' content = 'width=device-width, initial-scale=1'>
                  <link rel = 'stylesheet' href = 'https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css'>
                </head>
                <body>
                    <div {0}>", _reportOptions?.ToString());

                if (PreTableElements?.Any() == true)
                {
                    foreach (var element in PreTableElements)
                    {
                        report.Append(await element.RenderToStringAsync());
                    }
                }

                foreach (var group in groups)
                {
                    if (group.Any())
                    {
                        report.Append(await group.RenderToStringAsync());
                    }
                }

                if (PostTableElements?.Any() == true)
                {
                    foreach (var element in PostTableElements)
                    {
                        report.Append(await element.RenderToStringAsync());
                    }
                }

                report.Append(@"
                    </div>
                </body>
                </html>");

                return report.ToString();
            });
        }
    }
}
