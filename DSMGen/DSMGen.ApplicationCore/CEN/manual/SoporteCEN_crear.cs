
using System;
using System.Text;
using System.Collections.Generic;
using DSMGen.ApplicationCore.Exceptions;
using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.IRepository.DSM1;


/*PROTECTED REGION ID(usingDSMGen.ApplicationCore.CEN.DSM1_Soporte_crear) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DSMGen.ApplicationCore.CEN.DSM1
{
public partial class SoporteCEN
{
public int Crear (string p_mensaje, System.Collections.Generic.IList<int> p_cliente)
{
        /*PROTECTED REGION ID(DSMGen.ApplicationCore.CEN.DSM1_Soporte_crear_customized) ENABLED START*/

        // Se asume que el m�todo Crear tiene la firma:
        // public int Crear (string p_mensaje, System.Collections.Generic.IList<int> p_cliente)

        SoporteEN soporteEN = null;

        int oid;

        //Initialized SoporteEN
        soporteEN = new SoporteEN ();
        soporteEN.Mensaje = p_mensaje;
        soporteEN.FechaEnvio = DateTime.Now;

        // Inicializar la lista antes de usarla
        soporteEN.Cliente = new System.Collections.Generic.List<DSMGen.ApplicationCore.EN.DSM1.ClienteEN>();

        // CORRECCI�N AQU�: Usar 'foreach' en lugar de 'for' con ':'
        if (p_cliente != null) {
                // Asumiendo que p_cliente es una colecci�n de IDs (int)
                foreach (int item in p_cliente) {
                        DSMGen.ApplicationCore.EN.DSM1.ClienteEN en = new DSMGen.ApplicationCore.EN.DSM1.ClienteEN ();
                        en.IdUsuario = item;

                        // Usar .Cliente.Add(en) o .Cliente().Add(en) dependiendo de si Cliente es propiedad o m�todo
                        soporteEN.Cliente.Add (en);
                }
        }

        // NOTA: El bloque 'else' es redundante si inicializas la lista fuera del 'if'.
        // Si la lista ya se inicializ� arriba, puedes eliminar el 'else'.

        //Call to SoporteRepository

        oid = _ISoporteRepository.Crear (soporteEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
