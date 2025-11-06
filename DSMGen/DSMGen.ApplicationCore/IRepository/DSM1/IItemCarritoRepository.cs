
using System;
using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.CP.DSM1;

namespace DSMGen.ApplicationCore.IRepository.DSM1
{
public partial interface IItemCarritoRepository
{
void setSessionCP (GenericSessionCP session);

ItemCarritoEN ReadOIDDefault (int cantidad
                              );

void ModifyDefault (ItemCarritoEN itemCarrito);

System.Collections.Generic.IList<ItemCarritoEN> ReadAllDefault (int first, int size);



int Crear (ItemCarritoEN itemCarrito);

void Modificar (ItemCarritoEN itemCarrito);


void Borrar (int cantidad
             );


ItemCarritoEN ConsultarID (int cantidad
                           );


System.Collections.Generic.IList<ItemCarritoEN> ConsultarTodo (int first, int size);
}
}
