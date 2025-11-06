
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
 * Clase LinPedido:
 *
 */

namespace DSMGen.Infraestructure.Repository.DSM1
{
public partial class LinPedidoRepository : BasicRepository, ILinPedidoRepository
{
public LinPedidoRepository() : base ()
{
}


public LinPedidoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public LinPedidoEN ReadOIDDefault (int idLinPedido
                                   )
{
        LinPedidoEN linPedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                linPedidoEN = (LinPedidoEN)session.Get (typeof(LinPedidoNH), idLinPedido);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return linPedidoEN;
}

public System.Collections.Generic.IList<LinPedidoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LinPedidoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LinPedidoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<LinPedidoEN>();
                        else
                                result = session.CreateCriteria (typeof(LinPedidoNH)).List<LinPedidoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in LinPedidoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (LinPedidoEN linPedido)
{
        try
        {
                SessionInitializeTransaction ();
                LinPedidoNH linPedidoNH = (LinPedidoNH)session.Load (typeof(LinPedidoNH), linPedido.IdLinPedido);

                linPedidoNH.Cantidad = linPedido.Cantidad;


                linPedidoNH.Subtotal = linPedido.Subtotal;




                session.Update (linPedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in LinPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (LinPedidoEN linPedido)
{
        LinPedidoNH linPedidoNH = new LinPedidoNH (linPedido);

        try
        {
                SessionInitializeTransaction ();
                if (linPedido.Pedido != null) {
                        // Argumento OID y no colección.
                        linPedidoNH
                        .Pedido = (DSMGen.ApplicationCore.EN.DSM1.PedidoEN)session.Load (typeof(DSMGen.ApplicationCore.EN.DSM1.PedidoEN), linPedido.Pedido.IdPedido);

                        linPedidoNH.Pedido.LinPedido
                        .Add (linPedidoNH);
                }
                if (linPedido.Sombrero != null) {
                        // Argumento OID y no colección.
                        linPedidoNH
                        .Sombrero = (DSMGen.ApplicationCore.EN.DSM1.SombreroEN)session.Load (typeof(DSMGen.ApplicationCore.EN.DSM1.SombreroEN), linPedido.Sombrero.IdSombrero);

                        linPedidoNH.Sombrero.LinPedido
                        .Add (linPedidoNH);
                }

                session.Save (linPedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in LinPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return linPedidoNH.IdLinPedido;
}

public void Modificar (LinPedidoEN linPedido)
{
        try
        {
                SessionInitializeTransaction ();
                LinPedidoNH linPedidoNH = (LinPedidoNH)session.Load (typeof(LinPedidoNH), linPedido.IdLinPedido);

                linPedidoNH.Cantidad = linPedido.Cantidad;


                linPedidoNH.Subtotal = linPedido.Subtotal;

                session.Update (linPedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in LinPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int idLinPedido
                    )
{
        try
        {
                SessionInitializeTransaction ();
                LinPedidoNH linPedidoNH = (LinPedidoNH)session.Load (typeof(LinPedidoNH), idLinPedido);
                session.Delete (linPedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in LinPedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ConsultarID
//Con e: LinPedidoEN
public LinPedidoEN ConsultarID (int idLinPedido
                                )
{
        LinPedidoEN linPedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                linPedidoEN = (LinPedidoEN)session.Get (typeof(LinPedidoNH), idLinPedido);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return linPedidoEN;
}
}
}
