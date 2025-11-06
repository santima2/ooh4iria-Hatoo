
using System;
using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.CP.DSM1;

namespace DSMGen.ApplicationCore.IRepository.DSM1
{
public partial interface IPedidoRepository
{
void setSessionCP (GenericSessionCP session);

PedidoEN ReadOIDDefault (int idPedido
                         );

void ModifyDefault (PedidoEN pedido);

System.Collections.Generic.IList<PedidoEN> ReadAllDefault (int first, int size);



int Crear (PedidoEN pedido);

void Modificar (PedidoEN pedido);


void Borrar (int idPedido
             );


PedidoEN ConsultarID (int idPedido
                      );


System.Collections.Generic.IList<PedidoEN> ConsultarTodo (int first, int size);




System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.PedidoEN> PpedidosSombrero (int ? p_idSombrero);


System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.PedidoEN> PpedidosEsrado (double ? p_precio);
}
}
