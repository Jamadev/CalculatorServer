using System.ComponentModel.DataAnnotations;

namespace CalculatorService.Server.Models
{
    /// <summary>
    /// Data transfer object for receiving data of a substraction.
    /// </summary>
    public class SubstractionModel
    {
        /// <summary>
        /// Property of the class and its attributes.
        /// Minuend of the arithmetic subtraction.
        /// </summary>
        [Display(Name = "Minuend")]
        [Required(ErrorMessage = "The minuend is required")]
        public int Minuend { get; set; }

        /// <summary>
        /// Property of the class and its attributes.
        /// Subtrahend of the arithmetic subtraction.
        /// </summary>
        [Display(Name = "Subtrahend")]
        [Required(ErrorMessage = "The subtrahend is required")]
        public int Subtrahend { get; set; }
    }
}
