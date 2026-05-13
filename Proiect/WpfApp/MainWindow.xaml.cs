using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        private const int LIMITA_MAX_NUME = 15;
        private const int LIMITA_MIN_NUME = 1;

        private List<Materie> materii = new List<Materie>();
        private NivelStocareDate.IStocareData adminMaterii;
        private string numeFisier = "Materii.txt";

        public MainWindow()
        {
            InitializeComponent();
            Examen.Content = "Examen de cultura generala";

            adminMaterii = new NivelStocareDate.AdministrareMaterii_FisierText(numeFisier);
            IncarcaMaterii();
        }

        private void IncarcaMaterii()
        {
            // Citim mai intai din fisier
            materii = adminMaterii.GetMaterii();

            // Daca fisierul e gol, incarcam materiile predefinite si le salvam
            if (materii.Count == 0)
            {
                foreach (var m in materii)
                    adminMaterii.AddMaterie(m);
            }
        }

        

        private void btnSalveaza_Click(object sender, RoutedEventArgs e)
        {
            string numeMaterie = txtNumeMaterie.Text.Trim();
            string numeDificultate = txtDificultate.Text.Trim();
            bool esteValid = true;

            if (numeMaterie.Length < LIMITA_MIN_NUME || numeMaterie.Length > LIMITA_MAX_NUME)
            {
                lblNumeMaterie.Foreground = Brushes.Red;
                txtNumeMaterie.BorderBrush = Brushes.Red;
                errNumeMaterie.Text = $"Numele trebuie sa aiba intre {LIMITA_MIN_NUME} si {LIMITA_MAX_NUME} caractere.";
                errNumeMaterie.Visibility = Visibility.Visible;
                esteValid = false;
            }

            if (!int.TryParse(numeDificultate, out int dificultateInt) || dificultateInt < 1 || dificultateInt > 3)
            {
                lblDificultate.Foreground = Brushes.Red;
                errDificultate.Text = "Dificultatea trebuie sa fie 1, 2 sau 3.";
                errDificultate.Visibility = Visibility.Visible;
                esteValid = false;
            }

            if (esteValid)
            {
                Materie.DificultateMaterie dificultate = (Materie.DificultateMaterie)dificultateInt;

                Materie materieExistenta = materii.Find(m => m.Nume.ToLower() == numeMaterie.ToLower());

                if (materieExistenta != null)
                {
                    MessageBox.Show($"Materia '{numeMaterie}' exista deja in lista.", "Atentie");
                    return;
                }

                Materie materieNoua = new Materie(numeMaterie) { Dificultate = dificultate };
                materii.Add(materieNoua);
                adminMaterii.AddMaterie(materieNoua);

                MessageBox.Show($"Materia '{numeMaterie}' cu dificultatea '{dificultate}' a fost salvata!\nTotal materii: {materii.Count}", "Succes");
                ResetareFormular();
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ResetareFormular();
        }

        private void ResetareFormular()
        {
            txtNumeMaterie.Text = string.Empty;
            txtDificultate.Text = string.Empty;
            ResetareValidariVizuale();
        }

        private void ResetareValidariVizuale()
        {
            lblNumeMaterie.Foreground = Brushes.Black;
            lblDificultate.Foreground = Brushes.Black;
            txtNumeMaterie.BorderBrush = Brushes.Black;
            txtDificultate.BorderBrush = Brushes.Black;
            errNumeMaterie.Visibility = Visibility.Collapsed;
            errDificultate.Visibility = Visibility.Collapsed;
        }

        private void txtNumeMaterie_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblNumeMaterie.Foreground = Brushes.Black;
            errNumeMaterie.Visibility = Visibility.Collapsed;
        }

        private void txtDificultate_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblDificultate.Foreground = Brushes.Black;
            errDificultate.Visibility = Visibility.Collapsed;
        }
    }
}