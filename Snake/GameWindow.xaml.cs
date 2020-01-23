using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GameLogic;

namespace Snake
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private GameState _game;
        public GameWindow()
        {
            InitializeComponent();

            _game = new GameState();

        }

        private void captureKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Left)
                _game.ChangeDirection(Direction.Left);
            else if(e.Key == Key.Right)
                _game.ChangeDirection(Direction.Right);
            else if(e.Key == Key.Up)
                _game.ChangeDirection(Direction.Up);
            else if(e.Key == Key.Down)
                _game.ChangeDirection(Direction.Down);

        }
    }
}
