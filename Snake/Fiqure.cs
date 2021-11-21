using System.Collections.Generic;

namespace Snake
{
    class Figure
    {
        protected List<Point> pList;

        public void Draw()
        {
            foreach (Point point in pList)
            {
                point.Draw();
            }
        }

        internal bool IsHit(Figure figure) // ходим, смотрим не пересекаются ли точки, в параметр передаем фигуру(полиморфизм)
        {
            foreach (var point in pList)
            {
                if (figure.IsHit(point))
                    return true;
            }
            return false;
        }

        private bool IsHit(Point point) // ходим, смотрим не пересекаются ли точки, в параметр передаем точку(полиморфизм)
        {
            foreach (var p in pList)
            {
                if (p.IsHit(point))
                    return true;
            }
            return false;
        }
    }
}
