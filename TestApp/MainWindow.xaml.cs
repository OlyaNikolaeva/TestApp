using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace TestApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>  
    public partial class MainWindow : Window
    {
        public StaticPoint points = new StaticPoint();
        public Distance distances = new Distance();
        public List<double[]> allDist = new List<double[]>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var i = 1;
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            Nullable<bool> result = openFileDlg.ShowDialog();

            if (result == true)
            {
                var file = System.IO.File.ReadAllText(openFileDlg.FileName);
                System.IO.StringReader reader = new System.IO.StringReader(file);
                string[] lines = File.ReadAllLines(openFileDlg.FileName);

                FileNameTextBox.Text = openFileDlg.FileName;
                TextBlock1.Text = file;

                foreach (var line in lines)
                {
                    if (i == 1)
                    {
                        string[] coords = line.Split(',');
                        points.X1 = double.Parse(coords[0], CultureInfo.InvariantCulture);
                        points.Y1 = double.Parse(coords[1], CultureInfo.InvariantCulture);
                        points.X2 = double.Parse(coords[2], CultureInfo.InvariantCulture);
                        points.Y2 = double.Parse(coords[3], CultureInfo.InvariantCulture);
                        points.X3 = double.Parse(coords[4], CultureInfo.InvariantCulture);
                        points.Y3 = double.Parse(coords[5], CultureInfo.InvariantCulture);
                        i++;
                    }
                    else
                    {
                        string[] times = line.Split(',');
                        distances.TimeA = double.Parse(times[0], CultureInfo.InvariantCulture);
                        distances.TimeB = double.Parse(times[1], CultureInfo.InvariantCulture);
                        distances.TimeC = double.Parse(times[2], CultureInfo.InvariantCulture);
                        var d = distances.GetDis();
                        var xy = GetX0Y0(points, d);
                        allDist.Add(xy);
                    }
                }

                var buttonResult = new Button
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Content = "Result",
                    Margin = new Thickness(10, 280, 10, 10)
                };
                buttonResult.Click += Button_Click;
                startGrid.Children.Add(buttonResult);

            }
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Result resultGraph = new Result(points, allDist);
            resultGraph.Show();
            Hide();
        }

        public double[] GetX0Y0(StaticPoint p, double[] dist)
        {
            int v = 2;
            //решена система уравнения:
            //d1^2=(x1-x0)^2+(y1-y0)^2
            //d2^2=(x2-x0)^2+(y2-y0)^2
            //d3^2=(x3-x0)^2+(y3-y0)^2

            var x0 = (((p.Y2 - p.Y1) * ((dist[1]*dist[1]) - (dist[2]*dist[2]) + (p.X3*p.X3) - (p.X2*p.X2) + (p.Y3*p.Y3) - (p.Y2*p.Y2))) - ((p.Y3 - p.Y2) * ((dist[0]*dist[0]) - (dist[1]*dist[1]) + (p.X2*p.X2) - (p.X1*p.X1) + (p.Y2*p.Y2) - (p.Y1*p.Y1)))) / (2 * ((p.X1 - p.X2) * (p.Y3 - p.Y2) + (p.X3 - p.X2) * (p.Y2 - p.Y1)));
            var y0 = ((Math.Pow(dist[0], v)) - (Math.Pow(dist[1], v)) - (Math.Pow(p.X1, v)) + (Math.Pow(p.X2, v)) - (Math.Pow(p.Y1, v)) + (Math.Pow(p.Y2, v)) - (2 * x0 * p.X2)+ (2 * x0 * p.X1)) / (2 * (p.Y2 - p.Y1));
            var getxy = new DynamicPoint();
            getxy.X0 = Math.Round(x0*0.95 , 8);
            getxy.Y0 = Math.Round(y0*0.95, 8);

            return getxy.GetDynamic();
        }
    }
}
