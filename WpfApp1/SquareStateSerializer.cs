using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace WpfApp1
{
    public class SquareStateSerializer
    {
        private static readonly string FileName = "squarestate.xml";
        private static readonly XmlSerializer Serializer = new XmlSerializer(typeof(Point));

        public static void SaveSquareState(Point state)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FileName))
                {
                    Serializer.Serialize(writer, state);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failure to maintain the status: {ex.Message}", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public static Point LoadSquareState()
        {
            if (File.Exists(FileName))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(FileName))
                    {
                        return (Point)Serializer.Deserialize(reader);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Mistake of the status upload: {ex.Message}", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            return new Point();
        }
    }
}
