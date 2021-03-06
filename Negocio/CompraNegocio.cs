using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Negocio
{
    public class CompraNegocio
    {

        public List<_Compra> listar()
        {
            List<_Compra> lista = new List<_Compra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select NUM_COMPRA, COD_PROVEEDOR, P.NOMBRE_PROVEEDOR, TOTAL, C.FECHA FROM COMPRAS C INNER JOIN PROVEEDORES P ON C.COD_PROVEEDOR = P.CUIT order by NUM_COMPRA desc");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    _Compra aux = new _Compra();
                    aux.Proveedor = new _Proveedor2();

                    aux.numcompra = (int)datos.Lector["NUM_COMPRA"];
                    aux.Proveedor.CUIT = (string)datos.Lector["COD_PROVEEDOR"];
                    aux.Proveedor.Nombre = (string)datos.Lector["NOMBRE_PROVEEDOR"];
                    aux.Total = (Decimal)datos.Lector["TOTAL"];
                    aux.Fecha = (DateTime)datos.Lector["FECHA"];

                    lista.Add(aux);
                }

                return lista;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                datos.cerrarConexion();
            }

        }


        public _Compra listarxnum(int buscado)
        {
            List<_Compra> lista = new List<_Compra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select C.NUM_COMPRA, C.COD_PROVEEDOR, P.NOMBRE_PROVEEDOR, C.TOTAL, C.FECHA, D.OBSERVACIONES, D.CONDICION_PAGO FROM COMPRAS C INNER JOIN PROVEEDORES P ON C.COD_PROVEEDOR = P.CUIT INNER JOIN DETALLE_COMPRA D ON D.DETALLE_COMPRA = C.NUM_COMPRA WHERE C.NUM_COMPRA = @BUSCADO");
                datos.setearParametro("@BUSCADO", buscado);
                datos.ejecutarLectura();

                _Compra aux = new _Compra();
                aux.Proveedor = new _Proveedor2();

                while (datos.Lector.Read())
                {
                    aux.numcompra = (int)datos.Lector["NUM_COMPRA"];
                    aux.Proveedor.CUIT = (string)datos.Lector["COD_PROVEEDOR"];
                    aux.Proveedor.Nombre = (string)datos.Lector["NOMBRE_PROVEEDOR"];
                    aux.Total = (Decimal)datos.Lector["TOTAL"];
                    aux.Fecha = (DateTime)datos.Lector["FECHA"];
                    aux.Observaciones = (string)datos.Lector["OBSERVACIONES"];
                    aux.Condicion = (string)datos.Lector["CONDICION_PAGO"];
                }

                return aux;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                datos.cerrarConexion();
            }

        }



        public List<_Compra> listarxproveedor(string cuit)
        {
            List<_Compra> lista = new List<_Compra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select NUM_COMPRA, COD_PROVEEDOR, P.NOMBRE_PROVEEDOR, TOTAL, C.FECHA FROM COMPRAS C INNER JOIN PROVEEDORES P ON C.COD_PROVEEDOR = P.CUIT where P.CUIT=@CUIT order by NUM_COMPRA desc");
                datos.setearParametro("@CUIT",cuit);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    _Compra aux = new _Compra();
                    aux.Proveedor = new _Proveedor2();

                    aux.numcompra = (int)datos.Lector["NUM_COMPRA"];
                    aux.Proveedor.CUIT = (string)datos.Lector["COD_PROVEEDOR"];
                    aux.Proveedor.Nombre = (string)datos.Lector["NOMBRE_PROVEEDOR"];
                    aux.Total = (Decimal)datos.Lector["TOTAL"];
                    aux.Fecha = (DateTime)datos.Lector["FECHA"];

                    lista.Add(aux);
                }

                return lista;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                datos.cerrarConexion();
            }

        }



        public List<_Compra> listarxmin(decimal min)
        {
            List<_Compra> lista = new List<_Compra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select NUM_COMPRA, COD_PROVEEDOR, P.NOMBRE_PROVEEDOR, TOTAL, C.FECHA FROM COMPRAS C INNER JOIN PROVEEDORES P ON C.COD_PROVEEDOR = P.CUIT where total >= @min");
                datos.setearParametro("@min", min);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    _Compra aux = new _Compra();
                    aux.Proveedor = new _Proveedor2();

                    aux.numcompra = (int)datos.Lector["NUM_COMPRA"];
                    aux.Proveedor.CUIT = (string)datos.Lector["COD_PROVEEDOR"];
                    aux.Proveedor.Nombre = (string)datos.Lector["NOMBRE_PROVEEDOR"];
                    aux.Total = (Decimal)datos.Lector["TOTAL"];
                    aux.Fecha = (DateTime)datos.Lector["FECHA"];

                    lista.Add(aux);
                }

                return lista;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                datos.cerrarConexion();
            }

        }

        public List<_Compra> listarxmax(decimal max)
        {
            List<_Compra> lista = new List<_Compra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select NUM_COMPRA, COD_PROVEEDOR, P.NOMBRE_PROVEEDOR, TOTAL, C.FECHA FROM COMPRAS C INNER JOIN PROVEEDORES P ON C.COD_PROVEEDOR = P.CUIT where total <= @max");
                datos.setearParametro("@max", max);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    _Compra aux = new _Compra();
                    aux.Proveedor = new _Proveedor2();

                    aux.numcompra = (int)datos.Lector["NUM_COMPRA"];
                    aux.Proveedor.CUIT = (string)datos.Lector["COD_PROVEEDOR"];
                    aux.Proveedor.Nombre = (string)datos.Lector["NOMBRE_PROVEEDOR"];
                    aux.Total = (Decimal)datos.Lector["TOTAL"];
                    aux.Fecha = (DateTime)datos.Lector["FECHA"];

                    lista.Add(aux);
                }

                return lista;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                datos.cerrarConexion();
            }

        }

        public List<_Compra> listarxrango(decimal min, decimal max)
        {
            List<_Compra> lista = new List<_Compra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select NUM_COMPRA, COD_PROVEEDOR, P.NOMBRE_PROVEEDOR, TOTAL, C.FECHA FROM COMPRAS C INNER JOIN PROVEEDORES P ON C.COD_PROVEEDOR = P.CUIT where total between @min and @max");
                datos.setearParametro("@min", min);
                datos.setearParametro("@max", max);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    _Compra aux = new _Compra();
                    aux.Proveedor = new _Proveedor2();

                    aux.numcompra = (int)datos.Lector["NUM_COMPRA"];
                    aux.Proveedor.CUIT = (string)datos.Lector["COD_PROVEEDOR"];
                    aux.Proveedor.Nombre = (string)datos.Lector["NOMBRE_PROVEEDOR"];
                    aux.Total = (Decimal)datos.Lector["TOTAL"];
                    aux.Fecha = (DateTime)datos.Lector["FECHA"];

                    lista.Add(aux);
                }

                return lista;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                datos.cerrarConexion();
            }

        }

        public void agregar(_Compra nuevaCompra)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string prueba = DateTime.Now.ToString("yyyy-MM-dd");
                datos.setearConsulta("INSERT INTO COMPRAS (COD_PROVEEDOR,TOTAL,FECHA) VALUES ('" + nuevaCompra.Proveedor.CUIT + "','" + nuevaCompra.Total + "','" + prueba + "' )");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void agregarDetalle(_Compra nuevaCompra, Agregados agregado)
        {
            AccesoDatos datos = new AccesoDatos();
            int num = ultimoNumCompra();
            try
            {
                datos.setearConsulta("INSERT INTO DETALLE_COMPRA (DETALLE_COMPRA, COD_PRODUCTO, CANTIDAD, PRECIO_COMPRA, OBSERVACIONES, CONDICION_PAGO) VALUES ('" + num + "','" + agregado.Codigo + "','" + agregado.Cantidad + "','" + agregado.Precio + "','" + nuevaCompra.Observaciones + "','" + nuevaCompra.Condicion + "' )");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Agregados> listarDetalleProducto(int buscado)
        {
            List<Agregados> lista = new List<Agregados>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT P.NOMBRE,D.CANTIDAD,D.PRECIO_COMPRA FROM DETALLE_COMPRA D INNER JOIN PRODUCTOS P ON D.COD_PRODUCTO = P.CODIGO WHERE DETALLE_COMPRA = @BUSCADO");
                datos.setearParametro("@BUSCADO", buscado);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Agregados aux = new Agregados();
                    //aux.Proveedor = new _Proveedor2();

                    aux.Nombre = (string)datos.Lector["NOMBRE"];
                    aux.Cantidad = (int)datos.Lector["CANTIDAD"];
                    aux.Precio = (decimal)datos.Lector["PRECIO_COMPRA"];

                    lista.Add(aux);
                }

                return lista;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                datos.cerrarConexion();
            }

        }


        public int ultimoNumCompra()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT NUM_COMPRA FROM COMPRAS WHERE NUM_COMPRA = (SELECT max(NUM_COMPRA) FROM COMPRAS)");
                datos.ejecutarLectura();

                int num = 1;
                while (datos.Lector.Read())
                {
                    num = (int)datos.Lector["NUM_COMPRA"];
                }

                return num;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



        public void aumentarStock(Agregados agregado)
        {
            AccesoDatos datos = new AccesoDatos();

            //buscar el producto con el id del agregado y obtener el stock
            ProductoNegocio negocio = new ProductoNegocio();
            List<_Producto> lista = negocio.listar();
            _Producto producto = lista.Find(x => x.Codigo == agregado.Codigo);

            try
            {
                datos.setearConsulta("UPDATE PRODUCTOS SET STOCK_ACTUAL = @STOCK WHERE CODIGO = @CODIGO;");
                datos.setearParametro("@STOCK", producto.StockActual + agregado.Cantidad);
                datos.setearParametro("@CODIGO", agregado.Codigo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                //el producto ya existe
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void setearPrecio(Agregados agregado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE PRODUCTOS SET PRECIO = @PRECIO WHERE CODIGO = @CODIGO;");
                datos.setearParametro("@PRECIO", agregado.Precio);
                datos.setearParametro("@CODIGO", agregado.Codigo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                //el producto ya existe
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void setearPrecioVenta(Agregados agregado)
        {
            AccesoDatos datos = new AccesoDatos();

            //buscar el producto con el id del agregado y obtener el porcentaje
            ProductoNegocio negocio = new ProductoNegocio();
            List<_Producto> lista = negocio.listar();
            _Producto producto = lista.Find(x => x.Codigo == agregado.Codigo);

            try
            {
                datos.setearConsulta("UPDATE PRODUCTOS SET PRECIO_VENTA = @PRECIOVENTA WHERE CODIGO = @CODIGO;");
                datos.setearParametro("@PRECIOVENTA", agregado.Precio + (agregado.Precio * (producto.PorcentajeGanancia / 100)));
                datos.setearParametro("@CODIGO", agregado.Codigo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                //el producto ya existe
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public bool existeCompra(string buscado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select COD_PRODUCTO from DETALLE_COMPRA WHERE COD_PRODUCTO=@BUSCADO");
                datos.setearParametro("@BUSCADO", buscado);
                datos.ejecutarLectura();

                return datos.Lector.Read();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                datos.cerrarConexion();
            }

        }

        public decimal total()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //ver si hay registros
                datos.setearConsulta("select total from compras");
                datos.ejecutarLectura();

                decimal total = 0;
                if (datos.Lector.Read())
                {
                    datos.cerrarConexion();

                    datos.setearConsulta("select SUM(total) AS TOTAL from compras");
                    datos.ejecutarLectura();
                    while (datos.Lector.Read())
                    {
                        total = (decimal)datos.Lector["TOTAL"];
                    }
                }
                return total;


            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
