using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    class SnakePart
    {
        protected Vector2 Position;

        public SnakePart(Vector2 lastItemPosition, Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                {
                    Position.X = lastItemPosition.X + 30f;
                    Position.Y = lastItemPosition.Y;
                    break;
                }
                case Direction.Right:
                {
                    Position.X = lastItemPosition.X + 30f;
                    Position.Y = lastItemPosition.Y;
                    break;
                }
                default:
                {
                    Position.X = 0f;
                    Position.Y = 0f;
                    break;
                }
            }
        }

        public Vector2 GetPosition()
        {
            return Position;
        }

        public void SetXPosition(float value)
        {
            Position.X = value;
        }

        public void SetYPosition(float value)
        {
            Position.Y = value;
        }
    }
}
