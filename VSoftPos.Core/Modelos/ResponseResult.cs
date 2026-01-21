using System;

namespace Pos.Core.Modelos
{
    public class ResponseResult : IDisposable
    {
        public bool Ok { get; set; } = true;
        public object? Datos { get; set; } = null;
        public string? Mensaje { get; set; }
        public PagingResult? Paginacion { get; set; } = null;

        public ResponseResult() { }

        public ResponseResult(object datos)
        {
            Datos = datos;
        }

        public ResponseResult(bool ok, string mensaje)
        {
            Ok = ok;
            Mensaje = mensaje;
        }
        
        public ResponseResult(bool ok, string mensaje, object datos)
        {
            Ok = ok;
            Mensaje = mensaje;
            Datos = datos;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
