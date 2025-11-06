

using System;
using System.Text;
using System.Collections.Generic;

using DSMGen.ApplicationCore.Exceptions;

using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.IRepository.DSM1;


namespace DSMGen.ApplicationCore.CEN.DSM1
{
/*
 *      Definition of the class SombreroCEN
 *
 */
public partial class SombreroCEN
{
private ISombreroRepository _ISombreroRepository;

public SombreroCEN(ISombreroRepository _ISombreroRepository)
{
        this._ISombreroRepository = _ISombreroRepository;
}

public ISombreroRepository get_ISombreroRepository ()
{
        return this._ISombreroRepository;
}

public int Crear (string p_nombre, string p_modelo, string p_color, string p_material, string p_attemporadatribute, double p_precioBase, string p_descripcion, int p_administrador, int p_itemCarrito, int p_stock)
{
        SombreroEN sombreroEN = null;
        int oid;

        //Initialized SombreroEN
        sombreroEN = new SombreroEN ();
        sombreroEN.Nombre = p_nombre;

        sombreroEN.Modelo = p_modelo;

        sombreroEN.Color = p_color;

        sombreroEN.Material = p_material;

        sombreroEN.Attemporadatribute = p_attemporadatribute;

        sombreroEN.PrecioBase = p_precioBase;

        sombreroEN.Descripcion = p_descripcion;


        if (p_administrador != -1) {
                // El argumento p_administrador -> Property administrador es oid = false
                // Lista de oids idSombrero
                sombreroEN.Administrador = new DSMGen.ApplicationCore.EN.DSM1.AdministradorEN ();
                sombreroEN.Administrador.IdUsuario = p_administrador;
        }


        if (p_itemCarrito != -1) {
                // El argumento p_itemCarrito -> Property itemCarrito es oid = false
                // Lista de oids idSombrero
                sombreroEN.ItemCarrito = new DSMGen.ApplicationCore.EN.DSM1.ItemCarritoEN ();
                sombreroEN.ItemCarrito.Cantidad = p_itemCarrito;
        }

        sombreroEN.Stock = p_stock;



        oid = _ISombreroRepository.Crear (sombreroEN);
        return oid;
}

public void Modificar (int p_Sombrero_OID, string p_nombre, string p_modelo, string p_color, string p_material, string p_attemporadatribute, double p_precioBase, string p_descripcion, int p_stock)
{
        SombreroEN sombreroEN = null;

        //Initialized SombreroEN
        sombreroEN = new SombreroEN ();
        sombreroEN.IdSombrero = p_Sombrero_OID;
        sombreroEN.Nombre = p_nombre;
        sombreroEN.Modelo = p_modelo;
        sombreroEN.Color = p_color;
        sombreroEN.Material = p_material;
        sombreroEN.Attemporadatribute = p_attemporadatribute;
        sombreroEN.PrecioBase = p_precioBase;
        sombreroEN.Descripcion = p_descripcion;
        sombreroEN.Stock = p_stock;
        //Call to SombreroRepository

        _ISombreroRepository.Modificar (sombreroEN);
}

public void Borrar (int idSombrero
                    )
{
        _ISombreroRepository.Borrar (idSombrero);
}

public SombreroEN ConsultarID (int idSombrero
                               )
{
        SombreroEN sombreroEN = null;

        sombreroEN = _ISombreroRepository.ConsultarID (idSombrero);
        return sombreroEN;
}

public System.Collections.Generic.IList<SombreroEN> ConsultarTodo (int first, int size)
{
        System.Collections.Generic.IList<SombreroEN> list = null;

        list = _ISombreroRepository.ConsultarTodo (first, size);
        return list;
}
public System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.SombreroEN> PsombrerosPorModeloYColor (string p_modelo, string p_color)
{
        return _ISombreroRepository.PsombrerosPorModeloYColor (p_modelo, p_color);
}
public System.Collections.Generic.IList<DSMGen.ApplicationCore.EN.DSM1.SombreroEN> PporPrecio (double ? p_precio)
{
        return _ISombreroRepository.PporPrecio (p_precio);
}
}
}
