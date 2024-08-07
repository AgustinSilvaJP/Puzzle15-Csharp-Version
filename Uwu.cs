using System;
//class that contains general use methods
public class Uwu
{
	//dado el filePath lee el archivo y retorna una linea aleatoria;
	public static string RandomFileLine()
	{
		string randomLine = " ";
		try
		{
			var cantFileLines = File.ReadLines("C:\\Users\\agust\\OneDrive\\Documentos\\Projects\\Puzzle15\\init_game.txt").ToList();
			if (cantFileLines.Any())
			{
				Random random = new Random();
				int randomIndex = random.Next(0, cantFileLines.Count);
				randomLine = cantFileLines[randomIndex];
				Console.WriteLine($"Line: {randomLine}");
			}
			else Console.WriteLine("Empty File");
		}
		catch (Exception e)
		{
			Console.WriteLine("Path error");
		}
		return randomLine;
	}

	}
