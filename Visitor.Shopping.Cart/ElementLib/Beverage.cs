using System;

namespace ElementLib
{
  public class Beverage : Good
  {
    public Beverage()
    {
      var random = new Random();
      Alcohol = random.Next(0, 70);
      Calories = random.Next(0, 500);
    }

    public int Calories { get; set; }
    public double Alcohol { get; set; }
    public override void Accept(IVisitor visitor)
    {
      visitor.VisitBeverage(this);
    }
  }
}
