namespace ElementLib
{
    public class WeightVisitor : IVisitor
    {
        private double total = 0;
        
        public void VisitFood(Food food)
        {
            total += food.Weight*food.NrUnits;
        }

        public void VisitBeverage(Beverage beverage)
        {
            total += beverage.Weight*beverage.NrUnits;
        }

        public void VisitCosmetic(Cosmetic cosmetic)
        {
            total += cosmetic.Weight*cosmetic.NrUnits;
        }

        public string ResultString => $"Total Weight : {total} kg";
        public IVisitor Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}