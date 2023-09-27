using System.Text.RegularExpressions;


namespace YourScheduler.BusinessLogic.Extension
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<string> SearchByInput(this IEnumerable<string> names, string input)
        {
            string pattern = $"([^a-z]|^){input}([A-Z]|[a-z])*";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            foreach(var name in names)
            {
                if(regex.IsMatch(name))
                {
                    yield return name;
                }
            }
        }
    }
}
