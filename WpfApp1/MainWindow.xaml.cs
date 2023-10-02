using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Xml.Serialization;

namespace WpfApp1
{

    public partial class MainWindow : Window
    {
        const double step = 10;
        private SquareState squareState = new SquareState();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            squareState = SquareStateSerializer.LoadSquareState();

            if (squareState != null)
            {
               square.Margin = new Thickness(squareState.Position.X, squareState.Position.Y, 0, 0);
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.A:
                    square.Margin = new Thickness(square.Margin.Left - step, square.Margin.Top, 0, 0);
                    break;
                case Key.D:
                    square.Margin = new Thickness(square.Margin.Left + step, square.Margin.Top, 0, 0);
                    break;
                case Key.W:
                    square.Margin = new Thickness(square.Margin.Left, square.Margin.Top - step, 0, 0);
                    break;
                case Key.S:
                    square.Margin = new Thickness(square.Margin.Left, square.Margin.Top + step, 0, 0);
                    break;
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            squareState.Position = new Point(square.Margin.Left, square.Margin.Top);
            SquareStateSerializer.SaveSquareState(squareState);
        }
    }
}
