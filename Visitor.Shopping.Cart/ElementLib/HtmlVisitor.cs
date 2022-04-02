namespace ElementLib
{
    public class HtmlVisitor : IVisitor
    {
        public void VisitFood(Food food)
        {
            ResultString =
                $"<tr><td>{food.Name}</td><td>{food.PricePerUnit}€</td><td>{food.Weight}g</td><td{food.Calories} kcal</td></tr>";
        }

        public void VisitBeverage(Beverage beverage)
        {
            ResultString =
                $"<tr><td>{beverage.Name}</td><td>{beverage.PricePerUnit}€</td><td>{beverage.Weight}g</td><td{beverage.Alcohol:0.0}% Alc.</td></tr>";
        }

        public void VisitCosmetic(Cosmetic cosmetic)
        {
            ResultString = $"<tr><td>{cosmetic.Name}</td><td>{cosmetic.PricePerUnit}€</td><td>{cosmetic.Weight}g</td><td>&nbsp;</td></tr>";
        }

        public string ResultString { get; private set; }
        public IVisitor Reset()
        {
            ResultString = null;
            return this;
        }
    }
}