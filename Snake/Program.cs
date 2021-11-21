using System;
using System.Threading;

namespace Snake
{
	class Program
	{
		static void Main(string[] args)
		{
			// избавляемся от ошибки  System.ArgumentOutOfRangeException:
			// "Размер буфера консоли должен быть не меньше текущего размера и положения окна консоли
			// и не больше или равен значению Int16.MaxValue.
			// при задании width = 80

			Console.SetWindowSize(80, 25); // задаем размер окна 
			Console.SetBufferSize(80, 25); // чтобы при вызове вот этого метода не выполз эксепшен

			Walls walls = new Walls(80, 25);
			walls.Draw();

			// Отрисовка точек			
			Point point = new Point(4, 5, '*');
			Snake snake = new Snake(point, 4, Direction.RIGHT);
			snake.Draw();

			FoodCreator foodCreator = new FoodCreator(80, 25, '$');
			Point food = foodCreator.CreateFood();
			food.Draw();

			while (true)
			{
				if (walls.IsHit(snake) || snake.IsHitTail()) // тут мы теряем координацию и наносим себе увечия
				{
					break;
				}
				if (snake.Eat(food)) // тут мы едим, змейка наконец-то соединилась с едой
				{
					food = foodCreator.CreateFood();
					food.Draw();
				}
				else
				{
					snake.Move();
				}

				Thread.Sleep(100); // небольшая задержка, чтобы лишние точки в хвосте удалились, а к голове добавились
				//Console.KeyAvailable
				// Возвращает или задает значение, указывающее, доступно ли нажатие клавиши
				// (true, если нажатие клавиши доступно)
				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo key = Console.ReadKey();
					snake.HandleKey(key.Key);
				}
			}
			WriteGameOver();
			Console.ReadLine();
		}

		static void WriteGameOver()
		{
			int xOffset = 25;
			int yOffset = 8;
			Console.ForegroundColor = ConsoleColor.Magenta; // задаем цвет, я захотела фиолетовый
			Console.SetCursorPosition(xOffset, yOffset++);
			WriteText("============================", xOffset, yOffset++);
			WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
			yOffset++;
			WriteText("Автор: Койда Ирина", xOffset + 2, yOffset++);
			WriteText("============================", xOffset, yOffset++);
		}

		static void WriteText(String text, int xOffset, int yOffset)
		{
			Console.SetCursorPosition(xOffset, yOffset);
			Console.WriteLine(text);
		}
	}
}
