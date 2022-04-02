namespace ElementLib
{
    public class PriceVisitor : IVisitor
    {
        private double total = 0;
        public void VisitFood(Food food)
        {
            total += food.PricePerUnit*food.NrUnits;
        }

        public void VisitBeverage(Beverage beverage)
        {
            total += beverage.PricePerUnit*beverage.NrUnits;
        }

        public void VisitCosmetic(Cosmetic cosmetic)
        {
            total += cosmetic.PricePerUnit*cosmetic.NrUnits;
        }

        public string ResultString => $"Total Price: {total} €";
        public IVisitor Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}