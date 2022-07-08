﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPFinal_Rey_Balihaut
{
    public partial class ListadoProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }
            else if (Session["tipo"].ToString() != "ADMIN")
            {
                Response.Redirect("Default.aspx", false);
            }

            if(!IsPostBack)
            {
                ProveedorNegocio proveedor_negocio = new ProveedorNegocio();
                gvProveedores.DataSource = proveedor_negocio.listar();
                gvProveedores.DataBind();
            }
        }

        protected void gvProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            var codigoSelected = gvProveedores.SelectedDataKey.Value.ToString();
            Response.Redirect("Proveedores.aspx?id=" + codigoSelected);
        }


        protected void buscador_TextChanged(object sender, EventArgs e)
        {
            ProveedorNegocio proveedor_negocio = new ProveedorNegocio();
            if (buscador.Text != "")
            {
                gvProveedores.DataSource = proveedor_negocio.listarxtexto(buscador.Text);
            }
            else
            {
                gvProveedores.DataSource = proveedor_negocio.listar();
            }
            gvProveedores.DataBind();
        }



        protected void btnExcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=Proveedores.xls");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";

            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            gvProveedores.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}