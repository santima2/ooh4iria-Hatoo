

using System;
using System.Text;
using System.Collections.Generic;

using DSMGen.ApplicationCore.Exceptions;

using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.IRepository.DSM1;


namespace DSMGen.ApplicationCore.CEN.DSM1
{
/*
 *      Definition of the class LinPedidoCEN
 *
 */
public partial class LinPedidoCEN
{
private ILinPedidoRepository _ILinPedidoRepository;

public LinPedidoCEN(ILinPedidoRepository _ILinPedidoRepository)
{
        this._ILinPedidoRepository = _ILinPedidoRepository;
}

public ILinPedidoRepository get_ILinPedidoRepository ()
{
        return this._ILinPedidoRepository;
}

public int Crear (int p_cantidad, double p_subtotal, int p_pedido, int p_sombrero)
{
        LinPedidoEN linPedidoEN = null;
        int oid;

        //Initialized LinPedidoEN
        linPedidoEN = new LinPedidoEN ();
        linPedidoEN.Cantidad = p_cantidad;

        linPedidoEN.Subtotal = p_subtotal;


        if (p_pedido != -1) {
                // El argumento p_pedido -> Property pedido es oid = false
                // Lista de oids idLinPedido
                linPedidoEN.Pedido = new DSMGen.ApplicationCore.EN.DSM1.PedidoEN ();
                linPedidoEN.Pedido.IdPedido = p_pedido;
        }


        if (p_sombrero != -1) {
                // El argumento p_sombrero -> Property sombrero es oid = false
                // Lista de oids idLinPedido
                linPedidoEN.Sombrero = new DSMGen.ApplicationCore.EN.DSM1.SombreroEN ();
                linPedidoEN.Sombrero.IdSombrero = p_sombrero;
        }



        oid = _ILinPedidoRepository.Crear (linPedidoEN);
        return oid;
}

public void Modificar (int p_LinPedido_OID, int p_cantidad, double p_subtotal)
{
        LinPedidoEN linPedidoEN = null;

        //Initialized LinPedidoEN
        linPedidoEN = new LinPedidoEN ();
        linPedidoEN.IdLinPedido = p_LinPedido_OID;
        linPedidoEN.Cantidad = p_cantidad;
        linPedidoEN.Subtotal = p_subtotal;
        //Call to LinPedidoRepository

        _ILinPedidoRepository.Modificar (linPedidoEN);
}

public void Borrar (int idLinPedido
                    )
{
        _ILinPedidoRepository.Borrar (idLinPedido);
}

public LinPedidoEN ConsultarID (int idLinPedido
                                )
{
        LinPedidoEN linPedidoEN = null;

        linPedidoEN = _ILinPedidoRepository.ConsultarID (idLinPedido);
        return linPedidoEN;
}
}
}
