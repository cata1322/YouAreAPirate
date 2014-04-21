using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TgcViewer;
using TgcViewer.Utils.TgcGeometry;
using TgcViewer.Utils.TgcSceneLoader;


namespace AlumnoEjemplos.YouAreAPirate
{
    public partial class EjemploAlumno
    {
        TgcBox ocean;
        TgcSphere sun;

        public void initializeEnviroment()
        {
            Microsoft.DirectX.Direct3D.Device d3dDevice = GuiController.Instance.D3dDevice;

            TgcTexture waterTexture = TgcTexture.createTexture(d3dDevice, GuiController.Instance.AlumnoEjemplosMediaDir + "Textures\\water_texture.jpg");
            ocean = TgcBox.fromSize(new Vector3(0, 0, 0), new Vector3(200, 0, 200), waterTexture);

            sun = new TgcSphere();
            sun.setColor(Color.Yellow);
            sun.Radius = 5;
            sun.Position = new Vector3(0, 50, 0);
            sun.LevelOfDetail = 4;
            sun.updateValues();
            
        }


        public void loadEnviroment(float elapsedTime)
        {
            ocean.render();
            sun.render();
        }
    }
}

