using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace GameLogic
{
    public class GameState : IState
    {
        private int _points;
        private DispatcherTimer _gameTimer;
        private Player _player;
        private Direction _direction;

        public GameState()
        {

            _gameTimer = new DispatcherTimer();
            _gameTimer.Tick += new EventHandler(Loop);

            _gameTimer.Interval = new TimeSpan(2000000);
            _gameTimer.Start();


            //Create player
            _player = new Player();
            _direction = Direction.Right;

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
            _player.Move(_direction);
            Console.WriteLine(_player.GetHeadPosition().ToString());
            Console.WriteLine("Test");
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
