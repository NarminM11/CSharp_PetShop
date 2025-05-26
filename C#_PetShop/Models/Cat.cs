using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace C__PetShop.Models
{
    public class Cat : Pet
    {
        public string ColorPattern { get; set; }
        public int Size { get; set; }

        public Cat(string nickname, int age, char gender, double energy, int price, double mealQuantity, string colorPattern, int size)
            : base(nickname, age, gender, energy, price, mealQuantity)
        {
            ColorPattern = colorPattern;
            Size = size;
        }

        public override void Sleep()
        {
            Energy += 10;
        }

        public override void Eat()
        {

            int meal_quantity = 0;
            string meal_name = "";

            Console.WriteLine("Which food do you want the cat to eat?");
            Console.WriteLine("1. Whiskas");
            Console.WriteLine("2. Fish");
            Console.WriteLine("3. Chicken");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice == 1)
                {
                    meal_name = "Whiskas";
                }
                else if (choice == 2)
                {
                    meal_name = "Fish";
                }
                else if (choice == 3)
                {
                    meal_name = "Chicken";
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
            Console.WriteLine("1. 200 gr");
            Console.WriteLine("2. 400 gr");
            Console.WriteLine("3. 600 gr");

            int gramChoice;
            if (int.TryParse(Console.ReadLine(), out gramChoice))
            {
                if (gramChoice == 1)
                {
                    meal_quantity = 200;
                    Energy += 10;
                    Size++;
                    Price++;
                }
                else if (gramChoice == 2)
                {
                    meal_quantity = 400;
                    Energy += 20;
                    Size += 2;
                    Price++;
                }
                else if (gramChoice == 3)
                {
                    meal_quantity = 600;
                    Energy += 20;
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

            Console.WriteLine($"Cat ate {meal_quantity} gr of {meal_name} and got 10 energy.");
            MealQuantity += (double)meal_quantity;

        }

        public override void Play()
        {
            Energy -= 10;
            if (Energy <= 0)
            {
                Console.WriteLine($"{Nickname} is tired and needs to sleep.");
                Energy = 0;
                Sleep();
            }
            else
            {
                Console.WriteLine($"{Nickname} is playing and purring...");

                SoundPlayer player = new SoundPlayer(@"C:\Users\Ferid\Downloads\181957__magnus589__fia-cat-purring.wav");
                player.Play();
            }
        }

        public void CalculateAge()
        {
            if (Size > 10)
            {
                Age++;
            }
        }

        public override int TotalPrice()
        {
            return Price + (Size * 2);
        }

        public override string ToString()
        {
            return base.ToString() + $" | ColorPattern: {ColorPattern} | Size: {Size}";
        }

    }

}
