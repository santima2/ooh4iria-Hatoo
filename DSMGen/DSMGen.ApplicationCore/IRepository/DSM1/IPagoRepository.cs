
using System;
using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.CP.DSM1;

namespace DSMGen.ApplicationCore.IRepository.DSM1
{
public partial interface IPagoRepository
{
void setSessionCP (GenericSessionCP session);

PagoEN ReadOIDDefault (int idPago
                       );

void ModifyDefault (PagoEN pago);

System.Collections.Generic.IList<PagoEN> ReadAllDefault (int first, int size);



int Crear (PagoEN pago);

void Modificar (PagoEN pago);


void Borrar (int idPago
             );


PagoEN ConsultarID (int idPago
                    );


System.Collections.Generic.IList<PagoEN> ConsultarTodo (int first, int size);
}
}
