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