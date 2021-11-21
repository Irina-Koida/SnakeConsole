using System;

namespace Snake
{
	class FoodCreator
	{
		public int MapWidht;
		public int MapHeight;
		public char Sym;

		private readonly Random _random = new Random();

		public FoodCreator(int mapWidth, int mapHeight, char sym)
		{
			MapWidht = mapWidth;
			MapHeight = mapHeight;
			Sym = sym;
		}

		public Point CreateFood()
		{
			int x = _random.Next(2, MapWidht - 2);
			int y = _random.Next(2, MapHeight - 2);
			return new Point(x, y, Sym);
		}
	}
}
