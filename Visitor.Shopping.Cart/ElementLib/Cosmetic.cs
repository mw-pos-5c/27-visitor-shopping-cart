namespace ElementLib
{
  public class Cosmetic : Good
  {
    public override void Accept(IVisitor visitor)
    {
      visitor.VisitCosmetic(this);
    }
    
  }
}
