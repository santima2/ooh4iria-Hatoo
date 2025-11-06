
using System;
// Definición clase PagoEN
namespace DSMGen.ApplicationCore.EN.DSM1
{
public partial class PagoEN
{
/**
 *	Atributo idPago
 */
private int idPago;



/**
 *	Atributo fechaPago
 */
private Nullable<DateTime> fechaPago;



/**
 *	Atributo tipoPago
 */
private string tipoPago;



/**
 *	Atributo total
 */
private double total;



/**
 *	Atributo pedido
 */
private DSMGen.ApplicationCore.EN.DSM1.PedidoEN pedido;






public virtual int IdPago {
        get { return idPago; } set { idPago = value;  }
}



public virtual Nullable<DateTime> FechaPago {
        get { return fechaPago; } set { fechaPago = value;  }
}



public virtual string TipoPago {
        get { return tipoPago; } set { tipoPago = value;  }
}



public virtual double Total {
        get { return total; } set { total = value;  }
}



public virtual DSMGen.ApplicationCore.EN.DSM1.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}





public PagoEN()
{
}



public PagoEN(int idPago, Nullable<DateTime> fechaPago, string tipoPago, double total, DSMGen.ApplicationCore.EN.DSM1.PedidoEN pedido
              )
{
        this.init (IdPago, fechaPago, tipoPago, total, pedido);
}


public PagoEN(PagoEN pago)
{
        this.init (pago.IdPago, pago.FechaPago, pago.TipoPago, pago.Total, pago.Pedido);
}

private void init (int idPago
                   , Nullable<DateTime> fechaPago, string tipoPago, double total, DSMGen.ApplicationCore.EN.DSM1.PedidoEN pedido)
{
        this.IdPago = idPago;


        this.FechaPago = fechaPago;

        this.TipoPago = tipoPago;

        this.Total = total;

        this.Pedido = pedido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PagoEN t = obj as PagoEN;
        if (t == null)
                return false;
        if (IdPago.Equals (t.IdPago))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdPago.GetHashCode ();
        return hash;
}
}
}
