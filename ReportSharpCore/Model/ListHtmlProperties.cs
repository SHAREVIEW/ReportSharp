using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSharpCore.Model
{
    public class ListHtmlProperties : List<string>
    {
        public ListHtmlProperties(IEnumerable<string> _properties)
        {
            AddRange(_properties);
        }

        public override string ToString()
        {
            StringBuilder strProperties = new StringBuilder();
            foreach (var property in this)
            {
                strProperties.AppendFormat("{0} ", property);
            }
            return strProperties.ToString();
        }
    }
}
