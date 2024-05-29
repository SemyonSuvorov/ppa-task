namespace Units;

public static class UnitFactory
{
    public static IUnit CreateUnit(string unitType)
    {
        return unitType.ToLower() switch
        {
            "heavy" => new HeavyInfantry(),
            "archer" => new Archer(),
            "light" => new LightInfantry(),
            "mage" => new Mage(),
            _ => throw new ArgumentException("Invalid unit type")
        };
    }
}