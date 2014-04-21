using Microsoft.DirectX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TgcViewer;
using TgcViewer.Utils.TgcGeometry;

namespace AlumnoEjemplos.YouAreAPirate
{
    public partial class EjemploAlumno
    {

        public void initializeCamera(TgcBoundingBox objective)
        {
            GuiController.Instance.ThirdPersonCamera.Enable = true;
            GuiController.Instance.ThirdPersonCamera.setCamera(objective.Position, 50, 80);
        }

        public void loadCamera(float elapsedTime, TgcBoundingBox objective)
        {
            GuiController.Instance.ThirdPersonCamera.setCamera(objective.Position, 50, 80);
        }
    }
}
