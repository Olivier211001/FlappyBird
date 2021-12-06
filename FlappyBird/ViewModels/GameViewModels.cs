using FlappyBird.Commands;
using FlappyBird.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FlappyBird.ViewModels
{
    public class GameViewModels
    {      
        private ObjectManager objectManager = ObjectManager.Instance;

        private Timer timer = new Timer();

        private double score = 0;

        private Rect flappyBirdHitBox; //diagram

        private float totalTime = 0;

        public ICommand PlayCommand { get; set; }

        public Timer getTimer()
        {
            return timer;
        }

        public double getScore()
        {
            return score;
        }

        public float getTotalTime()
        {
            return totalTime;
        }

        public GameViewModels()
        {
            timer.GameTimer().Tick += MainEventTimer;
            PlayCommand = new PlayCommand(ExecuteMethod, CanExecuteMethod);
        }

        private bool CanExecuteMethod(object arg)
        {
            return true;
        }

        private void ExecuteMethod(object obj)
        {
            StartGame();
        }
        ///////////////////////////////////////////////////////////////////////
        ///Game Loop 
        private void MainEventTimer(object sender, EventArgs e)
        {
            TimerRunDisplay();
            objectManager.txtScore.Content = "score : " + score + " pts";
            flappyBirdHitBox = new Rect(Canvas.GetLeft(objectManager.flappyBird), Canvas.GetTop(objectManager.flappyBird), objectManager.flappyBird.Width - 5, objectManager.flappyBird.Height);
            Canvas.SetTop(objectManager.flappyBird, Canvas.GetTop(objectManager.flappyBird) + MainWindow.gravity);
            if (Canvas.GetTop(objectManager.flappyBird) < -10 || Canvas.GetTop(objectManager.flappyBird) > 458)
            {   
                EndGame();
            }
            SetMap();
        }
        ///Game Loop
        ///////////////////////////////////////////////////////////////////////

        private void SetMap()
        {
            foreach (var x in objectManager.MyCanvas.Children.OfType<Image>())
            {
                if ((string)x.Tag == "obs1" || (string)x.Tag == "obs2" || (string)x.Tag == "obs3")
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 5);
                    if (Canvas.GetLeft(x) < -100)
                    {
                        Canvas.SetLeft(x, 800);
                        score += .5;
                    }
                    Rect pipeHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                    if (flappyBirdHitBox.IntersectsWith(pipeHitBox))
                    {
                        EndGame();
                    }
                }
                if ((string)x.Tag == "cloud")
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 2);
                    if (Canvas.GetLeft(x) < -250)
                    {
                        Canvas.SetLeft(x, 550);
                    }
                }
            }
        }
        private void TimerRunDisplay()
        {
            totalTime += ((float)timer.GameTimer().Interval.TotalSeconds);  // ajout 
            objectManager.txtTimer.Content = "Timer : " + totalTime.ToString("0.00") + " secs"; // ajout 
            if (totalTime > 5)
            {

                objectManager.txtTimer.Foreground = new SolidColorBrush(Colors.Blue); // ajout

            }
            if (totalTime > 10)
            {
                objectManager.txtTimer.Foreground = new SolidColorBrush(Colors.Red); // ajout
            }
        }
        private void StartGame()
        {
            objectManager.Play.Visibility = Visibility.Hidden;  
            objectManager.MyCanvas.Focus();
            int temp = 300;
            score = 0;
            Canvas.SetTop(objectManager.flappyBird, 190);
            foreach (var x in objectManager.MyCanvas.Children.OfType<Image>())
            {
                if ((string)x.Tag == "obs1")
                {
                    Canvas.SetLeft(x, 500);
                }
                if ((string)x.Tag == "obs2")
                {
                    Canvas.SetLeft(x, 800);
                }
                if ((string)x.Tag == "obs3")
                {
                    Canvas.SetLeft(x, 1100);
                }
                if ((string)x.Tag == "cloud")
                {
                    Canvas.SetLeft(x, 300 + temp);
                    temp = 800;
                }
            }
            timer.GameTimer().Start();
        }
        private void EndGame()
        {
            objectManager.txtTimer.Foreground = new SolidColorBrush(Colors.Black);
            timer.GameTimer().Stop();
            objectManager.MyCanvas.Background = new SolidColorBrush(Colors.Black);
            MessageBoxImage icon = MessageBoxImage.Exclamation;
            MessageBoxResult result = MessageBox.Show("Your score : " + score.ToString() + " pts      Your time : " + totalTime.ToString("0.00") + " secs", "Game Over", MessageBoxButton.YesNo, icon); // ajout 
            totalTime = 0;
            switch (result)
            {
                case MessageBoxResult.Yes:
                    objectManager.MyCanvas.Background = new SolidColorBrush(Colors.LightBlue);
                    StartGame();
                    break;
                case MessageBoxResult.No:
                    //Close();
                    System.Windows.Application.Current.Shutdown();
                    break;
            }
        }
    }
}
