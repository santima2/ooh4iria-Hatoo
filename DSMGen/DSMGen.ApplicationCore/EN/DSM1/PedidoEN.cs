
using System;
// Definición clase PedidoEN
namespace DSMGen.ApplicationCore.EN.DSM1
{
public partial class PedidoEN
{
/**
 *	Atributo idPedido
 */
private int idPedido;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo estado
 */
private DSMGen.ApplicationCore.Enumerated.DSM1.EstadoPedidoEnum estado;



/**
 *	Atributo cliente
 */
private DSMGen.ApplicationCore.EN.DSM1.ClienteEN cliente;



/**
 *	Atributo linPedido
 */
private System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.LinPedidoEN> linPedido;



/**
 *	Atributo pago
 */
private DSMGen.ApplicationCore.EN.DSM1.PagoEN pago;






public virtual int IdPedido {
        get { return idPedido; } set { idPedido = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual DSMGen.ApplicationCore.Enumerated.DSM1.EstadoPedidoEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual DSMGen.ApplicationCore.EN.DSM1.ClienteEN Cliente {
        get { return cliente; } set { cliente = value;  }
}



public virtual System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.LinPedidoEN> LinPedido {
        get { return linPedido; } set { linPedido = value;  }
}



public virtual DSMGen.ApplicationCore.EN.DSM1.PagoEN Pago {
        get { return pago; } set { pago = value;  }
}





public PedidoEN()
{
        linPedido = new System.Collections.Generic.List<DSMGen.ApplicationCore.EN.DSM1.LinPedidoEN>();
}



public PedidoEN(int idPedido, Nullable<DateTime> fecha, DSMGen.ApplicationCore.Enumerated.DSM1.EstadoPedidoEnum estado, DSMGen.ApplicationCore.EN.DSM1.ClienteEN cliente, System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.LinPedidoEN> linPedido, DSMGen.ApplicationCore.EN.DSM1.PagoEN pago
                )
{
        this.init (IdPedido, fecha, estado, cliente, linPedido, pago);
}


public PedidoEN(PedidoEN pedido)
{
        this.init (pedido.IdPedido, pedido.Fecha, pedido.Estado, pedido.Cliente, pedido.LinPedido, pedido.Pago);
}

private void init (int idPedido
                   , Nullable<DateTime> fecha, DSMGen.ApplicationCore.Enumerated.DSM1.EstadoPedidoEnum estado, DSMGen.ApplicationCore.EN.DSM1.ClienteEN cliente, System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.LinPedidoEN> linPedido, DSMGen.ApplicationCore.EN.DSM1.PagoEN pago)
{
        this.IdPedido = idPedido;


        this.Fecha = fecha;

        this.Estado = estado;

        this.Cliente = cliente;

        this.LinPedido = linPedido;

        this.Pago = pago;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PedidoEN t = obj as PedidoEN;
        if (t == null)
                return false;
        if (IdPedido.Equals (t.IdPedido))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdPedido.GetHashCode ();
        return hash;
}
}
}
