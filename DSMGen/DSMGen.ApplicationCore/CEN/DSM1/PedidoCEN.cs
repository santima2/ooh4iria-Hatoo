

using System;
using System.Text;
using System.Collections.Generic;

using DSMGen.ApplicationCore.Exceptions;

using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.IRepository.DSM1;


namespace DSMGen.ApplicationCore.CEN.DSM1
{
/*
 *      Definition of the class PedidoCEN
 *
 */
public partial class PedidoCEN
{
private IPedidoRepository _IPedidoRepository;

public PedidoCEN(IPedidoRepository _IPedidoRepository)
{
        this._IPedidoRepository = _IPedidoRepository;
}

public IPedidoRepository get_IPedidoRepository ()
{
        return this._IPedidoRepository;
}

public void Borrar (int idPedido
                    )
{
        _IPedidoRepository.Borrar (idPedido);
}

public PedidoEN ConsultarID (int idPedido
                             )
{
        PedidoEN pedidoEN = null;

        pedidoEN = _IPedidoRepository.ConsultarID (idPedido);
        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> ConsultarTodo (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> list = null;

        list = _IPedidoRepository.ConsultarTodo (first, size);
        return list;
}
public System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.PedidoEN> PpedidosSombrero (int ? p_idSombrero)
{
        return _IPedidoRepository.PpedidosSombrero (p_idSombrero);
}
public System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.PedidoEN> PpedidosEsrado (double ? p_precio)
{
        return _IPedidoRepository.PpedidosEsrado (p_precio);
}
}
}
