

using System;
using System.Text;
using System.Collections.Generic;

using DSMGen.ApplicationCore.Exceptions;

using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.IRepository.DSM1;


namespace DSMGen.ApplicationCore.CEN.DSM1
{
/*
 *      Definition of the class AdministradorCEN
 *
 */
public partial class AdministradorCEN
{
private IAdministradorRepository _IAdministradorRepository;

public AdministradorCEN(IAdministradorRepository _IAdministradorRepository)
{
        this._IAdministradorRepository = _IAdministradorRepository;
}

public IAdministradorRepository get_IAdministradorRepository ()
{
        return this._IAdministradorRepository;
}

public int New_ (string p_nombre, string p_email, string p_telefono, String p_pass)
{
        AdministradorEN administradorEN = null;
        int oid;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.Nombre = p_nombre;

        administradorEN.Email = p_email;

        administradorEN.Telefono = p_telefono;

        administradorEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);



        oid = _IAdministradorRepository.New_ (administradorEN);
        return oid;
}

public void Modify (int p_Administrador_OID, string p_nombre, string p_email, string p_telefono, String p_pass)
{
        AdministradorEN administradorEN = null;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.IdUsuario = p_Administrador_OID;
        administradorEN.Nombre = p_nombre;
        administradorEN.Email = p_email;
        administradorEN.Telefono = p_telefono;
        administradorEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        //Call to AdministradorRepository

        _IAdministradorRepository.Modify (administradorEN);
}

public void Destroy (int idUsuario
                     )
{
        _IAdministradorRepository.Destroy (idUsuario);
}
}
}
