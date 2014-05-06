using Microsoft.DirectX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TgcViewer;
using TgcViewer.Utils.TgcGeometry;
using TgcViewer.Utils.TgcSceneLoader;

namespace AlumnoEjemplos.YouAreAPirate
{
    public partial class EjemploAlumno
    {

        public void initializeCamera(TgcMesh objective)
        {
      //      GuiController.Instance.ThirdPersonCamera.Enable = true;
            GuiController.Instance.ThirdPersonCamera.setCamera(objective.Position, 50, 80);
        }

        public void loadCamera(float elapsedTime, TgcBoundingBox objective)
        {
            GuiController.Instance.ThirdPersonCamera.setCamera(objective.Position, 50, 80);
        }
    }
}
