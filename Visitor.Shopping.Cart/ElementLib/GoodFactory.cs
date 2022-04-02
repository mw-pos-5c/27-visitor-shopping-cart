using System;

namespace ElementLib
{
    public class GoodFactory
    {
        public static Good GetGood(string good)
        {
            switch (good)
            {
                case "Beverage":
                    return new Beverage();
                case "Cosmetic":
                    return new Cosmetic();
                case "Food":
                    return new Food();
            }

            return null;
        }
    }
}