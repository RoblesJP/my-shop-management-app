using GestionForrajeria.Entities;
using GestionForrajeria.ViewModels.Mercaderia;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionForrajeria.Models
{
    public class MercaderiaRepository :  Repository
    {
       public List<Mercaderia> GetAll()
        {
            List<Mercaderia> mercaderia = new List<Mercaderia>();

            string q = @"SELECT id_mercaderia, nombre, id_categoria, categoria, precio_por_kg, precio_por_100gr 
                         FROM Mercaderia 
                         INNER JOIN Categorias USING(id_categoria);";

            SqliteConnection con = new SqliteConnection(DataPath);
            con.Open();
            SqliteCommand cmd = con.CreateCommand();
            cmd.CommandText = q;
            SqliteDataReader data = cmd.ExecuteReader();

            while (data.Read())
            {
                int idMercaderia = data.GetInt32(0);
                string nombre = data.GetString(1);
                int idCategoria = data.GetInt32(2);
                string categoria = data.GetString(3);
                int? precioPorKg = data.IsDBNull(4) ? null : (int?)data.GetInt32(4);
                int? precioPor100gr = data.IsDBNull(5) ? null : (int?)data.GetInt32(5);
                Mercaderia item = new Mercaderia(idMercaderia, nombre,idCategoria, categoria, precioPorKg, precioPor100gr);
                mercaderia.Add(item);
            }

            con.Close();
            return mercaderia;
        }

        public void Insert(CreateMercaderiaViewModel mercaderiaViewModel)
        {
            string q = @"INSERT INTO Mercaderia (nombre, id_categoria, precio_por_kg, precio_por_100gr)
                         VALUES(@Nombre, @IdCategoria, @PrecioPorKg, @PrecioPor100gr);";

            SqliteConnection con = new SqliteConnection(DataPath);
            con.Open();
            SqliteCommand cmd = con.CreateCommand();
            cmd.CommandText = q;

            cmd.Parameters.AddWithValue("@Nombre", mercaderiaViewModel.Nombre.ToUpper());
            cmd.Parameters.AddWithValue("@IdCategoria", mercaderiaViewModel.IdCategoria);

            if (mercaderiaViewModel.PrecioPorKg.HasValue)
                cmd.Parameters.AddWithValue("@PrecioPorKg", mercaderiaViewModel.PrecioPorKg);
            else
                cmd.Parameters.AddWithValue("@PrecioPorKg", DBNull.Value);

            if (mercaderiaViewModel.PrecioPor100gr.HasValue)
                cmd.Parameters.AddWithValue("@PrecioPor100gr", mercaderiaViewModel.PrecioPor100gr);
            else
                cmd.Parameters.AddWithValue("@PrecioPor100gr", DBNull.Value);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Update(Mercaderia Mercaderia)
        {
            string q = @"UPDATE Mercaderia 
                         SET nombre = '@Nombre', id_categoria = @IdCategoria, precio_por_kg = @PrecioPorKg, precio_por_100gr = @PrecioPor100gr
                         WHERE id_mercaderia = @IdMercaderia;";

            SqliteConnection con = new SqliteConnection(DataPath);
            con.Open();
            SqliteCommand cmd = con.CreateCommand();
            cmd.CommandText = q;
            cmd.Parameters.AddWithValue("@IdMercaderia", Mercaderia.IdMercaderia);
            cmd.Parameters.AddWithValue("@Nombre", Mercaderia.Nombre);
            cmd.Parameters.AddWithValue("@IdCategoria", Mercaderia.IdCategoria);
            cmd.Parameters.AddWithValue("@PrecioPorKg", Mercaderia.PrecioPorKg);
            cmd.Parameters.AddWithValue("@PrecioPor100gr", Mercaderia.PrecioPor100gr);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(int idMercaderia)
        {
            string q = @"DELETE FROM Mercaderia WHERE id_mercaderia = @idMercaderia;";

            SqliteConnection con = new SqliteConnection(DataPath);
            con.Open();
            SqliteCommand cmd = con.CreateCommand();
            cmd.CommandText = q;
            cmd.Parameters.AddWithValue("@idMercaderia", idMercaderia);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<string> GetCategorias()
        {
            List<string> categorias = new List<string>();
            string q = @"SELECT categoria FROM Categorias;";

            SqliteConnection con = new SqliteConnection(DataPath);
            con.Open();
            SqliteCommand cmd = con.CreateCommand();
            cmd.CommandText = q;
            SqliteDataReader data = cmd.ExecuteReader();

            while (data.Read())
            {
                categorias.Add(data.GetString(0));
            }

            return categorias;
        }
 
    }
}
