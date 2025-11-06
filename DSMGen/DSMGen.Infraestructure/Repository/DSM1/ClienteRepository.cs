
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
 * Clase Cliente:
 *
 */

namespace DSMGen.Infraestructure.Repository.DSM1
{
public partial class ClienteRepository : BasicRepository, IClienteRepository
{
public ClienteRepository() : base ()
{
}


public ClienteRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ClienteEN ReadOIDDefault (int idUsuario
                                 )
{
        ClienteEN clienteEN = null;

        try
        {
                SessionInitializeTransaction ();
                clienteEN = (ClienteEN)session.Get (typeof(ClienteNH), idUsuario);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return clienteEN;
}

public System.Collections.Generic.IList<ClienteEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ClienteEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ClienteNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ClienteEN>();
                        else
                                result = session.CreateCriteria (typeof(ClienteNH)).List<ClienteEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ClienteRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ClienteEN cliente)
{
        try
        {
                SessionInitializeTransaction ();
                ClienteNH clienteNH = (ClienteNH)session.Load (typeof(ClienteNH), cliente.IdUsuario);




                session.Update (clienteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ClienteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ClienteEN cliente)
{
        ClienteNH clienteNH = new ClienteNH (cliente);

        try
        {
                SessionInitializeTransaction ();

                session.Save (clienteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in ClienteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return clienteNH.IdUsuario;
}
}
}
