using System;
using System.Collections.Generic;

namespace S.Multiton
{
    class Program
    {
        static void Main(string[] args)
        {
            //singiltonan farki belli sarta gore instanslar
            //uretib gercekden o satrlarada intansin verimesidir

            Camera camera1 = Camera.GetCamera("nikon");
            Camera camera2 = Camera.GetCamera("nikon");
            Camera camera3 = Camera.GetCamera("canon");
            Camera camera4 = Camera.GetCamera("canon");
            Console.WriteLine(camera1.Id);
            Console.WriteLine(camera2.Id);
            Console.WriteLine(camera3.Id);
            Console.WriteLine(camera4.Id);



        }

        class Camera
        {
            private static Dictionary<string, Camera> _cameras = new Dictionary<string, Camera>();

            static object _lock = new object();
            public Guid Id { get; set; }

            private Camera()
            {

                Id = Guid.NewGuid();
            }

            public static Camera GetCamera(string brand)
            {
                lock (_lock)
                {
                    if (!_cameras.ContainsKey(brand))
                    {
                        _cameras.Add(brand, new Camera());

                    }

                    
                }
                return _cameras[brand];

            }



        }
    }
}
