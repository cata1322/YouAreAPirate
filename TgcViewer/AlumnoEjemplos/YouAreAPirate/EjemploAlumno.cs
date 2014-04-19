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

namespace AlumnoEjemplos.MiGrupo
{
    /// <summary>
    /// Ejemplo del alumno
    /// </summary>
    public class EjemploAlumno : TgcExample
    {
        TgcBox mobileCube, ocean;

        public override string getCategory()
        {
            return "AlumnoEjemplos";
        }


        public override string getName()
        {
            return "Grupo 99";
        }


        public override string getDescription()
        {
            return "MiIdea - Descripcion de la idea";
        }

        public override void init()
        {

            ocean = TgcBox.fromSize(new Vector3(0, 0, 0), new Vector3(50, 50, 0), Color.Blue);
            mobileCube = TgcBox.fromSize(new Vector3(1, 1, 1), new Vector3(10, 10, 10), Color.Brown);
     


        }


     
        public override void render(float elapsedTime)
        {
            ocean.render();
            mobileCube.render();

        }


        public override void close()
        {

        }

    }
}
