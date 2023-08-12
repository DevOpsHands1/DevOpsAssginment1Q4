/*
    Consider the class Current with the following data members 
companytName.:, string 
typeOfBusiness: string 
website: string 
contactName: string
Override the equals() to check for equality. Check if the two Company instances are same by using the equals() method and display the same. 
*/

/*
 * Create company class variables of private modifiers with the appropriate data types create constructor create getters and setters.
Create the main method. create the menu driven program.
To add details make a method at details and pass the object of the company class.
Take the user input and validate each input.
To check the equal information create a check equal function pass the object of the company class. Now check with the details of day 
company class are equal or not with help of equals method. And display the details with the help of getters
 */


using System;

namespace Assginment1Q4
{

    class Company
    {
        private string companyName;
        private string typeOfBusiness;
        private string website;
        private string contactName;

        public Company(string companyName, string typeOfBusiness, string website, string contactName)
        {
            this.companyName = companyName;
            this.typeOfBusiness = typeOfBusiness;
            this.website = website;
            this.contactName = contactName;
        }

        public string CompanyName { get => companyName; set => companyName = value; }
        public string TypeOfBusiness { get => typeOfBusiness; set => typeOfBusiness = value; }
        public string Website { get => website; set => website = value; }
        public string ContactName { get => contactName; set => contactName = value; }
    }


    class Validation
    {
        public string CompanyName()
        {
            Console.WriteLine("Enter Company Name");
            string companyName = Console.ReadLine();
            if (companyName.Length > 0)
                return (companyName);
            else
            {
                Console.WriteLine("This is not a valid company name");
                return (CompanyName());
            }
        }

        public string TypeOfBusiness()
        {
            Console.WriteLine("Enter the type of Business");
            string businessType = Console.ReadLine();
            int invalid = 0;
            if (businessType.Length < 1)
            {
                Console.WriteLine("incorrect business type");
                return (TypeOfBusiness());
            }
            for (int i = 0; i < businessType.Length; i++)
            {
                if (businessType[i] < 65 || businessType[i] > 90 && businessType[i] < 97 || businessType[i] > 122)
                    invalid++;
            }
            if (invalid == 0)
                return (businessType);
            else
            {
                Console.WriteLine("incorrect business type");
                return (TypeOfBusiness());
            }
        }

        public string Website()
        {
            Console.WriteLine("Enter website");
            Console.WriteLine("Format: 'www.website name.com' and there should not be any space and all the letters should be in lower case");
            string site = Console.ReadLine();
            int inValid = 0;
            int valid = 0;
            if (site.Length < 8)
            {
                Console.WriteLine("incorrect website");
                return (Website());
            }
            if (site[0] != 'w' || site[1] != 'w' || site[2] != 'w' || site[3] != '.')
            {
                Console.WriteLine("Please include www. first");
                return (Website());
            }
            if (site[site.Length - 4] != '.' || site[site.Length - 3] != 'c' || site[site.Length - 2] != 'o' || site[site.Length - 1] != 'm')
            {
                Console.WriteLine("Please include .com at the end");
                return (Website());
            }
            for (int i = 4; i < site.Length-4; i++)
            {
                if ((int)site[i] >= 97 && (int)site[i] <= 122 || (int)site[i]==32)
                    valid++;
                else
                    inValid++;
            }
            if (inValid != 0)
            {
                Console.WriteLine("All the letter should be in lower case and no space is allowed, TRY AGAIN");
                return (Website());
            }
            else
            {
                return (site);
            }
        }
        public string ContactName()
        {
            Console.WriteLine("Enter contact name");
            string contactName = Console.ReadLine();
            int inValid = 0;
            int valid = 0;
            if (contactName.Length < 1)
            {
                Console.WriteLine("Incorrect Contact Name... TRY AGAIN");
                return (ContactName());
            }
            for (int i = 0; i < contactName.Length; i++)
            {
                if ((int)contactName[i] >= 65 && (int)contactName[i] <= 90 || (int)contactName[i] >= 97 && (int)contactName[i] <= 122 || (int)contactName[i] == 32)
                    valid++;
                else
                    inValid++;
            
            }
            if(inValid == 0)
            {   
                return(contactName);
            }
            else 
            {
                Console.WriteLine("incorrect name");
                return(ContactName());
            }
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            
            Company[] info = null;
            int choice = 0;
            do
            {
                display();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1: info = AddDetails(info);
                            break;

                    case 2: CheckEquals(info);
                            break;
                default: Console.WriteLine("invalid choice");
                    break;
                }
            } while (choice == 1 || choice == 2);
        }

        private static void display()
        {
            Console.WriteLine("1. Add Details");
            Console.WriteLine("2. Check Equal Details");
            Console.WriteLine("Enter Your Choice");
        }
        

        private static Company [] AddDetails(Company[] info)
        {
        
            Validation isValid = new Validation();
            Console.WriteLine("Enter the number of company details to input");
            int companies = Convert.ToInt32(Console.ReadLine());
            info = new Company[companies];
            for (int i = 0; i < companies; i++)
            {
                string companyName = isValid.CompanyName();
                string typeOfBusiness = isValid.TypeOfBusiness();
                string website = isValid.Website();
                string contactName = isValid.ContactName();

                info[i] = new Company(companyName, typeOfBusiness, website, contactName);
            }
            return (info);
        }
        
        private static void CheckEquals(Company[] info)
        {
            for (int i = 0; i < info.Length-1; i++)
            {
                for (int j = i + 1; j < info.Length; j++)
                {
                    if (info[i].CompanyName.Equals(info[j].CompanyName)  &&  info[i].TypeOfBusiness.Equals(info[j].TypeOfBusiness)  &&  info[i].Website.Equals(info[i].Website)  &&  info[i].ContactName.Equals(info[i].ContactName))
                    {
                        Console.WriteLine("Company Name : " + info[i].CompanyName);
                        Console.WriteLine("Type of Business : " + info[i].TypeOfBusiness);
                        Console.WriteLine("Website : " + info[i].Website);
                        Console.WriteLine("Contact Name : " + info[i].ContactName);
                    }
                }
            }
        }
    }
}
