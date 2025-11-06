
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
 * Clase Soporte:
 *
 */

namespace DSMGen.Infraestructure.Repository.DSM1
{
public partial class SoporteRepository : BasicRepository, ISoporteRepository
{
public SoporteRepository() : base ()
{
}


public SoporteRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public SoporteEN ReadOIDDefault (int idSoporte
                                 )
{
        SoporteEN soporteEN = null;

        try
        {
                SessionInitializeTransaction ();
                soporteEN = (SoporteEN)session.Get (typeof(SoporteNH), idSoporte);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return soporteEN;
}

public System.Collections.Generic.IList<SoporteEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<SoporteEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(SoporteNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<SoporteEN>();
                        else
                                result = session.CreateCriteria (typeof(SoporteNH)).List<SoporteEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in SoporteRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (SoporteEN soporte)
{
        try
        {
                SessionInitializeTransaction ();
                SoporteNH soporteNH = (SoporteNH)session.Load (typeof(SoporteNH), soporte.IdSoporte);

                soporteNH.Mensaje = soporte.Mensaje;


                soporteNH.FechaEnvio = soporte.FechaEnvio;


                session.Update (soporteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in SoporteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (SoporteEN soporte)
{
        SoporteNH soporteNH = new SoporteNH (soporte);

        try
        {
                SessionInitializeTransaction ();
                if (soporte.Cliente != null) {
                        for (int i = 0; i < soporte.Cliente.Count; i++) {
                                soporte.Cliente [i] = (DSMGen.ApplicationCore.EN.DSM1.ClienteEN)session.Load (typeof(DSMGen.ApplicationCore.EN.DSM1.ClienteEN), soporte.Cliente [i].IdUsuario);
                                soporte.Cliente [i].Soporte.Add (soporteNH);
                        }
                }

                session.Save (soporteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in SoporteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return soporteNH.IdSoporte;
}

public void Modificar (SoporteEN soporte)
{
        try
        {
                SessionInitializeTransaction ();
                SoporteNH soporteNH = (SoporteNH)session.Load (typeof(SoporteNH), soporte.IdSoporte);

                soporteNH.Mensaje = soporte.Mensaje;


                soporteNH.FechaEnvio = soporte.FechaEnvio;

                session.Update (soporteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in SoporteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int idSoporte
                    )
{
        try
        {
                SessionInitializeTransaction ();
                SoporteNH soporteNH = (SoporteNH)session.Load (typeof(SoporteNH), idSoporte);
                session.Delete (soporteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in SoporteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ConsultarID
//Con e: SoporteEN
public SoporteEN ConsultarID (int idSoporte
                              )
{
        SoporteEN soporteEN = null;

        try
        {
                SessionInitializeTransaction ();
                soporteEN = (SoporteEN)session.Get (typeof(SoporteNH), idSoporte);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return soporteEN;
}

public System.Collections.Generic.IList<SoporteEN> ConsultarTodo (int first, int size)
{
        System.Collections.Generic.IList<SoporteEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(SoporteNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<SoporteEN>();
                else
                        result = session.CreateCriteria (typeof(SoporteNH)).List<SoporteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in SoporteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
