using System.ComponentModel.DataAnnotations;

namespace task_2._1._1
{
    public class Patient
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public double height { get; set; }
        public double weight { get; set; }
        public int age { get; set; }
        public double bmi { get; set; }
    }

    public class PatientModel
    {
        [Required]
        public string fullname { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public double height { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public double weight { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int age { get; set; }
    }
}
