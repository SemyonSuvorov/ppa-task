using Players;

namespace GulyayPole;

public class Misc
{
    public static List<Player> GetPlayers()
    {
        Console.WriteLine("Player 1, please enter your name:");
        var firstName = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Player 2, please enter your name:");
        var secondName = Console.ReadLine();
        var players = new List<Player> { new Player(firstName), new Player(secondName) };
        Console.Clear();
        return players;
    }

    public static List<Player> SetStrategy(List<Player> players)
    {
        foreach (var player in players)
        {
            Console.WriteLine($"Choose army for {player.Name}:");
            Console.WriteLine("1. Balanced Army");
            Console.WriteLine("2. Agile Army");

            var choice = int.Parse(Console.ReadLine());
            player.ChooseArmy(ArmyFactory.GetArmyFactory(choice));
            
            Console.WriteLine($"{player.Name} has chosen their army.");
            //Thread.Sleep(1500);
            Console.Clear();
        }
        Console.Clear();
        return players;
    }

    private static int TurnMenu()
    {
        Console.WriteLine("1. Attack");
        Console.WriteLine("2. Show Army");
        Console.WriteLine("3. Clone Unit");
        Console.WriteLine("4. Heal Unit");
        var s = Console.ReadLine();
        var c = int.TryParse(s, out var a);
        return !c ? 0 : a;
    }

    public static void Turn(Player player, Player enemy)
    {
        Console.WriteLine($"{player.Name}'s turn!");
        Console.WriteLine();
        while (true)
        {
            var command = CommandFactory.GetCommand(TurnMenu(), player, enemy);
            if (command != null)
            {
                command.Execute();
                if (command.IsTerminating)
                    break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid Input!");
                Console.WriteLine();
            }
        }
    }
}



