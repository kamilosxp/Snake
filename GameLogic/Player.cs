using System;
using System.Collections.Generic;
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

        }

        public Player(int x, int y, int lenght = 0)
        {

        }

        public Vector2 GetPosition()
        {
            throw new NotImplementedException();
        }

        public void Move(Direction direction)
        {
            throw new NotImplementedException();
        }

        public void SetPlayerPos(Vector2 position)
        {
            throw new NotImplementedException();
        }
    }
}
