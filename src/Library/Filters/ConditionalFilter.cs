using System;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Clase encargada de verificar si una imagen contiene o no una cara
    /// </remarks>
    public class ConditionalFilter
    {
        public ConditionalFilter(string path)
        {
            this.Path= path;
        }
        public string Path {get; set;}
        public bool HasFace {get; set;}
        public IPicture Filter(IPicture picture)
        {
            CognitiveCoreUCU.CognitiveFace face= new CognitiveCoreUCU.CognitiveFace();
            face.Recognize(this.Path);
            this.HasFace= face.FaceFound;
            return picture;
        }
    }
}