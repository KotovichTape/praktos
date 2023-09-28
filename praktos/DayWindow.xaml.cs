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
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace praktos
{
    /// <summary>
    /// Логика взаимодействия для DayWindow.xaml
    /// </summary>
    public partial class DayWindow : Window
    {
        private DateTime date;
        private bool FirstInitial = true;
        private int index_;

        public DayWindow(DateTime date, int index_)
        {
            InitializeComponent();
            List<string> chosen = new List<string>();
            this.date = date;
            this.index_ = index_;
            List<Data> data = JSONconv.getInfo<List<Data>>("D:\\data.json");
            if (data != null)
            {
                foreach (Data dataItem in data)
                {
                    if (dataItem.date.Month == date.Month && dataItem.Index == index_)
                    {
                        chosen = dataItem.chosedPositions;
                        FirstInitial = false;
                        break;
                    }
                }
            }
            if (FirstInitial)
            {
                Init();
            }
            else
            {
                Init(chosen);
            }

              
        }

        private List<CheckBoxWithImage> InitCreate()
        {
            List<CheckBoxWithImage> list = new List<CheckBoxWithImage>();
            CheckBoxWithImage cb1 = new CheckBoxWithImage();
            CheckBoxWithImage cb2 = new CheckBoxWithImage();
            CheckBoxWithImage cb3 = new CheckBoxWithImage();
            CheckBoxWithImage cb4 = new CheckBoxWithImage();
            cb1.check_box.Content = "Бегал";
            cb2.check_box.Content = "Занимался в зале";
            cb3.check_box.Content = "Плавал";
            cb4.check_box.Content = "Спал";
            cb1.ImageSet.Source = (new ImageSourceConverter().ConvertFromString("resources\\beg.png") as ImageSource);
            cb2.ImageSet.Source = (new ImageSourceConverter().ConvertFromString("resources\\Gym.png") as ImageSource);
            cb3.ImageSet.Source = (new ImageSourceConverter().ConvertFromString("resources\\swim.png") as ImageSource);
            cb4.ImageSet.Source = (new ImageSourceConverter().ConvertFromString("resources\\sleep.png") as ImageSource);
            list.Add(cb1);
            list.Add(cb2);
            list.Add(cb3);
            list.Add(cb4);
            return list;
        }
        private void Init()
        {
            
            Items.ItemsSource = InitCreate();
        }
        private void Init(List<string> chosenparams)
        {
            var list = InitCreate();
            foreach (CheckBoxWithImage item in list)
            {
                foreach (string item2 in chosenparams)
                {
                    if (item.check_box.Content.ToString() == item2)
                    {
                        item.check_box.IsChecked = true;
                    }
                }
            }
            Items.ItemsSource = list;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            List<string> checked_ob = new List<string>();
            foreach(CheckBoxWithImage item in Items.Items)
            {
                if (item.check_box.IsChecked == true)
                {
                    checked_ob.Add(item.check_box.Content.ToString());
                }
            }
            Data _data = new Data(checked_ob, date, index_);
            List<Data> data = JSONconv.getInfo<List<Data>>("D:\\data.json");
            bool isChecked = false;
            if (data != null)
            {
                for(int i = 0; i < data.Count; i++)
                {
                    if (data[i].date.Month == date.Month && data[i].Index == index_)
                    {
                        data.RemoveAt(i);
                        data.Insert(i, _data);
                        isChecked = true;
                        break;
                    }
                }
                if (isChecked)
                {
                    JSONconv.saveInfo("D:\\data.json", data);
                }
                else
                {
                    data.Add(_data);
                    JSONconv.saveInfo("D:\\data.json", data);
                }
            }
            else
            {
                List<Data> data__ = new List<Data>();
                data__.Add(_data);
                JSONconv.saveInfo("D:\\data.json", data__);
                Close();
            }
            Close();
        }
    }
}
