using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake
{
	class Snake : Figure // говорим что змейка - это фигура, которая состоит из точек
	{
		Direction direction;

		// в конструкторе инициализируем положение змейки(длина хвоста), длину змейки и ее движение

		public Snake(Point tail, int length, Direction _direction) 
		{
			direction = _direction;
			pList = new List<Point>();
			for (int i = 0; i < length; i++)
			{
				Point p = new Point(tail);
				p.Move(i, direction);
				pList.Add(p);
			}
		}

		public void Move()
		{
			Point tail = pList.First(); // метод, который возвращает первый элемент из списка
			pList.Remove(tail); // так как змейка ползет вперед, то та точка, что становится последней в хвосте - больше не нужна
			Point head = GetNextPoint();
			pList.Add(head);

			tail.Clear();
			head.Draw();
		}

		public Point GetNextPoint()
		{
			Point head = pList.Last(); // метод, который возвращает последний элемент из списка
			Point nextPoint = new Point(head);
			nextPoint.Move(1, direction); // сместись на 1 позицию, в указаном направлении
			return nextPoint;
		}

		public bool IsHitTail()
		{
			var head = pList.Last();
			for (int i = 0; i < pList.Count - 2; i++)
			{
				if (head.IsHit(pList[i]))
					return true;
			}
			return false;
		}

		public void HandleKey(ConsoleKey key)
		{
			if (key == ConsoleKey.LeftArrow)
				direction = Direction.LEFT;
			else if (key == ConsoleKey.RightArrow)
				direction = Direction.RIGHT;
			else if (key == ConsoleKey.DownArrow)
				direction = Direction.DOWN;
			else if (key == ConsoleKey.UpArrow)
				direction = Direction.UP;
		}

		public bool Eat(Point food)
		{
			Point head = GetNextPoint();
			if (head.IsHit(food))
			{
				food.sym = head.sym;
				pList.Add(food);
				return true;
			}
			else
				return false;
		}
	}
}
