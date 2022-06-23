﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListadoArticulos.aspx.cs" Inherits="TPFinal_Rey_Balihaut.ListadoArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="text-align:center">Tus Articulos</h1>

    <a href="Articulos.aspx" class="btn btn-primary btn-lg btnlogin" style="width:20%; margin:20px auto">Nuevo Articulo</a>

    <asp:GridView ID="gvArticulos" OnSelectedIndexChanged="gvArticulos_SelectedIndexChanged" CssClass="table table-bordered" DataKeyNames="Codigo" style="color:#fff" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Código" DataField="Codigo"/>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
            <asp:BoundField HeaderText="Marca" DataField="Marca.DescripcionMarca"/>
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.DescripcionCategoria"/>
            <asp:BoundField HeaderText="Precio" DataField="Precio"/>
            <asp:BoundField HeaderText="Proveedor" DataField="Proveedor.Nombre"/>
            <asp:BoundField HeaderText="Stock Minimo" DataField="StockMinimo"/>
            <asp:BoundField HeaderText="Stock Actual" DataField="StockActual"/>
            <asp:BoundField HeaderText="Porcentaje Ganancia" DataField="PorcentajeGanancia"/>

            <asp:CommandField ShowSelectButton="true" SelectText="Modificar" HeaderText="Accion"/>
            <asp:CommandField ShowSelectButton="true" SelectText="Eliminar" HeaderText="Accion" />
        </Columns>
    </asp:GridView>

</asp:Content>
