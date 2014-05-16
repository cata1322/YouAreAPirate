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
        ShipObject ship;

        #region Objeto Barco
        /// <summary>
        /// Clase utilizada para declarar un objeto como conjunto de barco más cañones
        /// </summary>
        public class ShipObject
        {
            public TgcMesh ship { get; set; }
            public TgcMesh canon1 { get; set; }
            public TgcMesh canon2 { get; set; }
            public TgcMesh canon3 { get; set; }
            public TgcMesh canon4 { get; set; }
            public ShipObject(TgcMesh ship, TgcMesh canon1, TgcMesh canon2, TgcMesh canon3, TgcMesh canon4)
            {
                this.ship = ship;
                this.canon1 = canon1;
                this.canon2 = canon2;
                this.canon3 = canon3;
                this.canon4 = canon4;
                RotateY((float)Math.PI / 2);
            }

            public void Move(Vector3 movement)
            {
                ship.move(movement);
                canon1.move(movement);
                canon2.move(movement);
                canon3.move(movement);
                canon4.move(movement);
            }

            public void Scale(Vector3 vectorScale)
            {
                ship.Scale = canon1.Scale = canon2.Scale = canon3.Scale = canon4.Scale = vectorScale;
            }

            public void Position(Vector3 vectorPosition)
            {
                ship.Position = canon1.Position = canon2.Position = canon3.Position = canon4.Position = vectorPosition;
            }

            public void Render()
            {
                ship.render();
                canon1.render();
                canon2.render();
                canon3.render();
                canon4.render();
            }

            public void RotateY(float value)
            {
                ship.rotateY(value);
                canon1.rotateY(value);
                canon2.rotateY(value);
                canon3.rotateY(value);
                canon4.rotateY(value);
            }

            public TgcBoundingBox getBoundingBox()
            {
                return this.ship.BoundingBox;
            }
        } 
        #endregion

        public void initializeShip()
        {
            float scale = 0.07f;
            string urlMesh = Path.Combine(GuiController.Instance.AlumnoEjemplosMediaDir, @"BarcoPirata\BarcoPirata-TgcScene.xml");
            Vector3 vectorScale = new Vector3(scale, scale, scale);
            Vector3 vectorPosition = new Vector3(0, 0, 0);
            TgcSceneLoader loader = new TgcSceneLoader();
            TgcScene scene = loader.loadSceneFromFile(urlMesh);
            ship = new ShipObject((TgcMesh)scene.Meshes[0],(TgcMesh)scene.Meshes[1],(TgcMesh)scene.Meshes[2],(TgcMesh)scene.Meshes[3],(TgcMesh)scene.Meshes[4]);
            ship.Scale(vectorScale);
            ship.Position(vectorPosition);
        }


        public void moveShip(float elapsedTime)
        {
            //proceso para mover el barco con las letras A,D,W,S.

            //Declaramos un vector de movimiento, inicializado en 0.
            Vector3 movement = new Vector3(0, 0, 0);

            //El movimiento sobre el ocenao es en los ejes XZ.
            //Movernos de izquierda a derecha, sobre el eje X.
            if (input.keyDown(Key.Left))
            {
                movement.Z = 1;
                movement *= MOVEMENT_SPEED * elapsedTime;
                ship.Move(movement);
                ship.RotateY(-0.0001f);
                ship.Render();
                return;
            }
            else if (input.keyDown(Key.Right))
            {
                movement.Z = 1;
                movement *= MOVEMENT_SPEED * elapsedTime;
                ship.Move(movement);
                ship.RotateY(0.0001f);
                ship.Render();
                return;
            }
            //Movernos para adelante y atrás, sobre el eje Z.
            if (input.keyDown(Key.Up))
            {
                movement.Z = 1;
            }
            else if (input.keyDown(Key.Down))
            {
                movement.Z = -1;
            }
            else if (input.keyDown(Key.Down) && input.keyDown(Key.Right))
            {
                movement.Z = -1;
            }
            

            //Multiplicar movimiento por velocidad y elapsedTime
            movement *= MOVEMENT_SPEED * elapsedTime;

            //Aplicar movimiento
            ship.Move(movement);

            //ship.rotateY(0.0001f);
        }

        public void loadShip(float elapsedTime)
        {
            moveShip(elapsedTime);
            ship.Render();
        }
    }
}
