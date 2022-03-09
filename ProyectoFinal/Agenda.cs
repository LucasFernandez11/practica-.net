using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    class Agenda
    {
        private const int TAM = 10;
        private Contacto[] _contactos;
        private int _index;

        public int NumContactos
        {
            get
            {
                return _index;
            }
        }

        public Agenda()
        {
            _index = 0;
            _contactos = new Contacto[TAM];
        }

        public void AgregarContacto(Contacto contacto)
        {
            if (_index < TAM)
            {
                _contactos[_index] = contacto;
                _index++;
            }
            else
            {
                Console.WriteLine("Agenda Llena");
            }
        }

        public void BorrarUltimoContacto()
        {
            if (_index > 0)
            {
                _contactos[_index] = null;
                _index--;
            }
            else
            {
                Console.WriteLine("La agenda ya está vacía");
            }
        }

        private bool NoHayContactos()
        {
            if(_index == 0)
            {
                Console.WriteLine("No hay contactos");
                return true;
            }

            return false;
        }

        public void MostrarOrdenados()
        {
            if (NoHayContactos()) { return; }

            Contacto[] ordenados = new Contacto[_index];
            Array.Copy(_contactos, ordenados, _index);
            Array.Sort(ordenados);

            Console.WriteLine(CadenaContactos(ordenados));
        }

        public void MostrarOrdenadosDesc()
        {
            if (NoHayContactos()) { return; }

            Contacto[] ordenados = new Contacto[_index];
            Array.Copy(_contactos, ordenados, _index);
            Array.Sort(ordenados);
            Array.Reverse(ordenados);

            Console.WriteLine(CadenaContactos(ordenados)); 
        }

        public Contacto BuscarPorNombre(string nombre)
        {
            foreach (Contacto contacto in _contactos)
            {
                if (contacto != null && contacto.Nombre == nombre)
                {
                    return contacto;
                }
            }

            return null;
        }

        public void MostrarContactos()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return CadenaContactos(_contactos);
        }

        private string CadenaContactos(Contacto[] contactos)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _index; i++)
            {
                if(_contactos[i] == null) { continue; }

                string dato = string.Format("{0}. {1}", i + 1, contactos[i]);
                sb.AppendLine(dato);
            }

            return sb.ToString();
        }
    }
}
