using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace pp_AN;

public partial class EDITassort : Window
{
    private List<Ассортимент> _Ассортиментs;
    private Ассортимент CurrentServ;
    private MySqlConnection conn;
    private string _connString="server=localhost; database=pp; port=3306;User Id=root;password=root";
    public EDITassort(Ассортимент currentServ, List<Ассортимент> _ассортиментs)
    {
        InitializeComponent();
        CurrentServ = currentServ;
        this.DataContext = currentServ;
        _Ассортиментs = _ассортиментs;
    }
    
    private void EditProduct(object sender, RoutedEventArgs e)
    {
        var usr = _Ассортиментs.FirstOrDefault(x => x.ID == CurrentServ.ID);
        if (usr != null)
        {
            try
            {
                conn = new MySqlConnection(_connString);
                conn.Open();
                string upd = "UPDATE ассортимент SET Название = '" + Name.Text +
                             "', Категория_id = '" + Convert.ToInt32(Category.Text) + "', Цена = '" +
                             Convert.ToInt32(Price.Text) +"', Количество = '" +Convert.ToInt32(Quantity.Text)+ "'  WHERE ID = " + Convert.ToInt32(ID.Text) + ";";
                MySqlCommand cmd = new MySqlCommand(upd, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                assortment back = new assortment();
                back.Show();
                this.Close();
            }
            catch (Exception exception)
            {
                Console.Write("Error" + exception);
            }
        }
    }
    
    
    private void GoBack(object? sender, RoutedEventArgs e)
    {
        assortment back = new assortment();
        back.Show();
        this.Close();
    }
}