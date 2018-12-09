using System;
using System.Collections.Generic;
using CapaDeDatos;
using System.Web.Mvc;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SES_WebServices.Controllers
{
    public class EmailController : Controller
    {
        string key = "BSC-Reportes";
        public List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        // GET: api/Pedidos
        [System.Web.Mvc.HttpGet]
        public ActionResult CuentaEmail()
        {
            string cadena = string.Empty;
            CLS_Correos ParmGen = new CLS_Correos();
            ParmGen.MtdSeleccionar();
            if (ParmGen.Exito)
            {
                GetJson(ParmGen.Datos);
                return Json(rows, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(cadena, JsonRequestBehavior.AllowGet);
            }
        }
        [System.Web.Mvc.HttpGet]
        public ActionResult DestinoEmail()
        {
            string cadena = string.Empty;
            CLS_Correos ParmGen = new CLS_Correos();
            ParmGen.MtdSeleccionarCorreosDestino();
            if (ParmGen.Exito)
            {
                GetJson(ParmGen.Datos);
                return Json(rows, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(cadena, JsonRequestBehavior.AllowGet);
            }
        }
        public void GetJson(DataTable dt)
        {
            Dictionary<string, object> row;

            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();

                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }

                rows.Add(row);
            }
        }
    }
}
