using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    interface IState
    {
        void Initialize();
        void Update();
        void Exit();
    }
}
