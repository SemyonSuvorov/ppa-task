namespace GulyayPole;

public class InvalidCommand : ICommand
{
    public void Execute()
    {
        Console.Clear();
        Console.WriteLine("Invalid Input!");
        Console.WriteLine();
    }

    public bool IsTerminating => false;
}