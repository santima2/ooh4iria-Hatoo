
using System;
using System.Collections.Generic;
using System.Text;

namespace DSMGen.ApplicationCore.IRepository.DSM1
{
public abstract class GenericUnitOfWorkRepository
{
protected IPedidoRepository pedidorepository;
protected IClienteRepository clienterepository;
protected IAdministradorRepository administradorrepository;
protected IUsuarioRepository usuariorepository;
protected ICarritoRepository carritorepository;
protected ISoporteRepository soporterepository;
protected ILinPedidoRepository linpedidorepository;
protected IPagoRepository pagorepository;
protected IItemCarritoRepository itemcarritorepository;
protected ISombreroRepository sombrerorepository;
protected IValoracionRepository valoracionrepository;
protected IPersonalizacionRepository personalizacionrepository;


public abstract IPedidoRepository PedidoRepository {
        get;
}
public abstract IClienteRepository ClienteRepository {
        get;
}
public abstract IAdministradorRepository AdministradorRepository {
        get;
}
public abstract IUsuarioRepository UsuarioRepository {
        get;
}
public abstract ICarritoRepository CarritoRepository {
        get;
}
public abstract ISoporteRepository SoporteRepository {
        get;
}
public abstract ILinPedidoRepository LinPedidoRepository {
        get;
}
public abstract IPagoRepository PagoRepository {
        get;
}
public abstract IItemCarritoRepository ItemCarritoRepository {
        get;
}
public abstract ISombreroRepository SombreroRepository {
        get;
}
public abstract IValoracionRepository ValoracionRepository {
        get;
}
public abstract IPersonalizacionRepository PersonalizacionRepository {
        get;
}
}
}
