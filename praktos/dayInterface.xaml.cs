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

namespace praktos
{
    /// <summary>
    /// Логика взаимодействия для dayInterface.xaml
    /// </summary>
    public partial class dayInterface : UserControl
    {
        public DateTime date;
        public int index;
        public dayInterface(DateTime date, int index, int firstID)
        {
            InitializeComponent();
            switch (firstID)
            {
                case 0:
                    break;
                case 1:
                    image.Source = (new ImageSourceConverter().ConvertFromString("resources\\beg.png") as ImageSource);
                    break;
                case 2:
                    image.Source = (new ImageSourceConverter().ConvertFromString("resources\\Gym.png") as ImageSource);
                    break;
                case 3:
                    image.Source = (new ImageSourceConverter().ConvertFromString("resources\\swim.png") as ImageSource);
                    break;
                case 4:
                    image.Source = (new ImageSourceConverter().ConvertFromString("resources\\sleep.png") as ImageSource);
                    break;
                default:
                    break;
            }
            this.date = date;
            this.index = index;
        }

        private void open_dayInfo_Click(object sender, RoutedEventArgs e)
        {
            DayWindow DW = new DayWindow(date, index);
            DW.Show();
        }
    }
}
