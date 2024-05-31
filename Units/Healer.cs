namespace Units;

public class Healer : Unit
{
    public Healer()
    {
        Health = 100;
        MeleeAttackPower = 7;
        DefencePower = 2;
        Cost = 150;
    }
    public override string ToString() => "Healer";
    
}

