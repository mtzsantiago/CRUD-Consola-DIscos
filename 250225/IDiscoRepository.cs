using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250225
{
    public interface IDiscoRepository
    {
        void InsertarDisco(Disco disco);
        void ActualizarDisco(Disco disco);
        void EliminarDisco(int id); // Cambiar aquí para aceptar un int
        List<Disco> ObtenerDisco();
    }

}
