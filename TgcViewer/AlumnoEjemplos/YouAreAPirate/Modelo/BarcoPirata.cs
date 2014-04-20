using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlumnoEjemplos.YouAreAPirate.Objetos
{
    public class BarcoPirata
    {
        public int CantidadPiratas { get; set; }

        public void InicializarBarcoPirata(int _cantidadPiratas)
        {
            this.CantidadPiratas = _cantidadPiratas;
        }


    }
}
