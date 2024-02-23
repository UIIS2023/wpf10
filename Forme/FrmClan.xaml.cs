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
    public partial class FrmClan : Window
    {
        Konekcija con = new Konekcija();
        SqlConnection connection = new SqlConnection();
        private bool update;
        private DataRowView row;

        public FrmClan()
        {
            InitializeComponent();
            txtIme.Focus();
            connection = con.KreirajKonekciju();
            fillComboBox();
        }

        public FrmClan (bool update, DataRowView row)
        {
            InitializeComponent ();
            txtIme.Focus();
            connection = con.KreirajKonekciju();
            fillComboBox();
            this.update = update;
            this.row = row;
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
                cmd.Parameters.Add("@Verifikacija", SqlDbType.Bit).Value = Convert.ToInt32(chbVerifikacija.IsChecked);
                cmd.Parameters.Add("@TipClanstva", SqlDbType.NVarChar).Value = txtTipClanstva.Text;
                cmd.Parameters.Add("@Klub", SqlDbType.Int).Value = cbKlub.SelectedValue;
                if (update)
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"update tblClan set ImeClana = @Ime, PrezimeClana = @Prezime, Verifikacija = @verifikacija, TipClanstva = @TipClanstva, KlubID = @Klub where ClanID = @ID";
                    row = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblClan(ImeClana, PrezimeClana, Verifikacija, TipClanstva, KlubID) values (@Ime, @Prezime, @Verifikacija, @TipClanstva, @Klub)";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Pogresano uneti podaci!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
