
public class Game
{
    private int[,] _gameState;
    private int _cantMoves;
    private int _score;
    private int[] _emptyPos;
    private int[] _adyL;
    private int[] _adyR;
    private int[] _adyUp;
    private int[] _adyDown;

    public Game()
    {
        _gameState = Uwu.ArrayTo4x4Matrix(Uwu.FileLineToIntArray(Uwu.RandomFileLine()));
        _cantMoves = 0;
        _score = 0;
        _emptyPos = Uwu.EmptyIndex(_gameState);
        _adyL = new int[] { _emptyPos[0], _emptyPos[1] - 1 };
        _adyR = new int[] { _emptyPos[0], _emptyPos[1] + 1 };
        _adyUp = new int[] { _emptyPos[0] - 1, _emptyPos[1] };
        _adyDown = new int[] { _emptyPos[0] + 1, _emptyPos[1] };
    }
    public int Movements => _cantMoves;
    public void SetScoreAbandonGame() => _score = 0;
    public int Score => _score;
    public void WinMessage() => Console.WriteLine("GG Ez");
    public void ActualizePos()
    {
        _emptyPos = Uwu.EmptyIndex(_gameState);
        _adyL = new int[] { _emptyPos[0], _emptyPos[1] - 1 };
        _adyR = new int[] { _emptyPos[0], _emptyPos[1] + 1 };
        _adyUp = new int[] { _emptyPos[0] - 1, _emptyPos[1] };
        _adyDown = new int[] { _emptyPos[0] + 1, _emptyPos[1] };
        _cantMoves++;
    }
    public Boolean WinCondition()
    {
        if (_gameState[0, 3] > _gameState[1, 0]) return false;
        if (_gameState[1, 3] > _gameState[2, 0]) return false;
        if (_gameState[2, 3] > _gameState[3, 0]) return false;

        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 3; y++) if (_gameState[x, y] > _gameState[x, y + 1]) return false;
        }
        return true;
    }
    public void Move(ConsoleKey key1)
    {
        switch (key1)
        {
            case ConsoleKey.UpArrow: MoveUp(); break;
            case ConsoleKey.DownArrow: MoveDown(); break;
            case ConsoleKey.LeftArrow: MoveLeft(); break;
            case ConsoleKey.RightArrow: MoveRight(); break;
        }
    }
    public void MoveDown()
    {
        try
        {
            _gameState[_emptyPos[0], _emptyPos[1]] = _gameState[_adyUp[0], _adyUp[1]];
            _gameState[_adyUp[0], _adyUp[1]] = 16;
            ActualizePos();
        }
        catch (Exception) { }
    }
    public void MoveUp()
    {
        try
        {
            _gameState[_emptyPos[0], _emptyPos[1]] = _gameState[_adyDown[0], _adyDown[1]];
            _gameState[_adyDown[0], _adyDown[1]] = 16;
            ActualizePos();
        }
        catch (Exception) { }
    }
    public void MoveLeft()
    {
        try
        {
            _gameState[_emptyPos[0], _emptyPos[1]] = _gameState[_adyR[0], _adyR[1]];
            _gameState[_adyR[0], _adyR[1]] = 16;
            ActualizePos();
        }
        catch (Exception) { }
    }
    public void MoveRight()
    {
        try
        {
            _gameState[_emptyPos[0], _emptyPos[1]] = _gameState[_adyL[0], _adyL[1]];
            _gameState[_adyL[0], _adyL[1]] = 16;
            ActualizePos();
        }
        catch (Exception) { }
    }
    public void SetScore(int apuesta)
    {
        if (_cantMoves < apuesta - 10) _score = 1500;
        else if ((_cantMoves >= apuesta) && (_cantMoves < apuesta)) _score = 1200;
        else if (_cantMoves == apuesta) _score = 1000;
        else if ((_cantMoves > apuesta) && (_cantMoves <= apuesta + 10)) _score = 500;
        else _score = 0;
    }
    public void printGameState()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("╔════╦════╦════╦════╗");
        for (int x = 0; x < 4; x++)
        {
            Console.Write("║");
            for (int i = 0; i < 4; i++)
            {
                if (_gameState[x, i] == 16)
                {
                    Console.Write("    ║");
                }
                else
                {
                    string asd = _gameState[x, i].ToString().PadLeft(2);
                    Console.Write($" {asd} ║");
                }
            }
            Console.WriteLine();
            if (x < 3) Console.WriteLine("╠════╬════╬════╬════╣");
        }
        Console.WriteLine("╚════╩════╩════╩════╝");
    }
    public void PrintGameScore() => Console.WriteLine($"║ Score: {_score} ║");
    public void printGameController()
    {// ^ < > v
        string asd = _cantMoves.ToString().PadLeft(3);
        Console.WriteLine("           ╔═══╗");
        Console.WriteLine("           ║ ^ ║");
        Console.WriteLine("╔═══╗  ╔═══╬═══╬═══╗  ╔══════════════════╗");
        Console.WriteLine($"║Esc║  ║ < ║ v ║ > ║  ║Cant Movements:{asd}║");
        Console.WriteLine("╚═══╝  ╚═══╩═══╩═══╝  ╚══════════════════╝");
    }
    public void PrintGameOptions()
    {
        Console.WriteLine("╔═══╗  ╔═══╗");
        Console.WriteLine("║Esc║  ║Ent║");
        Console.WriteLine("╚═══╝  ╚═══╝");
    }
}
