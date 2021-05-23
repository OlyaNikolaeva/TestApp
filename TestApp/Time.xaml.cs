using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TestApp
{
    /// <summary>
    /// Логика взаимодействия для Time.xaml
    /// </summary>
    public partial class Time : Window
    {
        StaticPoint point = new StaticPoint();
        public Time(StaticPoint p)
        {
            InitializeComponent();

            point = p;
            var number = p.N;
            var grid = window1;

            ColumnDefinition column1 = new ColumnDefinition();
            grid.ColumnDefinitions.Add(column1);
            ColumnDefinition column2 = new ColumnDefinition();
            grid.ColumnDefinitions.Add(column2);
            ColumnDefinition column3 = new ColumnDefinition();
            grid.ColumnDefinitions.Add(column3);
            ColumnDefinition column4 = new ColumnDefinition();
            grid.ColumnDefinitions.Add(column4);

            for (int i = 0; i < number; i++)
            {
                RowDefinition rowDef1 = new RowDefinition();
                grid.RowDefinitions.Add(rowDef1);            

                var textBlock = new TextBlock
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Text = "Введите t" + i
                };
                Grid.SetRow(textBlock,i);
                Grid.SetColumn(textBlock, 0);
                grid.Children.Add(textBlock);

                var textBox1 = new TextBox
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Name = "t1"+i,
                    Width = 80,
                };
                Grid.SetRow(textBox1, i);
                Grid.SetColumn(textBox1,1);
                grid.Children.Add(textBox1);

                var textBox2 = new TextBox
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Name = "t2"+i,
                    Width = 80,

                };
                Grid.SetRow(textBox2, i);
                Grid.SetColumn(textBox2, 2);
                grid.Children.Add(textBox2);

                var textBox3 = new TextBox
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Name = "t3"+i,
                    Width = 80,

                };
                Grid.SetRow(textBox3, i);
                Grid.SetColumn(textBox3, 3);
                grid.Children.Add(textBox3);
            }
        }

        public void Result_Graph(object sender, RoutedEventArgs e)
        {
            var listT = new List<double[]>();
            var grid = window1.Children;
            double[] timeABC = new double[3];
            int i = 0;
            foreach (var element in grid)
            {
                if (element is TextBox)
                {
                    var w = double.Parse(((TextBox)element).Text);
                    timeABC[i] = w;
                    i++;
                    if (i == 3) { listT.Add(timeABC); timeABC=new double[3]; i = 0; }
                }
            }
            GetDis(point,listT);
        }

        public void GetDis(StaticPoint staticPoint, List<double[]> listDis)
        {
            List<double[]> allDist = new List<double[]>();
            double[] dist = new double[3];
            Distance distance = new Distance();
            for (int i = 0; i < listDis.Count; i++)
            {
                distance.TimeA= listDis[i][0];
                distance.TimeB = listDis[i][1];
                distance.TimeC = listDis[i][2];
                var d=distance.GetDis();
                var xy = GetX0Y0(staticPoint, d);
                allDist.Add(xy);
            }

            Result resultGraph = new Result(staticPoint,allDist);
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

            var y0 = (((p.X2 - p.X1) * ((Math.Pow(dist[1],v)) - (Math.Pow(dist[2],v)) + (Math.Pow(p.X3,v)) - (Math.Pow(p.X2,v)) + (Math.Pow(p.Y3,v)) - (Math.Pow(p.Y2,v)))) - ((p.X3 - p.X2) * ((Math.Pow(dist[0],v)) - (Math.Pow(dist[1],v)) + (Math.Pow(p.X2,v)) - (Math.Pow(p.X1,v)) + (Math.Pow(p.Y2,v)) - (Math.Pow(p.Y1,v))))) / (2 * ((p.X2 - p.X1) * (p.Y3 - p.Y2) - (p.X3 - p.X2) * (p.Y2 - p.Y1)));
            var x0 = ((Math.Pow(dist[0], v)) - (Math.Pow(dist[1], v)) - (Math.Pow(p.X1, v)) + (Math.Pow(p.X2, v)) - (Math.Pow(p.Y1, v)) + (Math.Pow(p.Y2, v)) - (2*y0 * (p.Y2 - p.Y1)))/(2*(p.X2-p.X1));
            var getxy = new DynamicPoint();
            getxy.X0 = x0;
            getxy.Y0 = y0;

            return getxy.GetDynamic();
        }
    }
}
