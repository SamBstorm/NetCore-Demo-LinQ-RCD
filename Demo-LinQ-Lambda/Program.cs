using Demo_LinQ_Lambda;

List<Personne> persons = new List<Personne>() {
    new Personne(){ Last_name = "Legrain", First_name = "Samuel", Birth_date = new DateTime (1987,9,27), Gender="Male"},
    new Personne(){ Last_name = "Willis", First_name = "Bruce", Birth_date = new DateTime (1955,3,19), Gender="Male"},
    new Personne(){ Last_name = "Morre", First_name = "Demi", Birth_date = new DateTime (1962,11,11), Gender="Female"}
};

List<Personne> result = filter<Personne>(persons, (p) => p.Gender == "Male");
result = filter<Personne>(persons, (p) => p.Birth_date.Year > 1960);

static List<T> filter<T>(List<T> liste, Func<T, bool> predicate)
{
    List<T> filtered_list = new List<T>();

    foreach (T item in liste)
    {
        if (predicate(item)) filtered_list.Add(item);
    }
    return filtered_list;
}