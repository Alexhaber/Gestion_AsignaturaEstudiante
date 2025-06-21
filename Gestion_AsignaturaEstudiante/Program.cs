using Gestion_AsignaturaEstudiante;

class Program
{
    // se crea una instancia de la asignatura
    static Asignatura asignatura = new Asignatura("POO");

    static void Main()
    {
        bool salir = false;

        while (!salir)
        {
            // menú principal con las opciones disponibles
            Console.WriteLine("\n=== menú principal ===");
            Console.WriteLine("asignatura: " + asignatura.Nombre);
            Console.WriteLine("1. crear nuevo grupo");
            Console.WriteLine("2. agregar estudiantes a un grupo");
            Console.WriteLine("3. registrar notas en un grupo");
            Console.WriteLine("4. mostrar listado de calificaciones de un grupo");
            Console.WriteLine("5. ver porcentaje de aprobados de un grupo");
            Console.WriteLine("6. salir");
            Console.Write("seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    CrearGrupo();
                    break;
                case "2":
                    AgregarEstudiantes();
                    break;
                case "3":
                    RegistrarNotas();
                    break;
                case "4":
                    MostrarListado();
                    break;
                case "5":
                    VerPorcentajeAprobados();
                    break;
                case "6":
                    salir = true;
                    Console.WriteLine("saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("opción inválida.");
                    break;
            }
        }
    }

    // permite crear un nuevo grupo dentro de la asignatura
    static void CrearGrupo()
    {
        Console.Write("\ningrese el nombre del nuevo grupo: ");
        string nombreGrupo = Console.ReadLine();

        // verifica que no se repita el nombre del grupo
        if (asignatura.Grupos.Any(g => g.Nombre.Equals(nombreGrupo, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("ya existe un grupo con ese nombre.");
            return;
        }

        asignatura.CrearGrupo(nombreGrupo);
        Console.WriteLine($"grupo '{nombreGrupo}' creado correctamente.");
    }

    // permite seleccionar un grupo de la lista de grupos existentes
    static Grupo SeleccionarGrupo()
    {
        if (!asignatura.Grupos.Any())
        {
            Console.WriteLine("no hay grupos creados.");
            return null;
        }

        Console.WriteLine("\ngrupos disponibles:");
        for (int i = 0; i < asignatura.Grupos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {asignatura.Grupos[i].Nombre}");
        }

        Console.Write("seleccione el número del grupo: ");
        if (int.TryParse(Console.ReadLine(), out int seleccion) &&
            seleccion >= 1 && seleccion <= asignatura.Grupos.Count)
        {
            return asignatura.Grupos[seleccion - 1];
        }

        Console.WriteLine("selección inválida.");
        return null;
    }

    // permite agregar estudiantes al grupo que se elija
    static void AgregarEstudiantes()
    {
        var grupo = SeleccionarGrupo();
        if (grupo == null) return;

        Console.Write("\ncantidad de estudiantes a ingresar: ");
        if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad <= 0)
        {
            Console.WriteLine("entrada inválida.");
            return;
        }

        for (int i = 0; i < cantidad; i++)
        {
            Console.WriteLine($"\nestudiante #{i + 1}");

            Console.Write("nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("matrícula: ");
            string matricula = Console.ReadLine();

            Console.Write("tipo (1-presencial, 2-distancia): ");
            string tipoEntrada = Console.ReadLine();

            Estudiante estudiante;
            if (tipoEntrada == "1")
                estudiante = new EstudiantePresencial(nombre, matricula);
            else if (tipoEntrada == "2")
                estudiante = new EstudianteDistancia(nombre, matricula);
            else
            {
                Console.WriteLine("tipo inválido.");
                i--;
                continue;
            }

            var resultado = grupo.AgregarEstudiante(estudiante);
            Console.WriteLine(resultado.Message);
        }
    }

    // permite registrar las notas de cada estudiante en un grupo
    static void RegistrarNotas()
    {
        var grupo = SeleccionarGrupo();
        if (grupo == null) return;

        if (!grupo.Estudiantes.Any())
        {
            Console.WriteLine("este grupo no tiene estudiantes.");
            return;
        }

        Console.WriteLine("\n--- registro de notas ---");
        foreach (var estudiante in grupo.Estudiantes)
        {
            Console.WriteLine($"\nestudiante: {estudiante.Nombre} ({estudiante.Matricula})");

            Console.Write("nota de examen: ");
            if (!double.TryParse(Console.ReadLine(), out double examen))
            {
                Console.WriteLine("nota inválida.");
                continue;
            }

            Console.Write("nota de práctica: ");
            if (!double.TryParse(Console.ReadLine(), out double practica))
            {
                Console.WriteLine("nota inválida.");
                continue;
            }

            var resultado = grupo.RegistrarNotas(estudiante.Matricula, examen, practica);
            Console.WriteLine(resultado.Message);
        }
    }

    // muestra la lista de estudiantes con sus calificaciones finales
    static void MostrarListado()
    {
        var grupo = SeleccionarGrupo();
        if (grupo == null) return;

        grupo.MostrarListado();
    }

    // calcula y muestra el porcentaje de estudiantes aprobados en un grupo
    static void VerPorcentajeAprobados()
    {
        var grupo = SeleccionarGrupo();
        if (grupo == null) return;

        double porcentaje = grupo.CalcularPorcentajeAprobados();
        Console.WriteLine($"\nporcentaje de estudiantes aprobados en el grupo '{grupo.Nombre}': {porcentaje:F2}%");
    }
}

