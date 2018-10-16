using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data;
using System.Collections;

namespace DATA
{
    public class dataBodega
    {
        public string Conexion()
        {
            string cadena_conexion = "DRIVER={MySQL ODBC 3.51 Driver};" + "SERVER=localhost;" + "DATABASE=logistica_bd;" + "UID=root;" + "PASSWORD=;";
            return cadena_conexion;

        }

        //crear bodega
        public bool createBodega(string nombre, int tipo, int encargado, string ubicacion, int estado)
        {

            //OdbcConnection conn;

            try
            {
                using (var conn = new OdbcConnection(Conexion()))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "INSERT INTO bodega VALUES('','" + nombre + "','" + tipo + "','" + encargado + "','" + ubicacion + "','" + estado + "')";
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //modificar
        public bool updateBodega(int cod, string nombre, int tipo, int encargado, string ubicacion, int estado)
        {
            try
            {
                using (var conn = new OdbcConnection(Conexion()))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {

                        cmd.CommandText = "UPDATE bodega SET bode_nombre = '" + nombre + "', bode_tipo = '" + tipo + "', bode_encargado = '" + encargado + "', bode_ubicacion = '" + ubicacion + "', bode_estado = '" + estado + "' WHERE bode_codigo = '" + cod + "'";
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        //Encargados


        //GET MODULOS
        public DataTable getEncargados()
        {
            DataTable dt = new DataTable();

            try
            {
                using (var conn = new OdbcConnection(Conexion()))
                {
                    OdbcDataReader dr;
                    conn.Open();
                    {
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "SELECT * FROM encargado_bodega";
                            dt.Columns.Add("name");
                            dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                DataRow row = dt.NewRow();
                                row["name"] = dr["nombre"];
                                dt.Rows.Add(row);
                            }

                            dr.Close();
                            conn.Close();
                            return dt;

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                return dt;
            }
        }



        //GET TIPO
        public DataTable getTipo()
        {
            DataTable dt = new DataTable();

            try
            {
                using (var conn = new OdbcConnection(Conexion()))
                {
                    OdbcDataReader dr;
                    conn.Open();
                    {
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "SELECT * FROM tipo_bodega";
                            dt.Columns.Add("name");
                            dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                DataRow row = dt.NewRow();
                                row["name"] = dr["tipo_bodega_nombre"];
                                dt.Rows.Add(row);
                            }

                            dr.Close();
                            conn.Close();
                            return dt;

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                return dt;
            }
        }


        //BUSCAR COD TIPO
        public int CodTipo(string nom)
        {
            OdbcDataReader dr = null;
            int cod = 0;

            try
            {
                using (var conn = new OdbcConnection(Conexion()))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT tipo_bodega_codigo FROM tipo_bodega WHERE tipo_bodega_nombre = '" + nom + "'";
                        dr = cmd.ExecuteReader();
                        dr.Read();

                        cod = Convert.ToInt32(dr["tipo_bodega_codigo"].ToString());

                        dr.Close();
                        conn.Close();
                        return cod;
                    }

                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        //BUSCAR NOMBRE TIPO
        public string nameTipo(int ID)
        {
            OdbcDataReader dr = null;
            string name = "";

            try
            {
                using (var conn = new OdbcConnection(Conexion()))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT tipo_bodega_nombre FROM tipo_bodega WHERE tipo_bodega_codigo = '" + ID + "'";
                        dr = cmd.ExecuteReader();
                        dr.Read();

                        name = dr["tipo_bodega_nombre"].ToString();

                        dr.Close();
                        conn.Close();
                        return name;
                    }

                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }


        //BUSCAR NOMBRE ENCARGADO
        public string nameEncargado(int ID)
        {
            OdbcDataReader dr = null;
            string name = "";

            try
            {
                using (var conn = new OdbcConnection(Conexion()))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT nombre FROM encargado_bodega WHERE encargado_empleado_codigo = '" + ID + "'";
                        dr = cmd.ExecuteReader();
                        dr.Read();

                        name = dr["nombre"].ToString();

                        dr.Close();
                        conn.Close();
                        return name;
                    }

                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }


        //BUSCAR COD ENCARGADO
        public int CodEncargado(string nom)
        {
            OdbcDataReader dr = null;
            int cod = 0;

            try
            {
                using (var conn = new OdbcConnection(Conexion()))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT encargado_empleado_codigo FROM encargado_bodega WHERE nombre = '" + nom + "'";
                        dr = cmd.ExecuteReader();
                        dr.Read();

                        cod = Convert.ToInt32(dr["encargado_empleado_codigo"].ToString());

                        dr.Close();
                        conn.Close();
                        return cod;
                    }

                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }



        //GET BODEGAS
        public DataTable getBodegas()
        {

            OdbcDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                using (var conn = new OdbcConnection(Conexion()))
                {

                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        dt.Columns.Add("codigo");
                        dt.Columns.Add("nombre");
                        dt.Columns.Add("tipo");
                        dt.Columns.Add("encargado");
                        dt.Columns.Add("ubicacion");
                        dt.Columns.Add("estado");
                        cmd.CommandText = "SELECT * FROM bodega";
                        dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            DataRow row = dt.NewRow();

                            row["codigo"] = dr["bode_codigo"];
                            row["nombre"] = dr["bode_nombre"];
                            row["tipo"] = nameTipo(Convert.ToInt32(dr["bode_tipo"].ToString()));
                            row["encargado"] = nameEncargado(Convert.ToInt32(dr["bode_encargado"].ToString()));
                            row["ubicacion"] = dr["bode_ubicacion"];
                            if (Convert.ToInt32(dr["bode_estado"].ToString()) == 1)
                            {
                                row["estado"] = "ACTIVO";
                            }
                            else
                            {
                                row["estado"] = "INACTIVO";
                            }



                            dt.Rows.Add(row);
                        }
                        dr.Read();
                        conn.Close();
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                return dt;
            }
        }




        //FILTRO BODEGA
        public DataTable filtBodegas(string name)
        {

            OdbcDataReader dr = null;
            DataTable dt = new DataTable();

            try
            {
                using (var conn = new OdbcConnection(Conexion()))
                {
                    string format = name + "%";

                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        dt.Columns.Add("codigo");
                        dt.Columns.Add("nombre");
                        dt.Columns.Add("tipo");
                        dt.Columns.Add("encargado");
                        dt.Columns.Add("ubicacion");
                        dt.Columns.Add("estado");
                        cmd.CommandText = "SELECT * FROM bodega WHERE bode_nombre LIKE '" + format + "'";
                        dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            DataRow row = dt.NewRow();

                            row["codigo"] = dr["bode_codigo"];
                            row["nombre"] = dr["bode_nombre"];
                            row["tipo"] = dr["bode_tipo"];
                            row["encargado"] = dr["bode_encargado"];
                            row["ubicacion"] = dr["bode_ubicacion"];
                            row["estado"] = dr["bode_estado"];
                            dt.Rows.Add(row);
                        }
                        dr.Read();
                        conn.Close();
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                return dt;
            }
        }
    }
}

//KEVIN RICARDO
