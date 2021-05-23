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
using System.Windows.Shapes;

namespace TestApp
{
    /// <summary>
    /// Логика взаимодействия для Result.xaml
    /// </summary>
    public partial class Result : Window
    {
        public Result(StaticPoint stPoint, List<double[]> listDist)
        {
            InitializeComponent();
            DrawStaticPoint(stPoint);
            var i = 0;
            foreach(var el in listDist)
            {
                DrawDynamicPoint(el,i);
                i++;
            }
        }

        public void DrawStaticPoint(StaticPoint p)
        {
            Ellipse elipsA = new Ellipse();
            elipsA.Stroke = Brushes.Gray;
            elipsA.Width = 30;
            elipsA.Height = 30;
            Canvas.SetLeft(elipsA, (p.X1*(-1))*10 + 250-elipsA.Width/2);
            Canvas.SetTop(elipsA, p.Y1*10 + 250-elipsA.Height/2);
            canvas.Children.Add(elipsA);

            Ellipse elipsB = new Ellipse();
            elipsB.Stroke = Brushes.Gray;
            elipsB.Width = 30;
            elipsB.Height = 30;
            
            Canvas.SetLeft(elipsB, (p.X2*(-1))*10 + 250-elipsB.Width/2);
            Canvas.SetTop(elipsB, p.Y2*10 + 250-elipsB.Height/2);
            canvas.Children.Add(elipsB);

            Ellipse elipsC = new Ellipse();
            elipsC.Stroke = Brushes.Gray;
            elipsC.Width = 30;
            elipsC.Height = 30;
            Canvas.SetLeft(elipsC, (p.X3*(-1))*10 + 250-elipsC.Width/2);
            Canvas.SetTop(elipsC, p.Y3*10 + 250-elipsC.Height/2);
            canvas.Children.Add(elipsC);
        }

        public void DrawDynamicPoint(double[] d,int i)
        {
            Ellipse elipsXY = new Ellipse();
            elipsXY.Stroke = Brushes.Red;
            elipsXY.Width = 30;
            elipsXY.Height = 30;
            Canvas.SetLeft(elipsXY, (d[0] * (-1)) * 10 + 250 - elipsXY.Width / 2);
            Canvas.SetTop(elipsXY, d[1] * 10 + 250 - elipsXY.Height / 2);
            canvas.Children.Add(elipsXY);

            RowDefinition rowDef1 = new RowDefinition();
            textGrid.RowDefinitions.Add(rowDef1);
            var textBlock = new TextBlock
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(0,0,0,0),
                TextWrapping = TextWrapping.Wrap,
                Text = " X0:" + d[0]+ "  Y0:" + d[1]
            };
            Grid.SetRow(textBlock, i);
            textGrid.Children.Add(textBlock);
        }
    }
}
