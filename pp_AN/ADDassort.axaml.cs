using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySql.Data.MySqlClient;

namespace pp_AN;

public partial class ADDassort : Window
{
    private MySqlConnection conn;
    private string _connString="server=localhost; database=pp; port=3306;User Id=root;password=root";
    public ADDassort()
    {
        InitializeComponent();
    }
    
    private void AddProduct(object sender, RoutedEventArgs e)
    {
        string название = Name.Text; // Получите значение из элемента управления для ввода имени агента
        string категория = Category.Text;
        string цена = Price.Text;
        string количество = Quantity.Text;
        string sql = "INSERT INTO ассортимент (Название, Категория_id, Цена, Количество) VALUES (@Название, @Категория_id, @Цена, @Количество)";

        conn = new MySqlConnection(_connString);
        conn.Open();
        MySqlCommand command = new MySqlCommand(sql, conn);
        command.Parameters.AddWithValue("@Название", название);
        command.Parameters.AddWithValue("@Категория_id", категория);
        command.Parameters.AddWithValue("@Цена", цена);
        command.Parameters.AddWithValue("@Количество", количество);
        command.ExecuteNonQuery();
        conn.Close();
        assortment back = new assortment();
        back.Show();
        this.Close();
    }
    
    
    private void GoBack(object? sender, RoutedEventArgs e)
    {
        assortment back = new assortment();
        back.Show();
        this.Close();
    }
}