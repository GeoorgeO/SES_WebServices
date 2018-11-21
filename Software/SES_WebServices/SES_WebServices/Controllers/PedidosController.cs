using System;
using System.Collections.Generic;
using CapaDeDatos;
using System.Web.Mvc;
using System.Data;

namespace SES_WebServices
{
    public class PedidosController : Controller
    {
        public List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        // GET: api/Pedidos
        [System.Web.Mvc.HttpGet]
        public ActionResult PedidosDetalles(int PedidosId)
        {
            String cadena = "";
            WEB_Pedidos q = new WEB_Pedidos();
            q.PedidosId = PedidosId;
            q.MtdSelectPedidoDetallesProveedor();
            if (q.Exito)
            {
                GetJson(q.Datos);
                return Json(rows, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(cadena, JsonRequestBehavior.AllowGet);
            }
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Pedidos()
        {
            String cadena = "";
            WEB_Pedidos q = new WEB_Pedidos();
            q.MtdSelectPedidoProveedor();
            if (q.Exito)
            {
                GetJson(q.Datos);
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
