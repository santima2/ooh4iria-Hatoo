
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
 * Clase Pago:
 *
 */

namespace DSMGen.Infraestructure.Repository.DSM1
{
public partial class PagoRepository : BasicRepository, IPagoRepository
{
public PagoRepository() : base ()
{
}


public PagoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public PagoEN ReadOIDDefault (int idPago
                              )
{
        PagoEN pagoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pagoEN = (PagoEN)session.Get (typeof(PagoNH), idPago);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return pagoEN;
}

public System.Collections.Generic.IList<PagoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PagoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PagoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<PagoEN>();
                        else
                                result = session.CreateCriteria (typeof(PagoNH)).List<PagoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PagoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PagoEN pago)
{
        try
        {
                SessionInitializeTransaction ();
                PagoNH pagoNH = (PagoNH)session.Load (typeof(PagoNH), pago.IdPago);

                pagoNH.FechaPago = pago.FechaPago;


                pagoNH.TipoPago = pago.TipoPago;


                pagoNH.Total = pago.Total;


                session.Update (pagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (PagoEN pago)
{
        PagoNH pagoNH = new PagoNH (pago);

        try
        {
                SessionInitializeTransaction ();
                if (pago.Pedido != null) {
                        // Argumento OID y no colección.
                        pagoNH
                        .Pedido = (DSMGen.ApplicationCore.EN.DSM1.PedidoEN)session.Load (typeof(DSMGen.ApplicationCore.EN.DSM1.PedidoEN), pago.Pedido.IdPedido);

                        pagoNH.Pedido.Pago
                                = pagoNH;
                }

                session.Save (pagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pagoNH.IdPago;
}

public void Modificar (PagoEN pago)
{
        try
        {
                SessionInitializeTransaction ();
                PagoNH pagoNH = (PagoNH)session.Load (typeof(PagoNH), pago.IdPago);

                pagoNH.FechaPago = pago.FechaPago;


                pagoNH.TipoPago = pago.TipoPago;


                pagoNH.Total = pago.Total;

                session.Update (pagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int idPago
                    )
{
        try
        {
                SessionInitializeTransaction ();
                PagoNH pagoNH = (PagoNH)session.Load (typeof(PagoNH), idPago);
                session.Delete (pagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ConsultarID
//Con e: PagoEN
public PagoEN ConsultarID (int idPago
                           )
{
        PagoEN pagoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pagoEN = (PagoEN)session.Get (typeof(PagoNH), idPago);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return pagoEN;
}

public System.Collections.Generic.IList<PagoEN> ConsultarTodo (int first, int size)
{
        System.Collections.Generic.IList<PagoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PagoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<PagoEN>();
                else
                        result = session.CreateCriteria (typeof(PagoNH)).List<PagoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
