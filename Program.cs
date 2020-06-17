using System;
using System.Collections.Generic;
namespace hungryNinja
{

    class Food
    {
        public string Name;
        public int Calories;
        public bool IsSpicy;
        public bool IsSweet;

        public Food(string dish, int cal, bool isSpi, bool isSwe)
        {
            Name = dish;
            Calories = cal;
            IsSpicy = isSpi;
            IsSweet = isSwe;
        }
    }

    class Buffet
    {
        public List<Food> Menu;
        public Buffet()
        {
            Menu = new List<Food>()
            {
                new Food("Bread", 1500, false, false),
                new Food("Corn", 260, false, false),
                new Food("Soup", 2600, false, false),
                new Food("Sushi", 260, true, false),
                new Food("Eggs", 2600, false, false),
                new Food("Spegetti", 260, false, false),
                new Food("Bagel", 260, true, false),
                new Food("Lobster", 1800, false, false)
            };
        }

        public Food Serve()
        {
            Random Rand = new Random();
            Food dish = Menu[Rand.Next(Menu.Count)];
            Console.WriteLine(dish.Name);

            return dish ;
        }
    }

    class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory;

        public int calorieIntakeProp
        {
            get
            {
                return calorieIntake;
            }
        }

        public Ninja()
        {
            calorieIntake = 0;
            FoodHistory = new List<Food>();
        }

        public bool IsFull
        {
            get
            {
                if(calorieIntake > 1200){
                    // Console.WriteLine("Full");
                    return true;
                }
                // Console.WriteLine("Hungry");
                return false;
            }
        }

        public void Eat(Food dish)
        {
            if(IsFull == false)
            {
                calorieIntake += dish.Calories;
                FoodHistory.Add(dish);
                if(dish.IsSpicy == true || dish.IsSweet == true)
                {
                    Console.WriteLine("this is either spicy or sweet");
                }
            }
            if(IsFull == true){Console.WriteLine("Full, can't eat anymore");}
        }
    }

        class Program
    {
        static void Main(string[] args)
        {
            Buffet Star = new Buffet();

            Ninja Slow = new Ninja();
            while(Slow.IsFull == false) // OR while(Slow.IsFull != true)
            {
                Slow.Eat(Star.Serve());
            }
        }
    }
}
