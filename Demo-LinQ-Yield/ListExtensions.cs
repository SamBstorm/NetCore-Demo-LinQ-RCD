namespace Demo_LinQ_Yield
{
    public static class ListExtensions
    {
        public static List<T> Filter<T>(this IEnumerable<T> liste, Func<T, bool> predicate)
        {
            List<T> filtered_list = new List<T>();

            foreach (T item in liste)
            {
                if (predicate(item)) filtered_list.Add(item);
            }
            return filtered_list;
        }

        public static IEnumerable<T> YieldFilter<T>(this IEnumerable<T> liste, Func<T, bool> predicate)
        {
            foreach (T item in liste)
            {
                if (predicate(item)) yield return item;
            }
        }
    }
}
