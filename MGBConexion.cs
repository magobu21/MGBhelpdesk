using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MGBLogicaHelpdesk
{
    public class MGBConexion
    {
        private string sentenciaSQL1;
        private string sentenciaSQL2;
        System.Data.OleDb.OleDbConnection conn;
        System.Data.OleDb.OleDbTransaction miTran;

        private string mensaje;

        public string GestMensaje
        {
            get { return mensaje; }
        }


        public conexion()
        {
            conn = new System.Data.OleDb.OleDbConnection(); // Se hace una instancia de la clase OleDbConnection
            //conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\ProgramacionObjetos27Abril2015\AplicacionConConsultasyRetorno\AppCompletaBD27AbrilConsultas\SoluionClienteYJC\persistenciaYJC\BDcliente.accdb";
            //conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Informatica\AppCompletaBD27AbrilConsultas\BDcliente.accdb";
            //Microsoft.Jet.OLEDB.4.0
            //Persist Security Info=False;User ID=*****;Password=*****;Initial Catalog=AdventureWorks;Server=MySqlServer
            conn.ConnectionString = @"Provider=SQLNCLI11;Data Source=FALCON;User ID=sa;Password=VVmsprst21;Initial Catalog=Ventas;Persist Security Info=False;";
            //Provider=SQLNCLI11;Data Source=LABING50611\TEW_SQLEXPRESS;User ID=sa;Initial Catalog=VentasSQL
            //           conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Informatica\AppCompletaBD27AbrilConsultas\SoluionClienteYJC\persistenciaYJC\BDclienteVerAnterior.mdb";
            // se asigna a la cadena de conexion (Propiedad ConnectionString) los valores de los parámetros de conexión: Driver y Ruta Base de datos
            //  conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Yeisonn\Documents\UD\ArqutecturaDatosServWeb\cliente\BDcliente.accbd";

            //conn.DataSource = "BDEjemplo";
        }

        public void SetSentencia1(string s1)
        {
            sentenciaSQL1 = s1;
        }
        public void SetSentencia2(string s2)
        {
            sentenciaSQL2 = s2;
        }
        public String EjecutarSQL2()
        {

            try
            {
                System.Data.OleDb.OleDbCommand miComando = new System.Data.OleDb.OleDbCommand();
                //conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Yeisonn\Documents\UD\ArqutecturaDatosServWeb\cliente\BDcliente.accbd";
                miComando.Connection = conn; // Se pasa la cadena conexion al Comando
                conn.Open();
                //System.Data.OleDb.OleDbCommand miComando = conn.CreateCommand(); // Creación de un Objeto de tipo comando
                // Objeto de tipo transacción
                miTran = conn.BeginTransaction(); //ok Prueba con Bloqueos
                miComando.Connection = conn; // Se pasa el nombre de la conexion al Objeto Comando
                miComando.Transaction = miTran; // SE pasa el nombre de la transaccion al objeto Comando
                miComando.CommandText = sentenciaSQL1;
                miComando.ExecuteNonQuery();
                miComando.CommandText = sentenciaSQL2;
                miComando.ExecuteNonQuery();
                miTran.Commit(); // Dejamos en firme
                return "Todo OK";
            }
            catch (Exception e)
            {
                miTran.Rollback();
                return "Se presento el siguiente error " + e.Message;
            }
            finally
            {
                conn.Close();
                //return ""+e.Message; 
            }
        }
        //miConexion=new Clases.Conexion(Application.StartupPath);
        // IMPORTANTE PARA RUTA DE BASES DE DATOS
        public System.Data.DataSet Consultar()
        {
            try
            {
                conn.Open();
                System.Data.OleDb.OleDbDataAdapter objRes;
                objRes = new System.Data.OleDb.OleDbDataAdapter(sentenciaSQL1, conn);
                System.Data.DataSet datos;
                datos = new System.Data.DataSet();
                objRes.Fill(datos, "Tabla");
                mensaje = "Todo OK";
                return datos;
            }
            catch (Exception MiExc)
            {
                System.Data.DataSet datos2;
                datos2 = new System.Data.DataSet();
                mensaje = "Se presento el Siguiente Error " + MiExc.Message;
                return datos2;

            }
            finally
            {
                conn.Close();
            }
        }

        public String EjecutarSQL1()
        {

            try
            {
                System.Data.OleDb.OleDbCommand miComando = new System.Data.OleDb.OleDbCommand();
                //conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\SistInfArauca\Prototipo\prueba\prueba.mdb;"; //Colocar la base en C:\
                miComando.Connection = conn;
                conn.Open();

                //System.Data.OleDb.OleDbCommand miComando = conn.CreateCommand(); // Creación de un Objeto de tipo comando
                // Objeto de tipo transacción
                miTran = conn.BeginTransaction(); //ok Prueba con Bloqueos
                miComando.Connection = conn; // Se pasa el nombre de la conexion al Objeto Comando
                miComando.Transaction = miTran; // SE pasa el nombre de la transaccion al objeto Comando
                miComando.CommandText = sentenciaSQL1;
                //miComando.ExecuteNonQuery();
                //miComando.CommandText = sentenciaSQL2;
                miComando.ExecuteNonQuery();
                miTran.Commit(); // Dejamos en firme
                return "Todo OK";
            }
            catch (Exception e)
            {
                miTran.Rollback();
                return "Se presento el siguiente error " + e.Message;
            }
            finally
            {
                conn.Close();
                //return ""+e.Message; 
            }
        }
    }


}
