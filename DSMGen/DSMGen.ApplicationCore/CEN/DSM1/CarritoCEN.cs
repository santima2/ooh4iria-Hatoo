

using System;
using System.Text;
using System.Collections.Generic;

using DSMGen.ApplicationCore.Exceptions;

using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.IRepository.DSM1;


namespace DSMGen.ApplicationCore.CEN.DSM1
{
/*
 *      Definition of the class CarritoCEN
 *
 */
public partial class CarritoCEN
{
private ICarritoRepository _ICarritoRepository;

public CarritoCEN(ICarritoRepository _ICarritoRepository)
{
        this._ICarritoRepository = _ICarritoRepository;
}

public ICarritoRepository get_ICarritoRepository ()
{
        return this._ICarritoRepository;
}

public int Crear (double p_total, int p_cliente)
{
        CarritoEN carritoEN = null;
        int oid;

        //Initialized CarritoEN
        carritoEN = new CarritoEN ();
        carritoEN.Total = p_total;


        if (p_cliente != -1) {
                // El argumento p_cliente -> Property cliente es oid = false
                // Lista de oids idCarrito
                carritoEN.Cliente = new DSMGen.ApplicationCore.EN.DSM1.ClienteEN ();
                carritoEN.Cliente.IdUsuario = p_cliente;
        }



        oid = _ICarritoRepository.Crear (carritoEN);
        return oid;
}

public void Modificar (int p_Carrito_OID, double p_total)
{
        CarritoEN carritoEN = null;

        //Initialized CarritoEN
        carritoEN = new CarritoEN ();
        carritoEN.IdCarrito = p_Carrito_OID;
        carritoEN.Total = p_total;
        //Call to CarritoRepository

        _ICarritoRepository.Modificar (carritoEN);
}

public void Borrar (int idCarrito
                    )
{
        _ICarritoRepository.Borrar (idCarrito);
}

public CarritoEN ConsultarID (int idCarrito
                              )
{
        CarritoEN carritoEN = null;

        carritoEN = _ICarritoRepository.ConsultarID (idCarrito);
        return carritoEN;
}

public System.Collections.Generic.IList<CarritoEN> ConsultarTodo (int first, int size)
{
        System.Collections.Generic.IList<CarritoEN> list = null;

        list = _ICarritoRepository.ConsultarTodo (first, size);
        return list;
}
}
}
