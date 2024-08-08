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
			}
			else Console.WriteLine("Empty File");
		}
		catch (Exception)
		{
			Console.WriteLine("Path error");
		}
		return randomLine;
	}
	//dado un string, lo separa en un string[] mediante ',', se crea un int[] y se convierte los elementos del string[] a int[] y se retorna;
	public static int[] FileLineToIntArray(string fileLine)
	{
		string[] numbers = fileLine.Split(",");
		int cantElem = numbers.Length;
		int[] array = new int[cantElem];

		for (int i = 0; i < cantElem; i++) array[i] = Convert.ToInt32(numbers[i]);
		return array;
	}
	public static int[,] ArrayTo4x4Matrix(int[] array)
	{
		int[,] matrix = new int[4, 4];
		int index = 0;
		for(int i = 0; i < 4; i++)
		{
			for(int x = 0; x < 4; x++)
			{
				matrix[i, x] = array[index];
				index++;
			}
		}
		return matrix;
	}
	//dado un array[,] retorna int[] con index del lugar libre;
	public static int[] EmptyIndex(int[,] array)
	{
		int[] emptyIndex = {-1, -1};
		for(int x = 0; x < 4; x++)
		{
			for(int y = 0; y < 4; y++)
			{
				if (array[x, y] == 16)
				{
					emptyIndex = new int[] { x, y };
					return emptyIndex;
				}
			}
		}
		return emptyIndex;
	}
}
