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
    public partial class FrmTrener : Window
    {
        Konekcija con = new Konekcija();
        SqlConnection connection = new SqlConnection();
        private bool update;
        private DataRowView row;

        public FrmTrener()
        {
            InitializeComponent();
            txtIme.Focus();
            connection = con.KreirajKonekciju();
            fillComboBox();
        }

        public FrmTrener(bool update, DataRowView row)
        {
            InitializeComponent();
            txtIme.Focus();
            connection = con.KreirajKonekciju();
            this.update = update;
            this.row = row;
            fillComboBox();
        }

        private void fillComboBox()
        {
            try
            {
                connection.Open();
                string PopuniKlub = @"select KlubID, Naziv from tblKlub";
                SqlDataAdapter daKlub = new SqlDataAdapter(PopuniKlub, connection);
                DataTable dtKlub = new DataTable();
                daKlub.Fill(dtKlub);
                cbKlub.ItemsSource = dtKlub.DefaultView;
                daKlub.Dispose();
                dtKlub.Dispose();
            }
            catch
            {
                MessageBox.Show("Greška pri ucitavanju", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally { if (connection != null) connection.Close(); }
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = connection
                };
                cmd.Parameters.Add("@Ime", SqlDbType.NVarChar).Value = txtIme.Text;
                cmd.Parameters.Add("@Prezime", SqlDbType.NVarChar).Value = txtPrezime.Text;
                cmd.Parameters.Add("@Godine", SqlDbType.Int).Value = txtGodine.Text;
                cmd.Parameters.Add("@Karijera", SqlDbType.NVarChar).Value = txtKarijera.Text;
                cmd.Parameters.Add("@Klub", SqlDbType.Int).Value = cbKlub.SelectedValue;
                if (update)
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"update tblTrener set ImeTrenera = @Ime, PrezimeTrenera = @Prezime, GodineTrenera = @Godine, KarijeraTrenera = @Karijera, KlubID = @Klub where TrenerID = @ID";
                    row = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblTrener(ImeTrenera, PrezimeTrenera, GodineTrenera, KarijeraTrenera, KlubID) values (@Ime, @Prezime, @Godine, @Karijera, @Klub)";
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
