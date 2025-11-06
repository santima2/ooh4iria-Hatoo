
using System;
using System.Text;
using System.Collections.Generic;
using DSMGen.ApplicationCore.Exceptions;
using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.IRepository.DSM1;


/*PROTECTED REGION ID(usingDSMGen.ApplicationCore.CEN.DSM1_Sombrero_decrementarStock) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSMGen.ApplicationCore.CEN.DSM1
{
public partial class SombreroCEN
{
public void DecrementarStock (int p_Sombrero_OID, int p_cantidad)
{
        /*PROTECTED REGION ID(DSMGen.ApplicationCore.CEN.DSM1_Sombrero_decrementarStock) ENABLED START*/

        SombreroEN en = _ISombreroRepository.ConsultarID (p_Sombrero_OID);

        if (!(en.Stock >= p_cantidad))
                throw new ModelException ("La cantidad siempre tiene que ser inferior o igual que el sotck");

        en.Stock -= p_cantidad;

        _ISombreroRepository.ModifyDefault (en);

        /*PROTECTED REGION END*/
}
}
}
