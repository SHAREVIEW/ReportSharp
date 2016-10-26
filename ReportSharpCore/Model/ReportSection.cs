using ReportSharpCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using ReportSharpCore.Helper;
using System.Reflection;
using ReportSharpCore.Enum;

namespace ReportSharpCore.Model
{
    public class ReportSection : IReportGroup
    {
        public string Key { get; private set; }
        private List<List<string>> Items { get; set; }
        public IReportElement GroupHeader { get; set; }
        private int Columns { get; set; }

        public HtmlTag Tag { get; set; }
        public object Content { get; set; }
        public HtmlOptions HtmlProperties { get; set; }
        public Func<string> GetContent { get; set; }

        public ReportSection(string _key, HtmlTag _tag = HtmlTag.table, HtmlOptions _groupOptions = null)
        {
            Key = _key;
            Tag = _tag;
            HtmlProperties = _groupOptions == null ? new HtmlOptions
            {
                CssClass = "table table-responsive table-striped",
                TableLayout = HtmlOptions.TableLayoutValue.Fixed,
                WordWrap = HtmlOptions.WordWrapValue.BreakWord
            } : _groupOptions;
        }

        public ReportSection(string _key, int _columns, HtmlTag _tag = HtmlTag.table, HtmlOptions _groupOptions = null) : this(_key, _tag, _groupOptions)
        {
            Columns = _columns;
            Items = new List<List<string>>();
            for (var x = 0; x < Columns; x++)
            {
                Items.Add(new List<string>());
            }
        }

        public ReportSection(string _key, IEnumerable<KeyValueColumn> _range, HtmlTag _tag = HtmlTag.table, HtmlOptions _groupOptions = null) : this(_key, _range.Max(t => t.Column) + 1, _tag, _groupOptions)
        {
            Task.Run(async() => { await AddRangeAsync(_range); }).GetAwaiter().GetResult();
        }

        public async Task AddRangeAsync(IEnumerable<KeyValueColumn> _range)
        {
            foreach(var _keyValueColumn in _range)
            {
                await AddAsync(_keyValueColumn);
            }
        }

        public async Task AddAsync(KeyValueColumn _keyValueColumn)
        {
            await AddAsync(_keyValueColumn.Key, _keyValueColumn.Value, _keyValueColumn.Column);
        }

        public async Task AddAsync(IReportElement key, IReportElement value, int column)
        {
            var content = "";
            if(key != null)
            {
                content += await key.RenderToStringAsync();
            }
            if(value != null)
            {
                content += await value.RenderToStringAsync();
            }
            Items[column].Add(content);
        }

        public async Task<string> RenderToStringAsync()
        {
            return await Task.Run(async() =>
            {
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
                GroupHeader = GroupHeader == null ? new ReportElement
                {
                    Tag = HtmlTag.h2,
                    Content = Key,
                } : GroupHeader;

                content.AppendFormat(@"<tr><td colspan='{0}'>{1}</td></tr>", Columns, GroupHeader.ToString());

                var linhas = Items.Max(t => t.Count);
                for (var x = 0; x < linhas; x++)
                {
                    content.Append(@"<tr>");
                    foreach (var coluna in Items)
                    {
                        if (coluna.Count > x)
                        {
                            content.AppendFormat(@"<td>{0}</td>", coluna[x].ToString());
                        }
                        else
                        {
                            content.Append(@"<td></td>");
                        }
                    }
                    content.Append(@"</tr>");
                }
                return content.ToString();
            });
        }

        public IEnumerator<object> GetEnumerator()
        {
            return Items?.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items?.GetEnumerator();
        }

        public class KeyValueColumn
        {
            public IReportElement Key { get; set; }
            public IReportElement Value { get; set; }
            public int Column { get; set; }

            public KeyValueColumn(IReportElement _key, IReportElement _value, int _column)
            {
                Key = _key;
                Value = _value;
                Column = _column;
            }
        }
    }
}
