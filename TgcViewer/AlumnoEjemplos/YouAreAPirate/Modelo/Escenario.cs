using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlumnoEjemplos.YouAreAPirate.Objetos
{
    public class Escenario
    {

        public int CantidadEnemigos { get; set; }

        public double Ancho { get; set; }
        public double Alto { get; set; }


        public void InicializarEscenario(int _cantidadEnemigos, double _alto, double _ancho)
        {
            this.Alto = _alto;
            this.CantidadEnemigos = _cantidadEnemigos;
            this.Ancho = _ancho;
        }

    }
}
