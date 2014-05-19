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
        List<ShipObject> shipEnemies { get; set; }        

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
            shipEnemies = new List<ShipObject>();
            shipEnemies.Add(new ShipObject(EnumShipType.Standard, new Vector3(0, 0, 50)));
            loadModifiers();
            initializeEnviroment();
            initializeShip(EnumShipType.Standard,new Vector3(0,0,0));
            initializeEnemies(shipEnemies);
            initializeCamera(ship.ship);
            //pueba del sol
            //initializeSol();
        }

        


        public override void render(float elapsedTime)
        {
            loadEnviroment(elapsedTime);
            loadShip(elapsedTime);
            loadCamera(elapsedTime, ship.getBoundingBox());
            loadEnemies(elapsedTime);
            //pueba del sol
            //loadSol(elapsedTime);
        }

         


        public override void close()
        {

        }

    }
}
