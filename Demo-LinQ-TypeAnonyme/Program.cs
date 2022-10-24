using Demo_LinQ_TypeAnonyme;

List<Personne> persons = new List<Personne>() {
    new Personne(){ Last_name = "Legrain", First_name = "Samuel", Birth_date = new DateTime (1987,9,27), Gender="Male"},
    new Personne(){ Last_name = "Willis", First_name = "Bruce", Birth_date = new DateTime (1955,3,19), Gender="Male"},
    new Personne(){ Last_name = "Morre", First_name = "Demi", Birth_date = new DateTime (1962,11,11), Gender="Female"}
};

for (int i = 0; i < persons.Count; i++)
{
    var person_lite = new { Index = i, Nom = persons[i].Last_name, persons[i].First_name };
}