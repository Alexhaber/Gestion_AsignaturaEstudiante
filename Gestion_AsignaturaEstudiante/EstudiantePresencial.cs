using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_AsignaturaEstudiante
{
    // clase que representa a un estudiante presencial
    public class EstudiantePresencial : Estudiante
    {
        public EstudiantePresencial(string? nombre, string? matricula) : base(nombre, matricula) { }

        // la nota final se calcula con 60% del examen y 40% de la practica, a diferencia de los estudiantes a distancia,
        // esto con el motivo de diferenciar aun más los tipos de estudiantes
        public override double CalcularNotaFinal()
        {
            return (NotaExamen * 0.6) + (NotaPractica * 0.4);
        }
    }
}
