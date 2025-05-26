using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__PetShop.Models
{
    public class Dog : Pet
    {
        public string Breed { get; set; }
        public int Size { get; set; }

        public Dog(string nickname, int age, char gender, double energy, int price, double mealQuantity, string breed, int size)
            : base(nickname, age, gender, energy, price, mealQuantity)
        {
            Breed = breed;
            Size = size;
        }

        public override void Sleep()
        {
            Energy += 15;
        }

        public override void Eat()
        {
            int meal_quantity = 0;
            string meal_name = "";

            Console.WriteLine("Which food do you want the dog to eat?");
            Console.WriteLine("1. Dog Food");
            Console.WriteLine("2. Meat");
            Console.WriteLine("3. Bone");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice == 1)
                {
                    meal_name = "Dog Food";
                }
                else if (choice == 2)
                {
                    meal_name = "Meat";
                }
                else if (choice == 3)
                {
                    meal_name = "Bone";
                }
                else
                {
                    Console.WriteLine("Invalid food choice.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            Console.WriteLine("Please choose grams of the meal:");
            Console.WriteLine("1. 300 gr");
            Console.WriteLine("2. 500 gr");
            Console.WriteLine("3. 700 gr");

            int gramChoice;
            if (int.TryParse(Console.ReadLine(), out gramChoice))
            {
                if (gramChoice == 1)
                {
                    meal_quantity = 300;
                    Energy += 15;
                    Size++;
                    Price++;
                }
                else if (gramChoice == 2)
                {
                    meal_quantity = 500;
                    Energy += 25;
                    Size += 2;
                    Price++;
                }
                else if (gramChoice == 3)
                {
                    meal_quantity = 700;
                    Energy += 30;
                    Size += 3;
                    Price++;
                }
                else
                {
                    Console.WriteLine("Invalid gram choice.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            Console.WriteLine($"Dog ate {meal_quantity} gr of {meal_name} and gained energy.");
            MealQuantity += (double)meal_quantity;
        }

        public override void Play()
        {
            Energy -= 15;
            if (Energy <= 0)
            {
                Console.WriteLine($"{Nickname} is tired and needs to sleep.");
                Energy = 0;
                Sleep();
            }
            else
            {
                Console.WriteLine($"{Nickname} is playing happily!");


            }
        }

        public void CalculateAge()
        {
            if (Size > 15)
            {
                Age++;
            }
        }

        public override int TotalPrice()
        {
            return Price + (Size * 3);
        }

        public override string ToString()
        {
            return base.ToString() + $" | Breed: {Breed} | Size: {Size}";
        }
    }

}
