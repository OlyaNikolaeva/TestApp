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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>  
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }
        public StaticPoint poin = new StaticPoint();
        public void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            var n = int.Parse(tranNumber.Text);
            var x1 = double.Parse(firstX.Text);
            var y1 = double.Parse(firstY.Text);
            var x2 = double.Parse(secondX.Text);
            var y2 = double.Parse(secondY.Text);
            var x3 = double.Parse(thirdX.Text);
            var y3 = double.Parse(thirdY.Text);

            if (n < 0)
            {
                tranNumber.ToolTip = "Нет измерений";
                tranNumber.Background = Brushes.DarkRed;
            }
            else
            {
                tranNumber.ToolTip = "";
                tranNumber.Background = Brushes.Transparent;
            }

            poin = new StaticPoint(n, x1, y1, x2, y2, x3, y3);
            
            Time time = new Time(poin);
            time.Show();
            Hide();
        }

    }
}
