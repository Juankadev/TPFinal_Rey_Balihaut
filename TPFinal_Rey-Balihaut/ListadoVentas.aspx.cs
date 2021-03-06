using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPFinal_Rey_Balihaut
{
    public partial class ListadoVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("Login.aspx", false);
                }

                if (!IsPostBack)
                {
                    VentaNegocio negocio_venta = new VentaNegocio();
                    gvVentas.DataSource = negocio_venta.listar();
                    gvVentas.DataBind();

                    ClienteNegocio negocio_cliente = new ClienteNegocio();
                    ddlclientes.DataSource = negocio_cliente.listar();
                    ddlclientes.DataTextField = "Apellido";
                    ddlclientes.DataValueField = "DNI";
                    ddlclientes.DataBind();

                    total.Text = "$" + String.Format("{0:0.00}", negocio_venta.total());

                    promedio.Text = "$" + String.Format("{0:0.00}", negocio_venta.promedio());

                    CompraNegocio negocio_compra = new CompraNegocio();
                    ganancia.Text = "$" + String.Format("{0:0.00}", negocio_venta.total() - negocio_compra.total());
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void gvVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var numSelected = gvVentas.SelectedDataKey.Value.ToString();
                Response.Redirect("RegistroVenta.aspx?num=" + numSelected,false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void gvVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvVentas.PageIndex = e.NewPageIndex;
                gvVentas.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void ddlclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                VentaNegocio negocio_venta = new VentaNegocio();
                gvVentas.DataSource = negocio_venta.listarxcliente(ddlclientes.SelectedValue);
                gvVentas.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }


        protected void btnfiltro_Click(object sender, EventArgs e)
        {
            try
            {
                VentaNegocio venta_negocio = new VentaNegocio();

                if (tboxmin.Text != "" && tboxmax.Text != "")
                {
                    decimal min = decimal.Parse(tboxmin.Text);
                    decimal max = decimal.Parse(tboxmax.Text);
                    gvVentas.DataSource = venta_negocio.listarxrango(min, max);
                }
                else if (tboxmin.Text != "" && tboxmax.Text == "")
                {
                    decimal min = decimal.Parse(tboxmin.Text);
                    gvVentas.DataSource = venta_negocio.listarxmin(min);
                }
                else if (tboxmin.Text == "" && tboxmax.Text != "")
                {
                    decimal max = decimal.Parse(tboxmax.Text);
                    gvVentas.DataSource = venta_negocio.listarxmax(max);
                }
                else
                {
                    gvVentas.DataSource = venta_negocio.listar();
                }
                gvVentas.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }


        protected void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment;filename=Ventas.xls");
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.xls";

                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

                gvVentas.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}



