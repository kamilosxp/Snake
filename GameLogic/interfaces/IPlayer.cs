using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    interface IPlayer
    {
        void Move(Direction direction);
        Vector2 GetPosition();
        void SetPlayerPos(Vector2 position);
    }
}
