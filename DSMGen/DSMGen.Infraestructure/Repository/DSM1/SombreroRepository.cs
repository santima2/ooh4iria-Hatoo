
using System;
using System.Text;
using DSMGen.ApplicationCore.CEN.DSM1;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.Exceptions;
using DSMGen.ApplicationCore.IRepository.DSM1;
using DSMGen.ApplicationCore.CP.DSM1;
using DSMGen.Infraestructure.EN.DSM1;


/*
 * Clase Sombrero:
 *
 */

namespace DSMGen.Infraestructure.Repository.DSM1
{
public partial class SombreroRepository : BasicRepository, ISombreroRepository
{
public SombreroRepository() : base ()
{
}


public SombreroRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public SombreroEN ReadOIDDefault (int idSombrero
                                  )
{
        SombreroEN sombreroEN = null;

        try
        {
                SessionInitializeTransaction ();
                sombreroEN = (SombreroEN)session.Get (typeof(SombreroNH), idSombrero);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return sombreroEN;
}

public System.Collections.Generic.IList<SombreroEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<SombreroEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(SombreroNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<SombreroEN>();
                        else
                                result = session.CreateCriteria (typeof(SombreroNH)).List<SombreroEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in SombreroRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (SombreroEN sombrero)
{
        try
        {
                SessionInitializeTransaction ();
                SombreroNH sombreroNH = (SombreroNH)session.Load (typeof(SombreroNH), sombrero.IdSombrero);

                sombreroNH.Modelo = sombrero.Modelo;


                sombreroNH.Color = sombrero.Color;


                sombreroNH.Material = sombrero.Material;


                sombreroNH.Attemporadatribute = sombrero.Attemporadatribute;


                sombreroNH.PrecioBase = sombrero.PrecioBase;


                sombreroNH.Descripcion = sombrero.Descripcion;


                sombreroNH.Nombre = sombrero.Nombre;







                sombreroNH.Stock = sombrero.Stock;

                session.Update (sombreroNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in SombreroRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (SombreroEN sombrero)
{
        SombreroNH sombreroNH = new SombreroNH (sombrero);

        try
        {
                SessionInitializeTransaction ();
                if (sombrero.Administrador != null) {
                        // Argumento OID y no colección.
                        sombreroNH
                        .Administrador = (DSMGen.ApplicationCore.EN.DSM1.AdministradorEN)session.Load (typeof(DSMGen.ApplicationCore.EN.DSM1.AdministradorEN), sombrero.Administrador.IdUsuario);

                        sombreroNH.Administrador.Sombrero
                        .Add (sombreroNH);
                }
                if (sombrero.ItemCarrito != null) {
                        // Argumento OID y no colección.
                        sombreroNH
                        .ItemCarrito = (DSMGen.ApplicationCore.EN.DSM1.ItemCarritoEN)session.Load (typeof(DSMGen.ApplicationCore.EN.DSM1.ItemCarritoEN), sombrero.ItemCarrito.Cantidad);

                        sombreroNH.ItemCarrito.Sombrero
                                = sombreroNH;
                }

                session.Save (sombreroNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in SombreroRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return sombreroNH.IdSombrero;
}

public void Modificar (SombreroEN sombrero)
{
        try
        {
                SessionInitializeTransaction ();
                SombreroNH sombreroNH = (SombreroNH)session.Load (typeof(SombreroNH), sombrero.IdSombrero);

                sombreroNH.Nombre = sombrero.Nombre;


                sombreroNH.Modelo = sombrero.Modelo;


                sombreroNH.Color = sombrero.Color;


                sombreroNH.Material = sombrero.Material;


                sombreroNH.Attemporadatribute = sombrero.Attemporadatribute;


                sombreroNH.PrecioBase = sombrero.PrecioBase;


                sombreroNH.Descripcion = sombrero.Descripcion;


                sombreroNH.Stock = sombrero.Stock;

                session.Update (sombreroNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in SombreroRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int idSombrero
                    )
{
        try
        {
                SessionInitializeTransaction ();
                SombreroNH sombreroNH = (SombreroNH)session.Load (typeof(SombreroNH), idSombrero);
                session.Delete (sombreroNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in SombreroRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ConsultarID
//Con e: SombreroEN
public SombreroEN ConsultarID (int idSombrero
                               )
{
        SombreroEN sombreroEN = null;

        try
        {
                SessionInitializeTransaction ();
                sombreroEN = (SombreroEN)session.Get (typeof(SombreroNH), idSombrero);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return sombreroEN;
}

public System.Collections.Generic.IList<SombreroEN> ConsultarTodo (int first, int size)
{
        System.Collections.Generic.IList<SombreroEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(SombreroNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<SombreroEN>();
                else
                        result = session.CreateCriteria (typeof(SombreroNH)).List<SombreroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in SombreroRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.SombreroEN> PsombrerosPorModeloYColor (string p_modelo, string p_color)
{
        System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.SombreroEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SombreroNH self where FROM SombreroNH as som WHERE som.Modelo = :p_modelo AND som.Color = :p_color";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SombreroNHPsombrerosPorModeloYColorHQL");
                query.SetParameter ("p_modelo", p_modelo);
                query.SetParameter ("p_color", p_color);

                result = query.List<DSMGen.ApplicationCore.EN.DSM1.SombreroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in SombreroRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.SombreroEN> PporPrecio (double ? p_precio)
{
        System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.SombreroEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM SombreroNH self where FROM SombreroNH as som WHERE som.PrecioBase = :p_precio";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("SombreroNHPporPrecioHQL");
                query.SetParameter ("p_precio", p_precio);

                result = query.List<DSMGen.ApplicationCore.EN.DSM1.SombreroEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in SombreroRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
