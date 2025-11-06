
using System;
// Definición clase SoporteEN
namespace DSMGen.ApplicationCore.EN.DSM1
{
public partial class SoporteEN
{
/**
 *	Atributo idSoporte
 */
private int idSoporte;



/**
 *	Atributo mensaje
 */
private string mensaje;



/**
 *	Atributo fechaEnvio
 */
private Nullable<DateTime> fechaEnvio;



/**
 *	Atributo cliente
 */
private System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.ClienteEN> cliente;






public virtual int IdSoporte {
        get { return idSoporte; } set { idSoporte = value;  }
}



public virtual string Mensaje {
        get { return mensaje; } set { mensaje = value;  }
}



public virtual Nullable<DateTime> FechaEnvio {
        get { return fechaEnvio; } set { fechaEnvio = value;  }
}



public virtual System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.ClienteEN> Cliente {
        get { return cliente; } set { cliente = value;  }
}





public SoporteEN()
{
        cliente = new System.Collections.Generic.List<DSMGen.ApplicationCore.EN.DSM1.ClienteEN>();
}



public SoporteEN(int idSoporte, string mensaje, Nullable<DateTime> fechaEnvio, System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.ClienteEN> cliente
                 )
{
        this.init (IdSoporte, mensaje, fechaEnvio, cliente);
}


public SoporteEN(SoporteEN soporte)
{
        this.init (soporte.IdSoporte, soporte.Mensaje, soporte.FechaEnvio, soporte.Cliente);
}

private void init (int idSoporte
                   , string mensaje, Nullable<DateTime> fechaEnvio, System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.ClienteEN> cliente)
{
        this.IdSoporte = idSoporte;


        this.Mensaje = mensaje;

        this.FechaEnvio = fechaEnvio;

        this.Cliente = cliente;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        SoporteEN t = obj as SoporteEN;
        if (t == null)
                return false;
        if (IdSoporte.Equals (t.IdSoporte))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdSoporte.GetHashCode ();
        return hash;
}
}
}
