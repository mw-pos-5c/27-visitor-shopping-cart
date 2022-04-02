using System.Runtime.CompilerServices;

namespace ElementLib
{
    public class CaloriesVisitor : IVisitor
    {
        private int total = 0;
        
        public void VisitFood(Food food)
        {
            total += food.Calories*food.NrUnits;
        }

        public void VisitBeverage(Beverage beverage)
        {
            total += beverage.Calories*beverage.NrUnits;
        }

        public void VisitCosmetic(Cosmetic cosmetic)
        {
        }

        public string ResultString => $"Kalorien: {total}";
        public IVisitor Reset()
        {
            total = 0;
            return this;
        }
    }
}