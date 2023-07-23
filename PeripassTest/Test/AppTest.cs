
namespace PeripassTest.Test
{
    internal static class AppTest
    {
        internal static bool TestingTwoListsEquality(List<string> target, List<string> result)
        {
            return target.FirstOrDefault(e => !result.Contains(e)) == null;
        }
    }
}
