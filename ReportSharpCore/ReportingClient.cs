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
        public async Task<string> CompileReport(IEnumerable<IReportGroup> groups, IEnumerable<ReportElement> PreTableElements = null, IEnumerable<ReportElement> PostTableElements = null)
        {
            return await Task.Run(() =>
            {
                StringBuilder report = new StringBuilder();
                report.Append(@"
                <!DOCTYPE html>
                <html>
                <head>
                  <title> Report </title>
                    <meta charset = 'utf-8'>
                    <meta name = 'viewport' content = 'width=device-width, initial-scale=1'>
                    <link rel = 'stylesheet' href = 'https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css'>
                </head>
                <body>
                    <div class='conteiner'>");

                if (PreTableElements?.Any() == true)
                {
                    foreach (var element in PreTableElements)
                    {
                        report.Append(element.ToString());
                    }
                }


                report.Append(@"
                <table class='table table-responsive table-striped' style='width: 800px; table-layout: fixed; word-wrap: break-word;'>");

                foreach (var group in groups)
                {
                    if (group.Any())
                    {
                        

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
                </table>
                </div>
                </body>
                </html>");

                return report.ToString();
            });
        }
    }
}
