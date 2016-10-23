using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using ReportSharpCore.Interface;
using System.Reflection;
using ReportSharpCore.Model;
using ReportSharpCore.Enum;
using ReportSharpCore.Helper;

namespace ReportSharpCore.Model
{
    public sealed class ReportGroup : IReportGroup
    {
        public string Key { get; private set; }
        public Dictionary<string, HtmlOptions> Options { get; set; }
        private IEnumerable<object> Items { get; set; }
        public HtmlOptions GroupHtmlOptions { get; set; }

        public HtmlTag HeaderSize = HtmlTag.h2;

        public ReportGroup(string _key, IEnumerable<object> _items)
        {
            Key = _key;
            Items = _items;
        }

        public IEnumerator<object> GetEnumerator()
        {
            return Items?.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items?.GetEnumerator();
        }

        public override string ToString()
        {
            var headerOptions = GroupHtmlOptions?.ToString();

            StringBuilder group = new StringBuilder();
            group.Append(@"<table class='table table-responsive table-striped' style='table-layout: fixed; word-wrap: break-word;'>");
            
            //Get all properties of the object to be printed on the report
            var type = this.First().GetType();
            var runtimeProperties = type.GetRuntimeProperties().ToList();

            //Remove invisible columns
            if (Options?.Any() == true)
            {
                var invisibleProperties = Options.Where(t => t.Value.Display == HtmlOptions.DisplayValue.None).Select(t => t.Key);
                runtimeProperties.RemoveAll(t => invisibleProperties.Contains(t.Name));
            }

            //Write report header
            var columnCount = runtimeProperties.Count();
            group.AppendFormat(@"<tr {2} ><td colspan='{0}'><{3}>{1}</{3}></th></tr><tr>", columnCount, Key, headerOptions, HeaderSize);
            foreach (var name in runtimeProperties.Select(t => t.Name))
            {
                string properties = Options.TryGet(name)?.ToString();
                group.AppendFormat(@"<th {0} >{1}</th>", properties, name);
            }
            group.Append(@"</tr>");

            //Escreve conteúdo do relatório
            foreach (var item in this)
            {
                group.Append(@"<tr>");
                var values = runtimeProperties.Select(t => t.GetValue(item));
                foreach (var value in values)
                {
                    group.AppendFormat(@"<td>{0}</td>", value);
                }
                group.Append(@"</tr>");
            }
            group.Append(@"</table>");
            return group.ToString();
        }
    }
}
