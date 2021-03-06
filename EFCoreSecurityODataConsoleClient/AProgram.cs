﻿using System;

namespace EFCoreSecurityODataConsoleClient
{

    public class AProgram
    {
        //This method exists so you can loop through the given container of cars and find the perfect primairy key(known as ID for car)
        static int GetCorrectID(DefaultContainer container)
        {
            int indexTracker = 0;

            //Here i loop through all the instances of Car in Cars stored in the container
            foreach (var p in container.Contact)
            {
                if (p.Index >= indexTracker)
                {
                    indexTracker = p.Index;
                }
            }
            //I increment the result by 1 so i do not get the same result as the currently highest ID but 1 higher
            indexTracker++;

            return indexTracker;
        }

        //This method exists to read all the information regarding a specific entity
        static void ReadEntry(DefaultContainer container)
        {
            int cleanInput = 0;
            //Asks the user which entry the user wants information about
            Console.WriteLine($"Give the Index of the entity you wish to read \n");

            string userInput = Console.ReadLine();

            //Checks if the input given by the user is an actual valid int
            while (!int.TryParse(userInput, out  cleanInput))
            {
                Console.Write("This is not valid input. Please enter an integer value: \n");
                userInput = Console.ReadLine();
            }

            foreach (var p in container.Contact)
            {
                //when the correct entry in the database is found give the user the requested information
                if (p.Index == cleanInput)
                {
                    //Console.WriteLine(p.AmountMade);
                    Console.WriteLine(p.Index);
                    Console.WriteLine(p.Email);
                    Console.WriteLine(p.JobTitle);
                    Console.WriteLine(p.MobileNo);
                    Console.WriteLine(p.FormalName);
                }
            }

            Console.WriteLine($"Your result: read the info of a entity \n");
        }

        static void DeleteEntry(DefaultContainer container)
        {

            string userInput = " ";
            int cleanInput = 0;

            Console.WriteLine($"Give the ID of the entity you wish to remove \n");

            userInput = Console.ReadLine();

            while (!int.TryParse(userInput, out cleanInput))
            {
                Console.Write("This is not valid input. Please enter an integer value: \n");
                userInput = Console.ReadLine();
            }

            foreach (var p in container.Contact)
            {
                if (p.Index == cleanInput)
                {
                    container.DeleteObject(p);

                    var serviceResponse = container.SaveChanges();

                    foreach (var operationResponse in serviceResponse)
                    {
                        Console.WriteLine("Response: {0}", operationResponse.StatusCode);
                    }
                }
            }

            Console.WriteLine($"Your result: removed a entity \n");
        }

        static void AddEntry(DefaultContainer container)
        {
            bool answer = false;
            string input1 = "";
            string colour = "";
            int cleanNum1 = 0;
            int iD = 0;
            var p = new ContactRecord();

            //Console.Write("Type the number of cars made, and then press Enter: \n");
            //input1 = Console.ReadLine();

            //while (!int.TryParse(input1, out cleanNum1))
            //{
            //    Console.Write("This is not valid input. Please enter an integer value: \n");
            //    input1 = Console.ReadLine();
            //}

            Console.Write("Type the job title, and then press Enter: \n");
            colour = Console.ReadLine();

            //Console.Write("Is the car APK certifeid? Type true or false, and then press Enter: \n");
            //input1 = Console.ReadLine().ToLower();

            iD = GetCorrectID(container);

            if (string.Equals(input1, "true"))
            {
                answer = true;
            }

            p.Index = iD;
            p.JobTitle = colour;
            //p.AmountMade = cleanNum1;
            //p.Colour = colour;
            //p.TimeWhenAddedToDatabase = DateTime.Now;
            //p.APK = answer;

            //container.AddObject("cars", p);
            container.AddObject("Contact", p);

            var serviceResponse = container.SaveChanges();

            foreach (var operationResponse in serviceResponse)
            {
                Console.WriteLine("Response: {0}", operationResponse.StatusCode);
            }

            Console.WriteLine($"Your result: Added a car");
        }

        static void ChangeEntry(DefaultContainer container)
        {
            string userInput = " ";
            int cleanInput = 0;

            Console.WriteLine($"Give the ID of the entry you wish to change \n");

            userInput = Console.ReadLine();

            while (!int.TryParse(userInput, out cleanInput))
            {
                Console.Write("This is not valid input. Please enter an integer value: \n");
                userInput = Console.ReadLine();
            }

            foreach (var p in container.Contact)
            {
                if (p.Index == cleanInput)
                {
                    p.ArchivedDateTime = DateTime.Now;
                    container.UpdateObject(p);

                    var serviceResponse = container.SaveChanges();

                    foreach (var operationResponse in serviceResponse)
                    {
                        Console.WriteLine("Response: {0}", operationResponse.StatusCode);
                    }
                }
            }
            Console.WriteLine($"Your result: Changed a entry \n");
        }



        //set the brand to what the user of the software wants 
        //static _Brands SetBrand()
        //{

        //    //var brand = _Brands;

        //    var brand = _Brands.Audi;

        //    Console.WriteLine("Select your car brand from the following list: \n");
        //    Console.WriteLine("\tt - Tesla ");
        //    Console.WriteLine("\tf - Ferrari");
        //    Console.WriteLine("\tm - Mini");
        //    Console.WriteLine("\tp - Porsche ");
        //    Console.WriteLine("\tv - Volkswagen");
        //    Console.WriteLine("\tn - Nissan");
        //    Console.WriteLine("\ta - Audi ");
        //    Console.WriteLine("\tF - Ford");
        //    Console.WriteLine("\th - Honda");
        //    Console.WriteLine("\tB - BMW ");
        //    Console.WriteLine("\tM - Mercedes");
        //    Console.WriteLine("\tT - Toyota");
        //    Console.WriteLine("------------------------\n");
        //    Console.Write("Your option? \n");

        //    switch (Console.ReadLine())
        //    {
        //        default:
        //            Console.WriteLine($"Your result: error");
        //            break;

        //        case "t":
        //            Console.WriteLine($"You Selected: Tesla");
        //            brand = _Brands.Tesla;
        //            break;

        //        case "f":
        //            Console.WriteLine($"You Selected: Ferrari");
        //            brand = _Brands.Ferrari;
        //            break;

        //        case "m":
        //            Console.WriteLine($"You Selected: Mini");
        //            brand = _Brands.Mini;
        //            break;

        //        case "p":
        //            Console.WriteLine($"You Selected: Porsche");
        //            brand = _Brands.Porsche;
        //            break;

        //        case "v":
        //            Console.WriteLine($"You Selected: Volkswagen");
        //            brand = _Brands.Volkswagen;
        //            break;

        //        case "n":
        //            Console.WriteLine($"You Selected: Nissan");
        //            brand = _Brands.Nissan;
        //            break;

        //        case "a":
        //            Console.WriteLine($"You Selected: Audi");
        //            brand = _Brands.Audi;
        //            break;


        //        case "F":
        //            Console.WriteLine($"You Selected: Ford");
        //            brand = _Brands.Ford;
        //            break;

        //        case "h":
        //            Console.WriteLine($"You Selected: Honda");
        //            brand = _Brands.Honda;
        //            break;

        //        case "B":
        //            Console.WriteLine($"You Selected: BMW");
        //            brand = _Brands.BMW;
        //            break;

        //        case "M":
        //            Console.WriteLine($"You Selected: Mercedes");
        //            brand = _Brands.Mercedes;
        //            break;

        //        case "T":
        //            Console.WriteLine($"You Selected: Toyota");
        //            brand = _Brands.Toyota;
        //            break;
        //    }
        //    return brand;
        //}

        //Adds a new car to the list of cars


        //this runs first, I also call the other functions from here
        static void Main(string[] args)
        {
            bool endApp = false;
            Console.WriteLine("Welcome to the client side!");
            Console.WriteLine("------------------------\n");
            while (!endApp)
            {

                string serviceUri = "http://localhost:52412/odata/";
                var container = new DefaultContainer(new Uri(serviceUri));

                Console.WriteLine("Choose an option from the following list:");
                Console.WriteLine("\ta - Add Entity ");
                Console.WriteLine("\tc - change a entry");
                Console.WriteLine("\tr - read the info of a entity");
                Console.WriteLine("\tR - remove a entity");
                Console.WriteLine("------------------------\n");
                Console.Write("Your option? ");

                switch (Console.ReadLine())
                {
                    default:
                        //works
                        Console.WriteLine($"Your result: error \n");
                        Console.WriteLine("\n");
                        break;

                    case "a":
                        Console.WriteLine("\n");
                        AddEntry(container);
                        break;

                    case "c":
                        //works
                        Console.WriteLine("\n");
                        ChangeEntry(container);
                        break;

                    case "r":
                        //works
                        Console.WriteLine("\n");
                        ReadEntry(container);
                        break;

                    case "R":
                        //works
                        Console.WriteLine("\n");
                        DeleteEntry(container);
                        break;
                }

                Console.WriteLine("------------------------\n");
               
                // Ask if they want to close the app or continue
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }
            return;
        }
    }
}
