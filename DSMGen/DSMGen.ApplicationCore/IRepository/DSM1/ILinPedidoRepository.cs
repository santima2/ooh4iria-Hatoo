
using System;
using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.CP.DSM1;

namespace DSMGen.ApplicationCore.IRepository.DSM1
{
public partial interface ILinPedidoRepository
{
void setSessionCP (GenericSessionCP session);

LinPedidoEN ReadOIDDefault (int idLinPedido
                            );

void ModifyDefault (LinPedidoEN linPedido);

System.Collections.Generic.IList<LinPedidoEN> ReadAllDefault (int first, int size);



int Crear (LinPedidoEN linPedido);

void Modificar (LinPedidoEN linPedido);


void Borrar (int idLinPedido
             );


LinPedidoEN ConsultarID (int idLinPedido
                         );
}
}
