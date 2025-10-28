
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
 * Clase Imagen:
 *
 */

namespace SportacusGen.Infraestructure.Repository.Sportacus
{
public partial class ImagenRepository : BasicRepository, IImagenRepository
{
public ImagenRepository() : base ()
{
}


public ImagenRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ImagenEN ReadOIDDefault (int id
                                )
{
        ImagenEN imagenEN = null;

        try
        {
                SessionInitializeTransaction ();
                imagenEN = (ImagenEN)session.Get (typeof(ImagenNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return imagenEN;
}

public System.Collections.Generic.IList<ImagenEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ImagenEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ImagenNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ImagenEN>();
                        else
                                result = session.CreateCriteria (typeof(ImagenNH)).List<ImagenEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ImagenRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ImagenEN imagen)
{
        try
        {
                SessionInitializeTransaction ();
                ImagenNH imagenNH = (ImagenNH)session.Load (typeof(ImagenNH), imagen.Id);

                imagenNH.Url = imagen.Url;


                imagenNH.Descripcion = imagen.Descripcion;


                imagenNH.FechaSubida = imagen.FechaSubida;


                session.Update (imagenNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ImagenRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ImagenEN imagen)
{
        ImagenNH imagenNH = new ImagenNH (imagen);

        try
        {
                SessionInitializeTransaction ();

                session.Save (imagenNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ImagenRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return imagenNH.Id;
}

public void Modify (ImagenEN imagen)
{
        try
        {
                SessionInitializeTransaction ();
                ImagenNH imagenNH = (ImagenNH)session.Load (typeof(ImagenNH), imagen.Id);

                imagenNH.Url = imagen.Url;


                imagenNH.Descripcion = imagen.Descripcion;


                imagenNH.FechaSubida = imagen.FechaSubida;

                session.Update (imagenNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ImagenRepository.", ex);
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
                ImagenNH imagenNH = (ImagenNH)session.Load (typeof(ImagenNH), id);
                session.Delete (imagenNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ImagenRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ImagenEN
public ImagenEN ReadOID (int id
                         )
{
        ImagenEN imagenEN = null;

        try
        {
                SessionInitializeTransaction ();
                imagenEN = (ImagenEN)session.Get (typeof(ImagenNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return imagenEN;
}

public System.Collections.Generic.IList<ImagenEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ImagenEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ImagenNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ImagenEN>();
                else
                        result = session.CreateCriteria (typeof(ImagenNH)).List<ImagenEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is SportacusGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new SportacusGen.ApplicationCore.Exceptions.DataLayerException ("Error in ImagenRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
