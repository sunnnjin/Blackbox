using System.Windows;

namespace Blackbox
{
    public enum Direction
    {
        DirTop,
        DirBottom,
        DirLeft,
        DirRight,
        DirTopLeft,
        DirTopRight,
        DirBottomLeft,
        DirBottomRight,
        DirCenter
    };

    public class Line
    {
        public Line() { }

        public Line(Point from, Point to)
        {
            From = from;
            To = to;
        }

        public Line(Line line)
        {
            From = line.From;
            To = line.To;
        }

        public Point From { get; set; }
        public Point To { get; set; }

        public Direction Dir()
        {
            if (From.X == To.X && From.Y > To.Y)
            {
                return Direction.DirTop;
            }
            else if (From.X == To.X && From.Y < To.Y)
            {
                return Direction.DirBottom;
            }
            else if (From.X > To.X && From.Y == To.Y)
            {
                return Direction.DirLeft;
            }
            else if (From.X < To.X && From.Y == To.Y)
            {
                return Direction.DirRight;
            }
            else if (From.X > To.X && From.Y > To.Y)
            {
                return Direction.DirTopLeft;
            }
            else if (From.X < To.X && From.Y < To.Y)
            {
                return Direction.DirBottomRight;
            }
            else if (From.X > To.X && From.Y < To.Y)
            {
                return Direction.DirBottomLeft;
            }
            else if (From.X < To.X && From.Y > To.Y)
            {
                return Direction.DirTopRight;
            }
            else
            {
                return Direction.DirCenter;
            }
        }
    }
}
