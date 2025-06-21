using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_AsignaturaEstudiante
{
    // clase representativa de lo estudiantes a distancia.cs
    public class EstudianteDistancia : Estudiante
    {
        public EstudianteDistancia(string nombre, string matricula) : base(nombre, matricula) { }

        public override double CalcularNotaFinal()
        {
            return (NotaExamen * 0.7) + (NotaPractica * 0.3);
        }
    }
}
