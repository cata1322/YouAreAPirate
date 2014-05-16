using System;
using System.Collections.Generic;
using System.Text;
using TgcViewer.Example;
using TgcViewer;
using Microsoft.DirectX.Direct3D;
using System.Drawing;
using Microsoft.DirectX;
using TgcViewer.Utils.Modifiers;
using TgcViewer.Utils.TgcGeometry;

namespace AlumnoEjemplos.YouAreAPirate
{
    /// <summary>
    /// Ejemplo del alumno.
    /// </summary>
    public partial class EjemploAlumno : TgcExample
    {

        public void MetodoEjemeplo()
        {

        }

        public override string getCategory()
        {
            return "Pirate Ship";
        }


        public override string getName()
        {
            return "You Are A Pirate";
        }


        public override string getDescription()
        {
            return "MiIdea - Descripcion de la idea";
        }


        public override void init()
        {
            loadModifiers();
            initializeEnviroment();
            initializeShip();
            initializeCamera(ship.ship);
            //pueba del sol
            //initializeSol();
        }       


        public override void render(float elapsedTime)
        {
            loadEnviroment(elapsedTime);
            loadShip(elapsedTime);
            loadCamera(elapsedTime, ship.getBoundingBox());
            //pueba del sol
            //loadSol(elapsedTime);
        }       


        public override void close()
        {

        }

    }
}
