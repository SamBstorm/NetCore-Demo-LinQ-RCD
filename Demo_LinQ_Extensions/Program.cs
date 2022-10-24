using Demo_LinQ_Extensions;

List<Personne> persons = new List<Personne>() {
    new Personne(){ Last_name = "Legrain", First_name = "Samuel", Birth_date = new DateTime (1987,9,27), Gender="Male"},
    new Personne(){ Last_name = "Willis", First_name = "Bruce", Birth_date = new DateTime (1955,3,19), Gender="Male"},
    new Personne(){ Last_name = "Morre", First_name = "Demi", Birth_date = new DateTime (1962,11,11), Gender="Female"}
};

List<Personne> result = persons.Filter((p) => p.Gender == "Male");
result = ListExtensions.Filter(persons, (p) => p.Birth_date.Year > 1960);
result = persons.Filter((p) => p.Birth_date.Year > 1960);

Console.WriteLine( persons[0].Convert() ); 