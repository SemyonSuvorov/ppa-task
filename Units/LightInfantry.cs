namespace Units;


public class LightInfantry : Unit, ICloneable
{
    public LightInfantry() 
    {
        Health = 100;
        MeleeAttackPower = 13;
        DefencePower = 3;
        Cost = 60;
    }

    public object Clone()
    {
        return MemberwiseClone();
    }
}
