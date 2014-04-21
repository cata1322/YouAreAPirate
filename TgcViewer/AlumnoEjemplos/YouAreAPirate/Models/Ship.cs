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

namespace AlumnoEjemplos.YouAreAPirate
{
    public partial class EjemploAlumno
    {
        const float MOVEMENT_SPEED = 10f;
        TgcD3dInput input = GuiController.Instance.D3dInput;
        TgcBox ship;

        public void initializeShip()
        {
            ship = TgcBox.fromSize(new Vector3(0, 0, 0), new Vector3(10,10,10), Color.Brown);
        }

        public void moveShip(float elapsedTime)
        {
            Vector3 movement = new Vector3(0, 0, 0);

   
            if (input.keyDown(Key.Left) || input.keyDown(Key.A))
            {
                movement.X = 1;
            }
            else if (input.keyDown(Key.Right) || input.keyDown(Key.D))
            {
                movement.X = -1;
            }

            if (input.keyDown(Key.Up) || input.keyDown(Key.W))
            {
                movement.Z = -1;
            }
            else if (input.keyDown(Key.Down) || input.keyDown(Key.S))
            {
                movement.Z = 1;
            }

            movement *= MOVEMENT_SPEED * elapsedTime;

            ship.move(movement);
        }

        public void loadShip(float elapsedTime)
        {
            moveShip(elapsedTime);
            ship.render();
        }
    }
}
