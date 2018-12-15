using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

public static class MetodosExtensao
{
    public static double RetornaMetade(this int Valor)
    {
        return Valor / 2;
    }

    public static double DescontaImpostos(this double Valor)
    {
        // Desconta imposto
        return Valor - 10;
    }

    public static string LetraInicialMaiuscula(this string Texto)
    {
        return Texto.Substring(0, 1).ToUpper() +
               Texto.Substring(1, Texto.Length - 1).ToLower();

    }

    public static string LetraInicialMaiuscula(this string Texto,
                                               bool UltimaMinuscula)
    {
        if (UltimaMinuscula)
        {
            return Texto.Substring(0, 1).ToUpper() +
                  Texto.Substring(1, Texto.Length - 1).ToLower();
        }
        else
        {
            return Texto.Substring(0, 1).ToUpper() +
                  Texto.Substring(1, Texto.Length - 1);
        }
    }

}

namespace ConsoleApp.Classes

{
    public partial class Cliente : IDisposable
    {

        public SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Loja;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public Cliente()
        {

        }

        public Cliente(int Codigo)
        {
            using (connection)
            {
                try
                {
                    connection.Open();
                }
                catch (Exception)
                {

                    throw;
                }
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText =
                        "select * from   Cliente where  Codigo = @codigo";
                    sqlCommand.Parameters.AddWithValue("@codigo", Codigo);

                    using (SqlDataReader data = sqlCommand.ExecuteReader())
                    {
                        if(data.HasRows)
                        {
                            data.Read();
                            this._codigo = data.GetInt32(data.GetOrdinal("Codigo"));
                            this._nome = data.GetString(data.GetOrdinal("Nome"));
                            this._tipo = data.GetInt32(data.GetOrdinal("Tipo"));
                            this._dataCadastro = data.GetDateTime(data.GetOrdinal("DataCadastro"));

                        }
                    }
                }
            }

        }

        public void Dispose()
        {
            this.Gravar();

        }

        public void Gravar()
        {
            using (connection)
            {
                try
                {
                    connection.Open();
                }
                catch (Exception)
                {

                    throw;
                }

                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.CommandText =
                        "insert into Cliente(" +
                        "            Codigo," +
                        "            Nome," +
                        "            Tipo," +
                        "            DataCadastro)" +
                        "values(" +
                        "@codigo," +
                        "@nome," +
                        "@tipo," +
                        "@datacadastro)";
                    sqlCommand.Connection = connection;

                    sqlCommand.Parameters.AddWithValue("@codigo", this._codigo);
                    sqlCommand.Parameters.AddWithValue("@nome", this._nome);
                    sqlCommand.Parameters.AddWithValue("@tipo", this._tipo);
                    sqlCommand.Parameters.AddWithValue("@datacadastro", this._dataCadastro);

                    try
                    {
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }


        }

        public void Apagar() { }

    }


}
