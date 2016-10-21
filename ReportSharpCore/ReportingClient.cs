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
            <table class='table table-responsive table-striped'>");
        
            foreach (var group in groups)
            {
                if (group.Any()) {
                    //Escreve o header do relatório
                    var type = group.First().GetType();
                    var columnCount = type.GetRuntimeProperties().Count();
                    report.AppendFormat(@"
                    <tr>
                        <td colspan='{0}'><h2>{1}</h2></th>
                    </tr>
                    <tr>
                    ", columnCount, group.Key);
                    foreach (var name in type.GetRuntimeProperties().Select(t => t.Name)){
                        string properties = "";
                        if (group.Options?.ContainsKey(name) == true) {
                            properties = HtmlStringHelper.CreateHtmlPropertiesString(group.Options[name]);
                        }
                        report.AppendFormat(@"<th {0} >{1}</th>", properties, name);
                    }
                    report.Append(@"
                    </tr>");

                    //Escreve conteúdo do relatório
                    foreach (var item in group)
                    {
                        report.Append(@"<tr>");
                        foreach (var value in type.GetRuntimeProperties().Select(t => t.GetValue(item))) {
                            report.AppendFormat(@"<td>{0}</td>", value);
                        }
                        report.Append(@"</tr>");
                    }

                }
            }

            if (PostTableElements?.Any() == true) {
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
        }
    }
}
