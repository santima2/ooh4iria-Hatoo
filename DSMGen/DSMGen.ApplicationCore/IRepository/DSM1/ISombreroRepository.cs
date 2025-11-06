
using System;
using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.CP.DSM1;

namespace DSMGen.ApplicationCore.IRepository.DSM1
{
public partial interface ISombreroRepository
{
void setSessionCP (GenericSessionCP session);

SombreroEN ReadOIDDefault (int idSombrero
                           );

void ModifyDefault (SombreroEN sombrero);

System.Collections.Generic.IList<SombreroEN> ReadAllDefault (int first, int size);



int Crear (SombreroEN sombrero);

void Modificar (SombreroEN sombrero);


void Borrar (int idSombrero
             );


SombreroEN ConsultarID (int idSombrero
                        );


System.Collections.Generic.IList<SombreroEN> ConsultarTodo (int first, int size);




System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.SombreroEN> PsombrerosPorModeloYColor (string p_modelo, string p_color);


System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.SombreroEN> PporPrecio (double ? p_precio);
}
}
