
using System;
using System.Text;
using System.Collections.Generic;
using DSMGen.ApplicationCore.Exceptions;
using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.IRepository.DSM1;


/*PROTECTED REGION ID(usingDSMGen.ApplicationCore.CEN.DSM1_Pago_crear) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSMGen.ApplicationCore.CEN.DSM1
{
public partial class PagoCEN
{
public int Crear (string p_tipoPago, double p_total, int p_pedido)
{
        /*PROTECTED REGION ID(DSMGen.ApplicationCore.CEN.DSM1_Pago_crear_customized) ENABLED START*/

        PagoEN pagoEN = null;

        int oid;

        //Initialized PagoEN
        pagoEN = new PagoEN ();
        pagoEN.TipoPago = p_tipoPago;
        pagoEN.FechaPago = DateTime.Now;
        pagoEN.Total = p_total;


        if (p_pedido != -1) {
                pagoEN.Pedido = new DSMGen.ApplicationCore.EN.DSM1.PedidoEN ();
                pagoEN.Pedido.IdPedido = p_pedido;
        }

        //Call to PagoRepository

        oid = _IPagoRepository.Crear (pagoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
