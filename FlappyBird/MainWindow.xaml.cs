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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Timers;

namespace FlappyBird
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer();

        double score = 0;
        int gravity = 8;
        Rect flappyBirdHitBox;
        public MainWindow()
        {
            InitializeComponent();

            gameTimer.Tick += MainEventTimer;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            
            StartGame();
        }
        float totalTime = 0;
        private void MainEventTimer(object sender, EventArgs e)
        {
            totalTime += ((float)gameTimer.Interval.TotalSeconds);  // ajout 
            txtTimer.Content = "Timer : " + totalTime.ToString("0.00") + " secs"; // ajout 
            if(totalTime > 5)
            {
                txtTimer.Foreground = new SolidColorBrush(Colors.Blue);

            }
            if(totalTime > 10)
            {
                txtTimer.Foreground = new SolidColorBrush(Colors.Red);
            }
            txtScore.Content = "score : " + score + " pts";
            flappyBirdHitBox = new Rect(Canvas.GetLeft(flappyBird), Canvas.GetTop(flappyBird), flappyBird.Width -5 , flappyBird.Height);
            Canvas.SetTop(flappyBird, Canvas.GetTop(flappyBird) + gravity);
            if(Canvas.GetTop(flappyBird) < -10 || Canvas.GetTop(flappyBird) > 458)
            {
                EndGame();
            }
            foreach(var x in MyCanvas.Children.OfType<Image>())
            {
                if((string)x.Tag == "obs1" || (string)x.Tag == "obs2" || (string)x.Tag == "obs3")
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 5);
                    if(Canvas.GetLeft(x) < -100)
                    {
                        Canvas.SetLeft(x, 800);
                        score += .5;
                    }
                    Rect pipeHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                    if(flappyBirdHitBox.IntersectsWith(pipeHitBox))
                    {
                        EndGame();
                    }
                }
                if((string)x.Tag == "cloud")
                {
                    Canvas.SetLeft(x, Canvas.GetLeft(x) - 2);
                    if(Canvas.GetLeft(x) < -250)
                    {
                        Canvas.SetLeft(x, 550);
                    }
                }
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                flappyBird.RenderTransform = new RotateTransform(-20, flappyBird.Width / 2, flappyBird.Height / 2);
                gravity = -8;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            flappyBird.RenderTransform = new RotateTransform(5, flappyBird.Width / 2, flappyBird.Height / 2);
            gravity = 8;
        }

        private void StartGame()
        {
            MyCanvas.Focus();
            int temp = 300;
            score = 0;
            Canvas.SetTop(flappyBird, 190);
            foreach(var x in MyCanvas.Children.OfType<Image>())
            {
                if((string)x.Tag == "obs1")
                {
                    Canvas.SetLeft(x, 500);
                }
                if((string)x.Tag == "obs2")
                {
                    Canvas.SetLeft(x, 800);
                }
                if((string)x.Tag == "obs3")
                {
                    Canvas.SetLeft(x, 1100);
                }
                if((string)x.Tag == "cloud")
                {
                    Canvas.SetLeft(x, 300 + temp);
                    temp = 800;
                }
            }
            gameTimer.Start();
        }

        private void EndGame() 
        {
            txtTimer.Foreground = new SolidColorBrush(Colors.Black);
            gameTimer.Stop();
            MyCanvas.Background = new SolidColorBrush(Colors.Black);
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxResult result = MessageBox.Show("Your score : " + score.ToString() + " pts      Your time : " + totalTime.ToString("0.00") + " secs", "Game Over", MessageBoxButton.YesNo, icon); // ajout 
            totalTime = 0;
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MyCanvas.Background = new SolidColorBrush(Colors.LightBlue);
                    StartGame();
                    break;
                case MessageBoxResult.No:
                    Close();
                    break;
            }
        }      
    }
}
