namespace Units;

public class Archer : Unit, ICloneable
{
    public Archer() 
    {
        Health = 100;
        MeleeAttackPower = 8;
        //max range = 2 units
        RangeAttackPower = 6;
        DefencePower = 2;
        Cost = 60;
    }
    public object Clone()
    {
        return MemberwiseClone();
    }
    
}