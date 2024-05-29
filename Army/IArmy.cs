namespace Army;
using Units;

public interface IArmy
{
    IList<IUnit> Units { get; }
    void DisplayArmy();
    void RemoveDeadUnits();
}