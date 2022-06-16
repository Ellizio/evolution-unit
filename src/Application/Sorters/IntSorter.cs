namespace Application.Sorters
{
    public static class IntSorter
    {
        private static readonly Random _random = new Random(DateTime.Now.Millisecond);

        public static List<int> Sort(IReadOnlyList<int> collection) => collection.OrderBy(x => x).ToList();

        public static List<int> Mix(IReadOnlyList<int> collection) => collection.OrderBy(x => _random.Next()).ToList();
    }
}
