
using System;
using System.Text;
using System.Collections.Generic;
using DSMGen.ApplicationCore.Exceptions;
using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.IRepository.DSM1;


/*PROTECTED REGION ID(usingDSMGen.ApplicationCore.CEN.DSM1_Carrito_aplicarDescuento) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSMGen.ApplicationCore.CEN.DSM1
{
public partial class CarritoCEN
{
public void AplicarDescuento (int p_oid, int p_descuento)
{
        /*PROTECTED REGION ID(DSMGen.ApplicationCore.CEN.DSM1_Carrito_aplicarDescuento) ENABLED START*/

        // Write here your custom code...

        CarritoEN carrito = _ICarritoRepository.ConsultarID (p_oid);

        if ((p_descuento >= 100 || p_descuento <= 0)) {
                throw new ModelException ("El descuento tiene que ser menos que 100 y mayor que 0");
        }
        carrito.Total = carrito.Total * (100 - p_descuento) / 100;

        _ICarritoRepository.ModifyDefault (carrito);
        /*PROTECTED REGION END*/
}
}
}
