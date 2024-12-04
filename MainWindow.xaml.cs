using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PaintApp
{
    public partial class MainWindow : Window
    {
        private Point currentPosition;
        private double penSize = 4;
        private Brush penColor = Brushes.Black;
        private string mode = "Free Draw";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            DrawingCanvas.Children.Clear();
        }

        private void BrushSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BrushSizeComboBox.SelectedItem is ComboBoxItem selectedItem)
            {

                switch (selectedItem.Content.ToString())
                {
                    case "2":
                        penSize = 2; 
                        break;
                    case "4":
                        penSize = 4; 
                        break;
                    case "6":
                        penSize = 6; 
                        break;
                    case "8":
                        penSize = 8; 
                        break;
                    case "10":
                        penSize = 10;
                        break;
                }
            }
        }

        private void BrushColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BrushColorComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
               
                switch (selectedItem.Content.ToString())
                {
                    case "Red":
                        penColor = Brushes.Red;
                        break;
                    case "Blue":
                        penColor = Brushes.Blue;
                        break;
                    case "Green":
                        penColor = Brushes.Green;
                        break;
                    case "Black":
                        penColor = Brushes.Black;
                        break;
                }
            }
        }

        private void DrawingModeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DrawingModeComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                mode = selectedItem.Content.ToString(); 
            }
        }

        private void CanvasMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPosition = e.GetPosition(DrawingCanvas);
        }

        private void CanvasMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (mode == "Free Draw")
                {
                    Line line = new Line
                    {
                        Stroke = penColor,
                        StrokeThickness = penSize,
                        X1 = currentPosition.X,
                        Y1 = currentPosition.Y,
                        X2 = e.GetPosition(DrawingCanvas).X,
                        Y2 = e.GetPosition(DrawingCanvas).Y
                    };

                    currentPosition = e.GetPosition(DrawingCanvas);

                    DrawingCanvas.Children.Add(line);
                }
                else if (mode == "Straight Line")
                {
                    Line line = new Line
                    {
                        Stroke = penColor,
                        StrokeThickness = penSize,
                        X1 = currentPosition.X,
                        Y1 = currentPosition.Y,
                        X2 = e.GetPosition(DrawingCanvas).X,
                        Y2 = e.GetPosition(DrawingCanvas).Y
                    };

                    DrawingCanvas.Children.Clear();
                    DrawingCanvas.Children.Add(line);
                }
            }
        }
    }
}
