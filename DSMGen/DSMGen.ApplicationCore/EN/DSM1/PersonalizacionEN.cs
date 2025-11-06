
using System;
// Definición clase PersonalizacionEN
namespace DSMGen.ApplicationCore.EN.DSM1
{
public partial class PersonalizacionEN
{
/**
 *	Atributo idPersonalizacion
 */
private int idPersonalizacion;



/**
 *	Atributo color
 */
private string color;



/**
 *	Atributo estampado
 */
private string estampado;



/**
 *	Atributo tamaño
 */
private string tamaño;



/**
 *	Atributo precioExtra
 */
private string precioExtra;



/**
 *	Atributo linPedido
 */
private DSMGen.ApplicationCore.EN.DSM1.LinPedidoEN linPedido;



/**
 *	Atributo sombrero
 */
private DSMGen.ApplicationCore.EN.DSM1.SombreroEN sombrero;






public virtual int IdPersonalizacion {
        get { return idPersonalizacion; } set { idPersonalizacion = value;  }
}



public virtual string Color {
        get { return color; } set { color = value;  }
}



public virtual string Estampado {
        get { return estampado; } set { estampado = value;  }
}



public virtual string Tamaño {
        get { return tamaño; } set { tamaño = value;  }
}



public virtual string PrecioExtra {
        get { return precioExtra; } set { precioExtra = value;  }
}



public virtual DSMGen.ApplicationCore.EN.DSM1.LinPedidoEN LinPedido {
        get { return linPedido; } set { linPedido = value;  }
}



public virtual DSMGen.ApplicationCore.EN.DSM1.SombreroEN Sombrero {
        get { return sombrero; } set { sombrero = value;  }
}





public PersonalizacionEN()
{
}



public PersonalizacionEN(int idPersonalizacion, string color, string estampado, string tamaño, string precioExtra, DSMGen.ApplicationCore.EN.DSM1.LinPedidoEN linPedido, DSMGen.ApplicationCore.EN.DSM1.SombreroEN sombrero
                         )
{
        this.init (IdPersonalizacion, color, estampado, tamaño, precioExtra, linPedido, sombrero);
}


public PersonalizacionEN(PersonalizacionEN personalizacion)
{
        this.init (personalizacion.IdPersonalizacion, personalizacion.Color, personalizacion.Estampado, personalizacion.Tamaño, personalizacion.PrecioExtra, personalizacion.LinPedido, personalizacion.Sombrero);
}

private void init (int idPersonalizacion
                   , string color, string estampado, string tamaño, string precioExtra, DSMGen.ApplicationCore.EN.DSM1.LinPedidoEN linPedido, DSMGen.ApplicationCore.EN.DSM1.SombreroEN sombrero)
{
        this.IdPersonalizacion = idPersonalizacion;


        this.Color = color;

        this.Estampado = estampado;

        this.Tamaño = tamaño;

        this.PrecioExtra = precioExtra;

        this.LinPedido = linPedido;

        this.Sombrero = sombrero;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PersonalizacionEN t = obj as PersonalizacionEN;
        if (t == null)
                return false;
        if (IdPersonalizacion.Equals (t.IdPersonalizacion))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdPersonalizacion.GetHashCode ();
        return hash;
}
}
}
