
using System;
using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.CP.DSM1;

namespace DSMGen.ApplicationCore.IRepository.DSM1
{
public partial interface ISoporteRepository
{
void setSessionCP (GenericSessionCP session);

SoporteEN ReadOIDDefault (int idSoporte
                          );

void ModifyDefault (SoporteEN soporte);

System.Collections.Generic.IList<SoporteEN> ReadAllDefault (int first, int size);



int Crear (SoporteEN soporte);

void Modificar (SoporteEN soporte);


void Borrar (int idSoporte
             );


SoporteEN ConsultarID (int idSoporte
                       );


System.Collections.Generic.IList<SoporteEN> ConsultarTodo (int first, int size);
}
}
