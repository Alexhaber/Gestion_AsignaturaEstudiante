using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_AsignaturaEstudiante
{
    // clase que representa el resultado de una operación (éxito o error)
    public class OperationResult
    {
        public string Message { get; set; }     // mensaje descriptivo
        public bool Success { get; set; }       // indica si la operación fue exitosa
        public dynamic Data { get; set; }       // cualquier dato adicional que se quiera retornar

        public OperationResult(string message, bool success, dynamic data)
        {
            Message = message;
            Success = success;
            Data = data;
        }
    }
}
