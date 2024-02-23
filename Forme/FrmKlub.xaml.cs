using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace FudbalskiKlub.Forme
{
    public partial class FrmKlub : Window
    {
        Konekcija con = new Konekcija();
        SqlConnection connection = new SqlConnection();
        private bool update;
        private DataRowView row;
        public FrmKlub()
        {
            InitializeComponent();
            txtNaziv.Focus();
            connection = con.KreirajKonekciju();
        }

        public FrmKlub(bool update, DataRowView row)
        {
            InitializeComponent();
            txtNaziv.Focus();
            connection = con.KreirajKonekciju();
            this.update = update;
            this.row = row;
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.Open();
                DateTime date = (DateTime)GodinaOsnivanja.SelectedDate;
                string datum = date.ToString("dd-MM-yyyy");
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = connection
                };
                cmd.Parameters.Add("@Naziv", SqlDbType.NVarChar).Value = txtNaziv.Text;
                cmd.Parameters.Add("@Liga", SqlDbType.NVarChar).Value = txtLiga.Text;
                cmd.Parameters.Add("@GodinaOsnivanja", SqlDbType.Date).Value = datum;
                cmd.Parameters.Add("@Adresa", SqlDbType.NVarChar).Value = txtAdresa.Text;
                if (update)
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"update tblKlub set Naziv = @Naziv, Liga = @Liga, GodinaOsnivanja = @GodinaOsnivanja, Adresa = @Adresa where KlubID = @ID";
                    row = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblKlub(Naziv, Liga, GodinaOsnivanja, Adresa) values (@Naziv, @Liga, @GodinaOsnivanja, @Adresa)";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Pogresan unos podataka!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally 
            { 
                if (connection != null) 
                    connection.Close(); 
            }
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
