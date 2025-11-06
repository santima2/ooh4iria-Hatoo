
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
 * Clase ItemCarrito:
 *
 */

namespace DSMGen.Infraestructure.Repository.DSM1
{
public partial class ItemCarritoRepository : BasicRepository, IItemCarritoRepository
{
public ItemCarritoRepository() : base ()
{
}


public ItemCarritoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ItemCarritoEN ReadOIDDefault (int cantidad
                                     )
{
        ItemCarritoEN itemCarritoEN = null;

        try
        {
                SessionInitializeTransaction ();
                itemCarritoEN = (ItemCarritoEN)session.Get (typeof(ItemCarritoNH), cantidad);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return itemCarritoEN;
}

public System.Collections.Generic.IList<ItemCarritoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ItemCarritoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ItemCarritoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ItemCarritoEN>();
                        else
                                result = session.CreateCriteria (typeof(ItemCarritoNH)).List<ItemCarritoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ItemCarritoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ItemCarritoEN itemCarrito)
{
        try
        {
                SessionInitializeTransaction ();
                ItemCarritoNH itemCarritoNH = (ItemCarritoNH)session.Load (typeof(ItemCarritoNH), itemCarrito.Cantidad);

                itemCarritoNH.Subtotal = itemCarrito.Subtotal;



                session.Update (itemCarritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ItemCarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (ItemCarritoEN itemCarrito)
{
        ItemCarritoNH itemCarritoNH = new ItemCarritoNH (itemCarrito);

        try
        {
                SessionInitializeTransaction ();
                if (itemCarrito.Carrito != null) {
                        // Argumento OID y no colección.
                        itemCarritoNH
                        .Carrito = (DSMGen.ApplicationCore.EN.DSM1.CarritoEN)session.Load (typeof(DSMGen.ApplicationCore.EN.DSM1.CarritoEN), itemCarrito.Carrito.IdCarrito);

                        itemCarritoNH.Carrito.ItemCarrito
                        .Add (itemCarritoNH);
                }

                session.Save (itemCarritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ItemCarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return itemCarritoNH.Cantidad;
}

public void Modificar (ItemCarritoEN itemCarrito)
{
        try
        {
                SessionInitializeTransaction ();
                ItemCarritoNH itemCarritoNH = (ItemCarritoNH)session.Load (typeof(ItemCarritoNH), itemCarrito.Cantidad);

                itemCarritoNH.Subtotal = itemCarrito.Subtotal;

                session.Update (itemCarritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ItemCarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int cantidad
                    )
{
        try
        {
                SessionInitializeTransaction ();
                ItemCarritoNH itemCarritoNH = (ItemCarritoNH)session.Load (typeof(ItemCarritoNH), cantidad);
                session.Delete (itemCarritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ItemCarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ConsultarID
//Con e: ItemCarritoEN
public ItemCarritoEN ConsultarID (int cantidad
                                  )
{
        ItemCarritoEN itemCarritoEN = null;

        try
        {
                SessionInitializeTransaction ();
                itemCarritoEN = (ItemCarritoEN)session.Get (typeof(ItemCarritoNH), cantidad);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return itemCarritoEN;
}

public System.Collections.Generic.IList<ItemCarritoEN> ConsultarTodo (int first, int size)
{
        System.Collections.Generic.IList<ItemCarritoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ItemCarritoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ItemCarritoEN>();
                else
                        result = session.CreateCriteria (typeof(ItemCarritoNH)).List<ItemCarritoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ItemCarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
