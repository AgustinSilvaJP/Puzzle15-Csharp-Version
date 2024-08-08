Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.Black;
Console.Clear();
ConsoleKeyInfo key;
do
{
    Game game = new Game();
    int apuestaGame = -1;
    Console.Write("Ingrese valor entre (40, 200): ");
    do
    {
        try
        {
            apuestaGame = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception) { Console.WriteLine("ERROR! ESCRIBA UN NUMERO!"); }
    } while (apuestaGame < 40 || apuestaGame > 200);
    do
    {
        game.printGameState();
        game.printGameController();
        key = Console.ReadKey();
        Console.WriteLine();
        if (key.Key == ConsoleKey.Escape) break;
        game.Move(key.Key);
    } while (!game.WinCondition());
    Console.Clear();
    if (key.Key == ConsoleKey.Escape) game.SetScoreAbandonGame();
    else game.SetScore(apuestaGame);

    if (game.WinCondition()) game.WinMessage();
    game.PrintGameScore();
    Console.WriteLine("Do you want to play again?");
    game.PrintGameOptions();

} while (Console.ReadKey().Key == ConsoleKey.Enter);

