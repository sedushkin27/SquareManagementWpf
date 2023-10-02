using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    [Serializable]
    public class SquareState
    {
        public Point Position { get; set; }

        public SquareState() 
        {
            Position = new Point();
        }
    }
}
