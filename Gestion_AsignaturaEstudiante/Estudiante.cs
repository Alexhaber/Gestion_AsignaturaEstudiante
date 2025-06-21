using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_AsignaturaEstudiante
{
    // es una clase base abstracta para representar un estudiante
    public abstract class Estudiante
    {
        public string Nombre { get; set; }
        public string Matricula { get; set; }
        public double NotaExamen { get; set; }
        public double NotaPractica { get; set; }

        // constructor que recibe el nombre y la matricula
        public Estudiante(string nombre, string matricula)
        {
            Nombre = nombre;
            Matricula = matricula;
        }

        // permite asignar las notas del estudiante
        public void AsignarNotas(double examen, double practica)
        {
            NotaExamen = examen;
            NotaPractica = practica;
        }

        // metodo abstracto para calcular la nota final
        public abstract double CalcularNotaFinal();

        // devuelve true si el estudiante está aprobado (nota final >= 70)
        public bool EstaAprobado() => CalcularNotaFinal() >= 70;

        // devuelve la informacion general del estudiante con su estado
        public string ObtenerInformacion()
        {
            return $"Nombre: {Nombre} | Matrícula: {Matricula} | Nota Final: {CalcularNotaFinal():F2} | Estado: {(EstaAprobado() ? "Aprobado" : "Reprobado")}";
        }
    }


}
