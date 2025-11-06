
using System;
// Definición clase CarritoEN
namespace DSMGen.ApplicationCore.EN.DSM1
{
public partial class CarritoEN
{
/**
 *	Atributo idCarrito
 */
private int idCarrito;



/**
 *	Atributo total
 */
private double total;



/**
 *	Atributo cliente
 */
private DSMGen.ApplicationCore.EN.DSM1.ClienteEN cliente;



/**
 *	Atributo itemCarrito
 */
private System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.ItemCarritoEN> itemCarrito;






public virtual int IdCarrito {
        get { return idCarrito; } set { idCarrito = value;  }
}



public virtual double Total {
        get { return total; } set { total = value;  }
}



public virtual DSMGen.ApplicationCore.EN.DSM1.ClienteEN Cliente {
        get { return cliente; } set { cliente = value;  }
}



public virtual System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.ItemCarritoEN> ItemCarrito {
        get { return itemCarrito; } set { itemCarrito = value;  }
}





public CarritoEN()
{
        itemCarrito = new System.Collections.Generic.List<DSMGen.ApplicationCore.EN.DSM1.ItemCarritoEN>();
}



public CarritoEN(int idCarrito, double total, DSMGen.ApplicationCore.EN.DSM1.ClienteEN cliente, System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.ItemCarritoEN> itemCarrito
                 )
{
        this.init (IdCarrito, total, cliente, itemCarrito);
}


public CarritoEN(CarritoEN carrito)
{
        this.init (carrito.IdCarrito, carrito.Total, carrito.Cliente, carrito.ItemCarrito);
}

private void init (int idCarrito
                   , double total, DSMGen.ApplicationCore.EN.DSM1.ClienteEN cliente, System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.ItemCarritoEN> itemCarrito)
{
        this.IdCarrito = idCarrito;


        this.Total = total;

        this.Cliente = cliente;

        this.ItemCarrito = itemCarrito;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CarritoEN t = obj as CarritoEN;
        if (t == null)
                return false;
        if (IdCarrito.Equals (t.IdCarrito))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdCarrito.GetHashCode ();
        return hash;
}
}
}
