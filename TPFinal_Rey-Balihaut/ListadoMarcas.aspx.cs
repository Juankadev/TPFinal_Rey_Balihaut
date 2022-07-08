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
    public partial class Listado_Marca_Categoria : System.Web.UI.Page
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
                MarcaNegocio marca_negocio = new MarcaNegocio();
                gvMarcas.DataSource = marca_negocio.listar();
                gvMarcas.DataBind();
            }
        }

        protected void gvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var codigoSelected = gvMarcas.SelectedDataKey.Value.ToString();
            Response.Redirect("Marcas.aspx?id=" + codigoSelected);
        }

        protected void buscador_TextChanged(object sender, EventArgs e)
        {
            MarcaNegocio marca_negocio = new MarcaNegocio();
            if (buscador.Text != "")
            {
                gvMarcas.DataSource = marca_negocio.listarxtexto(buscador.Text);
            }
            else
            {
                gvMarcas.DataSource = marca_negocio.listar();
            }
            gvMarcas.DataBind();
        }


        protected void btnExcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=Marcas.xls");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.xls";

            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            gvMarcas.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}