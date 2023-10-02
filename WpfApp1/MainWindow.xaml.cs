using System;
using System.Collections.Generic;
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
        private const string SaveFiveName = "squarestate.xml";
        private SquareState squareState;

        public MainWindow()
        {
            InitializeComponent();

            squareState = LoadSquareSatate();

            if (squareState != null ) { square.Margin = new Thickness(squareState.Left, squareState.Top, 0, 0); }
            else { squareState = new SquareState(); }

            KeyDown += MainWindow_KeyDown;
            Closing += MainWindow_Closing;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            double step = 10;

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
            squareState.Left = square.Margin.Left;
            squareState.Top = square.Margin.Top;

            SaveSquareState(squareState);
        }

        private void SaveSquareState(SquareState state) 
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SquareState));

                using (StreamWriter writer = new StreamWriter(SaveFiveName))
                {
                    serializer.Serialize(writer, state);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failure to maintain the status: {ex.Message}", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private SquareState LoadSquareSatate()
        {
            if (File.Exists(SaveFiveName))
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(SquareState));

                    using (StreamReader reader = new StreamReader(SaveFiveName))
                    {
                        return (SquareState)serializer.Deserialize(reader);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Mistake of the status upload: {ex.Message}", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            return null;
        }
    }
}
