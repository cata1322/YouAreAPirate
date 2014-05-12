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

        #region Variables
        TgcEditableLand ocean;
        TgcSphere sun;
        TgcSphere skyBox;
        float totalTime;
        int oceanMovimientoLateral = 0;
        Vector3 oceanPosition = new Vector3(-120, 0, -120);
        #endregion


        public void initializeEnviroment()
        {
            //Acceso a Device de DirectX.
            Microsoft.DirectX.Direct3D.Device d3dDevice = GuiController.Instance.D3dDevice;
            totalTime = 0;
          
            //OCEAN
            ocean = new TgcEditableLand();
            ocean.setTexture(TgcTexture.createTexture(GuiController.Instance.AlumnoEjemplosMediaDir + "Textures\\environment\\water_texture.jpg"));
            ocean.Position = oceanPosition;
            ocean.Scale = new Vector3(20, 20, 20);     
            

            //SUN
            sun = new TgcSphere();
            sun.Radius = 20;
            sun.setColor(Color.Yellow);
            sun.setTexture(TgcTexture.createTexture(d3dDevice, GuiController.Instance.AlumnoEjemplosMediaDir + "Textures\\environment\\sun.jpg"));
            sun.Position = new Vector3(0, 300, 0);
            sun.LevelOfDetail = 4;
            sun.updateValues();

            //SKY
            TgcTexture skyTexture = TgcTexture.createTexture(d3dDevice, GuiController.Instance.AlumnoEjemplosMediaDir + "Textures\\environment\\sky_patten.jpg");
            skyBox = new TgcSphere();
            skyBox.Radius = (int)GuiController.Instance.Modifiers["skyRadius"];
            skyBox.setTexture(skyTexture);
            skyBox.Position = (Vector3)GuiController.Instance.Modifiers["skyPosition"];
            skyBox.LevelOfDetail = 4;
            skyBox.updateValues();
                   
        }


        public void loadEnviroment(float elapsedTime)
        {

            totalTime += elapsedTime;
            if (oceanMovimientoLateral < 100000)
            {
                oceanPosition.Z = oceanPosition.Z + 0.001f;                    
                oceanMovimientoLateral++;
            }
            else if (oceanMovimientoLateral < 200000 && oceanMovimientoLateral >= 100000)
            {
                oceanPosition.Z = oceanPosition.Z - 0.001f;                
                oceanMovimientoLateral++;
            }
            else if (oceanMovimientoLateral == 200000)
            {
                oceanMovimientoLateral = 0;
            }
                

            ocean.Position = oceanPosition;            
            ocean.setVerticesY(TgcEditableLand.SELECTION_CENTER, (float) Math.Cos(totalTime));
            ocean.setVerticesY(TgcEditableLand.SELECTION_INTERIOR_RING, (float)Math.Sin(totalTime));
            ocean.setVerticesY(TgcEditableLand.SELECTION_EXTERIOR_RING, (float)Math.Sin(totalTime));
            ocean.setVerticesY(TgcEditableLand.SELECTION_TOP_SIDE, (float)Math.Sin(totalTime));
            ocean.setVerticesY(TgcEditableLand.SELECTION_LEFT_SIDE, (float)Math.Sin(totalTime));
            ocean.setVerticesY(TgcEditableLand.SELECTION_RIGHT_SIDE, (float)Math.Sin(totalTime));
            ocean.setVerticesY(TgcEditableLand.SELECTION_BOTTOM_SIDE, (float)Math.Sin(totalTime));
            ocean.updateValues();
            sun.rotateX(0.00001f);
            skyBox.Radius = (int)GuiController.Instance.Modifiers["skyRadius"];            
            skyBox.Position = (Vector3)GuiController.Instance.Modifiers["skyPosition"];
            //oceanPosition = (Vector3)GuiController.Instance.Modifiers["oceanPosition"];

            ocean.render();
            sun.render();
            skyBox.render();
        }
    }
}

