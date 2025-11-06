

using System;
using System.Text;
using System.Collections.Generic;

using DSMGen.ApplicationCore.Exceptions;

using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.IRepository.DSM1;


namespace DSMGen.ApplicationCore.CEN.DSM1
{
/*
 *      Definition of the class SoporteCEN
 *
 */
public partial class SoporteCEN
{
private ISoporteRepository _ISoporteRepository;

public SoporteCEN(ISoporteRepository _ISoporteRepository)
{
        this._ISoporteRepository = _ISoporteRepository;
}

public ISoporteRepository get_ISoporteRepository ()
{
        return this._ISoporteRepository;
}

public void Modificar (int p_Soporte_OID, string p_mensaje, Nullable<DateTime> p_fechaEnvio)
{
        SoporteEN soporteEN = null;

        //Initialized SoporteEN
        soporteEN = new SoporteEN ();
        soporteEN.IdSoporte = p_Soporte_OID;
        soporteEN.Mensaje = p_mensaje;
        soporteEN.FechaEnvio = p_fechaEnvio;
        //Call to SoporteRepository

        _ISoporteRepository.Modificar (soporteEN);
}

public void Borrar (int idSoporte
                    )
{
        _ISoporteRepository.Borrar (idSoporte);
}

public SoporteEN ConsultarID (int idSoporte
                              )
{
        SoporteEN soporteEN = null;

        soporteEN = _ISoporteRepository.ConsultarID (idSoporte);
        return soporteEN;
}

public System.Collections.Generic.IList<SoporteEN> ConsultarTodo (int first, int size)
{
        System.Collections.Generic.IList<SoporteEN> list = null;

        list = _ISoporteRepository.ConsultarTodo (first, size);
        return list;
}
}
}
