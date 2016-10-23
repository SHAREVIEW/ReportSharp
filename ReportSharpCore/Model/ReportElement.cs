using ReportSharpCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportSharpCore.Enum;
using ReportSharpCore.Helper;

namespace ReportSharpCore.Model
{
    public class ReportElement : IReportElement
    {
        public HtmlTag Tag { get; set; }
        public object Content { get; set; }
        public HtmlOptions HtmlProperties { get; set; }

        public override string ToString()
        {
            return string.Format("<{0} {2}> {1} </{0}>", Tag.ToString(), Content?.ToString(), HtmlProperties?.ToString());
        }
    }
}
