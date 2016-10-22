using ReportSharpCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ReportSharpCore.Interface
{
    public interface IReportGroup : IGrouping<string, object>
    {
        /// <summary>
        /// Key = Column key
        /// Value = HtmlProperties
        /// </summary>
        Dictionary<string, ListHtmlProperties> Options { get; set; }
        string ToString();
    }
}
