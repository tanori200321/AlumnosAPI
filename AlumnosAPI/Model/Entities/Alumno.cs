using System.ComponentModel.DataAnnotations;

namespace AlumnosAPI.Model.Entities
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<Materia> Materias { get; set; }
    }
}
