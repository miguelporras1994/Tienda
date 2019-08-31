using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace formulario
{
    class Conexion
    {
        SqlConnection Conectar;
        SqlCommand Db;
        SqlDataReader lectura;


        public Conexion()
        {

            Conectar = new SqlConnection("data source=HP-DL360;initial catalog=Doxa;user id=sa;password=@nim@ls.Ltd@;MultipleActiveResultSets=True;App=EntityFramework");
            Conectar.Open();
        }

    }
}
