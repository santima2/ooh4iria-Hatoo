
using System;
// Definición clase LinPedidoEN
namespace DSMGen.ApplicationCore.EN.DSM1
{
public partial class LinPedidoEN
{
/**
 *	Atributo idLinPedido
 */
private int idLinPedido;



/**
 *	Atributo cantidad
 */
private int cantidad;



/**
 *	Atributo subtotal
 */
private double subtotal;



/**
 *	Atributo pedido
 */
private DSMGen.ApplicationCore.EN.DSM1.PedidoEN pedido;



/**
 *	Atributo sombrero
 */
private DSMGen.ApplicationCore.EN.DSM1.SombreroEN sombrero;



/**
 *	Atributo personalizacion
 */
private DSMGen.ApplicationCore.EN.DSM1.PersonalizacionEN personalizacion;






public virtual int IdLinPedido {
        get { return idLinPedido; } set { idLinPedido = value;  }
}



public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}



public virtual double Subtotal {
        get { return subtotal; } set { subtotal = value;  }
}



public virtual DSMGen.ApplicationCore.EN.DSM1.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual DSMGen.ApplicationCore.EN.DSM1.SombreroEN Sombrero {
        get { return sombrero; } set { sombrero = value;  }
}



public virtual DSMGen.ApplicationCore.EN.DSM1.PersonalizacionEN Personalizacion {
        get { return personalizacion; } set { personalizacion = value;  }
}





public LinPedidoEN()
{
}



public LinPedidoEN(int idLinPedido, int cantidad, double subtotal, DSMGen.ApplicationCore.EN.DSM1.PedidoEN pedido, DSMGen.ApplicationCore.EN.DSM1.SombreroEN sombrero, DSMGen.ApplicationCore.EN.DSM1.PersonalizacionEN personalizacion
                   )
{
        this.init (IdLinPedido, cantidad, subtotal, pedido, sombrero, personalizacion);
}


public LinPedidoEN(LinPedidoEN linPedido)
{
        this.init (linPedido.IdLinPedido, linPedido.Cantidad, linPedido.Subtotal, linPedido.Pedido, linPedido.Sombrero, linPedido.Personalizacion);
}

private void init (int idLinPedido
                   , int cantidad, double subtotal, DSMGen.ApplicationCore.EN.DSM1.PedidoEN pedido, DSMGen.ApplicationCore.EN.DSM1.SombreroEN sombrero, DSMGen.ApplicationCore.EN.DSM1.PersonalizacionEN personalizacion)
{
        this.IdLinPedido = idLinPedido;


        this.Cantidad = cantidad;

        this.Subtotal = subtotal;

        this.Pedido = pedido;

        this.Sombrero = sombrero;

        this.Personalizacion = personalizacion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LinPedidoEN t = obj as LinPedidoEN;
        if (t == null)
                return false;
        if (IdLinPedido.Equals (t.IdLinPedido))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdLinPedido.GetHashCode ();
        return hash;
}
}
}
