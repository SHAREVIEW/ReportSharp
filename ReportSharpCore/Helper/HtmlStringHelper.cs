using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSharpCore.Helper
{
    public static class HtmlStringHelper
    {
        public static string CreateHtmlPropertiesString(IEnumerable<string> properties)
        {
            StringBuilder strProperties = new StringBuilder();
            foreach (var property in properties)
            {
                strProperties.AppendFormat("{0} ", property);
            }
            return strProperties.ToString();
        }
    }
}
