using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("Eqip.Utils.String.ToCamelCase.Tests")]
internal static class StringToCamelCaseExtensions
{

    public static string ToCamelCase(this string s)
    {
        if (string.IsNullOrEmpty(s))
            return s;

        if (!char.IsUpper(s[0]))
            return s;

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            bool hasNext = (i + 1 < s.Length);
            if ((i == 0 || !hasNext) || char.IsUpper(s[i + 1]))
            {
                char lowerCase;
                lowerCase = char.ToLowerInvariant(s[i]);
                sb.Append(lowerCase);
            }
            else
            {
                sb.Append(s.Substring(i));
                break;
            }
        }

        return sb.ToString();
    }
}
