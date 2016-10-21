using ReportSharpCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ReportSharpCore.Interface
{
    public interface IReportGroup : IEnumerable<object>
    {
        string Key { get; }
        /// <summary>
        /// Key = Column key
        /// Value = HtmlProperties
        /// </summary>
        Dictionary<string, IEnumerable<string>> Options { get; set; }
        IEnumerable<IReportGroup> Groups { get; set; }
        IEnumerable<object> Items { get; set; }
    }
}
