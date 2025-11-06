
using System;
using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.CP.DSM1;

namespace DSMGen.ApplicationCore.IRepository.DSM1
{
public partial interface IClienteRepository
{
void setSessionCP (GenericSessionCP session);

ClienteEN ReadOIDDefault (int idUsuario
                          );

void ModifyDefault (ClienteEN cliente);

System.Collections.Generic.IList<ClienteEN> ReadAllDefault (int first, int size);



int New_ (ClienteEN cliente);
}
}
