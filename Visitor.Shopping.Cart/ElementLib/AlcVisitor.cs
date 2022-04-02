namespace ElementLib
{
    public class AlcVisitor : IVisitor
    {
        private double sum = 0;
        private int count = 0;
        
        public void VisitFood(Food food)
        {
        }

        public void VisitBeverage(Beverage beverage)
        {
            sum += beverage.Alcohol*beverage.NrUnits;
            count += beverage.NrUnits;
        }

        public void VisitCosmetic(Cosmetic cosmetic)
        {
        }
        
        public string ResultString
        {
            get
            {
                double avg = 0;
                if (count > 0)
                {
                    avg = sum / count;
                }
                return $"Avg Alc: {avg}";
            }
        }

        public IVisitor Reset()
        {
            sum = 0;
            count = 0;
            return this;
        }
    }
}