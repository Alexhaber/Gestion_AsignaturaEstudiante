using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_AsignaturaEstudiante
{
    // clase que representa una asignatura que contiene varios grupos
    public class Asignatura
    {
        public string Nombre { get; set; }
        public List<Grupo> Grupos { get; set; } = new();

        public Asignatura(string nombre)
        {
            Nombre = nombre;
        }

        // crea un grupo nuevo y lo añade a la lista de grupos
        public Grupo CrearGrupo(string nombreGrupo)
        {
            var grupo = new Grupo(nombreGrupo);
            Grupos.Add(grupo);
            return grupo;
        }
    }
}
