using FudbalskiKlub.Forme;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FudbalskiKlub
{
    public partial class MainWindow : Window
    {
        Konekcija con = new Konekcija();
        SqlConnection connection = new SqlConnection();
        private bool update;
        private DataRowView row;
        private string? CurrentTable;

        #region Select queries
        private static string SelectKlub = @"select KlubID as ID, Naziv, Liga, GodinaOsnivanja, Adresa from tblKlub";
        private static string SelectIgrac = @"select IgracID as ID, ImeIgraca as Ime, PrezimeIgraca as Prezime, GodineIgraca as Godine, KarijeraIgraca as Karijera, PozicijaIgre as Pozicija, tblKlub.Naziv 
                                        from tblIgrac
                                        join tblKlub on tblIgrac.KlubID = tblKlub.KlubID";
        private static string SelectTrener = @"select TrenerID as ID, ImeTrenera as Ime, PrezimeTrenera as Prezime, GodineTrenera as Godine, KarijeraTrenera as Karijera, tblKlub.Naziv 
                                        from tblTrener
                                        join tblKlub on tblTrener.KlubID = tblKlub.KlubID";
        private static string SelectClan = @"select ClanID as ID, ImeClana as Ime, PrezimeClana as Prezime, Verifikacija, TipClanstva, tblKlub.Naziv
                                        from tblClan
                                        join tblKlub on tblClan.KlubID = tblKlub.KlubID";
        private static string SelectKarta = @"select KartaID as ID, Sediste, Pozicija, tblUtakmica.Protivnik 
                                        from tblKarta join tblUtakmica on tblKarta.UtakmicaID = tblUtakmica.UtakmicaID";
        private static string SelectUtakmica = @"select UtakmicaID as ID, MestoUtakmice as Mesto, DatumUtakmice as Datum, Protivnik, TipUtakmice from tblUtakmica";
        private static string SelectStadion = @"Select StadionID as ID, tblKlub.Naziv, tblUtakmica.Protivnik, InfirmacijeOUtakmici as Info
                                        from tblStadion join tblKlub on tblStadion.KlubID = tblKlub.KlubID
				                        join tblUtakmica on tblStadion.UtakmicaID = tblUtakmica.UtakmicaID";
        private static string SelectTurnir = @"select TurnirID as ID, MesteOdrzavanja, DatumTurnira as Datum, Oblik, tblKlub.Naziv
                                         from tblTurnir
                                         join tblKlub on tblTurnir.KlubID = tblKlub.KlubID";
        #endregion

        #region Select with statements
        private static string SelectStatementKlub = @"select * from tblKlub where KlubID=";
        private static string SelectStatementIgrac = @"select * from tblIgrac where IgracID=";
        private static string SelectStatementTrener = @"select * from tblTrener where TrenerID=";
        private static string SelectStatementClan = @"select * from tblClan where ClanID=";
        private static string SelectStatementUtakmica = @"select * from tblUtakmica where UtakmicaID=";
        private static string SelectStatementStadion = @"select * from tblStadion where StadionID=";
        private static string SelectStatementKarta = @"select * from tblKarta where KartaID=";
        private static string SelectStatementTurnir = @"select * from tblTurnir where TurnirID=";
        #endregion

        #region Delete queries
        private static string DeleteKlub = @"delete from tblKlub where KlubID = ";
        private static string DeleteIgrac = @"delete from tblIgrac where IgracID = ";
        private static string DeleteTrener = @"delete from tblTrener where TrenerID = ";
        private static string DeleteUtakmica = @"delete from tblUtakmica where UtakmicaID = ";
        private static string DeleteKarta = @"delete from tblKarta where KartaID = ";
        private static string DeleteStadion = @"delete from tblStadion where StadionID = ";
        private static string DeleteClan = @"delete from tblClan where ClanID = ";
        private static string DeleteTurnir = @"delete from tblTurnir where TurnirID = ";
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            connection = con.KreirajKonekciju();
            loadData(SelectKlub);
        }

        private void loadData(string SelectString)
        {
            try
            {
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(SelectString, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataGridCentralni != null)
                    dataGridCentralni.ItemsSource = dataTable.DefaultView;
                CurrentTable = SelectString;
                dataAdapter.Dispose();
                dataTable.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show("Neuspesno ucitani podaci!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (connection != null) 
                    connection.Close();
            }
        }

        private void btnKlub_Click(object sender, RoutedEventArgs e)
        {
            loadData(SelectKlub);
        }

        private void btnIgrac_Click(object sender, RoutedEventArgs e)
        {
            loadData(SelectIgrac);
        }

        private void btnTrener_Click(object sender, RoutedEventArgs e)
        {
            loadData(SelectTrener);
        }

        private void btnUtakmica_Click(object sender, RoutedEventArgs e)
        {
            loadData(SelectUtakmica);
        }

        private void btnStadion_Click(object sender, RoutedEventArgs e)
        {
            loadData(SelectStadion);
        }

        private void btnKarta_Click(object sender, RoutedEventArgs e)
        {
            loadData(SelectKarta);
        }

        private void btnTurnir_Click(object sender, RoutedEventArgs e)
        {
            loadData(SelectTurnir);
        }

        private void btnClan_Click(object sender, RoutedEventArgs e)
        {
            loadData(SelectClan);
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Window form;
            if (CurrentTable.Equals(SelectKlub))
            {
                form = new FrmKlub();
                form.ShowDialog();
                loadData(SelectKlub);
            }
            else if (CurrentTable.Equals(SelectIgrac))
            {
                form = new FrmIgrac();
                form.ShowDialog();
                loadData(SelectIgrac);
            }
            else if (CurrentTable.Equals(SelectTrener))
            {
                form = new FrmTrener();
                form.ShowDialog();
                loadData(SelectTrener);
            }
            else if (CurrentTable.Equals(SelectUtakmica))
            {
                form = new FrmUtakmica();
                form.ShowDialog();
                loadData(SelectUtakmica);
            }
            else if (CurrentTable.Equals(SelectStadion))
            {
                form = new FrmStadion();
                form.ShowDialog();
                loadData(SelectStadion);
            }
            else if (CurrentTable.Equals(SelectClan))
            {
                form = new FrmClan();
                form.ShowDialog();
                loadData(SelectClan);
            }
            else if (CurrentTable.Equals(SelectKarta))
            {
                form = new FrmKarta();
                form.ShowDialog();
                loadData(SelectKarta);
            }
            else if (CurrentTable.Equals(SelectTurnir))
            {
                form = new FrmTurnir();
                form.ShowDialog();
                loadData(SelectTurnir);
            }
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentTable.Equals(SelectKlub))
            {
                FillForm(SelectStatementKlub);
                loadData(SelectKlub);
            }
            else if (CurrentTable.Equals(SelectIgrac))
            {
                FillForm(SelectStatementIgrac);
                loadData(SelectIgrac);
            }
            else if (CurrentTable.Equals(SelectTrener))
            {
                FillForm(SelectStatementTrener);
                loadData(SelectTrener);
            }
            else if (CurrentTable.Equals(SelectUtakmica))
            {
                FillForm(SelectStatementUtakmica);
                loadData(SelectUtakmica);
            }
            else if (CurrentTable.Equals(SelectStadion))
            {
                FillForm(SelectStatementStadion);
                loadData(SelectStadion);
            }
            else if (CurrentTable.Equals(SelectClan))
            {
                FillForm(SelectStatementClan);
                loadData(SelectClan);
            }
            else if (CurrentTable.Equals(SelectKarta))
            {
                FillForm(SelectStatementKarta);
                loadData(SelectKarta);
            }
            else if (CurrentTable.Equals(SelectTurnir))
            {
                FillForm(SelectStatementTurnir);
                loadData(SelectTurnir);
            }
        }

        private void FillForm(string selectStatement)
        {
            try
            {
                connection.Open();
                update = true;
                row = (DataRowView)dataGridCentralni.SelectedItems[0];
                SqlCommand cmd = new SqlCommand { Connection = connection };
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = row["ID"];
                cmd.CommandText = selectStatement + "@ID";
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (CurrentTable.Equals(SelectKlub))
                    {
                        FrmKlub FormKlub = new FrmKlub(update, row);
                        FormKlub.txtNaziv.Text = reader["Naziv"].ToString();
                        FormKlub.txtLiga.Text = reader["Liga"].ToString();
                        FormKlub.GodinaOsnivanja.SelectedDate = (DateTime)reader["GodinaOsnivanja"];
                        FormKlub.txtAdresa.Text = reader["Adresa"].ToString();
                        FormKlub.ShowDialog();
                    }
                    else if (CurrentTable.Equals(SelectIgrac))
                    {
                        FrmIgrac FormIgrac = new FrmIgrac(update, row);
                        FormIgrac.txtIme.Text = reader["ImeIgraca"].ToString();
                        FormIgrac.txtPrezime.Text = reader["PrezimeIgraca"].ToString();
                        FormIgrac.txtGodine.Text = reader["GodineIgraca"].ToString();
                        FormIgrac.txtKarijera.Text = reader["KarijeraIgraca"].ToString();
                        FormIgrac.txtPozicija.Text = reader["PozicijaIgre"].ToString();
                        FormIgrac.cbKlub.SelectedValue = reader["KlubID"].ToString();
                        FormIgrac.ShowDialog();
                    }
                    else if (CurrentTable.Equals(SelectTrener))
                    {
                        FrmTrener FormTrener = new FrmTrener(update, row);
                        FormTrener.txtIme.Text = reader["ImeTrenera"].ToString();
                        FormTrener.txtPrezime.Text = reader["PrezimeTrenera"].ToString();
                        FormTrener.txtGodine.Text = reader["GodineTrenera"].ToString();
                        FormTrener.txtKarijera.Text = reader["KarijeraTrenera"].ToString();
                        FormTrener.cbKlub.SelectedValue = reader["KlubID"].ToString();
                        FormTrener.ShowDialog();
                    }
                    else if (CurrentTable.Equals(SelectUtakmica))
                    {
                        FrmUtakmica FormUtakmica = new FrmUtakmica(update, row);
                        FormUtakmica.txtMesto.Text = reader["MestoUtakmice"].ToString();
                        FormUtakmica.DatumUtakmice.SelectedDate = (DateTime)reader["DatumUtakmice"];
                        FormUtakmica.txtProtivnik.Text = reader["Protivnik"].ToString();
                        FormUtakmica.txtTipUtakmice.Text = reader["TipUtakmice"].ToString();
                        FormUtakmica.ShowDialog();
                    }
                    else if (CurrentTable.Equals(SelectStadion))
                    {
                        FrmStadion FormStadion = new FrmStadion(update, row);
                        FormStadion.cbKlub.SelectedValue = reader["KlubID"].ToString();
                        FormStadion.cbUtakmica.SelectedValue = reader["UtakmicaID"].ToString();
                        FormStadion.txtInformacije.Text = reader["InfirmacijeOUtakmici"].ToString();
                        FormStadion.ShowDialog();
                    }
                    else if (CurrentTable.Equals(SelectKarta))
                    {
                        FrmKarta FormKarta = new FrmKarta(update, row);
                        FormKarta.txtSediste.Text = reader["Sediste"].ToString();
                        FormKarta.txtPozicija.Text = reader["Pozicija"].ToString();
                        FormKarta.cbUtakmica.Text = reader["UtakmicaID"].ToString();
                        FormKarta.ShowDialog();
                    }
                    else if (CurrentTable.Equals(SelectClan))
                    {
                        FrmClan FormClan = new FrmClan(update, row);
                        FormClan.txtIme.Text = reader["ImeClana"].ToString();
                        FormClan.txtPrezime.Text = reader["PrezimeClana"].ToString();
                        FormClan.chbVerifikacija.IsChecked = (bool)reader["Verifikacija"];
                        FormClan.txtTipClanstva.Text = reader["TipClanstva"].ToString();
                        FormClan.cbKlub.SelectedValue = reader["KlubID"].ToString();
                        FormClan.ShowDialog();
                    }
                    else if (CurrentTable.Equals(SelectTurnir))
                    {
                        FrmTurnir FormTurnir = new FrmTurnir(update, row);
                        FormTurnir.txtMesto.Text = reader["MesteOdrzavanja"].ToString();
                        FormTurnir.dpDatum.SelectedDate = (DateTime)reader["DatumTurnira"];
                        FormTurnir.txtOblik.Text = reader["Oblik"].ToString();
                        FormTurnir.cbKlub.SelectedValue = reader["KlubID"].ToString();
                        FormTurnir.ShowDialog();
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Nije selektovan ni jedan red!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        private void btnObrisi_Click_1(object sender, RoutedEventArgs e)
        {
            if (CurrentTable.Equals(SelectKlub))
            {
                DeleteData(DeleteKlub);
                loadData(SelectKlub);
            }
            else if (CurrentTable.Equals(SelectIgrac))
            {
                DeleteData(DeleteIgrac);
                loadData(SelectIgrac);
            }
            else if (CurrentTable.Equals(SelectTrener))
            {
                DeleteData(DeleteTrener);
                loadData(SelectTrener);
            }
            else if (CurrentTable.Equals(SelectUtakmica))
            {
                DeleteData(DeleteUtakmica);
                loadData(SelectUtakmica);
            }
            else if (CurrentTable.Equals(SelectStadion))
            {
                DeleteData(DeleteStadion);
                loadData(SelectStadion);
            }
            else if (CurrentTable.Equals(SelectKarta))
            {
                DeleteData(DeleteKarta);
                loadData(SelectKarta);
            }
            else if (CurrentTable.Equals(SelectClan))
            {
                DeleteData(DeleteClan);
                loadData(SelectClan);
            }
            else if (CurrentTable.Equals(SelectTurnir))
            {
                DeleteData(DeleteTurnir);
                loadData(SelectTurnir);
            }
        }

        private void DeleteData(string deleteQuery)
        {
            try
            {
                connection.Open();
                row = (DataRowView)dataGridCentralni.SelectedItems[0];
                MessageBoxResult result = MessageBox.Show("Da li ste sigurni da zelite da obrisete?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = connection
                    };
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = row["ID"];
                    cmd.CommandText = deleteQuery + "@ID";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Nije selektovan ni jedan red!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (SqlException)
            {
                MessageBox.Show("Ima povezanih podataka sa drugim tabelama!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
    }
}

