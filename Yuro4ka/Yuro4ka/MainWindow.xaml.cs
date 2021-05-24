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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Yuro4ka
{
    public partial class Product
    {
        
        public Uri ImagePreview
        {
            get
            {
                var imageName = System.IO.Path.Combine(Environment.CurrentDirectory, Photo ?? "");
                return System.IO.File.Exists(imageName) ? new Uri(imageName) : new Uri("pack://application:,,,/img/picture.png");
            }
        }
        public float DiscountFloat
        {
            get
            {
                return Convert.ToSingle(Price ?? 0);
            }
        }


    }
    public partial class OrderList
    {

        public Uri ImagePreviewOrder
        {
            get
            {
                var imageName = System.IO.Path.Combine(Environment.CurrentDirectory, Logo ?? "");
                return System.IO.File.Exists(imageName) ? new Uri(imageName) : new Uri("pack://application:,,,/logo/picture.png");
            }
        }
       


    }

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        private List<Product> _ProductList;
        public List<Product> ProductList
        {
            get
            {
                var FilteredServiceList = _ProductList.FindAll(item =>
                item.DiscountFloat >= CurrentDiscountFilter.Item1 &&
                 item.DiscountFloat < CurrentDiscountFilter.Item2);

                if (SearchFilter != "")
                    FilteredServiceList = FilteredServiceList.Where(item =>
                        item.Name.IndexOf(SearchFilter, StringComparison.OrdinalIgnoreCase) != -1).ToList();

                if (SortPriceAscending)
                    return FilteredServiceList.OrderBy(item => (item.Price)).ToList();
                else
                    return FilteredServiceList.OrderByDescending(item => (item.Price)).ToList();
            }
            set
            {
                _ProductList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductList"));
                    PropertyChanged(this, new PropertyChangedEventArgs("ServicesCount"));
                    PropertyChanged(this, new PropertyChangedEventArgs("FilteredServicesCount"));
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            ProductList = Core.DB.Product.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private Boolean _SortPriceAscending = true;

        public event PropertyChangedEventHandler PropertyChanged;

        public Boolean SortPriceAscending
        {
            get { return _SortPriceAscending; }
            set
            {
                _SortPriceAscending = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductList"));
                    PropertyChanged(this, new PropertyChangedEventArgs("ServicesCount"));
                    PropertyChanged(this, new PropertyChangedEventArgs("FilteredServicesCount"));
                }
            }
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            SortPriceAscending = (sender as RadioButton).Tag.ToString() == "1";
        }
        private List<Tuple<string, float, float>> FilterByDiscountValuesList =
    new List<Tuple<string, float, float>>() {
        Tuple.Create("Все записи", 0f, 500f),
        Tuple.Create("от 0 до 25", 0f, 25f),
        Tuple.Create("от 25 до 50", 25f, 50f),
        Tuple.Create("от 50 до 100", 50f, 100f),
        Tuple.Create("от 100 до 250", 100f, 250f),
        Tuple.Create("от 250 до 500", 250f, 500f)
    };
        public List<string> FilterByDiscountNamesList
        {
            get
            {
                return FilterByDiscountValuesList
                    .Select(item => item.Item1)
                    .ToList();
            }
        }
        private Tuple<float, float> _CurrentDiscountFilter = Tuple.Create(float.MinValue, float.MaxValue);

        public Tuple<float, float> CurrentDiscountFilter
        {
            get
            {
                return _CurrentDiscountFilter;
            }
            set
            {
                _CurrentDiscountFilter = value;
                if (PropertyChanged != null)
                {
                    // при изменении фильтра список перерисовывается
                    PropertyChanged(this, new PropertyChangedEventArgs("ServicesCount"));
                    PropertyChanged(this, new PropertyChangedEventArgs("FilteredServicesCount"));
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductList"));
                }
            }
        }
        private void DiscountFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentDiscountFilter = Tuple.Create(
                FilterByDiscountValuesList[DiscountFilterComboBox.SelectedIndex].Item2,
                FilterByDiscountValuesList[DiscountFilterComboBox.SelectedIndex].Item3
            );
        }
        private string _SearchFilter = "";
        public string SearchFilter
        {
            get { return _SearchFilter; }
            set
            {
                _SearchFilter = value;
                if (PropertyChanged != null)
                {
                    // при изменении фильтра список перерисовывается
                    PropertyChanged(this, new PropertyChangedEventArgs("ProductList"));
                    PropertyChanged(this, new PropertyChangedEventArgs("ServicesCount"));
                    PropertyChanged(this, new PropertyChangedEventArgs("FilteredServicesCount"));
                }
            }
        }
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            SearchFilter = SearchFilterTextBox.Text;
        }
        public int ServicesCount
        {
            get
            {
                return _ProductList.Count;
            }

        }
        public int FilteredServicesCount
        {
            get
            {
                return ProductList.Count;
            }
        }

        private void OrderOpe_Click(object sender, RoutedEventArgs e)
        {
            var OpenOrder = new Order();
            OpenOrder.ShowDialog();
        }
        
        
    }
}
    
