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
        public Dictionary<string, ListHtmlProperties> Options { get; set; }
        private IEnumerable<object> Items { get; set; }

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
            var headerSize = HtmlTag.h2;
            System.Enum.TryParse(Options.TryGet("HeaderSize")?.ToString(), out headerSize);

            var headerOptions = Options.TryGet("HeaderOptions")?.ToString();

            StringBuilder group = new StringBuilder();
            group.Append(@"<table class='table table-responsive table-striped' style='table-layout: fixed; word-wrap: break-word;'>");
            //Escreve o header do relatório
            var type = this.First().GetType();
            var runtimeProperties = type.GetRuntimeProperties();
            var columnCount = runtimeProperties.Count();
            group.AppendFormat(@"<tr><td colspan='{0}'><h2>{1}</h2></th></tr><tr>", columnCount, Key);
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
