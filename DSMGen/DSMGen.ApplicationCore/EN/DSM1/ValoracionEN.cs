
using System;
// Definición clase ValoracionEN
namespace DSMGen.ApplicationCore.EN.DSM1
{
public partial class ValoracionEN
{
/**
 *	Atributo idValoracion
 */
private int idValoracion;



/**
 *	Atributo comentario
 */
private string comentario;



/**
 *	Atributo puntuacion
 */
private int puntuacion;



/**
 *	Atributo cliente
 */
private System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.ClienteEN> cliente;



/**
 *	Atributo sombrero
 */
private DSMGen.ApplicationCore.EN.DSM1.SombreroEN sombrero;






public virtual int IdValoracion {
        get { return idValoracion; } set { idValoracion = value;  }
}



public virtual string Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual int Puntuacion {
        get { return puntuacion; } set { puntuacion = value;  }
}



public virtual System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.ClienteEN> Cliente {
        get { return cliente; } set { cliente = value;  }
}



public virtual DSMGen.ApplicationCore.EN.DSM1.SombreroEN Sombrero {
        get { return sombrero; } set { sombrero = value;  }
}





public ValoracionEN()
{
        cliente = new System.Collections.Generic.List<DSMGen.ApplicationCore.EN.DSM1.ClienteEN>();
}



public ValoracionEN(int idValoracion, string comentario, int puntuacion, System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.ClienteEN> cliente, DSMGen.ApplicationCore.EN.DSM1.SombreroEN sombrero
                    )
{
        this.init (IdValoracion, comentario, puntuacion, cliente, sombrero);
}


public ValoracionEN(ValoracionEN valoracion)
{
        this.init (valoracion.IdValoracion, valoracion.Comentario, valoracion.Puntuacion, valoracion.Cliente, valoracion.Sombrero);
}

private void init (int idValoracion
                   , string comentario, int puntuacion, System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.ClienteEN> cliente, DSMGen.ApplicationCore.EN.DSM1.SombreroEN sombrero)
{
        this.IdValoracion = idValoracion;


        this.Comentario = comentario;

        this.Puntuacion = puntuacion;

        this.Cliente = cliente;

        this.Sombrero = sombrero;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ValoracionEN t = obj as ValoracionEN;
        if (t == null)
                return false;
        if (IdValoracion.Equals (t.IdValoracion))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdValoracion.GetHashCode ();
        return hash;
}
}
}
