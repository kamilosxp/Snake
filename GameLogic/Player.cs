using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    class Player : Snake, IPlayer  
    {
        public Player()
        {
            this.Lenght = 0;
            this.Position.X = 0;
            this.Position.Y = 0;
            SnakeParts = new List<SnakePart>
            {
                new SnakePart(new Vector2(0, 0), Direction.Right)
            };

        }

        public Player(int x = 0, int y = 0, int lenght = 0)
        {
            this.Lenght = lenght;
            this.Position.X = x;
            this.Position.Y = y;

        }

        public Vector2 GetPosition()
        {
            throw new NotImplementedException();
        }

        public Vector2 GetHeadPosition()
        {
            return SnakeParts[0].GetPosition();
        }
        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    foreach (var part in SnakeParts)
                    {
                        part.SetXPosition(part.GetPosition().X - 30f);
                    }
                    break;
                case Direction.Right:
                    foreach (var part in SnakeParts)
                    {
                        part.SetXPosition(part.GetPosition().X + 30f);
                    }
                    break;
                case Direction.Up:
                    foreach (var part in SnakeParts)
                    {
                        part.SetYPosition(part.GetPosition().Y - 30f);
                    }
                    break;
                case Direction.Down:
                    foreach (var part in SnakeParts)
                    {
                        part.SetYPosition(part.GetPosition().Y + 30f);
                    }
                    break;
            }
        }

        public void SetPlayerPos(Vector2 position)
        {
            throw new NotImplementedException();
        }
    }
}
