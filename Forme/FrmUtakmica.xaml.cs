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
    
    public partial class FrmUtakmica : Window
    {
        Konekcija con = new Konekcija();
        SqlConnection connection = new SqlConnection();
        private bool update;
        private DataRowView row;

        public FrmUtakmica()
        {
            InitializeComponent();
            txtMesto.Focus();
            connection = con.KreirajKonekciju();
        }

        public FrmUtakmica(bool update, DataRowView row)
        {
            InitializeComponent();
            txtMesto.Focus();
            connection = con.KreirajKonekciju();
            this.update = update;   
            this.row = row;
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.Open();
                DateTime date = (DateTime)DatumUtakmice.SelectedDate;
                string datum = date.ToString("dd-MM-yyyy");
                SqlCommand cmd = new SqlCommand()
                {
                    Connection = connection
                };
                cmd.Parameters.Add("@Mesto", SqlDbType.NVarChar).Value = txtMesto.Text;
                cmd.Parameters.Add("@Datum", SqlDbType.Date).Value = datum;
                cmd.Parameters.Add("@Protivnik", SqlDbType.NVarChar).Value = txtProtivnik.Text;
                cmd.Parameters.Add("@TipUtakmice", SqlDbType.NVarChar).Value = txtTipUtakmice.Text;
                if (update)
                {
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = @"update tblUtakmica set MestoUtakmice = @Mesto, DatumUtakmice = @Datum, Protivnik = @Protivnik, TipUtakmice = @TipUtakmice where UtakmicaID = @ID";
                    row = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblUtakmica(MestoUtakmice, DatumUtakmice, Protivnik, TipUtakmice) values (@Mesto, @Datum, @Protivnik, @TipUtakmice)";
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Pogresno uneti podaci!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
