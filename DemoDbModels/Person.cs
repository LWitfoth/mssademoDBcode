using System.ComponentModel.DataAnnotations;

namespace DemoDbModels
{
    public class Person
    {
        [Required]
        public int Id { get; set; }
        [Required, StringLength(250)]
        public string FirstName { get; set; }
        [Required, StringLength(250)]
        public string LastName { get; set; }
    }
}