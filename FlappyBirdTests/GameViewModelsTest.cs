using FlappyBird.ViewModels;
using System;
using System.Windows.Input;
using Xunit;

namespace FlappyBirdTests
{
    public class GameViewModelsTest
    {
        [Fact]
        public void timerTick_ShouldBeEqualMainEventTimer()
        {
            GameViewModels gmv = new GameViewModels();

            gmv.PlayCommand.Execute(string.Empty);

    
        }
    }
}
