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
        // GET: Pedidos
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
        [System.Web.Mvc.HttpGet]
        public ActionResult PedidosDetallesUpdate(int PedidosId, string ArticuloCodigo, int Surtido)
        {
            String cadena = "";
            WEB_Pedidos q = new WEB_Pedidos();
            q.PedidosId = PedidosId;
            q.ArticuloCodigo = ArticuloCodigo;
            q.Surtido = Surtido;
            q.MtdUpdatePedidoDetalleSurtido();
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
        public ActionResult Articulo(string ArticuloCodigo)
        {
            String cadena = "";
            WEB_Pedidos q = new WEB_Pedidos();
            q.ArticuloCodigo = ArticuloCodigo;
            q.MtdSelectArticulo();
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
        public ActionResult PedidosDetallesInsidencias(int PedidosId,string ArticuloCodigo,string ArticuloDescripcion,int Cantidad,string Tipo)
        {
            String cadena = "";
            WEB_Pedidos q = new WEB_Pedidos();
            q.PedidosId = PedidosId;
            q.ArticuloCodigo = ArticuloCodigo;
            q.ArticuloDescripcion = ArticuloDescripcion;
            q.Cantidad = Cantidad;
            q.Tipo = Tipo;
            q.MtdInsertPedidoDetalleInsidencias();
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
        public ActionResult PedidosSurtido(int PedidosId)
        {
            String cadena = "";
            WEB_Pedidos q = new WEB_Pedidos();
            q.PedidosId = PedidosId;
            q.MtdUpdatePedidoSurtido();
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
