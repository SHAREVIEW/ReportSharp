using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportSharpCore.Helper
{
    public static class DictionaryExtensions
    {
        public static TValue TryGet<TKey, TValue>(this Dictionary<TKey, TValue> instance, TKey _key) {
            var result = default(TValue);
            if (instance?.ContainsKey(_key) == true) {
                result = instance[_key];
            }
            return result;
        }
    }
}
