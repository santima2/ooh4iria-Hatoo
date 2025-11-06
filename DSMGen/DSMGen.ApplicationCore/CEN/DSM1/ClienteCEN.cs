

using System;
using System.Text;
using System.Collections.Generic;

using DSMGen.ApplicationCore.Exceptions;

using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.IRepository.DSM1;


namespace DSMGen.ApplicationCore.CEN.DSM1
{
/*
 *      Definition of the class ClienteCEN
 *
 */
public partial class ClienteCEN
{
private IClienteRepository _IClienteRepository;

public ClienteCEN(IClienteRepository _IClienteRepository)
{
        this._IClienteRepository = _IClienteRepository;
}

public IClienteRepository get_IClienteRepository ()
{
        return this._IClienteRepository;
}

public int New_ (string p_nombre, string p_email, string p_telefono, String p_pass)
{
        ClienteEN clienteEN = null;
        int oid;

        //Initialized ClienteEN
        clienteEN = new ClienteEN ();
        clienteEN.Nombre = p_nombre;

        clienteEN.Email = p_email;

        clienteEN.Telefono = p_telefono;

        clienteEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);



        oid = _IClienteRepository.New_ (clienteEN);
        return oid;
}
}
}
