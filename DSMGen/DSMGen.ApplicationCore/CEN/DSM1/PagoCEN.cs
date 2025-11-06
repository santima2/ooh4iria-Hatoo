

using System;
using System.Text;
using System.Collections.Generic;

using DSMGen.ApplicationCore.Exceptions;

using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.IRepository.DSM1;


namespace DSMGen.ApplicationCore.CEN.DSM1
{
/*
 *      Definition of the class PagoCEN
 *
 */
public partial class PagoCEN
{
private IPagoRepository _IPagoRepository;

public PagoCEN(IPagoRepository _IPagoRepository)
{
        this._IPagoRepository = _IPagoRepository;
}

public IPagoRepository get_IPagoRepository ()
{
        return this._IPagoRepository;
}

public void Modificar (int p_Pago_OID, Nullable<DateTime> p_fechaPago, string p_tipoPago, double p_total)
{
        PagoEN pagoEN = null;

        //Initialized PagoEN
        pagoEN = new PagoEN ();
        pagoEN.IdPago = p_Pago_OID;
        pagoEN.FechaPago = p_fechaPago;
        pagoEN.TipoPago = p_tipoPago;
        pagoEN.Total = p_total;
        //Call to PagoRepository

        _IPagoRepository.Modificar (pagoEN);
}

public void Borrar (int idPago
                    )
{
        _IPagoRepository.Borrar (idPago);
}

public PagoEN ConsultarID (int idPago
                           )
{
        PagoEN pagoEN = null;

        pagoEN = _IPagoRepository.ConsultarID (idPago);
        return pagoEN;
}

public System.Collections.Generic.IList<PagoEN> ConsultarTodo (int first, int size)
{
        System.Collections.Generic.IList<PagoEN> list = null;

        list = _IPagoRepository.ConsultarTodo (first, size);
        return list;
}
}
}
