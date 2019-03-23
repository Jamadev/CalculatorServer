using System.ComponentModel.DataAnnotations;

namespace CalculatorService.Server.Models
{
    /// <summary>
    ///  Data transfer object for receiving data of the square root function.
    /// </summary>
    public class SqrtModel
    {
        /// <summary>
        /// Property of the class and its attributes.
        /// Input of the square root mathematical function.
        /// </summary>
        [Display(Name = "Number")]
        [Required(ErrorMessage = "A number is required")]
        public int Number { get; set; }
    }
}
