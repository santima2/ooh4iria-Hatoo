

using System;
using System.Text;
using System.Collections.Generic;

using DSMGen.ApplicationCore.Exceptions;

using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.IRepository.DSM1;


namespace DSMGen.ApplicationCore.CEN.DSM1
{
/*
 *      Definition of the class ItemCarritoCEN
 *
 */
public partial class ItemCarritoCEN
{
private IItemCarritoRepository _IItemCarritoRepository;

public ItemCarritoCEN(IItemCarritoRepository _IItemCarritoRepository)
{
        this._IItemCarritoRepository = _IItemCarritoRepository;
}

public IItemCarritoRepository get_IItemCarritoRepository ()
{
        return this._IItemCarritoRepository;
}

public int Crear (int p_cantidad, double p_subtotal, int p_carrito)
{
        ItemCarritoEN itemCarritoEN = null;
        int oid;

        //Initialized ItemCarritoEN
        itemCarritoEN = new ItemCarritoEN ();
        itemCarritoEN.Cantidad = p_cantidad;

        itemCarritoEN.Subtotal = p_subtotal;


        if (p_carrito != -1) {
                // El argumento p_carrito -> Property carrito es oid = false
                // Lista de oids cantidad
                itemCarritoEN.Carrito = new DSMGen.ApplicationCore.EN.DSM1.CarritoEN ();
                itemCarritoEN.Carrito.IdCarrito = p_carrito;
        }



        oid = _IItemCarritoRepository.Crear (itemCarritoEN);
        return oid;
}

public void Modificar (int p_ItemCarrito_OID, double p_subtotal)
{
        ItemCarritoEN itemCarritoEN = null;

        //Initialized ItemCarritoEN
        itemCarritoEN = new ItemCarritoEN ();
        itemCarritoEN.Cantidad = p_ItemCarrito_OID;
        itemCarritoEN.Subtotal = p_subtotal;
        //Call to ItemCarritoRepository

        _IItemCarritoRepository.Modificar (itemCarritoEN);
}

public void Borrar (int cantidad
                    )
{
        _IItemCarritoRepository.Borrar (cantidad);
}

public ItemCarritoEN ConsultarID (int cantidad
                                  )
{
        ItemCarritoEN itemCarritoEN = null;

        itemCarritoEN = _IItemCarritoRepository.ConsultarID (cantidad);
        return itemCarritoEN;
}

public System.Collections.Generic.IList<ItemCarritoEN> ConsultarTodo (int first, int size)
{
        System.Collections.Generic.IList<ItemCarritoEN> list = null;

        list = _IItemCarritoRepository.ConsultarTodo (first, size);
        return list;
}
}
}
