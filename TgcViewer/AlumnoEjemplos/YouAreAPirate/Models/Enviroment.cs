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

        TgcCustomEditableLand ocean;
        TgcSphere sun;
        TgcSphere skyBox;
        float totalTime;

        public void initializeEnviroment()
        {
            //Acceso a Device de DirectX.
            Microsoft.DirectX.Direct3D.Device d3dDevice = GuiController.Instance.D3dDevice;
            totalTime = 0;
          
            //OCEAN
            int editable_ocea_grid_size = 10;
            int squares_per_side = 5;
            GuiController.Instance.Modifiers.addFloat("intensity", 0.1f, 10, 0.2f);
            GuiController.Instance.Modifiers.addInt("transformation_point", 0, editable_ocea_grid_size - 1, 0);
            ocean = new TgcCustomEditableLand(editable_ocea_grid_size, squares_per_side);
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

            //ocean.setVertexY( (int)GuiController.Instance.Modifiers["transformation_point"], (float)Math.Cos(totalTime) * (float)GuiController.Instance.Modifiers["intensity"]);
            ocean.setVerticesY(new int[] {50}, (float)Math.Sin(totalTime));
            
            ocean.updateValues();

            ocean.render();
//           sun.render();
//           skyBox.render();
        }
    }
}

