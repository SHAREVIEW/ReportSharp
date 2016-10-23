using ReportSharpCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ReportSharpCore.Model;
using ReportSharpCore.Helper;

namespace ReportSharpCore
{
    public class ReportingClient
    {
        public async Task<string> Render(IEnumerable<IReportGroup> groups, HtmlOptions reportOptions = null, IEnumerable<ReportElement> PreTableElements = null, IEnumerable<ReportElement> PostTableElements = null)
        {
            return await Task.Run(() =>
            {
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
                    <div {0}>", reportOptions?.ToString());

                if (PreTableElements?.Any() == true)
                {
                    foreach (var element in PreTableElements)
                    {
                        report.Append(element.ToString());
                    }
                }

                foreach (var group in groups)
                {
                    if (group.Any())
                    {
                        report.Append(group.ToString());
                    }
                }

                if (PostTableElements?.Any() == true)
                {
                    foreach (var element in PostTableElements)
                    {
                        report.Append(element.ToString());
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
