using ReportSharpCore.Enum;
using ReportSharpCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSharpCore.Interface
{
    public interface IReportElement
    {
        HtmlTag Tag { get; set; }
        object Content { get; set; }
        HtmlOptions HtmlProperties { get; set; }
        Func<string> GetContent { get; set; }
        Task<string> RenderToStringAsync();
    }
}
