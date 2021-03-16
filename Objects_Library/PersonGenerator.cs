using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects_Library
{
    public class PersonGenerator
    {
       public PersonGenerator() { }

        private string[] _names =
         {
            "Aleksey",
            "Aleksandr",
            "Maxim",
            "Stanislav",
            "Evgheniy",
            "Stepan",
            "Bogdan",
            "Nikolay",
            "Roman",
            "Andrey"
        };

        private string[] _surnames =
         {
            "Alekseev",
            "Aleksandrov",
            "Maximenko",
            "Ivanov",
            "Evghenyev",
            "Stepanenko",
            "Bogdanov",
            "Petrov",
            "Romanov",
            "Shevchenko"
        };

        private string[] _patronymic =
         {
            "Alekseevich",
            "Aleksandrovich",
            "Maximovich",
            "Stanislavovich",
            "Evghenievich",
            "Stepanovich",
            "Bogdanovich",
            "Nikolayevich",
            "Romanovich",
            "Andreyevich",
        };

        private string[] _birthdays =
         {
            "11-09-2001",
            "25-02-2000",
            "15-03-1995",
            "26-04-1986",
            "06-08-2001",
            "25-05-2003",
            "19-06-1992",
            "01-09-1999",
            "19-11-1997",
            "31-12-1999",
        };

        private string[] _birthplaces =
         {
            "Pripyat'",
            "Moscow",
            "St. Peterburg",
            "Tiraspol",
            "Kyiv",
            "Minsk",
            "Astana",
            "Krasnodar",
            "Karaganda",
            "Rostov-On-Don",
        };

        private string[] _id =
         {
            "58014387",
            "86176813",
            "85436871",
            "11454616",
            "54048103",
            "28382937",
            "76557978",
            "23314283",
            "48904353",
            "75510271",
        };

        private string[] _companies =
         {
            "RosTeleKom",
            "GazProm",
            "Google",
            "Yandex",
            "RosKosmos",
            "RosKomNadzor",
            "Facebook",
            "Telegram",
            "FSO",
            "DEX",
        };

        private Random rand = new Random();

        public Person GeneratePerson()
        {
            return new Person(
                _names[rand.Next(0, _names.Length)] + "" + _surnames[rand.Next(0, _surnames.Length)] + "" + _patronymic[rand.Next(0, _patronymic.Length)],
                _birthdays[rand.Next(0, _birthdays.Length)],
                _birthplaces[rand.Next(0, _birthplaces.Length)],
                _id[rand.Next(0,_id.Length)]
                );
        }

        public Dictionary<Person, string> WorkPlaceDictionary(int length)
        {
            var dictionary = new Dictionary<Person, string>();
            for (int i = 0; i < length; i++)
            {
                var person = GeneratePerson();
                dictionary.Add(person, _companies[rand.Next(0, _companies.Length)]);
            }
            return dictionary;
        }
    }
}
