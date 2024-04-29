using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

namespace negocio
{
    public class AccesoDatos
    {
        // Elementos necesarios para crear una conneccion con la BBDD
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        
        public SqlDataReader Lector 
        {
            get {return lector;}
        }


        // Setear la coneccion con la BBDD y declarar el comando
        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true");
            comando = new SqlCommand();
        }


        public void setearConsulta(string consulta) 
        {
            // Define el tipo de comando
            comando.CommandType = System.Data.CommandType.Text;
            // una vez definido el tipo de comando (Texto) se estable el comando
            comando.CommandText = consulta;
        }

        //Creamos un metodo para setear el procedimiento almacenado en la base de datos
        public void setearProcedimiento(string sp) 
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }

        // Se abre la coneccion y se ejecuta una lectura que solo sirve para leer la BBDD aunque suene redundante
        public void ejecutarLectura() 
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Se establecen comandos que no necesariamente son lectura a la BBDD tal como agregar un elemente o eliminar un elemento
        public void ejecutarAccion() 
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // Se establece un metodo para setear parametros
        public void setearParametros(string nombre, object valor) 
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void cerrarConexion() 
        {
            if (lector != null)
            {
                lector.Close();
            }
            conexion.Close();
        }

    }
    
}
