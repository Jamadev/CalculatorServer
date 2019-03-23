using System.ComponentModel.DataAnnotations;

namespace CalculatorService.Server.Models
{
    /// <summary>
    /// Data transfer object for receiving data of an addition.
    /// </summary>
    public class AdditionModel
    {

        /// <summary>
        /// Property of the class and its attributes.
        /// Array of numbers being added.
        /// </summary>
        [Display(Name = "Addends")]
        [Required(ErrorMessage = "The addends are required")]
        [MinLength(2, ErrorMessage = "You need at least two addends")]
        public int[] Addends { get; set; }
    }
}
