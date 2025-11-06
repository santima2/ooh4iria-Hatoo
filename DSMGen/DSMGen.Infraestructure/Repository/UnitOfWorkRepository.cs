

using DSMGen.ApplicationCore.IRepository.DSM1;
using DSMGen.Infraestructure.Repository.DSM1;
using DSMGen.Infraestructure.CP;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSMGen.Infraestructure.Repository
{
public class UnitOfWorkRepository : GenericUnitOfWorkRepository
{
SessionCPNHibernate session;


public UnitOfWorkRepository(SessionCPNHibernate session)
{
        this.session = session;
}

public override IPedidoRepository PedidoRepository {
        get
        {
                this.pedidorepository = new PedidoRepository ();
                this.pedidorepository.setSessionCP (session);
                return this.pedidorepository;
        }
}

public override IClienteRepository ClienteRepository {
        get
        {
                this.clienterepository = new ClienteRepository ();
                this.clienterepository.setSessionCP (session);
                return this.clienterepository;
        }
}

public override IAdministradorRepository AdministradorRepository {
        get
        {
                this.administradorrepository = new AdministradorRepository ();
                this.administradorrepository.setSessionCP (session);
                return this.administradorrepository;
        }
}

public override IUsuarioRepository UsuarioRepository {
        get
        {
                this.usuariorepository = new UsuarioRepository ();
                this.usuariorepository.setSessionCP (session);
                return this.usuariorepository;
        }
}

public override ICarritoRepository CarritoRepository {
        get
        {
                this.carritorepository = new CarritoRepository ();
                this.carritorepository.setSessionCP (session);
                return this.carritorepository;
        }
}

public override ISoporteRepository SoporteRepository {
        get
        {
                this.soporterepository = new SoporteRepository ();
                this.soporterepository.setSessionCP (session);
                return this.soporterepository;
        }
}

public override ILinPedidoRepository LinPedidoRepository {
        get
        {
                this.linpedidorepository = new LinPedidoRepository ();
                this.linpedidorepository.setSessionCP (session);
                return this.linpedidorepository;
        }
}

public override IPagoRepository PagoRepository {
        get
        {
                this.pagorepository = new PagoRepository ();
                this.pagorepository.setSessionCP (session);
                return this.pagorepository;
        }
}

public override IItemCarritoRepository ItemCarritoRepository {
        get
        {
                this.itemcarritorepository = new ItemCarritoRepository ();
                this.itemcarritorepository.setSessionCP (session);
                return this.itemcarritorepository;
        }
}

public override ISombreroRepository SombreroRepository {
        get
        {
                this.sombrerorepository = new SombreroRepository ();
                this.sombrerorepository.setSessionCP (session);
                return this.sombrerorepository;
        }
}

public override IValoracionRepository ValoracionRepository {
        get
        {
                this.valoracionrepository = new ValoracionRepository ();
                this.valoracionrepository.setSessionCP (session);
                return this.valoracionrepository;
        }
}

public override IPersonalizacionRepository PersonalizacionRepository {
        get
        {
                this.personalizacionrepository = new PersonalizacionRepository ();
                this.personalizacionrepository.setSessionCP (session);
                return this.personalizacionrepository;
        }
}
}
}

