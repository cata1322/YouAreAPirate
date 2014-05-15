using System.IO;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectInput;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TgcViewer;
using TgcViewer.Utils.Input;
using TgcViewer.Utils.TgcGeometry;
using TgcViewer.Utils.TgcSceneLoader;

namespace AlumnoEjemplos.YouAreAPirate
{
    public partial class EjemploAlumno
    {
        //variable que indica la velocidad con que se movera el barco.
        const float MOVEMENT_SPEED = 10f;
        TgcD3dInput input = GuiController.Instance.D3dInput;
        TgcMesh ship;
        

        public void initializeShip()
        {
            float scale = 0.07f;
            string urlMesh = Path.Combine(GuiController.Instance.AlumnoEjemplosMediaDir, @"BarcoPirata\BarcoPirata2-TgcScene.xml");

            TgcSceneLoader loader = new TgcSceneLoader();
            TgcScene scene = loader.loadSceneFromFile(urlMesh);
            ship = (TgcMesh) scene.Meshes[0];
            ship.Scale = new Vector3(scale, scale, scale);
            ship.Position = new Vector3(70,20,0);

        }

        
        public void moveShip(float elapsedTime)
        {
            //proceso para mover el barco con las letras A,D,W,S.

            //Declaramos un vector de movimiento, inicializado en 0.
            Vector3 movement = new Vector3(0, 0, 0);

            //El movimiento sobre el ocenao es en los ejes XZ.
            //Movernos de izquierda a derecha, sobre el eje X.
            if (input.keyDown(Key.Left) || input.keyDown(Key.A))
            {
                movement.X = 1;
            }
            else if (input.keyDown(Key.Right) || input.keyDown(Key.D))
            {
                movement.X = -1;
            }
            //Movernos para adelante y atrás, sobre el eje Z.
            if (input.keyDown(Key.Up) || input.keyDown(Key.W))
            {
                movement.Z = -1;
            }
            else if (input.keyDown(Key.Down) || input.keyDown(Key.S))
            {
                movement.Z = 1;
            }

            //Multiplicar movimiento por velocidad y elapsedTime
            movement *= MOVEMENT_SPEED * elapsedTime;

            //Aplicar movimiento
            ship.move(movement);
            //ship.rotateY(0.0001f);
        }

        public void loadShip(float elapsedTime)
        {
            moveShip(elapsedTime);
            ship.render();
        }
    }
}
