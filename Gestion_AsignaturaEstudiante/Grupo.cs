using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_AsignaturaEstudiante
{
    //es l clase que representa un grupo de estudiantes dentro de una asignatura
    public class Grupo
    {
        public string Nombre { get; set; }
        public List<Estudiante> Estudiantes { get; set; } = new();

        public Grupo(string nombre)
        {
            Nombre = nombre;
        }

        // agrega un estudiante a la lista del grupo
        public OperationResult AgregarEstudiante(Estudiante estudiante)
        {
            Estudiantes.Add(estudiante);
            return new OperationResult("estudiante agregado exitosamente", true, estudiante);
        }

        // registra las notas de un estudiante buscado por matrícula
        public OperationResult RegistrarNotas(string matricula, double examen, double practica)
        {
            var estudiante = Estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante == null)
            {
                return new OperationResult("estudiante no encontrado", false, null);
            }

            estudiante.AsignarNotas(examen, practica);
            return new OperationResult("notas registradas correctamente", true, estudiante);
        }

        // muestra por consola la información de todos los estudiantes del grupo
        public void MostrarListado()
        {
            Console.WriteLine($"\nlistado del grupo: {Nombre}");
            foreach (var estudiante in Estudiantes)
            {
                Console.WriteLine(estudiante.ObtenerInformacion());
            }
        }

        // calcula el porcentaje de estudiantes aprobados en el grupo
        public double CalcularPorcentajeAprobados()
        {
            if (Estudiantes.Count == 0) return 0;
            int aprobados = Estudiantes.Count(e => e.EstaAprobado());
            return (double)aprobados / Estudiantes.Count * 100;
        }
    }
}
