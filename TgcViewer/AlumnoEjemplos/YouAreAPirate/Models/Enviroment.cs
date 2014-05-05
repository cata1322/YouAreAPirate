using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TgcViewer;
using TgcViewer.Utils.Terrain;
using TgcViewer.Utils.TgcGeometry;
using TgcViewer.Utils.TgcSceneLoader;


namespace AlumnoEjemplos.YouAreAPirate
{
    public partial class EjemploAlumno
    {   

        TgcEditableLand ocean;
        TgcSphere sun;
        TgcSphere skyBox;
        float totalTime;

        public void initializeEnviroment()
        {
            //Acceso a Device de DirectX.
            Microsoft.DirectX.Direct3D.Device d3dDevice = GuiController.Instance.D3dDevice;
            totalTime = 0;
          
            //OCEAN
            ocean = new TgcEditableLand();
            ocean.setTexture(TgcTexture.createTexture(GuiController.Instance.AlumnoEjemplosMediaDir + "Textures\\environment\\water_texture.jpg"));
            ocean.Position = new Vector3(-120, 0, -120);
            ocean.Scale = new Vector3(3, 3, 3);

            //SUN
            sun = new TgcSphere();
            sun.Radius = 5;
            sun.setColor(Color.Yellow);
            sun.Position = new Vector3(0, 50, 0);
            sun.LevelOfDetail = 4;
            sun.updateValues();

            //SKY
            TgcTexture skyTexture = TgcTexture.createTexture(d3dDevice, GuiController.Instance.AlumnoEjemplosMediaDir + "Textures\\environment\\sky_patten.jpg");
            skyBox = new TgcSphere();
            skyBox.Radius = 100;
            skyBox.setTexture(skyTexture);
            skyBox.Position = new Vector3(0, 0, 0);
            skyBox.LevelOfDetail = 4;
            skyBox.updateValues();
                   
        }


        public void loadEnviroment(float elapsedTime)
        {

            totalTime += elapsedTime;

            ocean.setVerticesY(TgcEditableLand.SELECTION_CENTER, (float) Math.Cos(totalTime));
            ocean.setVerticesY(TgcEditableLand.SELECTION_INTERIOR_RING, (float)Math.Sin(totalTime+1));
            ocean.setVerticesY(TgcEditableLand.SELECTION_EXTERIOR_RING, (float)Math.Sin(totalTime));
            ocean.setVerticesY(TgcEditableLand.SELECTION_TOP_SIDE, (float)Math.Sin(totalTime));
            ocean.setVerticesY(TgcEditableLand.SELECTION_LEFT_SIDE, (float)Math.Sin(totalTime));
            ocean.setVerticesY(TgcEditableLand.SELECTION_RIGHT_SIDE, (float)Math.Sin(totalTime));
            ocean.setVerticesY(TgcEditableLand.SELECTION_BOTTOM_SIDE, (float)Math.Sin(totalTime));
            
            ocean.updateValues();

            ocean.render();
            sun.render();
            skyBox.render();
        }
    }
}

