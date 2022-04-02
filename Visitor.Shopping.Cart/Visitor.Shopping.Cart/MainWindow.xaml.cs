using System;
using System.Collections.Generic;
using System.Globalization;
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
using ElementLib;

namespace Visitor.Shopping.Cart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Good> cart;
        private List<Good> bag;

        public MainWindow()
        {
            InitializeComponent();

            cart = new List<Good>();
            bag = new List<Good>();
            
            lstCart.ItemsSource = cart;
            lstBag.ItemsSource = bag;
        }

        private void MainWin_dow_OnLoaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void PanButtons_Click(object sender, RoutedEventArgs e)
        {
            var goods = cart.Concat(bag);
            
            switch ((e.OriginalSource as Button)!.Name)
            {
                case "btn1":
                    MessageBox.Show(RunVisitor(goods, new AlcVisitor()));
                    break;
                case "btn2":
                    MessageBox.Show(RunVisitor(goods, new CaloriesVisitor()));
                    break;
                case "btn3":
                    MessageBox.Show(RunVisitor(goods, new PriceVisitor()));
                    break;
                case "btn4":
                    MessageBox.Show(GetHtml(goods));
                    break;
                case "btn5":
                    MessageBox.Show(RunVisitor(goods, new WeightVisitor()));
                    break;
            }
        }

        private string RunVisitor(IEnumerable<Good> list, IVisitor visitor)
        {
            foreach (var good in list)
            {
                good.Accept(visitor);
            }

            return visitor.ResultString;
        }

        private string GetHtml(IEnumerable<Good> list)
        {
            var visitor = new HtmlVisitor();
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("<table><tr><th>Produkt</th><th>Preis</th><th>Gewicht</th><th>Info</th></tr>");
            
            foreach (var good in list)
            {
                good.Accept(visitor);
                stringBuilder.Append(visitor.ResultString);
            }
            

            stringBuilder.Append("</table>");
            return stringBuilder.ToString();
        }

        private void BtnAddClicked(object sender, RoutedEventArgs e)
        {
            string cat = comboCategories.SelectionBoxItem as string ?? "";
            string name = txtName.Text;
            double price = double.Parse(txtPricePerUnit.Text, CultureInfo.InvariantCulture);
            int units = (int) sldUnits.Value;
            int weight = (int) sldWeight.Value;
            bool cartIsChecked = rdoCart.IsChecked ?? false;

            Good good = GoodFactory.GetGood(cat);

            if (good == null)
            {
                return;
            }
            
            good.Name = name;
            good.Weight = weight;
            good.NrUnits = units;
            good.PricePerUnit = price;

            if (cartIsChecked)
            {
                this.cart.Add(good);
                lstCart.Items.Refresh();
            }
            else
            {
                this.bag.Add(good);
                lstBag.Items.Refresh();
            }

        }
        
    }
}
