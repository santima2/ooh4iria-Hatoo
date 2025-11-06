
using System;
using System.Text;
using System.Collections.Generic;
using DSMGen.ApplicationCore.Exceptions;
using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.IRepository.DSM1;


/*PROTECTED REGION ID(usingDSMGen.ApplicationCore.CEN.DSM1_Pedido_crear) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSMGen.ApplicationCore.CEN.DSM1
{
public partial class PedidoCEN
{
public int Crear (Nullable<DateTime> p_fecha, int p_cliente)
{
        /*PROTECTED REGION ID(DSMGen.ApplicationCore.CEN.DSM1_Pedido_crear_customized) ENABLED START*/

        PedidoEN pedidoEN = null;

        int oid;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Fecha = p_fecha;


        if (p_cliente != -1) {
                pedidoEN.Cliente = new DSMGen.ApplicationCore.EN.DSM1.ClienteEN ();
                pedidoEN.Cliente.IdUsuario = p_cliente;
        }

        pedidoEN.Estado = DSMGen.ApplicationCore.Enumerated.DSM1.EstadoPedidoEnum.pendiente;
        //Call to PedidoRepository

        oid = _IPedidoRepository.Crear (pedidoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
