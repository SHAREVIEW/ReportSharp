using ReportSharpCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ReportSharpCore.Model
{
    public sealed class ReportGroup : IReportGroup
    {
        public string Key { get; private set; }
        public Dictionary<string, IEnumerable<string>> Options { get; set; }
        public IEnumerable<IReportGroup> Groups { get; set; }
        public IEnumerable<object> Items { get; set; }

        public ReportGroup(string key)
        {
            Key = key;
        }

        public IEnumerator<object> GetEnumerator()
        {
            return Items?.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items?.GetEnumerator();
        }
    }
}
