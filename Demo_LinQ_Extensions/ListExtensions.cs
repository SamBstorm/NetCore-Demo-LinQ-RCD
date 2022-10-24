namespace Demo_LinQ_Extensions
{
    public static class ListExtensions
    {
        public static List<T> Filter<T>(this List<T> liste, Func<T, bool> predicate)
        {
            List<T> filtered_list = new List<T>();

            foreach (T item in liste)
            {
                if (predicate(item)) filtered_list.Add(item);
            }
            return filtered_list;
        }
    }
}
