using Demo_LinQ_Yield;

List<Personne> persons = new List<Personne>() {
    new Personne(){ Last_name = "Legrain", First_name = "Samuel", Birth_date = new DateTime (1987,9,27), Gender="Male"},
    new Personne(){ Last_name = "Willis", First_name = "Bruce", Birth_date = new DateTime (1955,3,19), Gender="Male"},
    new Personne(){ Last_name = "Morre", First_name = "Demi", Birth_date = new DateTime (1962,11,11), Gender="Female"}
};

List<Personne> result_nonYield = persons.Filter((p) => p.Gender == "Male");

foreach (Personne person_nonYield in result_nonYield)
{
    Console.WriteLine($"{person_nonYield.Last_name} {person_nonYield.First_name}");
}

IEnumerable<Personne> result_yield = persons.YieldFilter((p) => p.Gender == "Male");

foreach (Personne person_yield in result_yield)
{
    Console.WriteLine($"{person_yield.Last_name} {person_yield.First_name}");
}

