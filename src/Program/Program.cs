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
            
            IPicture filteredPicture1 = pipeSerial1.Send(picture1);

            PictureProvider provider2 = new PictureProvider();
            provider2.SavePicture(filteredPicture1, @"Ejercicio1.jpg");

        // -------------------------------------------Ejercicio 4----------------------------------------------------------------

            IFilter twittFilter= new TwitterFilter(@"Nueva imagen.jpg");
            IPipe nullPipe= new PipeNull();
            IPipe truePipe= new PipeSerial(twittFilter, nullPipe);

            IFilter negativeFilter= new FilterNegative();
            IPipe nullPipe2= new PipeNull();
            IPipe falsePipe= new PipeSerial(negativeFilter, nullPipe2);

            IPipe conditionalFork= new PipeConditionalFork(truePipe, falsePipe, @"luke.jpg");
        }
    }
}
