using Units;

namespace Army;

public class Army : IArmy
{
    public IList<IUnit> Units { get; private set; } = new List<IUnit>();
    public void DisplayArmy()
    {
        Console.WriteLine("Army contains:");

        const int nameWidth = 15;
        const int hpWidth = 8;
        const int defenceWidth = 12;
        const int meleeAttackWidth = 15;
        const int rangeAttackWidth = 15;
        
        Console.WriteLine("{0}{1}{2}{3}{4}",
            "Name".PadRight(nameWidth),
            "HP".PadRight(hpWidth),
            "Defence".PadRight(defenceWidth),
            "Melee Attack".PadRight(meleeAttackWidth),
            "Range Attack".PadRight(rangeAttackWidth));
        
        foreach (var unit in Units)
        {
            var name = unit.GetType().Name;
            var hp = unit.Health.ToString();
            var defence = unit.DefencePower.ToString();
            var meleeAttack = unit.MeleeAttackPower.ToString();
            var rangeAttack = unit.RangeAttackPower.ToString();
            
            Console.WriteLine("{0}{1}{2}{3}{4}",
                name.PadRight(nameWidth),
                hp.PadRight(hpWidth),
                defence.PadRight(defenceWidth),
                meleeAttack.PadRight(meleeAttackWidth),
                rangeAttack.PadRight(rangeAttackWidth));
        }
    }
    
    public void RemoveDeadUnits()
    {
        Units = Units.Where(unit => unit.Health > 0).ToList();
    }
}