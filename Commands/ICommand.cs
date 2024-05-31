namespace Commands;

public interface ICommand
{
    void Execute();
    bool IsTerminating { get; }
}