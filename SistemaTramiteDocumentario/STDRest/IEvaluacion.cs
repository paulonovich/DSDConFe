﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using STDDatos;

namespace STDRest
{
        [ServiceContract]
        public interface IEvaluacion
        {
            [OperationContract]
            [WebInvoke(Method = "PUT", UriTemplate = "Evaluacion", ResponseFormat = WebMessageFormat.Json)]
            STDDatos.Expediente Actualizar(STDDatos.Expediente expedienteModificado);

            [OperationContract]
            [WebInvoke(Method = "GET", UriTemplate = "Evaluacion/{codigo}", ResponseFormat = WebMessageFormat.Json)]
            Evaluacion Obtener(string codigo);

            [OperationContract]
            [WebInvoke(Method = "GET", UriTemplate = "Evaluacion", ResponseFormat = WebMessageFormat.Json)]
            List<STDDatos.Evaluacion> Listar();
        }

}
