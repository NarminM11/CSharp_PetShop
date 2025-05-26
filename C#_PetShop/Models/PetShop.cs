using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C__PetShop.Models;
namespace C__PetShop.Models
{
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
        public void AddCat(Cat cat)
        {
            if (CatCount < Cats.Length)
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

}
