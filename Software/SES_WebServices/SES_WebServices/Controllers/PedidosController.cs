using System;
using System.Collections.Generic;
using CapaDeDatos;
using System.Web.Mvc;
using System.Data;
using System.ServiceModel;

namespace SES_WebServices
{
    [System.ServiceModel.ServiceBehavior(
        IncludeExceptionDetailInFaults = true)]
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
        public ActionResult PedidosDetallesInsidenciasSel(int PedidosId)
        {
            String cadena = "";
            WEB_Pedidos q = new WEB_Pedidos();
            q.PedidosId = PedidosId;
            q.MtdSelectPedidoDetallesInsidenciasProveedor();
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
        public ActionResult PedidosNombreProveedor(int PedidosId)
        {
            String cadena = "";
            WEB_Pedidos q = new WEB_Pedidos();
            q.PedidosId = PedidosId;
            q.MtdSelectPedidoNombreProveedor();
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
        public ActionResult PedidosSurtido(int PedidosId,int PedidosSurtido)
        {
            String cadena = "";
            WEB_Pedidos q = new WEB_Pedidos();
            q.PedidosId = PedidosId;
            q.PedidosSurtido = PedidosSurtido;
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
        [System.Web.Mvc.HttpGet]
        public ActionResult PedidosDeleteInsidencias(int PedidosId, string ArticuloCodigo)
        {
            String cadena = "";
            CLS_Pedidos q = new CLS_Pedidos();
            q.PedidosId = PedidosId;
            q.ArticuloCodigo = ArticuloCodigo;
            q.MtdEliminarInsidencia();
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
