using Demo_LinQ_Operateurs;
using System.Collections;

ArrayList arraylist_contacts = new ArrayList() {
        new Contact() { Email ="delphine@tftic.be", FirstName = "Delphine", LastName= "Vander Stricht", BirthDateYear = 2000 },
        new Contact() { Email ="michel@tftic.be", FirstName = "Michel", LastName= "Clarot", BirthDateYear = 2000 },
        new Contact() { Email ="paul@tftic.be", FirstName = "Paul", LastName= "Bottemanne", BirthDateYear = 1990 },
        new Contact() { Email ="benjamin@tftic.be", FirstName = "Benjamin", LastName= "Stercks", BirthDateYear = 1990 },
        new Contact() { Email ="jean@tftic.be", FirstName = "Jean", LastName= "Timmermans", BirthDateYear = 1990 },
        new Contact() { Email ="thomas@tftic.be", FirstName = "Thomas", LastName= "Ayissi", BirthDateYear = 2000 },
        new Contact() { Email ="jeremie@tftic.be", FirstName = "Jeremie", LastName= "Lopopola", BirthDateYear = 1940 },
        new Contact() { Email ="seif@tftic.be", FirstName = "Seif", LastName= "Meddeb", BirthDateYear = 1990 },
        new { Email = "samuel@form.tftic.be", LastName = "Legrain" },
        new Contact() { Email ="ryan@tftic.be", FirstName = "Ryan", LastName= "Costache", BirthDateYear = 2000 },
        new Contact() { Email ="yves@tftic.be", FirstName = "Yves", LastName= "Tshitamba", BirthDateYear = 2000 }
    };

List<RendezVous> meetings = new List<RendezVous>() { 
    new RendezVous() { Email = "michel@tftic.be", Date = new DateTime(2022,10,1) },
    new RendezVous() { Email = "michel@tftic.be", Date = new DateTime(2022,10,2) },
    new RendezVous() { Email = "michel@tftic.be", Date = new DateTime(2022,10,3) },
    new RendezVous() { Email = "michel@tftic.be", Date = new DateTime(2022,10,4) },
    new RendezVous() { Email = "thomas@tftic.be", Date = new DateTime(2022,10,4) },
    new RendezVous() { Email = "thomas@tftic.be", Date = new DateTime(2022,10,5) },
    new RendezVous() { Email = "thomas@tftic.be", Date = new DateTime(2022,10,6) },
    new RendezVous() { Email = "ryan@tftic.be", Date = new DateTime(2022,10,1) },
    new RendezVous() { Email = "ryan@tftic.be", Date = new DateTime(2022,10,4) }
};


#region Cast<T>() permet de caster seul les éléments compatibles sinon Exception
IEnumerable<Contact> contacts = arraylist_contacts.Cast<Contact>();

try
{
    foreach (Contact contact in contacts)
    {
        Console.WriteLine($"{contact.LastName} {contact.FirstName} ({contact.BirthDateYear}) : {contact.Email}");
    }
}
catch (Exception)
{
    Console.WriteLine("Tous ne sont pas des instances de 'Contact'");
}
#endregion

#region OfType<T>() permet de caster seulement les éléments compatible en excluant les incompatibles
contacts = arraylist_contacts.OfType<Contact>();

foreach (Contact contact in contacts)
{
    Console.WriteLine($"{contact.LastName} {contact.FirstName} ({contact.BirthDateYear}) : {contact.Email}");
}
#endregion

#region Where() filtre selon un Func<T, bool>
IEnumerable<Contact> filteredContact = contacts.Where((c) => c.FirstName.Length > 5);
filteredContact = filteredContact.Where((c) => c.BirthDateYear > 1920);

foreach (Contact contact in filteredContact)
{
    Console.WriteLine($"{contact.LastName} {contact.FirstName} ({contact.BirthDateYear}) : {contact.Email}");
}
#endregion


#region Select() Permet la transformation de données
//Récupération simple
IEnumerable<string> emails = contacts.Select((c) => c.Email);

foreach (string email in emails)
{
    Console.WriteLine(email);
}
//Transformation
var persons = contacts.Select((c) => new { NomDeFamille = c.LastName, Prenom = c.FirstName, AnneeDeNaissance = c.BirthDateYear });

Console.WriteLine($"Nous avons récupérer {persons.Count()} Personnes");
//Calcul de données
IEnumerable<int> ages = contacts.Select((c) => DateTime.Now.Year - c.BirthDateYear);

foreach (int age in ages)
{
    Console.WriteLine(age);
}
#endregion

#region GroupBy avec IGrouping<,>
IEnumerable<IGrouping<int, Contact>> result = contacts.GroupBy(c => c.BirthDateYear);

foreach (IGrouping<int, Contact> group in result)
{
    Console.WriteLine($"{group.Key} :");
    foreach (Contact contact in group)
    {
        Console.WriteLine($"\t{contact.FirstName} {contact.LastName}");
    }
} 
#endregion

#region Groupby avec transformation (attention mauvaise manipulation répétition de la clée)
//var email_by_year = contacts
//                    .Select(c => new { c.Email, c.BirthDateYear })
//                    .GroupBy(c => c.BirthDateYear);

//foreach (var group in email_by_year)
//{
//    Console.WriteLine($"{group.Key} :");
//    foreach (var mail_year in group)
//    {
//        Console.WriteLine($"\t{mail_year.Email}");
//    }
//} 
#endregion

#region Groupby avec transformation (attention bonne manipulation, mais plus de IGrouping<,>)
var email_by_year = contacts
            .GroupBy(c => c.BirthDateYear)
            .Select(g => new { Annee = g.Key, Emails = g.Select(c => c.Email) });

foreach (var group in email_by_year)
{
    Console.WriteLine($"{group.Annee} :");
    foreach (string mail in group.Emails)
    {
        Console.WriteLine($"\t{mail}");
    }
}
#endregion

#region Join
var rdv_contact = contacts.Join(meetings,
                        c => c.Email,
                        m => m.Email,
                        (c, m) => new { c.LastName, c.FirstName, m.Date });

foreach (var rdv in rdv_contact)
{
    Console.WriteLine($"{rdv.FirstName} {rdv.LastName} : {rdv.Date}");
}
#endregion

var rdv_contact_group = contacts.GroupJoin(meetings,
                                           c => c.Email,
                                           m => m.Email,
                                           (c, ms) => new { c.LastName, c.FirstName, Dates = ms.Select(m => m.Date) });

foreach (var rdv in rdv_contact_group)
{
    Console.WriteLine($"{rdv.FirstName} {rdv.LastName} :");
    foreach (DateTime date in rdv.Dates)
    {
        Console.WriteLine($"\t{date}");
    }
}