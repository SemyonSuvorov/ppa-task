namespace GulyayPole;

public interface ICommand
{
    void Execute();
    bool IsTerminating { get; }
}