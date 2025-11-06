
using System;
// Definición clase ItemCarritoEN
namespace DSMGen.ApplicationCore.EN.DSM1
{
public partial class ItemCarritoEN
{
/**
 *	Atributo cantidad
 */
private int cantidad;



/**
 *	Atributo subtotal
 */
private double subtotal;



/**
 *	Atributo carrito
 */
private DSMGen.ApplicationCore.EN.DSM1.CarritoEN carrito;



/**
 *	Atributo sombrero
 */
private DSMGen.ApplicationCore.EN.DSM1.SombreroEN sombrero;






public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}



public virtual double Subtotal {
        get { return subtotal; } set { subtotal = value;  }
}



public virtual DSMGen.ApplicationCore.EN.DSM1.CarritoEN Carrito {
        get { return carrito; } set { carrito = value;  }
}



public virtual DSMGen.ApplicationCore.EN.DSM1.SombreroEN Sombrero {
        get { return sombrero; } set { sombrero = value;  }
}





public ItemCarritoEN()
{
}



public ItemCarritoEN(int cantidad, double subtotal, DSMGen.ApplicationCore.EN.DSM1.CarritoEN carrito, DSMGen.ApplicationCore.EN.DSM1.SombreroEN sombrero
                     )
{
        this.init (Cantidad, subtotal, carrito, sombrero);
}


public ItemCarritoEN(ItemCarritoEN itemCarrito)
{
        this.init (itemCarrito.Cantidad, itemCarrito.Subtotal, itemCarrito.Carrito, itemCarrito.Sombrero);
}

private void init (int cantidad
                   , double subtotal, DSMGen.ApplicationCore.EN.DSM1.CarritoEN carrito, DSMGen.ApplicationCore.EN.DSM1.SombreroEN sombrero)
{
        this.Cantidad = cantidad;


        this.Subtotal = subtotal;

        this.Carrito = carrito;

        this.Sombrero = sombrero;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ItemCarritoEN t = obj as ItemCarritoEN;
        if (t == null)
                return false;
        if (Cantidad.Equals (t.Cantidad))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Cantidad.GetHashCode ();
        return hash;
}
}
}
