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
    public partial class FrmKarta : Window
    {
        Konekcija con = new Konekcija();
        SqlConnection connection = new SqlConnection();
        private bool update;
        private DataRowView row;

        public FrmKarta()
        {
            InitializeComponent();
            txtSediste.Focus();
            connection = con.KreirajKonekciju();
            fillComboBox();
        }

        public FrmKarta(bool  update, DataRowView row)
        {
            InitializeComponent();
            txtSediste.Focus();
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
                string PopuniUtakmice = @"select UtakmicaID, Protivnik from tblUtakmica";
                SqlDataAdapter daUtakmica = new SqlDataAdapter(PopuniUtakmice, connection);
                DataTable dtUtakmica = new DataTable();
                daUtakmica.Fill(dtUtakmica);
                cbUtakmica.ItemsSource = dtUtakmica.DefaultView;
                daUtakmica.Dispose();
                dtUtakmica.Dispose();
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
                cmd.Parameters.Add("@Sediste", SqlDbType.Int).Value = txtSediste.Text;
                cmd.Parameters.Add("@Pozicija", SqlDbType.NVarChar).Value = txtPozicija.Text;
                cmd.Parameters.Add("@Utakmica", SqlDbType.Int).Value = cbUtakmica.SelectedValue;
                if (update)
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"update tblKarta set Sediste = @Sediste, Pozicija = @Pozicija, UtakmicaID = @Utakmica where KartaID = @ID";
                    row = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblKarta(Sediste, Pozicija,  UtakmicaID) values (@Sediste, @Pozicija, @Utakmica)";
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

