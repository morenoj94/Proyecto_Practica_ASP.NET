using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.ComponentModel;

namespace negocio
{
    public class PokemonNegocio
    {
        public List<Pokemon> listar()
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conecxion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conecxion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Numero, Nombre, p.Descripcion, UrlImagen, e.Descripcion as Tipo, IdTipo, d.Descripcion as Debilidad, IdDebilidad, p.Id from POKEMONS P, ELEMENTOS E, ELEMENTOS D where p.IdTipo = e.Id and p.IdDebilidad = d.Id and Activo = 1 order by Numero asc";
                comando.Connection = conecxion;


                conecxion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)lector["Id"];
                    aux.Numero = lector.GetInt32(0);
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];

                    //if(!(lector.IsDBNull(lector.GetOrdinal("UrlImagen"))))
                    //    aux.UrlImagen = (string)lector["UrlImagen"];
                    if (!(lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)lector["UrlImagen"];

                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];


                    lista.Add(aux);
                }

                conecxion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void agregarPokemon(Pokemon poke)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta($"insert into POKEMONS (Numero, Nombre, Descripcion, UrlImagen, IdTipo, IdDebilidad, Activo) values ({poke.Numero}, '{poke.Nombre}', '{poke.Descripcion}', '{poke.UrlImagen}', @idTipo, @idDebilidad, 1)");
                datos.setearParametros("@idTipo", poke.Tipo.Id);
                datos.setearParametros("@idDebilidad", poke.Debilidad.Id);
                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConeccion();
            }

        }
        public void modificarPokemon(Pokemon poke)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update POKEMONS set Numero = @Numero, Nombre = @Nombre, Descripcion = @Descripcion, UrlImagen = @UrlImagen, IdTipo = @IdTipo, IdDebilidad = @IdDebilidad ");
                datos.setearParametros("@Id", poke.Id);
                datos.setearParametros("@Numero", poke.Numero);
                datos.setearParametros("@Nombre", poke.Nombre);
                datos.setearParametros("@Descripcion", poke.Descripcion);
                datos.setearParametros("@UrlImagen", poke.UrlImagen);
                datos.setearParametros("@IdTipo", poke.Tipo.Id);
                datos.setearParametros("@IdDebilidad", poke.Debilidad.Id);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConeccion();
            }
        }
        public void eliminarPokemon(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from POKEMONS where id = @id");
                datos.setearParametros("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConeccion();
            }
        }

        public void eliminarLogico(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update POKEMONS set Activo = 0 where Id = @id");
                datos.setearParametros("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConeccion();
            }
        }

        public List<Pokemon> listarConSP()
        {
            List<Pokemon> list = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storeListar");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Numero = (int)datos.Lector["Numero"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];

                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)datos.Lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)datos.Lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];

                    list.Add(aux);
                }
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public List<Pokemon> filtrar(string campo, string criterio, string filtro)
        {
            List<Pokemon> lista = new List<Pokemon>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string condicion;
                switch (campo)
                {
                    case "Numero":
                        switch (criterio)
                        {
                            case "Mayor que":
                                condicion = $"Numero > {filtro}";
                                break;
                            case "Menor que":
                                condicion = $"Numero < {filtro}";
                                break;
                            default:
                                condicion = $"Numero = {filtro}";
                                break;
                        }
                        break;
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Que inicie con":
                                condicion = $"Nombre like '{filtro}%'";
                                break;
                            case "Que termine con":
                                condicion = $"Nombre like '%{filtro}'";
                                break;
                            default:
                                condicion = $"Nombre like '%{filtro}%'";
                                break;
                        }
                        break;
                    default:
                        switch (criterio)
                        {
                            case "Que inicie con":
                                condicion = $"p.Descripcion like '{filtro}%'";
                                break;
                            case "Que termine con":
                                condicion = $"p.Descripcion like '%{filtro}'";
                                break;
                            default:
                                condicion = $"p.Descripcion like '%{filtro}%'";
                                break;
                        }
                        break;
                }
                string consulta = $@"select Numero, Nombre, p.Descripcion, UrlImagen, e.Descripcion as Tipo, IdTipo, d.Descripcion as Debilidad, IdDebilidad, p.Id from POKEMONS P, ELEMENTOS E, ELEMENTOS D where p.IdTipo = e.Id and p.IdDebilidad = d.Id and Activo = 1 and {condicion} order by Numero asc";
                datos.setearConsulta(consulta);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Numero = datos.Lector.GetInt32(0);
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];

                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)datos.Lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)datos.Lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];


                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
