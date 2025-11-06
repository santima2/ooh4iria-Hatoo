

using System;
using System.Text;
using System.Collections.Generic;

using DSMGen.ApplicationCore.Exceptions;

using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.IRepository.DSM1;


namespace DSMGen.ApplicationCore.CEN.DSM1
{
/*
 *      Definition of the class PersonalizacionCEN
 *
 */
public partial class PersonalizacionCEN
{
private IPersonalizacionRepository _IPersonalizacionRepository;

public PersonalizacionCEN(IPersonalizacionRepository _IPersonalizacionRepository)
{
        this._IPersonalizacionRepository = _IPersonalizacionRepository;
}

public IPersonalizacionRepository get_IPersonalizacionRepository ()
{
        return this._IPersonalizacionRepository;
}

public int Crear (string p_color, string p_estampado, string p_tamaño, string p_precioExtra, int p_sombrero)
{
        PersonalizacionEN personalizacionEN = null;
        int oid;

        //Initialized PersonalizacionEN
        personalizacionEN = new PersonalizacionEN ();
        personalizacionEN.Color = p_color;

        personalizacionEN.Estampado = p_estampado;

        personalizacionEN.Tamaño = p_tamaño;

        personalizacionEN.PrecioExtra = p_precioExtra;


        if (p_sombrero != -1) {
                // El argumento p_sombrero -> Property sombrero es oid = false
                // Lista de oids idPersonalizacion
                personalizacionEN.Sombrero = new DSMGen.ApplicationCore.EN.DSM1.SombreroEN ();
                personalizacionEN.Sombrero.IdSombrero = p_sombrero;
        }



        oid = _IPersonalizacionRepository.Crear (personalizacionEN);
        return oid;
}

public void Modificar (int p_Personalizacion_OID, string p_color, string p_estampado, string p_tamaño, string p_precioExtra)
{
        PersonalizacionEN personalizacionEN = null;

        //Initialized PersonalizacionEN
        personalizacionEN = new PersonalizacionEN ();
        personalizacionEN.IdPersonalizacion = p_Personalizacion_OID;
        personalizacionEN.Color = p_color;
        personalizacionEN.Estampado = p_estampado;
        personalizacionEN.Tamaño = p_tamaño;
        personalizacionEN.PrecioExtra = p_precioExtra;
        //Call to PersonalizacionRepository

        _IPersonalizacionRepository.Modificar (personalizacionEN);
}

public void Borrar (int idPersonalizacion
                    )
{
        _IPersonalizacionRepository.Borrar (idPersonalizacion);
}

public PersonalizacionEN ConsultarID (int idPersonalizacion
                                      )
{
        PersonalizacionEN personalizacionEN = null;

        personalizacionEN = _IPersonalizacionRepository.ConsultarID (idPersonalizacion);
        return personalizacionEN;
}

public System.Collections.Generic.IList<PersonalizacionEN> ConsultarTodo (int first, int size)
{
        System.Collections.Generic.IList<PersonalizacionEN> list = null;

        list = _IPersonalizacionRepository.ConsultarTodo (first, size);
        return list;
}
}
}
