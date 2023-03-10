using System;
using System.Collections.Generic;
using System.Linq;

namespace JurassicPark
{
    //   Create a class to represent your dinosaurs. The class should have the following properties
    class Dinosaur
    {
        public string Name { get; set; } //Name
        public string DietType { get; set; }//DietType - This will be "carnivore" or "herbivore"
        public DateTime WhenAcquired { get; set; }//WhenAcquired - This will default to the current time when the dinosaur is created
        public int Weight { get; set; }//Weight - How heavy the dinosaur is in pounds.
        public int EnclosureNumber { get; set; }//EnclosureNumber - the number of the pen the dinosaur is in
        public string Description()
        {
            var dinoDescription = $"Name: {Name}\nDietType: {DietType}\nDate Acquired: {WhenAcquired}\nWeight: {Weight} pounds\nEnclosure #: {EnclosureNumber}";
            return dinoDescription;
        }
    }
    class DinosaurDatabase
    {
        private List<Dinosaur> dinosaurs = new List<Dinosaur>();
        public List<Dinosaur> GetAllDinosaurs()
        {
            return dinosaurs;
        }
        public void AddDinosaur(Dinosaur newDinosaur)
        {
            dinosaurs.Add(newDinosaur);
        }
        public Dinosaur FindOneDinosaur(string name)
        {

            Dinosaur foundDinosaur = dinosaurs.FirstOrDefault(dinosaur => dinosaur.Name == name);
            return foundDinosaur;
        }


    }
    class Program
    {
        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();
            return userInput;
        }
        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);
            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }
        static void Main(string[] args)
        {
            var database = new DinosaurDatabase();

            var keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine("What would you like to do?(A)dd a dino (V) all dinos (Q)uit");
                var choice = Console.ReadLine().ToUpper();

                if (choice == "A")
                {
                    var dinosaur = new Dinosaur();

                    dinosaur.Name = PromptForString("What is the name of the dinosaur? ");
                    dinosaur.DietType = PromptForString("What is the diet of the dinosaur? ");
                    dinosaur.Weight = PromptForInteger("How much does the dinosaur weigh in pounds? ");
                    dinosaur.EnclosureNumber = PromptForInteger("What enclosure number are they in? ");
                    dinosaur.WhenAcquired = DateTime.Now;

                    // Add it to the list
                    database.AddDinosaur(dinosaur);

                    //Add
                    //This command will let the user type in the information for a dinosaur and add it to the list. 
                    //Prompt for the Name, Diet Type, Weight and Enclosure Number, but the WhenAcquired must be supplied by the code.

                }
                else if (choice == "V")
                {
                    var dinosaurs = database.GetAllDinosaurs();
                    foreach (var dinosaur in dinosaurs)
                    {
                        // And print details
                        Console.WriteLine(dinosaur.Description());
                        Console.WriteLine();
                        //View
                        //This command will ask the user if they wish to see the dinosaurs in Name or EnclosureNumber order. 
                        //Based on that choice, the list of dinosaurs should be shown in the correct order.
                        // If there no dinosaurs in the park, print out a special message to the user.
                    }
                    Console.WriteLine("Remember to add LINQ features to sort the list");
                }
                else if (choice == "D")
                {
                    //Remove
                    //This command will prompt the user for a dinosaur name then find and delete the dinosaur with that name.
                }
                else if (choice == "T")
                {
                    //Transfer
                    //This command will prompt the user for a dinosaur name and a new EnclosureNumber and update that dino's information.
                }
                else if (choice == "S")
                {
                    //Summary
                    //This command will display the number of carnivores and the number of herbivores.
                }
                else if (choice == "Q")
                {
                    keepGoing = false;
                    //Quit
                }
                //This will stop the program
            }

        }
    }
}
