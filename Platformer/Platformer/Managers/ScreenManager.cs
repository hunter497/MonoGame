using Platformer.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Managers
{
    public class ScreenManager
    {
        Dictionary<string, GameScreen> screens = new Dictionary<string, GameScreen>();

        Stack<GameScreen> screenStack = new Stack<GameScreen>();
    }
}
