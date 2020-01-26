using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Player : Snake, IPlayer
    {
        public ObservableCollection<SnakePart> SnakeParts { get; set; }


        public Player()
        {
            this.Lenght = 0;
            this.Position.X = 0;
            this.Position.Y = 0;
            this.PosX = 250;
            SnakeParts = new ObservableCollection<SnakePart>
            {
                new SnakePart(new Vector2(0, 0), Direction.Right)
            };

        }

        public Vector2 GetPosition()
        {
            throw new NotImplementedException();
        }

        public Vector2 GetHeadPosition()
        {
            return SnakeParts[0].GetPosition();
        }

        public void AddSnakePart(Direction direction)
        {
            SnakeParts.Insert(0, (new SnakePart(SnakeParts.Last().GetPosition(), direction)));
        }
        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    SnakeParts.First().PosX = SnakeParts.Last().PosX - 10f;
                    SnakeParts.First().PosY = SnakeParts.Last().PosY;

                    SnakeParts.Add(SnakeParts.First());
                    SnakeParts.RemoveAt(0);

                    break;
                case Direction.Right:
                    SnakeParts.First().PosX = SnakeParts.Last().PosX + 10f;
                    SnakeParts.First().PosY = SnakeParts.Last().PosY;

                    SnakeParts.Add(SnakeParts.First());
                    SnakeParts.RemoveAt(0);

                    break;
                case Direction.Up:
                    SnakeParts.First().PosX = SnakeParts.Last().PosX;
                    SnakeParts.First().PosY = SnakeParts.Last().PosY - 10f;

                    SnakeParts.Add(SnakeParts.First());
                    SnakeParts.RemoveAt(0);

                    break;
                case Direction.Down:
                    SnakeParts.First().PosX = SnakeParts.Last().PosX;
                    SnakeParts.First().PosY = SnakeParts.Last().PosY + 10f;

                    SnakeParts.Add(SnakeParts.First());
                    SnakeParts.RemoveAt(0);

                    break;
            }
        }

        public void SetPlayerPos(Vector2 position)
        {
            throw new NotImplementedException();
        }

    }
}
