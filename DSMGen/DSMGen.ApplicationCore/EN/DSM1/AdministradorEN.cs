
using System;
// Definición clase AdministradorEN
namespace DSMGen.ApplicationCore.EN.DSM1
{
public partial class AdministradorEN                                                                        : DSMGen.ApplicationCore.EN.DSM1.UsuarioEN


{
/**
 *	Atributo sombrero
 */
private System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.SombreroEN> sombrero;






public virtual System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.SombreroEN> Sombrero {
        get { return sombrero; } set { sombrero = value;  }
}





public AdministradorEN() : base ()
{
        sombrero = new System.Collections.Generic.List<DSMGen.ApplicationCore.EN.DSM1.SombreroEN>();
}



public AdministradorEN(int idUsuario, System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.SombreroEN> sombrero
                       , string nombre, string email, string telefono, String pass
                       )
{
        this.init (IdUsuario, sombrero, nombre, email, telefono, pass);
}


public AdministradorEN(AdministradorEN administrador)
{
        this.init (administrador.IdUsuario, administrador.Sombrero, administrador.Nombre, administrador.Email, administrador.Telefono, administrador.Pass);
}

private void init (int idUsuario
                   , System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.SombreroEN> sombrero, string nombre, string email, string telefono, String pass)
{
        this.IdUsuario = idUsuario;


        this.Sombrero = sombrero;

        this.Nombre = nombre;

        this.Email = email;

        this.Telefono = telefono;

        this.Pass = pass;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdministradorEN t = obj as AdministradorEN;
        if (t == null)
                return false;
        if (IdUsuario.Equals (t.IdUsuario))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdUsuario.GetHashCode ();
        return hash;
}
}
}
