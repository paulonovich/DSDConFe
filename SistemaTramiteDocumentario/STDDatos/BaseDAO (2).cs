using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STDDatos
{
    public class BaseDAO
    {
        public BDDOCUMENTUMEntities conexion()
        {
            BDDOCUMENTUMEntities datos = new BDDOCUMENTUMEntities();
            datos.ContextOptions.LazyLoadingEnabled = false;
            datos.ContextOptions.ProxyCreationEnabled = false;
            return datos;
        }
    }
}
