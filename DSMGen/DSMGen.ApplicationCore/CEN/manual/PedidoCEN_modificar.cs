
using System;
using System.Text;
using System.Collections.Generic;
using DSMGen.ApplicationCore.Exceptions;
using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.IRepository.DSM1;


/*PROTECTED REGION ID(usingDSMGen.ApplicationCore.CEN.DSM1_Pedido_modificar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSMGen.ApplicationCore.CEN.DSM1
{
public partial class PedidoCEN
{
public void Modificar (int p_Pedido_OID, Nullable<DateTime> p_fecha)
{
        /*PROTECTED REGION ID(DSMGen.ApplicationCore.CEN.DSM1_Pedido_modificar_customized) START*/

        PedidoEN pedidoEN = null;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.IdPedido = p_Pedido_OID;
        pedidoEN.Fecha = p_fecha;
        //Call to PedidoRepository

        _IPedidoRepository.Modificar (pedidoEN);

        /*PROTECTED REGION END*/
}
}
}
