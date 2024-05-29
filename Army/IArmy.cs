namespace Army;
using Units;

public interface IArmy
{
    IList<IUnit> Units { get; }
    bool HasMage { get; }
    void DisplayArmy();
    void RemoveDeadUnits();
}