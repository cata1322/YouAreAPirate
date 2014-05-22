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

        #region Enumerable Tipo Barco

        public enum EnumShipType
        {
            Standard, SS_Holigan, BlackPearl
        }

        #endregion

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
            public EnumShipType shipType { get; set; }
            public Vector3 initialPosition { get; set; }

            public ShipObject(EnumShipType shipType, Vector3 initialPosition)
            {
                this.initialPosition = initialPosition;
                TgcScene scene = null;
                string urlMesh = "";
                TgcSceneLoader loader = new TgcSceneLoader();
                switch(shipType)
                {
                    case EnumShipType.Standard:
                        {
                            //se crea un barco standard (el que usamos hasta ahora)
                            this.shipType = shipType;
                            urlMesh = Path.Combine(GuiController.Instance.AlumnoEjemplosMediaDir, @"BarcoPirata\BarcoPirata2-TgcScene.xml");
                            scene = loader.loadSceneFromFile(urlMesh);
                            Scale(0.05f);
                        }
                        break;
                    case EnumShipType.SS_Holigan:
                        {
                            this.shipType = shipType;
                            urlMesh = Path.Combine(GuiController.Instance.AlumnoEjemplosMediaDir, @"BarcoPirata\SS Holigan-TgcScene.xml");
                            scene = loader.loadSceneFromFile(urlMesh);                            
                            Scale(0.05f);
                        }
                        break;
                    case EnumShipType.BlackPearl:
                        {
                            this.shipType = shipType;
                        }
                        break;
                    default: break;                
                }

                try
                {
                    this.ship = scene.Meshes[0];
                    this.canon1 = scene.Meshes[1];
                    this.canon2 = scene.Meshes[2];
                    this.canon3 = scene.Meshes[3];
                    this.canon4 = scene.Meshes[4];
                    Position(initialPosition);
                    RotateY((float)Math.PI / 2);
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }           
            

            public void Move(Vector3 movement)
            {
                ship.move(movement);
                if (shipType == EnumShipType.Standard)
                {
                    canon1.move(movement);
                    canon2.move(movement);
                    canon3.move(movement);
                    canon4.move(movement); 
                }
            }

            private void Scale(float scale)
            {
                Vector3 vectorScale = new Vector3(scale, scale, scale);
                ship.Scale = vectorScale;
                //si es de tipo standard, debo escalar los cañones por ser otros meshes
                if (shipType == EnumShipType.Standard)                
                   canon1.Scale = canon2.Scale = canon3.Scale = canon4.Scale = vectorScale; 
                
            }

            public void Position(Vector3 vectorPosition)
            {
                ship.Position = vectorPosition;
                //si es de tipo standard, debo mover los cañones por ser otros meshes
                if (shipType == EnumShipType.Standard)                
                    canon1.Position = canon2.Position = canon3.Position = canon4.Position = vectorPosition; 
                
            }

            public void Render()
            {
                ship.render();
                //si es de tipo standard, debo renderizar los cañones por ser otros meshes
                if (shipType == EnumShipType.Standard)
                {
                    canon1.render();
                    canon2.render();
                    canon3.render();
                    canon4.render(); 
                }
            }

            public void RotateY(float value)
            {
                ship.rotateY(value);
                if (shipType == EnumShipType.Standard)
                {
                    canon1.rotateY(value);
                    canon2.rotateY(value);
                    canon3.rotateY(value);
                    canon4.rotateY(value); 
                }
            }

            public TgcBoundingBox getBoundingBox()
            {
                return this.ship.BoundingBox;
            }
        } 
        #endregion

        #region Inicializacion del barco
        public void initializeShip(EnumShipType shipType, Vector3 vectorPosition)
        {
            ship = new ShipObject(shipType,vectorPosition);                                   
        } 
        #endregion


        public void moveShip(float elapsedTime)
        {
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

        private void initializeEnemies(List<ShipObject> shipEnemies)
        {
            
        }
        
        private void loadEnemies(float elapsedTime)
        {
            foreach (ShipObject ship in shipEnemies)
            {
                //accion para cada barco enemigo
                ship.Render();
            }
        }      
    }
}
