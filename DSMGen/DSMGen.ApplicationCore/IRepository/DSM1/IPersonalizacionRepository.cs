
using System;
using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.CP.DSM1;

namespace DSMGen.ApplicationCore.IRepository.DSM1
{
public partial interface IPersonalizacionRepository
{
void setSessionCP (GenericSessionCP session);

PersonalizacionEN ReadOIDDefault (int idPersonalizacion
                                  );

void ModifyDefault (PersonalizacionEN personalizacion);

System.Collections.Generic.IList<PersonalizacionEN> ReadAllDefault (int first, int size);



int Crear (PersonalizacionEN personalizacion);

void Modificar (PersonalizacionEN personalizacion);


void Borrar (int idPersonalizacion
             );


PersonalizacionEN ConsultarID (int idPersonalizacion
                               );


System.Collections.Generic.IList<PersonalizacionEN> ConsultarTodo (int first, int size);
}
}
