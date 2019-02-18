using System;

namespace Sup.Helpers
{
    public class Strings
    {
        public static string TruncateAtWord(string value, int length)
        {
            if (value == null || value.Trim().Length <= length)
                return value;

            int index = value.Trim().LastIndexOf(" ", StringComparison.Ordinal);

            while ((index + 3) > length)
                index = value.Substring(0, index).Trim().LastIndexOf(" ", StringComparison.Ordinal);

            if (index > 0)
                return value.Substring(0, index) + "...";

            return value.Substring(0, length - 3) + "...";
        }
    }
}