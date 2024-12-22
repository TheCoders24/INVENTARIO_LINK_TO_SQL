using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DCliente
    {
        private string Connection;

        public DCliente(string ConnString) 
        { 
            this.Connection = ConexionesDB.ConnectionString;
        }


        // Obtenemos el contexto de LINQ to SQL
        private DataAbarroteDBDataContext ObtenerContexto()
        {
            return new DataAbarroteDBDataContext(Connection);
        }

        // Metodo async para Obtener todos los Clientes
        public async Task<IQueryable<Cliente>> ObtenemosClientes()
        {
            return await Task.Run(() =>
            {
                using (var Contexto = ObtenerContexto())
                {
                    return Contexto.Cliente.AsQueryable(); // Devuelve todos los Clientes disponibles
                }
            });
        }

        // Metodo async para obtener un cliente por su id
        public async Task<Cliente> ObtenerClienteID(int idcliente)
        {
            return await Task.Run(() =>
            {
                using (var contexto = ObtenerContexto())
                {
                    return contexto.Cliente.FirstOrDefault(c => c.ID_Cliente == idcliente); //devolvemos el cliente del id
                }
            });
        }

        // Método asíncrono para agregar un nuevo cliente
        public async Task<int> AgregarClienteAsync(string nombre,string telefono,string direccion)
        {
            return await Task.Run(() =>
            {
                using (var contexto = ObtenerContexto())
                {
                    var nuevoCliente = new Cliente
                    {
                        Nombre = nombre,
                        Direccion = direccion,
                        Telefono = telefono
                    };

                    contexto.Cliente.InsertOnSubmit(nuevoCliente);
                    contexto.SubmitChanges(); // Guarda los cambios
                    return nuevoCliente.ID_Cliente; // Devuelve el ID del cliente insertado
                }
            });
        }

        // Método asíncrono para actualizar un cliente
        public async Task<bool> ActualizarClienteAsync(int idCliente, string nombre, string direccion, string telefono)
        {
            return await Task.Run(() =>
            {
                using (var contexto = ObtenerContexto())
                {
                    var cliente = contexto.Cliente.FirstOrDefault(c => c.ID_Cliente == idCliente);
                    if (cliente != null)
                    {
                        cliente.Nombre = nombre;
                        cliente.Direccion = direccion;
                        cliente.Telefono = telefono;

                        contexto.SubmitChanges(); // Guarda los cambios
                        return true; // Devuelve true si se actualizó correctamente
                    }
                    return false; // Devuelve false si no se encontró el cliente
                }
            });
        }

        // Método asíncrono para eliminar un cliente
        public async Task<bool> EliminarClienteAsync(int idCliente)
        {
            return await Task.Run(() =>
            {
                using (var contexto = ObtenerContexto())
                {
                    var cliente = contexto.Cliente.FirstOrDefault(c => c.ID_Cliente == idCliente);
                    if (cliente != null)
                    {
                        contexto.Cliente.DeleteOnSubmit(cliente);
                        contexto.SubmitChanges(); // Guarda los cambios
                        return true; // Devuelve true si se eliminó correctamente
                    }
                    return false; // Devuelve false si no se encontró el cliente
                }
            });
        }


    }
}
