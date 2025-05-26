using System;
using System.Media;

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
public class PetShop
{
    public Cat[] Cats = new Cat[10];
    public Dog[] Dogs = new Dog[10];
    public int CatCount = 0;
    public int DogCount = 0;
    public int Budget { get; set; }

    public PetShop()
    {
        Budget = 200;
    }
    public void AddCat(Cat cat) { 
       if(CatCount < Cats.Length)
        {
            Cats[CatCount++] = cat;
            Budget += cat.TotalPrice(); 

        }
        else
        {
            Console.WriteLine("Cat cannot be added, array is full");
        }
    }

    public void AddDog(Dog dog)
    {
        if (DogCount < Dogs.Length)
        {
            Dogs[DogCount++] = dog;
            Budget += dog.TotalPrice();  

        }
        else
        {
            Console.WriteLine("Cat cannot be added, array is full");
        }
    }
    public void RemoveByNickName(string nickname)
    {
        for (int i = 0; i < CatCount; i++)
        {
            if (Cats[i].Nickname == nickname)
            {
                Cats[i] = Cats[CatCount - 1];
                Cats[CatCount - 1] = null;
                CatCount--;
                Console.WriteLine($"Cat '{nickname}' removed.");
                return;
            }
        }

        Console.WriteLine($"Cat '{nickname}' not found.");
    }



    public void SellCat()
    {
        if (CatCount == 0)
        {
            Console.WriteLine("No cats available to sell.");
            return;
        }

        Cat soldCat = Cats[CatCount - 1];

        Cats[CatCount - 1] = null;
        CatCount--;

        Console.WriteLine($"Cat sold: {soldCat.Nickname}");
        Console.WriteLine($"Total earned from sale: {soldCat.TotalPrice()} AZN");
        Console.WriteLine($"Updated shop budget: {Budget} AZN");
    }


    public void SellDog()
    {
        if (DogCount == 0)
        {
            Console.WriteLine("No cats available to sell.");
            return;
        }

        Dog soldDog = Dogs[DogCount - 1];

        Budget += soldDog.TotalPrice();
        Dogs[DogCount - 1] = null;     //sonuncu iti silirik arrayden
        DogCount--;

        Console.WriteLine($"Dog sold: {soldDog.Nickname}");
        Console.WriteLine($"Budget after selling: {Budget} AZN");
    }

    public void CheckBudget()
    {
        Console.WriteLine($"Current budget of shop: {Budget}");
    }

}

public class Pet:PetShop
{
    public string Nickname { get; set; }
    public int Age { get; set; }
    public char Gender { get; set; }
    public double Energy { get; set; }
    public int Price { get; set; }
    public double MealQuantity { get; set; }

    public Pet()
    {
        Nickname = "Unknown";
        Age = 0;
        Gender = 'U';
        Energy = 0.0;
        Price = 0;
        MealQuantity = 0.0;
    }

    public Pet(string nickname, int age, char gender, double energy, int price, double mealQuantity)
    {
        Nickname = nickname;
        Age = age;
        Gender = gender;
        Energy = energy;
        Price = price;
        MealQuantity = mealQuantity;
    }

    public virtual void Sleep() { }
    public virtual void Eat() { }
    public virtual void Play() { }

    public override string ToString()
    {
        return @$"Name: {Nickname} | Age: {Age} | Gender: {Gender} | Energy: {Energy} | Price: {Price} | MealQuantity: {MealQuantity}";
    }

    public virtual int TotalPrice()
    {
        return Price;
    }
}

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
                Size+=2;
                Price++;
            }
            else if (gramChoice == 3)
            {
                meal_quantity = 600;
                Energy += 20;
                Size+=3;
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
        if(Size > 10)
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
