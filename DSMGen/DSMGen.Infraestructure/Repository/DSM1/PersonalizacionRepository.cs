
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
 * Clase Personalizacion:
 *
 */

namespace DSMGen.Infraestructure.Repository.DSM1
{
public partial class PersonalizacionRepository : BasicRepository, IPersonalizacionRepository
{
public PersonalizacionRepository() : base ()
{
}


public PersonalizacionRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public PersonalizacionEN ReadOIDDefault (int idPersonalizacion
                                         )
{
        PersonalizacionEN personalizacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                personalizacionEN = (PersonalizacionEN)session.Get (typeof(PersonalizacionNH), idPersonalizacion);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return personalizacionEN;
}

public System.Collections.Generic.IList<PersonalizacionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PersonalizacionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PersonalizacionNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<PersonalizacionEN>();
                        else
                                result = session.CreateCriteria (typeof(PersonalizacionNH)).List<PersonalizacionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PersonalizacionRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PersonalizacionEN personalizacion)
{
        try
        {
                SessionInitializeTransaction ();
                PersonalizacionNH personalizacionNH = (PersonalizacionNH)session.Load (typeof(PersonalizacionNH), personalizacion.IdPersonalizacion);

                personalizacionNH.Color = personalizacion.Color;


                personalizacionNH.Estampado = personalizacion.Estampado;


                personalizacionNH.Tamaño = personalizacion.Tamaño;


                personalizacionNH.PrecioExtra = personalizacion.PrecioExtra;



                session.Update (personalizacionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PersonalizacionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (PersonalizacionEN personalizacion)
{
        PersonalizacionNH personalizacionNH = new PersonalizacionNH (personalizacion);

        try
        {
                SessionInitializeTransaction ();
                if (personalizacion.Sombrero != null) {
                        // Argumento OID y no colección.
                        personalizacionNH
                        .Sombrero = (DSMGen.ApplicationCore.EN.DSM1.SombreroEN)session.Load (typeof(DSMGen.ApplicationCore.EN.DSM1.SombreroEN), personalizacion.Sombrero.IdSombrero);

                        personalizacionNH.Sombrero.Personalizacion
                        .Add (personalizacionNH);
                }

                session.Save (personalizacionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PersonalizacionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return personalizacionNH.IdPersonalizacion;
}

public void Modificar (PersonalizacionEN personalizacion)
{
        try
        {
                SessionInitializeTransaction ();
                PersonalizacionNH personalizacionNH = (PersonalizacionNH)session.Load (typeof(PersonalizacionNH), personalizacion.IdPersonalizacion);

                personalizacionNH.Color = personalizacion.Color;


                personalizacionNH.Estampado = personalizacion.Estampado;


                personalizacionNH.Tamaño = personalizacion.Tamaño;


                personalizacionNH.PrecioExtra = personalizacion.PrecioExtra;

                session.Update (personalizacionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PersonalizacionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int idPersonalizacion
                    )
{
        try
        {
                SessionInitializeTransaction ();
                PersonalizacionNH personalizacionNH = (PersonalizacionNH)session.Load (typeof(PersonalizacionNH), idPersonalizacion);
                session.Delete (personalizacionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PersonalizacionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ConsultarID
//Con e: PersonalizacionEN
public PersonalizacionEN ConsultarID (int idPersonalizacion
                                      )
{
        PersonalizacionEN personalizacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                personalizacionEN = (PersonalizacionEN)session.Get (typeof(PersonalizacionNH), idPersonalizacion);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return personalizacionEN;
}

public System.Collections.Generic.IList<PersonalizacionEN> ConsultarTodo (int first, int size)
{
        System.Collections.Generic.IList<PersonalizacionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PersonalizacionNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<PersonalizacionEN>();
                else
                        result = session.CreateCriteria (typeof(PersonalizacionNH)).List<PersonalizacionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSMGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DSMGen.ApplicationCore.Exceptions.DataLayerException ("Error in PersonalizacionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
