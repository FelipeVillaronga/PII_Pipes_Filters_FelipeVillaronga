using System;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y la almacena en un path dado.
    /// </remarks>
    public class FilterPersistance 
    {
        /// Un filtro que recibe una imagen y la almacena en un path dado.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>La imagen recibida.</returns>
        
        // public string Path {get; set;}
        public IPicture Filter(IPicture image, string path)
        {
            PictureProvider p = new PictureProvider();
            IPicture pic = p.SavePicture(image, path);
            return image;
        }

    }


}