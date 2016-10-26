using ReportSharpCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ReportSharpCore.Interface
{
    public interface IReportGroup : IGrouping<string, object>, IReportElement
    {
        /// <summary>
        /// Key = Column key
        /// Value = HtmlProperties
        /// </summary>
        IReportElement GroupHeader { get; set; }
    }
}
