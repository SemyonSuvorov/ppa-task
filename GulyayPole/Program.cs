using GulyayPole;

var p = Misc.GetPlayers();
while (true)
{
    var players = Misc.SetStrategy(p);
    foreach (var player in players)
    {
        player.DisplayArmy();
        Console.WriteLine();
    }
    Console.WriteLine("Press any key if you're ready to start the game!");
    Console.ReadKey();
    Console.Clear();
    var currentPlayerIndex = 0;
    while (players[0].IsNotEmpty() && players[1].IsNotEmpty())
    {
        var currentPlayer = players[currentPlayerIndex];
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
        var opponent = players[currentPlayerIndex];
        Misc.Turn(currentPlayer, opponent);
    }
    Console.WriteLine($"The game is over! {players.Where(x => x.IsNotEmpty()).ToList()[0].Name} won!");
}

