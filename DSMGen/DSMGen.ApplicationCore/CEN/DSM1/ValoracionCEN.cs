

using System;
using System.Text;
using System.Collections.Generic;

using DSMGen.ApplicationCore.Exceptions;

using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.IRepository.DSM1;


namespace DSMGen.ApplicationCore.CEN.DSM1
{
/*
 *      Definition of the class ValoracionCEN
 *
 */
public partial class ValoracionCEN
{
private IValoracionRepository _IValoracionRepository;

public ValoracionCEN(IValoracionRepository _IValoracionRepository)
{
        this._IValoracionRepository = _IValoracionRepository;
}

public IValoracionRepository get_IValoracionRepository ()
{
        return this._IValoracionRepository;
}

public int Crear (string p_comentario, int p_puntuacion, System.Collections.Generic.IList<int> p_cliente, int p_sombrero)
{
        ValoracionEN valoracionEN = null;
        int oid;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();
        valoracionEN.Comentario = p_comentario;

        valoracionEN.Puntuacion = p_puntuacion;


        valoracionEN.Cliente = new System.Collections.Generic.List<DSMGen.ApplicationCore.EN.DSM1.ClienteEN>();
        if (p_cliente != null) {
                foreach (int item in p_cliente) {
                        DSMGen.ApplicationCore.EN.DSM1.ClienteEN en = new DSMGen.ApplicationCore.EN.DSM1.ClienteEN ();
                        en.IdUsuario = item;
                        valoracionEN.Cliente.Add (en);
                }
        }

        else{
                valoracionEN.Cliente = new System.Collections.Generic.List<DSMGen.ApplicationCore.EN.DSM1.ClienteEN>();
        }


        if (p_sombrero != -1) {
                // El argumento p_sombrero -> Property sombrero es oid = false
                // Lista de oids idValoracion
                valoracionEN.Sombrero = new DSMGen.ApplicationCore.EN.DSM1.SombreroEN ();
                valoracionEN.Sombrero.IdSombrero = p_sombrero;
        }



        oid = _IValoracionRepository.Crear (valoracionEN);
        return oid;
}

public void Modificar (int p_Valoracion_OID, string p_comentario, int p_puntuacion)
{
        ValoracionEN valoracionEN = null;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();
        valoracionEN.IdValoracion = p_Valoracion_OID;
        valoracionEN.Comentario = p_comentario;
        valoracionEN.Puntuacion = p_puntuacion;
        //Call to ValoracionRepository

        _IValoracionRepository.Modificar (valoracionEN);
}

public void Borrar (int idValoracion
                    )
{
        _IValoracionRepository.Borrar (idValoracion);
}

public ValoracionEN ConsultarID (int idValoracion
                                 )
{
        ValoracionEN valoracionEN = null;

        valoracionEN = _IValoracionRepository.ConsultarID (idValoracion);
        return valoracionEN;
}

public System.Collections.Generic.IList<ValoracionEN> ConsultarTodo (int first, int size)
{
        System.Collections.Generic.IList<ValoracionEN> list = null;

        list = _IValoracionRepository.ConsultarTodo (first, size);
        return list;
}
}
}
