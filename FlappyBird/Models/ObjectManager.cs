using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FlappyBird.Models
{
    public class ObjectManager
    {
        public Label txtScore { get; set; }

        public Image flappyBird { get; set; }

        public Label txtTimer { get; set; }

        public Canvas MyCanvas { get; set; }

        public int gravity { get; set; }

        public Button Play { get; set; }

        private static ObjectManager instance = null;
        public static ObjectManager Instance 
        {
            get
            {
                if (instance == null)
                    instance = new ObjectManager();
                return instance;
            }           
        }
    }
}
