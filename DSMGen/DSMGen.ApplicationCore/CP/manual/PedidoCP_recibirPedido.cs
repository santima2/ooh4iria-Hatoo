
using System;
using System.Text;

using System.Collections.Generic;
using DSMGen.ApplicationCore.Exceptions;
using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.IRepository.DSM1;
using DSMGen.ApplicationCore.CEN.DSM1;



/*PROTECTED REGION ID(usingDSMGen.ApplicationCore.CP.DSM1_Pedido_recibirPedido) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSMGen.ApplicationCore.CP.DSM1
{
public partial class PedidoCP : GenericBasicCP
{
public void RecibirPedido (int p_oid)
{
        /*PROTECTED REGION ID(DSMGen.ApplicationCore.CP.DSM1_Pedido_recibirPedido) ENABLED START*/

        PedidoCEN pedidoCEN = null;



        try
        {
                CPSession.SessionInitializeTransaction ();
                pedidoCEN = new  PedidoCEN (CPSession.UnitRepo.PedidoRepository);



                // Write here your custom transaction ...
                SombreroCEN sombreroCEN = new SombreroCEN (CPSession.UnitRepo.SombreroRepository);

                PedidoEN pedidoEN = pedidoCEN.ConsultarID (p_oid);

                foreach (LinPedidoEN linea in pedidoEN.LinPedido) {
                        SombreroEN sombreroEN = linea.Sombrero;
                        sombreroCEN.AumentarStock (sombreroEN.IdSombrero, linea.Cantidad);
                }

                pedidoEN.Estado = DSMGen.ApplicationCore.Enumerated.DSM1.EstadoPedidoEnum.rechazado;

                pedidoCEN.get_IPedidoRepository ().ModifyDefault (pedidoEN);


                CPSession.Commit ();
        }
        catch (Exception ex)
        {
                CPSession.RollBack ();
                throw ex;
        }
        finally
        {
                CPSession.SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
