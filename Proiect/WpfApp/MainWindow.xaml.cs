using System;
using System.Collections.Generic;
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
            string numeMaterie = GetMaterieSelectata();
            string valDificultate = txtDificultate.Text.Trim();

            if (int.TryParse(valDificultate, out int dificultateInt) && dificultateInt >= 1 && dificultateInt <= 3)
            {
                Materie materieNoua = new Materie(numeMaterie);
                materieNoua.Dificultate = (Materie.DificultateMaterie)dificultateInt;
                adminMaterii.AddMaterie(materieNoua);
                materii.Add(materieNoua);

                MessageBox.Show($"Materia '{numeMaterie}' a fost salvată!", "Salvare");
                ResetareFormular();
            }
            else
            {
                lblDificultate.Foreground = Brushes.Red;
                txtDificultate.BorderBrush = Brushes.Red;
                errDificultate.Text = "Introduceți o cifră validă (1, 2 sau 3)!";
                errDificultate.Visibility = Visibility.Visible;
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e) => ResetareFormular();

        private void ResetareFormular()
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

        private void btnIncepeTest_Click(object sender, RoutedEventArgs e)
        {
            panelAdauga.Visibility = Visibility.Collapsed;
            btnMeniuCauta.Visibility = Visibility.Collapsed;
            panelTest.Visibility = Visibility.Visible;

        }
    }
}