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
    public partial class FrmTurnir : Window
    {
        Konekcija con = new Konekcija();
        SqlConnection connection = new SqlConnection();
        private bool update;
        private DataRowView row;

        public FrmTurnir()
        {
            InitializeComponent();
            txtMesto.Focus();
            connection = con.KreirajKonekciju();
            fillComboBox();
        }

        public FrmTurnir (bool update, DataRowView row)
        {
            InitializeComponent ();
            txtMesto.Focus ();
            connection = con.KreirajKonekciju ();
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
                DateTime date = (DateTime)dpDatum.SelectedDate;
                string datum = date.ToString("dd-MM-yyyy");
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = connection
                };
                cmd.Parameters.Add("@Mesto", SqlDbType.NVarChar).Value = txtMesto.Text;
                cmd.Parameters.Add("@Datum", SqlDbType.Date).Value = datum;
                cmd.Parameters.Add("@Oblik", SqlDbType.NVarChar).Value = txtOblik.Text;
                cmd.Parameters.Add("@Klub", SqlDbType.Int).Value = cbKlub.SelectedValue;
                if (update)
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"update tblTurnir set MesteOdrzavanja = @Mesto, DatumTurnira = @Datum, Oblik = @Oblik, KlubID = @Klub where TurnirID = @ID";
                    row = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblTurnir(MesteOdrzavanja, DatumTurnira, Oblik, KlubID) values (@Mesto, @Datum, @Oblik, @Klub)";
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
