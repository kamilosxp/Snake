using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Bonus : INotifyPropertyChanged
    {
        private float _PosY, _PosX;

        public float BonusPosY
        {
            get { return _PosY; }
            set
            {
                _PosY = value;
                OnPropertyChanged(new PropertyChangedEventArgs("BonusPosY"));
            }
        }

        public float BonusPosX
        {
            get { return _PosX; }
            set
            {
                _PosX = value;
                OnPropertyChanged(new PropertyChangedEventArgs("BonusPosX"));
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


        public Bonus()
        {
            ChangePosition();
        }

        public Vector2 GetBonusPosition()
        {
            return new Vector2(BonusPosX, BonusPosY);
        }
        public void ChangePosition()
        {
            Random random = new Random();

            BonusPosY = random.Next(0, 52) * 10;
            BonusPosX = random.Next(0, 80) * 10;

            Console.WriteLine($"{BonusPosX}  {BonusPosY}");
        }
    }
}
