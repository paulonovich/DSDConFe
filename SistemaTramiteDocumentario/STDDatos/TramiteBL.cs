using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STDDatos
{
    public class TramiteBl
    {
        public List<Tramite> Listar()
        {
            try
            {
                using (BDDOCUMENTUMEntities datos = new BaseDAO().conexion())
                {
                    var vResult = datos.Tramites.ToList();
                    return vResult;
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al listar los tramites.");
            }
        }    
    }
}
