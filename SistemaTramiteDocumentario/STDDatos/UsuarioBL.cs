using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace STDDatos
{
    public class UsuarioBL
    {
        public Usuario Obtener(string dni)
        {
            try
            {
                using (BDDOCUMENTUMEntities datos = new BaseDAO().conexion())
                {
                    Usuario vResult = datos.Usuarios.FirstOrDefault(t => t.DNI == dni);
                    return vResult;
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al buscar al usuario.");
            }
        }

        public bool Agregar(ref Usuario pUsuario)
        {
            try
            {
                using (BDDOCUMENTUMEntities datos = new BaseDAO().conexion())
                {
                    datos.Usuarios.AddObject(pUsuario);
                    var vResult = datos.SaveChanges();
                    if (vResult > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al registrar al usuario.");
            }
        }

        //public bool Agregar(ref Usuario pUsuario)
        //{

        //    try
        //    {
        //        string sql = "INSERT INTO Usuario VALUES (@dni,@nombre,@tipo); " +
        //                "SELECT @dni as dni";

        //        using (SqlConnection con = new SqlConnection(ObtenerCadena()))
        //        {
        //            con.Open();
        //            using (SqlCommand com = new SqlCommand(sql, con))
        //            {
        //                com.Parameters.Add(new SqlParameter("@dni", pUsuario.DNI));
        //                com.Parameters.Add(new SqlParameter("@nombre", pUsuario.Nombre));
        //                com.Parameters.Add(new SqlParameter("@tipo", pUsuario.Tipo));
        //                pUsuario.DNI = (string)com.ExecuteScalar();
        //            }
        //        }
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        public static string ObtenerCadena()
        {
            return @"Data Source=PROYDIG01\SQLSERVER2012;Initial Catalog=BDDOCUMENTUM;user id=documentumsa;password=Banbif02;";
        }


    }
}
