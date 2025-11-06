

using System;
using System.Text;
using System.Collections.Generic;

using DSMGen.ApplicationCore.Exceptions;

using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.IRepository.DSM1;
using Newtonsoft.Json;


namespace DSMGen.ApplicationCore.CEN.DSM1
{
/*
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioRepository _IUsuarioRepository;

public UsuarioCEN(IUsuarioRepository _IUsuarioRepository)
{
        this._IUsuarioRepository = _IUsuarioRepository;
}

public IUsuarioRepository get_IUsuarioRepository ()
{
        return this._IUsuarioRepository;
}

public int Crear (string p_nombre, string p_email, string p_telefono, String p_pass)
{
        UsuarioEN usuarioEN = null;
        int oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Nombre = p_nombre;

        usuarioEN.Email = p_email;

        usuarioEN.Telefono = p_telefono;

        usuarioEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);



        oid = _IUsuarioRepository.Crear (usuarioEN);
        return oid;
}

public void Modificar (int p_Usuario_OID, string p_nombre, string p_email, string p_telefono, String p_pass)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.IdUsuario = p_Usuario_OID;
        usuarioEN.Nombre = p_nombre;
        usuarioEN.Email = p_email;
        usuarioEN.Telefono = p_telefono;
        usuarioEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        //Call to UsuarioRepository

        _IUsuarioRepository.Modificar (usuarioEN);
}

public void Borrar (int idUsuario
                    )
{
        _IUsuarioRepository.Borrar (idUsuario);
}

public UsuarioEN ConsultarID (int idUsuario
                              )
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioRepository.ConsultarID (idUsuario);
        return usuarioEN;
}

public string Login (int p_Usuario_OID, string p_pass)
{
        string result = null;
        UsuarioEN en = _IUsuarioRepository.ReadOIDDefault (p_Usuario_OID);

        if (en != null && en.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = this.GetToken (en.IdUsuario);

        return result;
}

public System.Collections.Generic.IList<UsuarioEN> ConsultarTodo (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioRepository.ConsultarTodo (first, size);
        return list;
}



private string Encode (int idUsuario)
{
        var payload = new Dictionary<string, object>(){
                { "idUsuario", idUsuario }
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (int idUsuario)
{
        UsuarioEN en = _IUsuarioRepository.ReadOIDDefault (idUsuario);
        string token = Encode (en.IdUsuario);

        return token;
}
public int CheckToken (string token)
{
        int result = -1;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                int id = (int)ObtenerIDUSUARIO (decodedToken);

                UsuarioEN en = _IUsuarioRepository.ReadOIDDefault (id);

                if (en != null && ((long)en.IdUsuario).Equals (ObtenerIDUSUARIO (decodedToken))
                    ) {
                        result = id;
                }
                else throw new ModelException ("El token es incorrecto");
        } catch (Exception)
        {
                throw new ModelException ("El token es incorrecto");
        }

        return result;
}


public long ObtenerIDUSUARIO (string decodedToken)
{
        try
        {
                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object> >(decodedToken);
                long idusuario = (long)results ["idUsuario"];
                return idusuario;
        }
        catch
        {
                throw new Exception ("El token enviado no es correcto");
        }
}
}
}
