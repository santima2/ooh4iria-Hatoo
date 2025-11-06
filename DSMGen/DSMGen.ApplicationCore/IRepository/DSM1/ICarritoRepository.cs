
using System;
using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.CP.DSM1;

namespace DSMGen.ApplicationCore.IRepository.DSM1
{
public partial interface ICarritoRepository
{
void setSessionCP (GenericSessionCP session);

CarritoEN ReadOIDDefault (int idCarrito
                          );

void ModifyDefault (CarritoEN carrito);

System.Collections.Generic.IList<CarritoEN> ReadAllDefault (int first, int size);



int Crear (CarritoEN carrito);

void Modificar (CarritoEN carrito);


void Borrar (int idCarrito
             );


CarritoEN ConsultarID (int idCarrito
                       );


System.Collections.Generic.IList<CarritoEN> ConsultarTodo (int first, int size);
}
}
