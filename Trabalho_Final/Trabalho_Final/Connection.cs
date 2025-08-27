using MySql.Data.MySqlClient;

public class Connection
{

    private string connectionString = "Server=localhost;Port=3306;DataBase=senac_SGA;Uid=root;Pwd=xrtornado";
    public MySqlConnection Open()
    {
     try
     {
           return new MySqlConnection(connectionString);
     }
     catch (System.Exception e)
     {
        System.Console.WriteLine("Erro na Conexão"+e.Message);
        throw;
     }
    }

}