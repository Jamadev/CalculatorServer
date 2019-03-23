using System.ComponentModel.DataAnnotations;

namespace CalculatorService.Server.Models
{
    /// <summary>
    ///  Data transfer object for receiving data of a multiplication.
    /// </summary>
    public class MultiplicationModel
    {
        /// <summary>
        /// Property of the class and its attributes.
        /// Array of numbers being multiplied.
        /// </summary>
        [Display(Name = "Factors")]
        [Required(ErrorMessage = "The factors are required")]
        [MinLength(2, ErrorMessage = "You need at least two factors")]
        public int[] Factors { get; set; }
    }
}
