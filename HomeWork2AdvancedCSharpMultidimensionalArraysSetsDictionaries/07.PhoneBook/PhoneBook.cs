using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.PhoneBook
{
    class PhoneBook
    {
        private string name;
        private string phoneNumber;

        public PhoneBook(string name, string number)
        {
            this.name = Name;
            this.phoneNumber = number;
        }
        public string Name
        {
            get {
                    return this.name;
                }

            set {
                    if (value.Length > 10)
                    {
                        value = name;
                    }
                    else
                    {
                       Console.WriteLine("Nema da vali");
                    }
                 }

         }

        public string Search()
        {
            string result = "";



            return result;
        }

        static void Main()
        {
            string name = "Pe6o";
            string number = "0892222222";

            PhoneBook newContact = new PhoneBook(name, number);
            newContact.Name = "Kiril";
            newContact.phoneNumber = "2";
            newContact.Search();

        }
    }

}
