using System;
using System.Collections.Generic;
using System.Text;
using TgcViewer.Example;
using TgcViewer;
using Microsoft.DirectX.Direct3D;
using System.Drawing;
using Microsoft.DirectX;
using TgcViewer.Utils.Modifiers;
using TgcViewer.Utils.TgcSceneLoader;


namespace AlumnoEjemplos.YouAreAPirate
{
    /// <summary>
    /// Ejemplo SistemaSolar:
    /// Unidades PlayStaticSound:
    ///     # Unidad 3 - Conceptos Básicos de 3D - Transformaciones
    /// 
    /// Muestra como concatenar transformaciones para generar movimientos...En este caso el del sol
    public partial class EjemploAlumno
    {
        //Escalas de cada uno de los astros
        readonly Vector3 SUN_SCALE = new Vector3(10, 10, 10);

        const float AXIS_ROTATION_SPEED = 0.01f;
        
        TgcMesh sol;

        float axisRotation = 0f;

        public void initializeSol() 
        {
            Device d3dDevice = GuiController.Instance.D3dDevice;
            string sphere = GuiController.Instance.ExamplesMediaDir + "ModelosTgc\\Sphere\\Sphere-TgcScene.xml";
            TgcSceneLoader loader = new TgcSceneLoader();
            
           

            //Cargar modelos para el sol, la tierra y la luna. Son esfereas a las cuales le cambiamos la textura
            sol = loader.loadSceneFromFile(sphere).Meshes[0];
            sol.changeDiffuseMaps(new TgcTexture[] { TgcTexture.createTexture(d3dDevice, GuiController.Instance.AlumnoEjemplosMediaDir + "Textures\\environment\\sol1.jpg") });

            //Deshabilitamos el manejo automático de Transformaciones de TgcMesh, para poder manipularlas en forma customizada
            sun.AutoTransformEnable = false;

            //Posición del sol
            //NO logro ubicarlo arriba de todo. 
            sol.Position = new Vector3(990, 500, 1500);

            //Modifiers de la luz
            GuiController.Instance.Modifiers.addBoolean("lightEnable", "lightEnable", true);
            GuiController.Instance.Modifiers.addVertex3f("lightPos", new Vector3(-200, -100, -200), new Vector3(200, 200, 300), new Vector3(60, 35, 250));
            GuiController.Instance.Modifiers.addColor("lightColor", Color.White);
            GuiController.Instance.Modifiers.addFloat("lightIntensity", 0, 150, 20);
            GuiController.Instance.Modifiers.addFloat("lightAttenuation", 0.1f, 2, 0.3f);
            GuiController.Instance.Modifiers.addFloat("specularEx", 0, 20, 9f);

            //Modifiers de material
            GuiController.Instance.Modifiers.addColor("mEmissive", Color.Black);
            GuiController.Instance.Modifiers.addColor("mAmbient", Color.White);
            GuiController.Instance.Modifiers.addColor("mDiffuse", Color.White);
            GuiController.Instance.Modifiers.addColor("mSpecular", Color.White);
        }

        public void loadSol(float elapsedTime)
        {
            Device d3dDevice = GuiController.Instance.D3dDevice;
            //Actualizar transformacion y renderizar el sol
            sun.Transform = getSunTransform(elapsedTime);
            sun.render();

            //Limpiamos todas las transformaciones con la Matrix identidad
            d3dDevice.Transform.World = Matrix.Identity;

            axisRotation += AXIS_ROTATION_SPEED * elapsedTime;

           
        }
        private Matrix getSunTransform(float elapsedTime)
        {
            Matrix scale = Matrix.Scaling(SUN_SCALE);
            Matrix yRot = Matrix.RotationY(axisRotation);

            return scale * yRot;
        }
           
        
    }
}
