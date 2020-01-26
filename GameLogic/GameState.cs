using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using GameLogic.helpers;

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
        private float _gameSpeed;

        public event PropertyChangedEventHandler PropertyChanged;

        public GameState()
        {
            _gameSpeed = Consts.GameSpeed;
            _gameTimer = new DispatcherTimer();
            _gameTimer.Tick += new EventHandler(Loop);

            _gameTimer.Interval = new TimeSpan((long)_gameSpeed);
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
                //Increase game speed every 3 points
                if (Points % 3 == 0)
                    _gameSpeed /= 1.2f;
                _gameTimer.Interval = new TimeSpan((long)_gameSpeed);
            }

            List<SnakePart> _snakePartsToColision = Player.SnakeParts.ToList();
            _snakePartsToColision.Remove(_snakePartsToColision.Last());

            if (Player.SnakeParts.Last().GetPosition().X < 0 || Player.SnakeParts.Last().GetPosition().X > 800 ||
                Player.SnakeParts.Last().GetPosition().Y < 0 || Player.SnakeParts.Last().GetPosition().Y > 470)
            {
                Restart();
            }

            foreach (var z in _snakePartsToColision)
            {
                if(Player.SnakeParts.Last().GetPosition() == z.GetPosition())
                    Restart();
            }



            Console.WriteLine(Player.GetHeadPosition().ToString());
            //Console.WriteLine("Test");
        }

        public void Restart()
        {
            _gameSpeed = Consts.GameSpeed;
            _gameTimer.Interval = new TimeSpan(Consts.GameSpeed);
            Bonus.ChangePosition();
            //Player.SnakeParts.Clear();
            //Player.SetPlayerPos(new Vector2(0,0));

            var test = Player.SnakeParts.Last();
            Player.SnakeParts.Clear();
            Player.SnakeParts.Insert(0, test);
            Player.SnakeParts.Last().SetXPosition(0);
            Player.SnakeParts.Last().SetYPosition(0);
            _direction = Direction.Right;

            Points = 0;
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
