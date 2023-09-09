
using System.Text.RegularExpressions;


namespace YourScheduler.BusinessLogic.Extension
{
    public static class IEnumerableExtensions
    {
        public static void SearchByInput(this IEnumerable<string> names, string input)
        {
            string pattern = $"([^a-z]|^){input}([A-Z]|[a-z])*";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            names = names
                .Where(n => regex.IsMatch(n));
        }
    }
}
