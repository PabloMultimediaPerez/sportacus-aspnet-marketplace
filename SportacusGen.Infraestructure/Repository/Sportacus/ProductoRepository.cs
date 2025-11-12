
using System;
using System.Text;
using SportacusGen.ApplicationCore.CEN.Sportacus;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using SportacusGen.ApplicationCore.EN.Sportacus;
using SportacusGen.ApplicationCore.Exceptions;
using SportacusGen.ApplicationCore.IRepository.Sportacus;
using SportacusGen.ApplicationCore.CP.Sportacus;
using SportacusGen.Infraestructure.EN.Sportacus;


/*
 * Clase Producto:
 *
 */

namespace SportacusGen.Infraestructure.Repository.Sportacus
{
public partial class ProductoRepository : BasicRepository, IProductoRepository
{
public ProductoRepository() : base ()
{
}


public ProductoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ProductoEN ReadOIDDefault (int id
                                  )
{
        ProductoEN productoEN = null;

        try
        {
                SessionInitializeTransaction ();
                productoEN = (ProductoEN)session.Get (typeof(ProductoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return productoEN;
}

public System.Collections.Generic.IList<ProductoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ProductoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ProductoEN>();
                        else
                                result = session.CreateCriteria (typeof(ProductoNH)).List<ProductoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ProductoEN producto)
{
        try
        {
                SessionInitializeTransaction ();
                ProductoNH productoNH = (ProductoNH)session.Load (typeof(ProductoNH), producto.Id);

                productoNH.Titulo = producto.Titulo;


                productoNH.Descripcion = producto.Descripcion;


                productoNH.Precio = producto.Precio;


                productoNH.Estado = producto.Estado;


                productoNH.Categoria = producto.Categoria;


                productoNH.FechaPublicacion = producto.FechaPublicacion;


                productoNH.Disponible = producto.Disponible;






                session.Update (productoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ProductoEN producto)
{
        ProductoNH productoNH = new ProductoNH (producto);

        try
        {
                SessionInitializeTransaction ();

                session.Save (productoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return productoNH.Id;
}

public void Modify (ProductoEN producto)
{
        try
        {
                SessionInitializeTransaction ();
                ProductoNH productoNH = (ProductoNH)session.Load (typeof(ProductoNH), producto.Id);

                productoNH.Titulo = producto.Titulo;


                productoNH.Descripcion = producto.Descripcion;


                productoNH.Precio = producto.Precio;


                productoNH.Estado = producto.Estado;


                productoNH.Categoria = producto.Categoria;


                productoNH.FechaPublicacion = producto.FechaPublicacion;


                productoNH.Disponible = producto.Disponible;

                session.Update (productoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                ProductoNH productoNH = (ProductoNH)session.Load (typeof(ProductoNH), id);
                session.Delete (productoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ProductoEN
public ProductoEN ReadOID (int id
                           )
{
        ProductoEN productoEN = null;

        try
        {
                SessionInitializeTransaction ();
                productoEN = (ProductoEN)session.Get (typeof(ProductoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return productoEN;
}

public System.Collections.Generic.IList<ProductoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ProductoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ProductoEN>();
                else
                        result = session.CreateCriteria (typeof(ProductoNH)).List<ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN> BuscarPorTexto (string texto)
{
        System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProductoNH self where select p from ProductoNH p where lower(p.Titulo) like: texto or lower(p.Descripcion) like: texto order by p.Titulo asc";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProductoNHbuscarPorTextoHQL");
                query.SetParameter ("texto", texto);

                result = query.List<SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN> FiltrarPorCategoria (SportacusGen.ApplicationCore.Enumerated.Sportacus.CategoriaEnum ? categoria)
{
        System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProductoNH self where select p from ProductoNH p where p.Categoria = :categoria order by p.FechaPublicacion desc";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProductoNHfiltrarPorCategoriaHQL");
                query.SetParameter ("categoria", categoria);

                result = query.List<SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN> FiltrarPorPrecio (double? minPrecio, double ? maxPrecio)
{
        System.Collections.Generic.IList<SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProductoNH self where select p from ProductoNH p where p.Precio >= :minPrecio and p.Precio <= :maxPrecio order by p.Precio asc";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProductoNHfiltrarPorPrecioHQL");
                query.SetParameter ("minPrecio", minPrecio);
                query.SetParameter ("maxPrecio", maxPrecio);

                result = query.List<SportacusGen.ApplicationCore.EN.Sportacus.ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
