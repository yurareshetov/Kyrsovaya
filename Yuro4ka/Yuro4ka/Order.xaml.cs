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
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Window, INotifyPropertyChanged
    {
        

        public Order()
        {
            InitializeComponent();
            this.DataContext = this;
            OrderList = Core.DB.OrderList.ToList();
        }

        private List<OrderList> _OrderList;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<OrderList> OrderList
        {
            get
            {
                return _OrderList;
            }
            set
            {
                _OrderList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("OrderList"));
                }
            }
        }

        private void AddSevice_Click(object sender, RoutedEventArgs e)
        {
            var NewService = new OrderList();

            var NewServiceWindow = new OrderWindow(NewService);
            if ((bool)NewServiceWindow.ShowDialog())
            {
                // список услуг нужно перечитать с сервера
                OrderList = Core.DB.OrderList.ToList();
                PropertyChanged(this, new PropertyChangedEventArgs("FilteredProductsCount"));
                PropertyChanged(this, new PropertyChangedEventArgs("ProductsCount"));
            }
        }

        private Boolean _IsAdminMode = false;



        // публичный геттер, который меняет текущий режим (Админ/не Админ)
        public Boolean IsAdminMode
        {
            get { return _IsAdminMode; }
            set
            {
                _IsAdminMode = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("AdminModeCaption"));
                    PropertyChanged(this, new PropertyChangedEventArgs("AdminVisibility"));
                }

            }
        }
        // этот геттер возвращает текст для кнопки в зависимости от текущего режима
        public string AdminModeCaption
        {
            get
            {
                if (IsAdminMode) return "Выйти из режима\nАдминистратора";
                return "Войти в режим\nАдминистратора";
            }
        }
        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            // если мы уже в режиме Администратора, то выходим из него 
            if (IsAdminMode) IsAdminMode = false;
            else
            {
                // создаем окно для ввода пароля
                var InputBox = new InputBoxWindow("Введите пароль Администратора");
                // и показываем его как диалог (модально)
                if ((bool)InputBox.ShowDialog())
                {
                    // если нажали кнопку "Ok", то включаем режим, если пароль введен верно
                    IsAdminMode = InputBox.InputText == "0000";
                }
            }
        }
        public string AdminVisibility
        {
            get
            {
                if (IsAdminMode) return "Visible";
                return "Collapsed";
            }
        }

        private void EdditButton_Click(object sender, RoutedEventArgs e)
        {
            var SelectedOrder = ProductListView.SelectedItem as OrderList;
            var EditOrderWindow = new OrderWindow(SelectedOrder);
            if ((bool)EditOrderWindow.ShowDialog())
            {
                PropertyChanged(this, new PropertyChangedEventArgs("OrderList"));
            }
        }

        private void DeletteButton_Click(object sender, RoutedEventArgs e)
        {
            var item = ProductListView.SelectedItem as OrderList;
            Core.DB.OrderList.Remove(item);
            Core.DB.SaveChanges();
            OrderList = Core.DB.OrderList.ToList();
        }
    }
}
