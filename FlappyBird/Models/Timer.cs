using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace FlappyBird.Models
{
    public class Timer
    {
        private DispatcherTimer gameTimer = new DispatcherTimer();

        public DispatcherTimer GameTimer()
        {
            return gameTimer;
        }
        public Timer()
        {
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
        }
    }
}
