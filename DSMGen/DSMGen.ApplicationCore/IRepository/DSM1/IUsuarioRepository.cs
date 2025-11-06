
using System;
using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.CP.DSM1;

namespace DSMGen.ApplicationCore.IRepository.DSM1
{
public partial interface IUsuarioRepository
{
void setSessionCP (GenericSessionCP session);

UsuarioEN ReadOIDDefault (int idUsuario
                          );

void ModifyDefault (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size);



int Crear (UsuarioEN usuario);

void Modificar (UsuarioEN usuario);


void Borrar (int idUsuario
             );


UsuarioEN ConsultarID (int idUsuario
                       );



System.Collections.Generic.IList<UsuarioEN> ConsultarTodo (int first, int size);
}
}
