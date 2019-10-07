using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace VriendenList.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //declaratie van een list vrienden van het type string

        //declaratie van een list geboorteJaren van het type integer

        int index;

        public MainWindow()
        {
            InitializeComponent();
            //instantiëring van vrienden en geboorteJaren

            HuidigeVrienden();
        }

        #region Methodes waaraan niets moet veranderen
        int BepaalHuidigJaar()
        {
            int jaar;

            DateTime vandaag = DateTime.Today;
            jaar = vandaag.Year;

            return jaar;
        }

        int BerekenLeeftijd(int geboorteJaar)
        {
            int leeftijd;
            int huidigJaar;

            huidigJaar = BepaalHuidigJaar();
            leeftijd = huidigJaar - geboorteJaar;

            return leeftijd;
        }

        void HuidigeVrienden()
        {
            VoegVriendToe("Bart", 1965);
            VoegVriendToe("Peter", 1964);
            VoegVriendToe("Sandra", 1962);
        }

        string ToonLeeftijd(int geboortejaar)
        {
            int leeftijd;
            string leeftijdsInfo;
            leeftijd = BerekenLeeftijd(geboortejaar);
            leeftijdsInfo = "Leeftijd: " + leeftijd;
            return leeftijdsInfo;
        }

        void MaakVeldenLeeg()
        {
            txtGeboorteJaar.Text = "";
            txtNaam.Text = "";
            lblLeeftijd.Content = "";
        } 
        #endregion

        void VulListbox()
        {
            //Voeg de namen van de vrienden toe aan lstVrienden
            
            lstVrienden.Items.Refresh();
        }

        void VoegVriendToe(string naam, int jaar)
        {
            //Voeg de naam toe aan de list vrienden
            
            //Voeg het jaar toe aan de list geboorteJaren
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VulListbox();
        }

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            string vriend;
            int geboortejaar;

            vriend = txtNaam.Text;
            geboortejaar = int.Parse(txtGeboorteJaar.Text);

            //Wijzig de waarden in de resp. list


            VulListbox();

            lblLeeftijd.Content = ToonLeeftijd(geboortejaar);
        }

        private void btnVerwijder_Click(object sender, RoutedEventArgs e)
        {
            //Verwijder de geselecteerde vriend


            VulListbox();

            MaakVeldenLeeg();

            index = -1;
            lstVrienden.SelectedIndex = -1;
        }

        private void lstVrienden_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string vriend = "";
            int geboortejaar = 0;

            index = lstVrienden.SelectedIndex;

            //Geef vriend en geboortejaar de waarden van de geselecteerde vriend


            txtNaam.Text = vriend;
            txtGeboorteJaar.Text = geboortejaar.ToString();
            lblLeeftijd.Content = ToonLeeftijd(geboortejaar);
        }

        private void btnVoegToe_Click(object sender, RoutedEventArgs e)
        {
            MaakVeldenLeeg();

            txtNaam.Focus();

            VoegVriendToe("",0);

            VulListbox();

            //Verander de index zodat die overeenkomt met de laatst toegevoegde vriend

        }
    }
}
