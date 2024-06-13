using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BigonApp.Infrastructure.Extensions
{
    public static partial class RegularExtension
    {
        static public string ToSlug(this string context)
        {
            if (string.IsNullOrWhiteSpace(context))
                return null;
            //c# &&&&& sql=>csharp-and-sql

            var replaceSet = new Dictionary<string, string>()
            {
                {"Ü|ü","ü" },
                {"İ|I","i" },
                {"Ş|ş","s" },
                {"Ç|ç","c" },
                {"Ğ|ğ","g" },
                {"Ə|ə","e" },
                {"#","sharp" },
                {@"(\?|/|\|\.|'|`|%|\*|!|@|\+)+", ""},
                {@"\&+", "and" },
                {@"[^a-z0-9]+","-" },

            };

            return replaceSet.Aggregate(context, (i, m) => Regex.Replace(i, m.Key, m.Value, RegexOptions.IgnoreCase)).ToLower();
        }
    }
}
