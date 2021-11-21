using System;

namespace Snake
{
	class Point
	{
		public int x;
		public int y;
		public char sym;

		// конструктор, где мы обьявляем поля
		public Point(int x, int y, char sym)
		{
			this.x = x;
			this.y = y;
			this.sym = sym;
		}

		// конструктор, где мы задаем параметры точки, с помощью другой точки:)
		public Point(Point p)
		{
			x = p.x;
			y = p.y;
			sym = p.sym;
		}

		public void Move(int offset, Direction direction) // змейка движется
		{
			if (direction == Direction.RIGHT)
			{
				x += offset; // x = x+offset
			}
			else if (direction == Direction.LEFT)
			{
				x -= offset; // x = x-offset
			}
			else if (direction == Direction.UP)
			{
				y -= offset; // y = y-offset
			}
			else if (direction == Direction.DOWN)
			{
				y += offset; // y = y+offset
			}
		}

		public bool IsHit(Point p) // смотрим, есть ли пересечение координат
		{
			return p.x == this.x && p.y == this.y;
		}

		public void Draw() // отрисовка точек
		{
			// SetCursorPosition метод, чтобы указать, где должна начинаться следующая операция записи в окне консоли
			// указываем где будет начинатся рисунок наших точек
			Console.SetCursorPosition(x, y); 
			Console.Write(sym);
		}

		public void Clear() // очищаем точки, по которым уже прошлись с помошью нашего хвоста
		{
			sym = ' ';
			Draw();
		}

		public override string ToString() // используем полиморфизм и перезагружаем метод, чтобы не плодить кучу методов
		{
			return x + ", " + y + ", " + sym;
		}
	}
}
