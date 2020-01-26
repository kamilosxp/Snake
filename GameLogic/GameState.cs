using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace GameLogic
{
    public class GameState : IState, INotifyPropertyChanged
    {
        private int _points;

        public float Points
        {
            get { return _points; }
            set
            {
                _points = (int)value;
                OnPropertyChanged(new PropertyChangedEventArgs("Points"));
            }
        }

        private DispatcherTimer _gameTimer;
        public Player Player { get; set; }
        public Bonus Bonus { get; set; }
        private Direction _direction;

        public event PropertyChangedEventHandler PropertyChanged;

        public GameState()
        {

            _gameTimer = new DispatcherTimer();
            _gameTimer.Tick += new EventHandler(Loop);

            _gameTimer.Interval = new TimeSpan(200000);
            _gameTimer.Start();


            //Create player
            Player = new Player();
            _direction = Direction.Right;

            this.Bonus = new Bonus();
            Points = 0;

        }
        public void Exit()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            Player.Move(_direction);
            if (Player.SnakeParts.Last().GetPosition() == Bonus.GetBonusPosition())
            {
                Bonus.ChangePosition();
                Player.AddSnakePart(_direction);
                Points++;
            }

            //Console.WriteLine(Player.GetHeadPosition().ToString());
            //Console.WriteLine("Test");
        }

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        public void Loop(object sender, EventArgs e)
        {
            Update();

        }

        public void ChangeDirection(Direction direction)
        {
            Console.WriteLine("Changed Direciton");
            _direction = direction;
        }
    }
}
