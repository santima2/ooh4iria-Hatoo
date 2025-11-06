
using System;
// Definición clase SombreroEN
namespace DSMGen.ApplicationCore.EN.DSM1
{
public partial class SombreroEN
{
/**
 *	Atributo modelo
 */
private string modelo;



/**
 *	Atributo color
 */
private string color;



/**
 *	Atributo material
 */
private string material;



/**
 *	Atributo attemporadatribute
 */
private string attemporadatribute;



/**
 *	Atributo precioBase
 */
private double precioBase;



/**
 *	Atributo idSombrero
 */
private int idSombrero;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo administrador
 */
private DSMGen.ApplicationCore.EN.DSM1.AdministradorEN administrador;



/**
 *	Atributo itemCarrito
 */
private DSMGen.ApplicationCore.EN.DSM1.ItemCarritoEN itemCarrito;



/**
 *	Atributo linPedido
 */
private System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.LinPedidoEN> linPedido;



/**
 *	Atributo personalizacion
 */
private System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.PersonalizacionEN> personalizacion;



/**
 *	Atributo valoracion
 */
private System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.ValoracionEN> valoracion;



/**
 *	Atributo stock
 */
private int stock;






public virtual string Modelo {
        get { return modelo; } set { modelo = value;  }
}



public virtual string Color {
        get { return color; } set { color = value;  }
}



public virtual string Material {
        get { return material; } set { material = value;  }
}



public virtual string Attemporadatribute {
        get { return attemporadatribute; } set { attemporadatribute = value;  }
}



public virtual double PrecioBase {
        get { return precioBase; } set { precioBase = value;  }
}



public virtual int IdSombrero {
        get { return idSombrero; } set { idSombrero = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual DSMGen.ApplicationCore.EN.DSM1.AdministradorEN Administrador {
        get { return administrador; } set { administrador = value;  }
}



public virtual DSMGen.ApplicationCore.EN.DSM1.ItemCarritoEN ItemCarrito {
        get { return itemCarrito; } set { itemCarrito = value;  }
}



public virtual System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.LinPedidoEN> LinPedido {
        get { return linPedido; } set { linPedido = value;  }
}



public virtual System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.PersonalizacionEN> Personalizacion {
        get { return personalizacion; } set { personalizacion = value;  }
}



public virtual System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.ValoracionEN> Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual int Stock {
        get { return stock; } set { stock = value;  }
}





public SombreroEN()
{
        linPedido = new System.Collections.Generic.List<DSMGen.ApplicationCore.EN.DSM1.LinPedidoEN>();
        personalizacion = new System.Collections.Generic.List<DSMGen.ApplicationCore.EN.DSM1.PersonalizacionEN>();
        valoracion = new System.Collections.Generic.List<DSMGen.ApplicationCore.EN.DSM1.ValoracionEN>();
}



public SombreroEN(int idSombrero, string modelo, string color, string material, string attemporadatribute, double precioBase, string descripcion, string nombre, DSMGen.ApplicationCore.EN.DSM1.AdministradorEN administrador, DSMGen.ApplicationCore.EN.DSM1.ItemCarritoEN itemCarrito, System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.LinPedidoEN> linPedido, System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.PersonalizacionEN> personalizacion, System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.ValoracionEN> valoracion, int stock
                  )
{
        this.init (IdSombrero, modelo, color, material, attemporadatribute, precioBase, descripcion, nombre, administrador, itemCarrito, linPedido, personalizacion, valoracion, stock);
}


public SombreroEN(SombreroEN sombrero)
{
        this.init (sombrero.IdSombrero, sombrero.Modelo, sombrero.Color, sombrero.Material, sombrero.Attemporadatribute, sombrero.PrecioBase, sombrero.Descripcion, sombrero.Nombre, sombrero.Administrador, sombrero.ItemCarrito, sombrero.LinPedido, sombrero.Personalizacion, sombrero.Valoracion, sombrero.Stock);
}

private void init (int idSombrero
                   , string modelo, string color, string material, string attemporadatribute, double precioBase, string descripcion, string nombre, DSMGen.ApplicationCore.EN.DSM1.AdministradorEN administrador, DSMGen.ApplicationCore.EN.DSM1.ItemCarritoEN itemCarrito, System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.LinPedidoEN> linPedido, System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.PersonalizacionEN> personalizacion, System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.ValoracionEN> valoracion, int stock)
{
        this.IdSombrero = idSombrero;


        this.Modelo = modelo;

        this.Color = color;

        this.Material = material;

        this.Attemporadatribute = attemporadatribute;

        this.PrecioBase = precioBase;

        this.Descripcion = descripcion;

        this.Nombre = nombre;

        this.Administrador = administrador;

        this.ItemCarrito = itemCarrito;

        this.LinPedido = linPedido;

        this.Personalizacion = personalizacion;

        this.Valoracion = valoracion;

        this.Stock = stock;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        SombreroEN t = obj as SombreroEN;
        if (t == null)
                return false;
        if (IdSombrero.Equals (t.IdSombrero))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdSombrero.GetHashCode ();
        return hash;
}
}
}
