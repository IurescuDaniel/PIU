using System;
using System.Collections.Generic;
using System.Linq; // Necesar pentru FirstOrDefault
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using NivelStocareDate;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        private List<Materie> materii = new List<Materie>();
        private IStocareData adminMaterii;
        private string numeFisier = "Materii.txt";

        // Datele pentru testul activ
        private Materie materieSelectataPentruTest;
        private int indexIntrebareCurenta = 0;
        private int scor = 0;

        public MainWindow()
        {
            InitializeComponent();
            Examen.Content = "Examen de cultura generala";
            adminMaterii = new AdministrareMaterii_FisierText(numeFisier);
            IncarcaMaterii();
        }

        private void IncarcaMaterii()
        {
            materii = adminMaterii.GetMaterii();
        }

        private string GetMaterieSelectata()
        {
            if (rbIstorie.IsChecked == true) return "Istorie";
            if (rbGeografie.IsChecked == true) return "Geografie";
            if (rbBiologie.IsChecked == true) return "Biologie";
            if (rbInformatica.IsChecked == true) return "Informatica";
            if (rbMatematica.IsChecked == true) return "Matematica";
            return "Neselectat";
        }

        private void btnSalveaza_Click(object sender, RoutedEventArgs e)
        {
            ResetareValidariVizuale();
            string numeMaterieSelectata = GetMaterieSelectata();
            string valDificultate = txtDificultate.Text.Trim();

            if (int.TryParse(valDificultate, out int dificultateInt))
            {
                var gasit = materii.FirstOrDefault(m =>
                    m.Nume.Trim().Equals(numeMaterieSelectata, StringComparison.OrdinalIgnoreCase) &&
                    (int)m.Dificultate == dificultateInt);

                if (gasit != null && gasit.Intrebari != null && gasit.Intrebari.Count > 0)
                {
                    materieSelectataPentruTest = gasit;
                    MessageBox.Show($"Materia {numeMaterieSelectata} a fost pregătită!");
                }
                else
                {
                    MessageBox.Show("Nu există întrebări pentru această selecție în fișier.");
                }
            }
        }

        private void btnIncepeTest_Click(object sender, RoutedEventArgs e)
        {
            if (materieSelectataPentruTest == null)
            {
                MessageBox.Show("Mai întâi alege materia și apasă Salvează!");
                return;
            }

            indexIntrebareCurenta = 0;
            scor = 0;

            panelAdauga.Visibility = Visibility.Collapsed;
            btnMeniuCauta.Visibility = Visibility.Collapsed;
            panelTest.Visibility = Visibility.Visible;

            AfiseazaIntrebareaCurenta();
        }

        private void AfiseazaIntrebareaCurenta()
        {
            var intrebare = materieSelectataPentruTest.Intrebari[indexIntrebareCurenta];

            lblTitluTest.Text = $"{materieSelectataPentruTest.Nume} ({indexIntrebareCurenta + 1}/{materieSelectataPentruTest.Intrebari.Count})";

            lblTextIntrebare.Text = intrebare.Text;
            rbA.Content = intrebare.A;
            rbB.Content = intrebare.B;
            rbC.Content = intrebare.C;
            rbD.Content = intrebare.D;

            rbA.IsChecked = rbB.IsChecked = rbC.IsChecked = rbD.IsChecked = false;
        }

        private void btnTrimiteRaspuns_Click(object sender, RoutedEventArgs e)
        {
            char raspunsDat = ' ';
            if (rbA.IsChecked == true) raspunsDat = 'A';
            else if (rbB.IsChecked == true) raspunsDat = 'B';
            else if (rbC.IsChecked == true) raspunsDat = 'C';
            else if (rbD.IsChecked == true) raspunsDat = 'D';


            if (materieSelectataPentruTest.Intrebari[indexIntrebareCurenta].Verifica(raspunsDat))
                scor++;

            indexIntrebareCurenta++;

            if (indexIntrebareCurenta < materieSelectataPentruTest.Intrebari.Count)
            {
                AfiseazaIntrebareaCurenta();
            }
            else
            {
                MessageBox.Show($"Test finalizat! Scorul tău: {scor}/{materieSelectataPentruTest.Intrebari.Count}");
                panelTest.Visibility = Visibility.Collapsed;
                panelAdauga.Visibility = Visibility.Visible;
                btnMeniuCauta.Visibility = Visibility.Visible;
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e) => ResetareAlegereMaterie();

        private void ResetareAlegereMaterie()
        {
            rbIstorie.IsChecked = true;
            txtDificultate.Text = string.Empty;
            ResetareValidariVizuale();
        }

        private void ResetareValidariVizuale()
        {
            lblDificultate.Foreground = Brushes.Black;
            txtDificultate.BorderBrush = Brushes.Gray;
            errDificultate.Visibility = Visibility.Collapsed;
        }

        private void txtDificultate_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (errDificultate != null) ResetareValidariVizuale();
        }

        private void btnMeniuCauta_Click(object sender, RoutedEventArgs e)
        {
            panelAdauga.Visibility = Visibility.Collapsed;
            panelCauta.Visibility = Visibility.Visible;
        }

        private void btnInapoi_Click(object sender, RoutedEventArgs e)
        {
            panelCauta.Visibility = Visibility.Collapsed;
            panelAdauga.Visibility = Visibility.Visible;
        }
        private void btnAfisare_Click(object sender, RoutedEventArgs e)
        {
            lstRezultate.Items.Clear();

            string numeCautat = txtCautaNume.Text.Trim();

            int dificultateCautata = 1;
            if (rbCautaMediu.IsChecked == true) dificultateCautata = 2;
            if (rbCautaGreu.IsChecked == true) dificultateCautata = 3;

            var materieGasita = materii.FirstOrDefault(m =>
                m.Nume.Trim().Equals(numeCautat, StringComparison.OrdinalIgnoreCase) &&
                (int)m.Dificultate == dificultateCautata);

            if (materieGasita != null && materieGasita.Intrebari != null && materieGasita.Intrebari.Count > 0)
            {
                foreach (var intrebare in materieGasita.Intrebari)
                {
                    lstRezultate.Items.Add(intrebare.Text);
                }
            }
            else
            {
                lstRezultate.Items.Add("Nu s-au găsit întrebări pentru această selecție.");
            }
        }
    }
}