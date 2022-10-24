using CompAndDel.Filters;


namespace CompAndDel.Pipes
{
    public class PipeConditionalFork : IPipe
    {
        IPipe next2Pipe;
        IPipe nextPipe;

        /// <summary>
        /// La cañería recibe una imagen, la clona y envìa la original por una cañeria y la clonada por otra.
        /// </summary>
        /// <param name="tipoFiltro">Tipo de filtro que se debe aplicar sobre la imagen. Se crea un nuevo filtro con los parametros por defecto</param>
        /// <param name="nextPipe">Siguiente cañeria con filtro</param>
        /// <param name="next2Pipe">Siguiente cañeria sin filtro</param>
        public PipeConditionalFork(IPipe nextPipe, IPipe next2Pipe, string path)
        {
            this.Next2Pipe = next2Pipe;
            this.NextPipe = nextPipe;
            this.CondFilter= new ConditionalFilter(path);
        }
        
        public IPipe NextPipe {get; set;}
        public IPipe Next2Pipe {get; set;}

        public ConditionalFilter CondFilter {get; set;}

        /// <summary>
        /// La cañería recibe una imagen, construye un duplicado de la misma, 
        /// y envía la original por una cañería y el duplicado por otra.
        /// </summary>
        /// <param name="picture">imagen a filtrar y enviar a las siguientes cañerías</param>
        public IPicture Send(IPicture picture)
        {
            CondFilter.Filter(picture);
            if(CondFilter.HasFace)
            {
                Filters.FilterPersistance filter = new Filters.FilterPersistance();
                filter.Path = "EstadoActual.jpg";
                filter.Filter(picture);
                this.nextPipe.Send(picture);          
            }
            else
            {
                next2Pipe.Send(picture.Clone());
            }
            
            return picture;
        }
    }
}
