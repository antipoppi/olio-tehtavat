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

namespace WpfPelaajat
{
    public class Pelaaja
    {
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public string Pelipaikka { get; set; }
        public string Numero { get; set; }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGetPlayers_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("Heipä hei maailma!");
            Pelaaja p1 = new Pelaaja();
            p1.Etunimi = "Lasse"; p1.Sukunimi = "Kukkonen"; p1.Pelipaikka = "puolustaja"; p1.Numero = "24";
            Pelaaja p2 = new Pelaaja() { Etunimi = "Teemu", Sukunimi = "Selänne", Pelipaikka = "laitahyökkääjä", Numero = "17" };
            List < Pelaaja > pelaajat = new List<Pelaaja>();
            pelaajat.Add(p1);
            pelaajat.Add(p2);
            // lista pelaajista kiinnitetään DataGridille
            dtgPlayers.ItemsSource = pelaajat;
        }
    }
}
