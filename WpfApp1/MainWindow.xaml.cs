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
        const double Step = 10;
        private Point squareState;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                squareState = SquareStateSerializer.LoadSquareState();
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Mistake of the status upload: {ex.Message}", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (squareState != null)
            {
               square.Margin = new Thickness(squareState.X, squareState.Y, 0, 0);
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.A:
                    square.Margin = new Thickness(square.Margin.Left - Step, square.Margin.Top, 0, 0);
                    break;
                case Key.D:
                    square.Margin = new Thickness(square.Margin.Left + Step, square.Margin.Top, 0, 0);
                    break;
                case Key.W:
                    square.Margin = new Thickness(square.Margin.Left, square.Margin.Top - Step, 0, 0);
                    break;
                case Key.S:
                    square.Margin = new Thickness(square.Margin.Left, square.Margin.Top + Step, 0, 0);
                    break;
            }
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            squareState = new Point(square.Margin.Left, square.Margin.Top);
            try
            {
                SquareStateSerializer.SaveSquareState(squareState);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failure to maintain the status: {ex.Message}", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
