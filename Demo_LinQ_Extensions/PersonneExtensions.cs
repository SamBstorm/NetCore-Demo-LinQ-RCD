using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_LinQ_Extensions
{
    internal static class PersonneExtensions
    {
        public static string Convert(this Personne person)
        {
            return $@"<h1>{person.Last_name} {person.First_name}</h1>{(person.Gender == "Male"?"M":"F")}";
        }
    }
}
