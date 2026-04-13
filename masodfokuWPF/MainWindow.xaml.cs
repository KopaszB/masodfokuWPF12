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

namespace masodfokuWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_szamol_Click(object sender, RoutedEventArgs e)
        {
            if (!szamE(tbx_a.Text)|| !szamE(tbx_b.Text)|| !szamE(tbx_c.Text))
            {
                MessageBox.Show("Nem számot adtál meg!", "Hiba");
                return;
            }
            double a = int.Parse(tbx_a.Text);
            double b = int.Parse(tbx_b.Text);
            double c = int.Parse(tbx_c.Text);

            double disk = b * b - 4 * a * c;
            if (disk>0)
            {
                double x1 = (-b + Math.Sqrt(disk)) / (2 * a);
                double x2 = (-b - Math.Sqrt(disk)) / (2 * a);
                tbl_eredmeny.Text = $"Két valós gyök: x1={x1:f2}, x2={x2:f2}";
            }
            else if (disk<0)
            {
                tbl_eredmeny.Text = $"Nincs megoldás, mert a diszkrimináns negatív!";
            }
            else
            {
                double x = -b / (2 * a);
                tbl_eredmeny.Text = $"Egy valós gyök: x={x:f2}";
            }
            listBoxFeltolt();
        }

        private void listBoxFeltolt()
        {
            double a = int.Parse(tbx_a.Text);
            double b = int.Parse(tbx_b.Text);
            double c = int.Parse(tbx_c.Text);
            string eredmeny = $"{a}x² {elojel(b)} {Math.Abs(b)}x {elojel(c)} {Math.Abs(c)} = 0 -→ ";
            lb_eredmeny.Items.Clear();
            lb_eredmeny.Items.Add(eredmeny);
        }

        private string elojel(double szam)
        {
            if (szam>=0)
            {
                return "+";
            }
            else
            {
                return "-";
            }
        }

        private bool szamE(string szam)
        {
            if (double.TryParse(szam, out double szamSZ))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
