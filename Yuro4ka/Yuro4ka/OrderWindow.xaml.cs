using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Yuro4ka
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window, INotifyPropertyChanged
    {
        public OrderWindow(OrderList order)
        {
            InitializeComponent();
           CurrentService = order;
            DataContext = this;
        }
        public OrderList CurrentService { get; set; }

        public string WindowName
        {
            get
            {
                return CurrentService.Id == 0 ? "Новая услуга" : "Редактирование услуги";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

       
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentService.Total <= 0)
            {
                MessageBox.Show("Стоимость услуги должна быть больше нля");
                return;
            }
            if (CurrentService.Delivery =="")
            {
                MessageBox.Show("Не может быть пустым");
                return;
            }
            string Logos = CurrentService.Delivery;

            if (Logos == "Delivery" || Logos == "YandexFood" || Logos == "RadugaVkusa" || Logos == "Yin-Yan")
            {

                string sus="logo/" + Logos + ".png";
                CurrentService.Logo = sus;

            }
            else
            {
                MessageBox.Show("Выберите крьера из списка Delivery, YandexFood, RadugaVkusa, Yin-Yan");
                return;
            }

           

            var NumberOrder = CurrentService.Id;
            CurrentService.Number = NumberOrder;
           
            


            // если запись новая, то добавляем ее в список
            if (CurrentService.Id == 0)
                Core.DB.OrderList.Add(CurrentService);

            // сохранение в БД
            try
            {
                Core.DB.SaveChanges();
            }
            catch
            {
            }
            DialogResult = true;
        }
    }
}
