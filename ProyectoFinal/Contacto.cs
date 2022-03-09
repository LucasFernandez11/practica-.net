using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    class Contacto : IComparable<Contacto>
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public Contacto()
        {
        }

        public Contacto(string nombre, string telefono, string email)
        {
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Contacto c = obj as Contacto;
            if (c == null)
            {
                return false;
            }

            return string.Equals(Nombre, c.Nombre) && string.Equals(Telefono, c.Telefono);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashNombre = (Nombre != null ? Nombre.GetHashCode() : 0);
                int hashTelefono = (Telefono != null ? Telefono.GetHashCode() : 0);
                return (hashNombre * 397) ^ (hashTelefono);
            }
        }

        public override string ToString()
        {
            return string.Format("Nombre: {0}\nTeléfono: {1}\nEmail: {2}\n", Nombre, Telefono, Email);
        }

        public int CompareTo(Contacto other)
        {
            return Nombre.CompareTo(other.Nombre);
        }
    }
}
