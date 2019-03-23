using System.ComponentModel.DataAnnotations;

namespace CalculatorService.Server.Models
{
    /// <summary>
    /// Data transfer object for receiving data of a division.
    /// </summary>
    public class DivisionModel
    {
        /// <summary>
        /// Property of the class and its attributes.
        /// Number to be divided.
        /// </summary>
        [Display(Name = "Dividend")]
        [Required(ErrorMessage = "The dividend is required")]
        public int Dividend { get; set; }

        /// <summary>
        /// Property of the class and its attributes.
        /// Number dividing.
        /// </summary>
        [Display(Name = "Divisor")]
        [Required(ErrorMessage = "The divisor is required")]
        public int Divisor { get; set; }
    }
}
