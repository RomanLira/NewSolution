using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects_Library
{
    public class PersonGenerator
    {

        private Random rand = new Random();
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
            "Andrey",
            "Nikita",
            "Ivan",
            "Vyacheslav",
            "Serghey",
            "Anatoliy",
            "Mikhail",
            "Vasiliy",
            "Petr",
            "Lev",
            "Vladimir"
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
            "Shevchenko",
            "Nikitenko",
            "Ivanenko",
            "Vyacheslavov",
            "Sergheev",
            "Onopko",
            "Mikhailov",
            "Vasilyev",
            "Petrenko",
            "L'vov",
            "Vladimirov"
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
            "Nikitovich",
            "Ivanovich",
            "Vyacheslavovich",
            "Sergheyevich",
            "Anatolievich",
            "Mikhailovich",
            "Vasiliyevich",
            "Petrovich",
            "L'vovich",
            "Vladimirovich"
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
            "25-09-1995",
            "13-02-2000",
            "15-01-2001",
            "25-10-1993",
            "07-12-1994",
            "06-11-1998",
            "12-12-1992",
            "03-04-1995",
            "12-11-1990",
            "10-10-2000"
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
            "Odessa",
            "Lughansk",
            "Donetsk",
            "Kaliningrad",
            "Khabarovsk",
            "Toronto",
            "London",
            "Madrid",
            "Volgograd",
            "Sevastopol"
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

        public Person GeneratePerson()
        {
            return new Person(
                _surnames[rand.Next(0, _surnames.Length)] + " " + _names[rand.Next(0, _names.Length)] + " " + _patronymic[rand.Next(0, _patronymic.Length)],
                _birthdays[rand.Next(0, _birthdays.Length)],
                _birthplaces[rand.Next(0, _birthplaces.Length)],
                Convert.ToString(rand.Next(999999, 100000000))
                );
        }

        public PersonWithConstHashCode GeneratePersonWithConstHashCode()
        {
            return new PersonWithConstHashCode(
               _names[rand.Next(0, _names.Length)] + "" + _surnames[rand.Next(0, _surnames.Length)] + "" + _patronymic[rand.Next(0, _patronymic.Length)],
               _birthdays[rand.Next(0, _birthdays.Length)],
               _birthplaces[rand.Next(0, _birthplaces.Length)],
               Convert.ToString(rand.Next(999999, 100000000))
               );
        }

        public Dictionary<Person, string> CreateWorkPlaceDictionary(int length)
        {
            var dictionary = new Dictionary<Person, string>();
            for (int i = 0; i < length; i++)
            {
                string value = "";
                var person = GeneratePerson();
                while (dictionary.TryGetValue(person, out value))
                    person = GeneratePerson();
                dictionary.Add(person, _companies[rand.Next(0, _companies.Length)]);
            }
            return dictionary;
        }

        public Dictionary<PersonWithConstHashCode, string> CreateWorkPlaceDictionaryConstHashCode(int length)
        {
            var dictionary = new Dictionary<PersonWithConstHashCode, string>();
            for (int i = 0; i < length; i++)
            {
                string value = "";
                var person = GeneratePersonWithConstHashCode();
                while (dictionary.TryGetValue(person, out value))
                    person = GeneratePersonWithConstHashCode();
                dictionary.Add(person, _companies[rand.Next(0, _companies.Length)]);
            }
            return dictionary;
        }
    }
}
