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
            initializeCamera(ship);
        }


        public override void render(float elapsedTime)
        {

            loadEnviroment(elapsedTime);
            loadShip(elapsedTime);
            loadCamera(elapsedTime, ship.BoundingBox);

        }

        private void loadModifiers()
        {
            GuiController.Instance.Modifiers.addVertex3f("skyPosition", new Vector3(0, 0, 0), new Vector3(1000, 1000, 1000), new Vector3(20, 20, 20));
            GuiController.Instance.Modifiers.addInt("skyRadius", 100, 10000, 2000);
            GuiController.Instance.Modifiers.addVertex3f("oceanPosition", new Vector3(-1000, -1000, -1000), new Vector3(1000, 1000, 1000), new Vector3(-600, 0, -600));
            GuiController.Instance.Modifiers.addVertex3f("oceanScale", new Vector3(10, 10, 10), new Vector3(1000, 1000, 1000), new Vector3(20, 20, 20));


            //GuiController.Instance.Modifiers.addVertex3f("rotation", new Vector3(-180, -180, -180), new Vector3(180, 180, 180), new Vector3(0, 0, 0));
            //GuiController.Instance.Modifiers.addTexture("texture", GuiController.Instance.ExamplesMediaDir + "\\Texturas\\madera.jpg");
            //GuiController.Instance.Modifiers.addVertex2f("offset", new Vector2(-0.5f, -0.5f), new Vector2(0.9f, 0.9f), new Vector2(0, 0));
            //GuiController.Instance.Modifiers.addVertex2f("tiling", new Vector2(0.1f, 0.1f), new Vector2(4, 4), new Vector2(1, 1));
            //GuiController.Instance.Modifiers.addColor("color", Color.White);
            //GuiController.Instance.Modifiers.addBoolean("boundingBox", "BoundingBox", false);
        }


        public override void close()
        {

        }

    }
}
