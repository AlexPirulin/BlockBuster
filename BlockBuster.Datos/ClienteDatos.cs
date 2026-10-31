using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Datos
{
    public class ClienteDatos
    {
        public ClienteDatos()
        {
            BlockBusterDbContext.InicializarBaseDatos();
        }

        /// <summary>
        /// Obtiene todos los clientes registrados.
        /// </summary>
        public List<Cliente> ListarClientes()
        {
            using (var db = new BlockBusterDbContext())
            {
                return db.Clientes.AsNoTracking().ToList();
            }
        }

        /// <summary>
        /// Obtiene un cliente por su identificador.
        /// </summary>
        public Cliente ObtenerPorId(int idCliente)
        {
            using (var db = new BlockBusterDbContext())
            {
                return db.Clientes.Find(idCliente);
            }
        }

        /// <summary>
        /// Busca clientes por nombre, apellido, teléfono o email.
        /// </summary>
        public List<Cliente> BuscarClientes(string criterio)
        {
            using (var db = new BlockBusterDbContext())
            {
                if (string.IsNullOrWhiteSpace(criterio))
                    return db.Clientes.AsNoTracking().ToList();

                criterio = criterio.ToLower();
                return db.Clientes.AsNoTracking()
                    .Where(c => (c.Nombre != null && c.Nombre.ToLower().Contains(criterio))
                             || (c.Apellido != null && c.Apellido.ToLower().Contains(criterio))
                             || (c.Telefono != null && c.Telefono.Contains(criterio))
                             || (c.Email != null && c.Email.ToLower().Contains(criterio)))
                    .ToList();
            }
        }

        /// <summary>
        /// Registra un nuevo cliente en la base de datos.
        /// </summary>
        public bool InsertarCliente(Cliente cliente)
        {
            using (var db = new BlockBusterDbContext())
            {
                db.Clientes.Add(cliente);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Actualiza la información de un cliente existente.
        /// </summary>
        public bool ActualizarCliente(Cliente cliente)
        {
            using (var db = new BlockBusterDbContext())
            {
                db.Clientes.Update(cliente);
                return db.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Elimina un cliente por su ID.
        /// </summary>
        public bool EliminarCliente(int idCliente)
        {
            using (var db = new BlockBusterDbContext())
            {
                var cliente = db.Clientes.Find(idCliente);
                if (cliente == null) return false;

                db.Clientes.Remove(cliente);
                return db.SaveChanges() > 0;
            }
        }
    }
}
