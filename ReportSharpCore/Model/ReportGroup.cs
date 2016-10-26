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
using Windows.Storage;

namespace ReportSharpCore.Model
{
    [System.Runtime.InteropServices.Guid("8D5CD28E-DD4E-4D91-AAA6-4F97A1A86E18")]
    public sealed class ReportGroup : IReportGroup
    {
        public string Key { get; private set; }
        public Dictionary<string, HtmlOptions> Options { get; set; }
        private IEnumerable<object> Items { get; set; }
        public IReportElement GroupHeader { get; set; }
        private Dictionary<string, string> compiledOptions { get; set; }

        public HtmlTag Tag { get; set; }
        public object Content { get; set; }
        public HtmlOptions HtmlProperties { get; set; }
        public Func<string> GetContent { get; set; }
        public ReportGroup(string _key, IEnumerable<object> _items, HtmlTag _tag = HtmlTag.table, HtmlOptions _groupOptions = null)
        {
            Key = _key;
            Items = _items;
            Tag = _tag;
            HtmlProperties = _groupOptions == null ? new HtmlOptions
            {
                CssClass = "table table-responsive table-striped",
                TableLayout = HtmlOptions.TableLayoutValue.Fixed,
                WordWrap = HtmlOptions.WordWrapValue.BreakWord
            } : _groupOptions;
        }

        public IEnumerator<object> GetEnumerator()
        {
            return Items?.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items?.GetEnumerator();
        }

        public async Task<string> RenderToStringAsync()
        {
            return await Task.Run(async () => {
                if (GetContent != null)
                {
                    Content = GetContent?.Invoke();
                }
                else
                {
                    Content = await CompileContentAsync();
                }
                return string.Format("<{0} {2}> {1} </{0}>", Tag.ToString(), Content?.ToString(), HtmlProperties?.ToString());
            });
        }

        private async Task<string> CompileContentAsync()
        {
            return await Task.Run(() => {
                StringBuilder content = new StringBuilder();
                compiledOptions = new Dictionary<string, string>();

                if (Options?.Any() == true)
                {
                    foreach (var opt in Options)
                    {
                        compiledOptions.Add(opt.Key, opt.Value?.ToString());
                    }
                }
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

                GroupHeader = GroupHeader == null ? new ReportElement
                {
                    Tag = HtmlTag.h2,
                    Content = Key,
                } : GroupHeader;

                content.AppendFormat(@"<tr ><td colspan='{0}'>{1}</th></tr><tr>", columnCount, GroupHeader.ToString());
                foreach (var name in runtimeProperties.Select(t => t.Name))
                {
                    string properties = TryGetHead(name);
                    content.AppendFormat(@"<th {0} >{1}</th>", properties, name);
                }
                content.Append(@"</tr>");

                //Escreve conteúdo do relatório
                foreach (var item in this)
                {
                    content.Append(@"<tr>");
                    foreach (var property in runtimeProperties)
                    {
                        var value = property.GetValue(item);
                        string properties = TryGetBody(property.Name);
                        content.AppendFormat(@"<td {1} >{0}</td>", value, properties);
                    }
                    content.Append(@"</tr>");
                }
                return content.ToString();
            });
        }

        private string TryGetBody(string _key)
        {
            return TryGet(_key, "body");
        }

        private string TryGetHead(string _key)
        {
            return TryGet(_key, "head");
        }

        private string TryGet(string _key, string scope)
        {
            var property = compiledOptions.TryGet(_key + "_" + scope);
            if(property == null)
                property = compiledOptions.TryGet(_key);
            return property;
        }
    }
}
