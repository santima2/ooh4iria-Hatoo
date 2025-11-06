
using System;
// Definición clase ClienteEN
namespace DSMGen.ApplicationCore.EN.DSM1
{
public partial class ClienteEN                                                                      : DSMGen.ApplicationCore.EN.DSM1.UsuarioEN


{
/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.PedidoEN> pedido;



/**
 *	Atributo consulta
 */
private DSMGen.ApplicationCore.EN.DSM1.CarritoEN consulta;



/**
 *	Atributo valiracion
 */
private System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.ValoracionEN> valiracion;



/**
 *	Atributo soporte
 */
private System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.SoporteEN> soporte;






public virtual System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual DSMGen.ApplicationCore.EN.DSM1.CarritoEN Consulta {
        get { return consulta; } set { consulta = value;  }
}



public virtual System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.ValoracionEN> Valiracion {
        get { return valiracion; } set { valiracion = value;  }
}



public virtual System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.SoporteEN> Soporte {
        get { return soporte; } set { soporte = value;  }
}





public ClienteEN() : base ()
{
        pedido = new System.Collections.Generic.List<DSMGen.ApplicationCore.EN.DSM1.PedidoEN>();
        valiracion = new System.Collections.Generic.List<DSMGen.ApplicationCore.EN.DSM1.ValoracionEN>();
        soporte = new System.Collections.Generic.List<DSMGen.ApplicationCore.EN.DSM1.SoporteEN>();
}



public ClienteEN(int idUsuario, System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.PedidoEN> pedido, DSMGen.ApplicationCore.EN.DSM1.CarritoEN consulta, System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.ValoracionEN> valiracion, System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.SoporteEN> soporte
                 , string nombre, string email, string telefono, String pass
                 )
{
        this.init (IdUsuario, pedido, consulta, valiracion, soporte, nombre, email, telefono, pass);
}


public ClienteEN(ClienteEN cliente)
{
        this.init (cliente.IdUsuario, cliente.Pedido, cliente.Consulta, cliente.Valiracion, cliente.Soporte, cliente.Nombre, cliente.Email, cliente.Telefono, cliente.Pass);
}

private void init (int idUsuario
                   , System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.PedidoEN> pedido, DSMGen.ApplicationCore.EN.DSM1.CarritoEN consulta, System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.ValoracionEN> valiracion, System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.SoporteEN> soporte, string nombre, string email, string telefono, String pass)
{
        this.IdUsuario = idUsuario;


        this.Pedido = pedido;

        this.Consulta = consulta;

        this.Valiracion = valiracion;

        this.Soporte = soporte;

        this.Nombre = nombre;

        this.Email = email;

        this.Telefono = telefono;

        this.Pass = pass;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ClienteEN t = obj as ClienteEN;
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
