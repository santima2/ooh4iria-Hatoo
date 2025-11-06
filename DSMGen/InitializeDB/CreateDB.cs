
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.CEN.DSM1;
using DSMGen.Infraestructure.Repository.DSM1;
using DSMGen.Infraestructure.CP;
using DSMGen.ApplicationCore.Exceptions;

using DSMGen.ApplicationCore.CP.DSM1;
using DSMGen.Infraestructure.Repository;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception)
        {
                throw;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        try
        {
                // Initialising  CENs
                PedidoRepository pedidorepository = new PedidoRepository ();
                PedidoCEN pedidocen = new PedidoCEN (pedidorepository);
                ClienteRepository clienterepository = new ClienteRepository ();
                ClienteCEN clientecen = new ClienteCEN (clienterepository);
                AdministradorRepository administradorrepository = new AdministradorRepository ();
                AdministradorCEN administradorcen = new AdministradorCEN (administradorrepository);
                UsuarioRepository usuariorepository = new UsuarioRepository ();
                UsuarioCEN usuariocen = new UsuarioCEN (usuariorepository);
                CarritoRepository carritorepository = new CarritoRepository ();
                CarritoCEN carritocen = new CarritoCEN (carritorepository);
                SoporteRepository soporterepository = new SoporteRepository ();
                SoporteCEN soportecen = new SoporteCEN (soporterepository);
                LinPedidoRepository linpedidorepository = new LinPedidoRepository ();
                LinPedidoCEN linpedidocen = new LinPedidoCEN (linpedidorepository);
                PagoRepository pagorepository = new PagoRepository ();
                PagoCEN pagocen = new PagoCEN (pagorepository);
                ItemCarritoRepository itemcarritorepository = new ItemCarritoRepository ();
                ItemCarritoCEN itemcarritocen = new ItemCarritoCEN (itemcarritorepository);
                SombreroRepository sombrerorepository = new SombreroRepository ();
                SombreroCEN sombrerocen = new SombreroCEN (sombrerorepository);
                ValoracionRepository valoracionrepository = new ValoracionRepository ();
                ValoracionCEN valoracioncen = new ValoracionCEN (valoracionrepository);
                PersonalizacionRepository personalizacionrepository = new PersonalizacionRepository ();
                PersonalizacionCEN personalizacioncen = new PersonalizacionCEN (personalizacionrepository);



                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/

                
                int idCliente = clientecen.New_ (
                        "Cliente Ejemplo",
                        "cliente@test.com",
                        "666555444",
                        "clientepass"
                        );
                Console.WriteLine ("Cliente inicial creado con id: " + idCliente);

                int idAdmin = administradorcen.New_ (
                        "Admin Principal",
                        "admin@empresa.com",
                        "900123456",
                        "admin123"
                        );
                Console.WriteLine ("Administrador inicial creado con id: " + idAdmin);


                int idCarrito = carritocen.Crear (
                        0.0,
                        idCliente
                        );
                Console.WriteLine ("Carrito creado con id: " + idCarrito);

                int idItemCarrito = itemcarritocen.Crear (
                        1,
                        20.00,
                        idCarrito
                        );
                Console.WriteLine ("ItemCarrito creado con id: " + idItemCarrito);



                int sombrero1 = sombrerocen.Crear ("Sombrero1", "Vaquero", "Marron", "Cuero", "Asda", 20.00f, "sombrero chulisimo de vaquero", idAdmin, idItemCarrito, 100);

                Console.WriteLine ("Sombrero 1 creado con id: " + sombrero1);



                int idPedido = pedidocen.Crear (
                        DateTime.Now,
                        idCliente
                        );
                Console.WriteLine ("Pedido creado con id: " + idPedido);

                int idPago = pagocen.Crear (
                        "Tarjeta",
                        20.00,
                        idPedido 
                        );
                Console.WriteLine ("Pago creado con id: " + idPago);



                linpedidocen.Crear (
                        2,
                        2,
                        idPedido, 
                        sombrero1
                        );

                Console.WriteLine ("Linea de pedido creada para el sombrero 1");

                sombrerocen.DecrementarStock (sombrero1, 2);

                Console.WriteLine ("Stock del sombrero 1 decrementado en 2 unidades");


                SombreroEN sombreroVerificado = sombrerocen.ConsultarID (sombrero1);

                if (sombreroVerificado.Stock == 98) {
                        Console.WriteLine ("VERIFICACION EXITOSA: El stock del sombrero 1 es correctamente 98.");
                }
                else{
                        Console.WriteLine ("VERIFICACION FALLIDA: El stock esperado era 98, pero el valor real es {sombreroVerificado.Stock}");
                }

                soportecen.Crear (
                        "Necesito ayuda con mi pedido.",
                        new List<int> { idCliente }
                        );

                Console.WriteLine ("ESTA TODO GUCCI");

                PedidoCP pedidoCP = new PedidoCP (new SessionCPNHibernate ());
                pedidoCP.EnviarPedido (idPedido);

                sombrerocen.AumentarStock (sombrero1, 2);

                carritocen.AplicarDescuento (idCarrito, 99);

                IList<PedidoEN> pedidosPortArt = pedidocen.PpedidosSombrero (sombrero1);

                Console.WriteLine ("Pedidos que incluyen el sombrero 1:" + sombrero1);


                foreach (PedidoEN pedido in pedidosPortArt) {
                        Console.WriteLine ("Contiene el pedido" + pedido.IdPedido);
                }

                string modeloBuscado = "Clásico";
                string colorBuscado = "Rojo";

                IList<SombreroEN> sombrerosEncontrados = sombrerocen.PsombrerosPorModeloYColor (modeloBuscado, colorBuscado);

                Console.WriteLine ("Sombreros encontrados con Modelo: '{modeloBuscado}' y Color: '{colorBuscado}':");

                foreach (SombreroEN sombrero in sombrerosEncontrados) {
                        Console.WriteLine ("Contiene el sombrero con ID: {sombrero.IdSombrero}, Nombre: {sombrero.Nombre}");
                }

                Console.WriteLine ("Total de sombreros encontrados: {sombrerosEncontrados.Count}");

                IList<PedidoEN> pedidosPortPrec = pedidocen.PpedidosEsrado (sombrero1);

                Console.WriteLine ("Pedidos que incluyen el sombrero 1:" + sombrero1);


                foreach (PedidoEN pedido in pedidosPortPrec) {
                        Console.WriteLine ("Contiene el pedido" + pedido.IdPedido);
                }

                IList<SombreroEN> sombrerossPrecio = sombrerocen.PporPrecio (22.2);

                foreach (SombreroEN sombrero in sombrerossPrecio) {
                        Console.WriteLine ("Contiene el pedido" + sombrero.IdSombrero);
                }


                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw;
        }
}
}
}
