using System;

namespace ElementLib
{
  public class Food : Good
  {
    public Food()
    {
      var random = new Random();
      Calories = random.Next(0, 8000);
    }
    
    public int Calories { get; set; }
    public override void Accept(IVisitor visitor)
    {
      visitor.VisitFood(this);
    }
    
  }
}
