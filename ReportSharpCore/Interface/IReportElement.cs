using ReportSharpCore.Enum;
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
        IEnumerable<string> HtmlProperties { get; set; }
        string ToString();
    }
}
