
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
 * Clase Carrito:
 *
 */

namespace DSMGen.Infraestructure.Repository.DSM1
{
public partial class CarritoRepository : BasicRepository, ICarritoRepository
{
public CarritoRepository() : base ()
{
}


public CarritoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public CarritoEN ReadOIDDefault (int idCarrito
                                 )
{
        CarritoEN carritoEN = null;

        try
        {
                SessionInitializeTransaction ();
                carritoEN = (CarritoEN)session.Get (typeof(CarritoNH), idCarrito);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return carritoEN;
}

public System.Collections.Generic.IList<CarritoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CarritoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CarritoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<CarritoEN>();
                        else
                                result = session.CreateCriteria (typeof(CarritoNH)).List<CarritoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in CarritoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CarritoEN carrito)
{
        try
        {
                SessionInitializeTransaction ();
                CarritoNH carritoNH = (CarritoNH)session.Load (typeof(CarritoNH), carrito.IdCarrito);

                carritoNH.Total = carrito.Total;



                session.Update (carritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in CarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (CarritoEN carrito)
{
        CarritoNH carritoNH = new CarritoNH (carrito);

        try
        {
                SessionInitializeTransaction ();
                if (carrito.Cliente != null) {
                        // Argumento OID y no colección.
                        carritoNH
                        .Cliente = (DSMGen.ApplicationCore.EN.DSM1.ClienteEN)session.Load (typeof(DSMGen.ApplicationCore.EN.DSM1.ClienteEN), carrito.Cliente.IdUsuario);

                        carritoNH.Cliente.Consulta
                                = carritoNH;
                }

                session.Save (carritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in CarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return carritoNH.IdCarrito;
}

public void Modificar (CarritoEN carrito)
{
        try
        {
                SessionInitializeTransaction ();
                CarritoNH carritoNH = (CarritoNH)session.Load (typeof(CarritoNH), carrito.IdCarrito);

                carritoNH.Total = carrito.Total;

                session.Update (carritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in CarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int idCarrito
                    )
{
        try
        {
                SessionInitializeTransaction ();
                CarritoNH carritoNH = (CarritoNH)session.Load (typeof(CarritoNH), idCarrito);
                session.Delete (carritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in CarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ConsultarID
//Con e: CarritoEN
public CarritoEN ConsultarID (int idCarrito
                              )
{
        CarritoEN carritoEN = null;

        try
        {
                SessionInitializeTransaction ();
                carritoEN = (CarritoEN)session.Get (typeof(CarritoNH), idCarrito);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return carritoEN;
}

public System.Collections.Generic.IList<CarritoEN> ConsultarTodo (int first, int size)
{
        System.Collections.Generic.IList<CarritoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CarritoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<CarritoEN>();
                else
                        result = session.CreateCriteria (typeof(CarritoNH)).List<CarritoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in CarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
