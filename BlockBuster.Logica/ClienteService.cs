using System;
using System.Collections.Generic;
using BlockBuster.Datos;
using BlockBuster.Datos.Entidades;

namespace BlockBuster.Logica
{
    /// <summary>
    /// Servicio de capa lógica para guardar y buscar clientes (nombre, teléfono, correo).
    /// Valida permisos y datos antes de acceder a la capa de datos.
    /// </summary>
    public class ClienteService
    {
        private readonly ClienteDatos _clienteDatos;

        public ClienteService()
        {
            _clienteDatos = new ClienteDatos();
        }

        /// <summary>
        /// Obtiene la lista completa de clientes activos.
        /// </summary>
        public List<Cliente> ObtenerTodos()
        {
            try
            {
                return _clienteDatos.ListarClientes();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de clientes: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Busca clientes por nombre, teléfono o correo electrónico.
        /// </summary>
        public List<Cliente> Buscar(string criterio)
        {
            try
            {
                return _clienteDatos.BuscarClientes(criterio);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar clientes: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Obtiene un cliente por su identificador.
        /// </summary>
        public Cliente ObtenerPorId(int idCliente)
        {
            if (idCliente <= 0) return null;

            try
            {
                return _clienteDatos.ObtenerPorId(idCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el cliente: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Valida los datos y registra un nuevo cliente en el sistema.
        /// </summary>
        public bool Guardar(Cliente cliente, out string mensajeError)
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

            if (!string.IsNullOrWhiteSpace(cliente.Email) && !cliente.Email.Contains("@"))
            {
                mensajeError = "El correo electrónico no tiene un formato válido.";
                return false;
            }

            try
            {
                cliente.Nombre = cliente.Nombre.Trim();
                cliente.Apellido = cliente.Apellido?.Trim() ?? string.Empty;
                cliente.Telefono = cliente.Telefono?.Trim() ?? string.Empty;
                cliente.Email = cliente.Email?.Trim() ?? string.Empty;
                cliente.Direccion = cliente.Direccion?.Trim() ?? string.Empty;
                cliente.Activo = true;
                cliente.FechaRegistro = DateTime.Now;

                bool resultado = _clienteDatos.InsertarCliente(cliente);
                if (!resultado)
                {
                    mensajeError = "No se pudo registrar el cliente en la base de datos.";
                }
                return resultado;
            }
            catch (Exception ex)
            {
                mensajeError = "Error al registrar cliente: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Valida los datos y actualiza un cliente existente.
        /// </summary>
        public bool Actualizar(Cliente cliente, out string mensajeError)
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

            if (!string.IsNullOrWhiteSpace(cliente.Email) && !cliente.Email.Contains("@"))
            {
                mensajeError = "El correo electrónico no tiene un formato válido.";
                return false;
            }

            try
            {
                cliente.Nombre = cliente.Nombre.Trim();
                cliente.Apellido = cliente.Apellido?.Trim() ?? string.Empty;
                cliente.Telefono = cliente.Telefono?.Trim() ?? string.Empty;
                cliente.Email = cliente.Email?.Trim() ?? string.Empty;
                cliente.Direccion = cliente.Direccion?.Trim() ?? string.Empty;

                bool resultado = _clienteDatos.ActualizarCliente(cliente);
                if (!resultado)
                {
                    mensajeError = "No se pudo actualizar el cliente.";
                }
                return resultado;
            }
            catch (Exception ex)
            {
                mensajeError = "Error al actualizar cliente: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Elimina un cliente por su identificador.
        /// </summary>
        public bool Eliminar(int idCliente, out string mensajeError)
        {
            mensajeError = string.Empty;

            if (idCliente <= 0)
            {
                mensajeError = "Identificador de cliente no válido.";
                return false;
            }

            try
            {
                bool resultado = _clienteDatos.EliminarCliente(idCliente);
                if (!resultado)
                {
                    mensajeError = "No se encontró el cliente o no se pudo eliminar.";
                }
                return resultado;
            }
            catch (Exception ex)
            {
                mensajeError = "Error al eliminar cliente: " + ex.Message;
                return false;
            }
        }
    }
}

