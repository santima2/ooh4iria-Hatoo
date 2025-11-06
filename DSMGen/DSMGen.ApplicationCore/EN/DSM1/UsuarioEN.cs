
using System;
// Definición clase UsuarioEN
namespace DSMGen.ApplicationCore.EN.DSM1
{
public partial class UsuarioEN
{
/**
 *	Atributo idUsuario
 */
private int idUsuario;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo telefono
 */
private string telefono;



/**
 *	Atributo pass
 */
private String pass;






public virtual int IdUsuario {
        get { return idUsuario; } set { idUsuario = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Telefono {
        get { return telefono; } set { telefono = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}





public UsuarioEN()
{
}



public UsuarioEN(int idUsuario, string nombre, string email, string telefono, String pass
                 )
{
        this.init (IdUsuario, nombre, email, telefono, pass);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (usuario.IdUsuario, usuario.Nombre, usuario.Email, usuario.Telefono, usuario.Pass);
}

private void init (int idUsuario
                   , string nombre, string email, string telefono, String pass)
{
        this.IdUsuario = idUsuario;


        this.Nombre = nombre;

        this.Email = email;

        this.Telefono = telefono;

        this.Pass = pass;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
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
