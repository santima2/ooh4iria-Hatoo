
using System;
using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.CP.DSM1;

namespace DSMGen.ApplicationCore.IRepository.DSM1
{
public partial interface IValoracionRepository
{
void setSessionCP (GenericSessionCP session);

ValoracionEN ReadOIDDefault (int idValoracion
                             );

void ModifyDefault (ValoracionEN valoracion);

System.Collections.Generic.IList<ValoracionEN> ReadAllDefault (int first, int size);



int Crear (ValoracionEN valoracion);

void Modificar (ValoracionEN valoracion);


void Borrar (int idValoracion
             );


ValoracionEN ConsultarID (int idValoracion
                          );


System.Collections.Generic.IList<ValoracionEN> ConsultarTodo (int first, int size);
}
}
