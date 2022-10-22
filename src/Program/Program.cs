using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
        // -------------------------------------------Ejercicio 1----------------------------------------------------------------
            
            PictureProvider provider1 = new PictureProvider();
            IPicture picture1 = provider1.GetPicture(@"luke.jpg");

            IPipe pipeNull= new PipeNull();
            IFilter filterNegative= new FilterNegative();
            IPipe pipeSerial2= new PipeSerial(filterNegative, pipeNull);
            IFilter filterGreyScale= new FilterGreyscale();
            IPipe pipeSerial1= new PipeSerial(filterGreyScale, pipeSerial2);
            
            IPicture filteredPicture1 = pipeSerial1.Send(picture);

            PictureProvider provider2 = new PictureProvider();
            provider2.SavePicture(filteredPicture1, @"Ejercicio1.jpg");


        // -------------------------------------------Ejercicio 2----------------------------------------------------------------

            FilterPersistance filterPersistance= new FilterPersistance();
            filterPersistance.Filter(filteredPicture1, "EstadoActual.jpg");

        // -------------------------------------------Ejercicio 3----------------------------------------------------------------
        }
    }
}
