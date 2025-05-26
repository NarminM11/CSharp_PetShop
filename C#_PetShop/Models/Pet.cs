using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__PetShop.Models
{
    public class Pet : PetShop
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
}
