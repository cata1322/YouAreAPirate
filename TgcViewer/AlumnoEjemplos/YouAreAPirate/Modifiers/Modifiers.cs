using Microsoft.DirectX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TgcViewer;

namespace AlumnoEjemplos.YouAreAPirate
{
    public partial class EjemploAlumno
    {
        public void loadModifiers()
        {
            GuiController.Instance.Modifiers.addVertex3f("skyPosition", new Vector3(0, 0, 0), new Vector3(1000, 1000, 1000), new Vector3(20, 20, 20));
            GuiController.Instance.Modifiers.addInt("skyRadius", 100, 10000, 2000);
            GuiController.Instance.Modifiers.addVertex3f("oceanPosition", new Vector3(-1000, -1000, -1000), new Vector3(1000, 1000, 1000), new Vector3(-600, 0, -600));
            GuiController.Instance.Modifiers.addVertex3f("oceanScale", new Vector3(10, 10, 10), new Vector3(1000, 1000, 1000), new Vector3(20, 20, 20));

            #region modificadores de cámara
            GuiController.Instance.Modifiers.addVertex3f("cameraPosition", new Vector3(-100, -100, -100), new Vector3(100, 100, 100), new Vector3(0, 12, 12)); 
            #endregion
            
        }
    }
}
