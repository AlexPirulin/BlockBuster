using System;
using System.Collections.Generic;
using BlockBuster.Datos;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Logica
{
    public class ClienteLogica
    {
        private readonly ClienteDatos _clienteDatos;

        public ClienteLogica()
        {
            _clienteDatos = new ClienteDatos();
        }

        /// <summary>
        /// Obtiene la lista completa de clientes.
        /// </summary>
        public List<Cliente> ObtenerClientes()
        {
            return _clienteDatos.ListarClientes();
        }

        /// <summary>
        /// Busca clientes por término (nombre, apellido, teléfono o email).
        /// </summary>
        public List<Cliente> BuscarClientes(string criterio)
        {
            return _clienteDatos.BuscarClientes(criterio);
        }

        /// <summary>
        /// Obtiene un cliente por su identificador.
        /// </summary>
        public Cliente ObtenerCliente(int idCliente)
        {
            if (idCliente <= 0) return null;
            return _clienteDatos.ObtenerPorId(idCliente);
        }

        /// <summary>
        /// Valida y registra un nuevo cliente en el sistema.
        /// </summary>
        public bool RegistrarCliente(Cliente cliente, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (cliente == null)
            {
                mensajeError = "Los datos del cliente son requeridos.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(cliente.Nombre))
            {
                mensajeError = "El nombre del cliente es obligatorio.";
                return false;
            }

            try
            {
                cliente.Nombre = cliente.Nombre.Trim();
                cliente.Apellido = cliente.Apellido?.Trim();
                cliente.Telefono = cliente.Telefono?.Trim();
                cliente.Email = cliente.Email?.Trim();

                return _clienteDatos.InsertarCliente(cliente);
            }
            catch (Exception ex)
            {
                mensajeError = "Error al registrar cliente: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Valida y actualiza los datos de un cliente existente.
        /// </summary>
        public bool ModificarCliente(Cliente cliente, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (cliente == null || cliente.IdCliente <= 0)
            {
                mensajeError = "El identificador del cliente no es válido.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(cliente.Nombre))
            {
                mensajeError = "El nombre del cliente es obligatorio.";
                return false;
            }

            try
            {
                cliente.Nombre = cliente.Nombre.Trim();
                cliente.Apellido = cliente.Apellido?.Trim();
                cliente.Telefono = cliente.Telefono?.Trim();
                cliente.Email = cliente.Email?.Trim();

                return _clienteDatos.ActualizarCliente(cliente);
            }
            catch (Exception ex)
            {
                mensajeError = "Error al modificar cliente: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Elimina un cliente por su ID.
        /// </summary>
        public bool EliminarCliente(int idCliente, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (idCliente <= 0)
            {
                mensajeError = "Identificador de cliente no válido.";
                return false;
            }

            try
            {
                return _clienteDatos.EliminarCliente(idCliente);
            }
            catch (Exception ex)
            {
                mensajeError = "Error al eliminar cliente: " + ex.Message;
                return false;
            }
        }
    }
}
