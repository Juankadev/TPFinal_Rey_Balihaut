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
    public partial class Altas1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MarcaNegocio marca_negocio = new MarcaNegocio();
                ddlmarca.DataSource = marca_negocio.listar();
                ddlmarca.DataValueField = "IDMarca";
                ddlmarca.DataTextField = "DescripcionMarca";
                ddlmarca.DataBind();

                CategoriaNegocio categoria_negocio = new CategoriaNegocio();
                ddlcategoria.DataSource = categoria_negocio.listar();
                ddlcategoria.DataValueField = "IDCategoria";
                ddlcategoria.DataTextField = "DescripcionCategoria";
                ddlcategoria.DataBind();

                _ProveedorNegocio proveedor_negocio = new _ProveedorNegocio();
                ddlproveedor.DataSource = proveedor_negocio.listar();
                ddlproveedor.DataValueField = "CUIT";
                ddlproveedor.DataTextField = "Nombre";
                ddlproveedor.DataBind();


                if (Request.QueryString["id"] != null)
                {
                    codigo.ReadOnly = true;
                    string codigoURL = Request.QueryString["id"].ToString();

                    ProductoNegocio negocio = new ProductoNegocio();
                    List<_Producto> lista = negocio.listar();
                    _Producto producto = lista.Find(x => x.Codigo == codigoURL);

                    codigo.Text = producto.Codigo;
                    nombre.Text = producto.Nombre;
                    ddlmarca.SelectedIndex = producto.Marca.IDMarca;
                    ddlcategoria.SelectedIndex = producto.Categoria.IDCategoria;
                    //ddlproveedor.SelectedIndex = producto.Proveedor.;
                    //precio.Text = producto.Precio.ToString();
                    stockactual.Text = producto.StockActual.ToString();
                    stockminimo.Text = producto.StockMinimo.ToString();
                    ganancia.Text = producto.PorcentajeGanancia.ToString();
                }

            }
        }

        protected void altaArticulo_Click(object sender, EventArgs e)
        {
            ProductoNegocio producto_negocio = new ProductoNegocio();
            _Producto aux = new _Producto();
            aux.Marca = new _Marca();
            aux.Categoria = new _Categoria();
            aux.Proveedor = new _Proveedor2();

            aux.Codigo = codigo.Text;
            aux.Nombre = nombre.Text;
            aux.Marca.IDMarca = ddlmarca.SelectedIndex + 1;
            aux.Categoria.IDCategoria = ddlcategoria.SelectedIndex + 1;
            aux.Proveedor.CUIT = ddlproveedor.SelectedValue;
            aux.Precio = decimal.Parse(precio.Text);
            aux.StockActual = int.Parse(stockactual.Text);
            aux.StockMinimo = int.Parse(stockminimo.Text);
            aux.PorcentajeGanancia = int.Parse(ganancia.Text);
            producto_negocio.agregar(aux);


            codigo.Text = "";
            nombre.Text = "";
            //ddlmarca.Text = "";
            //ddlcategoria.Text = "";
            //ddlproveedor.Text = "";
            precio.Text = "";
            stockactual.Text = "";
            stockminimo.Text = "";
            ganancia.Text = "";
        }
    }
}