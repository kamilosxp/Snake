using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class SnakePart : INotifyPropertyChanged
    {
        protected Vector2 Position;
        private float _PosY, _PosX;

        public float PosY
        {
            get { return _PosY; }
            set
            {
                _PosY = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PosY"));
            }
        }

        public float PosX
        {
            get { return _PosX; }
            set
            {
                _PosX = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PosX"));
            }
        }
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public SnakePart(Vector2 lastItemPosition, Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                {
                    PosX = lastItemPosition.X + 10f;
                    PosY = lastItemPosition.Y;
                    break;
                }
                case Direction.Right:
                {
                    PosX = lastItemPosition.X - 10f;
                    PosY = lastItemPosition.Y;
                        break;
                }
                case Direction.Up:
                {
                    PosX = lastItemPosition.X;
                    PosY = lastItemPosition.Y - 10f;
                    break;
                }
                case Direction.Down:
                {
                    PosX = lastItemPosition.X;
                    PosY = lastItemPosition.Y + 10f;
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
            return new Vector2(PosX, PosY);
        }

        public void SetXPosition(float value)
        {
            PosX = value;
        }

        public void SetYPosition(float value)
        {
            PosY = value;
        }
    }
}
