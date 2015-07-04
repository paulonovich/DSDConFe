using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaTramiteDocumentario.Entidad
{
    public class Expediente
    {
        public int IdExpediente { get; set; }
        public String CodExpediente { get; set; }
        public String CodSUT { get; set; }
        public String DesRequisito { get; set; }
        public String DesExpediente { get; set; }
        public String Estado { get; set; }
    }
}