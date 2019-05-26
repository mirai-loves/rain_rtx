﻿using System;
using System.Threading;
using System.Drawing;
using System.IO;

namespace RainRTX_Demo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Start();
        }

        public static void Start()
        {
            Console.WriteLine("Scene preparing");
            var scene = PrepareScene();
            GraphicCore.RenderImage(1000, 1000, scene);
            Console.WriteLine("Render process started");
            while (!GraphicCore.isRenderingDone)
            {   
                Thread.Sleep(10);
            }
            Console.WriteLine("Rendering done");

            Console.WriteLine("Creating bitmap");

            var bitmap = GetDataPicture(GraphicCore.ColorBuffer);

            Console.WriteLine("Saving to file");
            FileStream fs = new FileStream("result.png", FileMode.Create, FileAccess.ReadWrite);
            bitmap.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
            fs.Close();
            Console.WriteLine("Done");

        }
            
        public static Scene PrepareScene()
        {
            return new Scene
            {
                ambientLights = new AmbientLight[] { new AmbientLight(0.2f) },
                pointLights = new PointLight[] { new PointLight(0.7f, new Vector3(2, 1, 0)) },
                directionalLights = new DirectionalLight[] { new DirectionalLight(0.3f, new Vector3(1, 4, 4)) },

                Spheres = new Sphere[]
                {
                    new Sphere(new Vector3(-1, -0.46, 5), 0.5f, new Color24(252,10,232),100),
                    new Sphere(new Vector3(0,-5001,100),5000, new Color24(159,163,151)),
                    new Sphere(new Vector3(0, -0.46, 3),0.6f, Color.White, 800),
                    new Sphere(new Vector3(1, -0.46, 6),0.6f, new Color24(167,252,55), 800)
                }
            };
            
        }

        private static Bitmap GetDataPicture(Color[,] colorBuff)
        {
            var w = colorBuff.GetLength(0);
            var h = colorBuff.GetLength(1);
            var bitmap = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    bitmap.SetPixel(x, y, colorBuff[x, y]);
                }
            }
            return bitmap;
        }
    }
}
