using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STDServices.Persistencia
{
    public class ConexionUtil
    {
        public static string obtenerCadena()
        {
            return @"Data Source=PROYDIG01\SQLSERVER2012;Initial Catalog=BDDOCUMENTUM;Persist Security Info=True;User ID=documentumsa;Password=Banbif02";
        }
    }
}