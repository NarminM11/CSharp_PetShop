using System;
using System.Media;
using C__PetShop.Models;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        PetShop shop = new PetShop();

        Console.WriteLine("Do you want to buy or remove an animal? (1 - Buy, 2 - Remove)");
        int operation;

        if (int.TryParse(Console.ReadLine(), out operation))
        {
            if (operation == 1) //buy cat or dog
            {
                Console.WriteLine("Which animal do you want to buy? 1. Cat 2. Dog");
                int choice;

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice == 1)
                    {
                        Console.WriteLine("Enter the nickname for the cat:");
                        string catNickname = Console.ReadLine();

                        Cat cat = new Cat(catNickname, 2, 'F', 50, 200, 0.3, "Calico", 10);

                        shop.AddCat(cat);
                        Console.WriteLine($"Cat with nickname '{catNickname}' added to the shop!");
                        shop.SellCat();

                        while (true)
                        {
                            Console.WriteLine("\nWhat do you want to do with the cat?");
                            Console.WriteLine("1. Feed");
                            Console.WriteLine("2. Play");
                            Console.WriteLine("3. Sleep");
                            Console.WriteLine("4. Show Info");
                            Console.WriteLine("0. Exit");

                            int action;
                            if (int.TryParse(Console.ReadLine(), out action))
                            {
                                if (action == 1)
                                {
                                    cat.Eat();
                                }
                                else if (action == 2)
                                {
                                    cat.Play();
                                }
                                else if (action == 3)
                                {
                                    cat.Sleep();
                                    Console.WriteLine("Cat slept and gained energy.");
                                }
                                else if (action == 4)
                                {
                                    Console.WriteLine(cat);
                                    Console.WriteLine("Total Price: " + cat.TotalPrice());
                                }
                                else if (action == 0)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid choice.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid number.");
                            }
                        }
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("Enter nickname for the dog:");
                        string dogNickname = Console.ReadLine();

                        Console.WriteLine("Enter dog's breed:");
                        string dogBreed = Console.ReadLine();

                        Dog dog = new Dog(dogNickname, 3, 'M', 60, 300, 0.5, dogBreed, 12);

                        shop.AddDog(dog);
                        Console.WriteLine("Dog added to the shop!");

                        while (true)
                        {
                            Console.WriteLine("\nWhat do you want to do with the dog?");
                            Console.WriteLine("1. Feed");
                            Console.WriteLine("2. Play");
                            Console.WriteLine("3. Sleep");
                            Console.WriteLine("4. Show Info");
                            Console.WriteLine("0. Exit");

                            int action;
                            if (int.TryParse(Console.ReadLine(), out action))
                            {
                                if (action == 1)
                                {
                                    dog.Eat();
                                }
                                else if (action == 2)
                                {
                                    dog.Play();
                                }
                                else if (action == 3)
                                {
                                    dog.Sleep();
                                    Console.WriteLine("Dog slept and gained energy.");
                                }
                                else if (action == 4)
                                {
                                    Console.WriteLine(dog);
                                    Console.WriteLine("Total Price: " + dog.TotalPrice());
                                }
                                else if (action == 0)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid choice.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid number.");
                            }
                        }
                    }
                    Console.WriteLine($"\nCurrent shop budget: {shop.Budget} AZN");
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
            else if (operation == 2) 
            {
                Console.WriteLine("Enter the nickname of the animal you want to remove:");
                string nickname = Console.ReadLine();

                shop.RemoveByNickName(nickname);
            }
            else
            {
                Console.WriteLine("Invalid option. Please select 1 or 2.");
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid number.");
        }
    }

}





