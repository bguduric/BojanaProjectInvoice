using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.Pages
{
    class GenerateRandomData

    {
        //private readonly IWebDriver driver;

        public static string GenerateRandomNumber(int lenght)
        {
            var numbers = "0123456789";
            var random = new Random();
            var accNum = new string(Enumerable.Repeat(numbers, lenght).Select(s => s[random.Next(s.Length)]).ToArray());
            return accNum;
        }
        public static string GenerateRandomNumberNoZero(int lenght)
        {
            var numbers = "123456789";
            var random = new Random();
            var accNum = new string(Enumerable.Repeat(numbers, lenght).Select(s => s[random.Next(s.Length)]).ToArray());
            return accNum;
        }
        public static string GenerateRandomAlpha(int lenght)
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            var accNum = new string(Enumerable.Repeat(alphabet, lenght).Select(s => s[random.Next(s.Length)]).ToArray());
            return accNum;
        }
        public static string GenerateRandomSpecChar(int lenght)
        {
            var spec_char = "~!@#$%^&*()_+{}<>?`";
            var random = new Random();
            var accNum = new string(Enumerable.Repeat(spec_char, lenght).Select(s => s[random.Next(s.Length)]).ToArray());
            return accNum;
        }
        public static int GenerateRandomYear()
        {
            var random = new Random();
            var list = new List<int>();
            int number = random.Next(1990, 2101);
            for (int i = 0; i < 10000000; i++)
            {
                list.Add(number);
            }
            var listOfNumbers = list;
            int lastNumber = listOfNumbers.Last();
            return lastNumber;
        }
        public static string GenerateMonths()
        {
            var list = new List<string>();
            Random rnd = new Random();

            list.Add("January");
            list.Add("February");
            list.Add("March");
            list.Add("April");
            list.Add("May");
            list.Add("June");
            list.Add("July");
            list.Add("August");
            list.Add("September");
            list.Add("October");
            list.Add("November");
            list.Add("December");

            var listOfNumbers = list;
            string month = listOfNumbers[rnd.Next(listOfNumbers.Count)];
            return month;

        }
        public static string GenerateMonthsRS()
        {
            var list = new List<string>();
            Random rnd = new Random();

            list.Add("januar");
            list.Add("februar");
            list.Add("mart");
            list.Add("april");
            list.Add("maj");
            list.Add("jun");
            list.Add("jul");
            list.Add("avgust");
            list.Add("septebar");
            list.Add("oktobar");
            list.Add("novebar");
            list.Add("decembar");

            var listOfNumbers = list;
            string month = listOfNumbers[rnd.Next(listOfNumbers.Count)];
            return month;

        }
        public string GenerateRandomUsername(int lenght)
        {
            var characters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
            var numbers = "0123456789";
            var random = new Random();
            var usernameChar = new string(Enumerable.Repeat(characters, lenght).Select(s => s[random.Next(s.Length)]).ToArray());
            var usernameNumb = new string(Enumerable.Repeat(numbers, lenght).Select(s => s[random.Next(s.Length)]).ToArray());
            var username = usernameChar + usernameNumb;
            return username;
        }
    }
}
