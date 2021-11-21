using System.Collections.Generic;

namespace Snake
{
	class HorizontalLine : Figure // наследование от класса Figure
	{
		// создаем конструктор

		public HorizontalLine(int xLeft, int xRight, int y, char sym) // задаем параметры наших точек
		{
			pList = new List<Point>();
			for (int x = xLeft; x <= xRight; x++) // присваеваем значение х и записываем их в список
			{
				Point point = new Point(x, y, sym);
				pList.Add(point);
			}
		}
	}
}
