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
using FlappyBird.Models;
using FlappyBird.ViewModels;

namespace FlappyBird
{
    public partial class MainWindow : Window
    {
        private ObjectManager objectManager = ObjectManager.Instance;

        private GameViewModels gmv;

        public static int gravity = 8;
        public MainWindow()
        {
            InitializeComponent();

            objectManager.txtScore = txtScore;
            objectManager.txtTimer = txtTimer;
            objectManager.flappyBird = flappyBird;
            objectManager.MyCanvas = MyCanvas;
            objectManager.Play = Play;
            gmv = new GameViewModels();

            DataContext = gmv;
        }
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                objectManager.flappyBird.RenderTransform = new RotateTransform(-20, objectManager.flappyBird.Width / 2, objectManager.flappyBird.Height / 2);
                gravity = -8;
            }
        }
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            objectManager.flappyBird.RenderTransform = new RotateTransform(5, objectManager.flappyBird.Width / 2, objectManager.flappyBird.Height / 2);
            gravity = 8;
        }

    }
}
