using System.ComponentModel.DataAnnotations;

namespace CalculatorService.Server.Models
{
    /// <summary>
    /// Data transfer object for receiving data for finding an specified journal.
    /// </summary>
    public class QueryModel
    {

        /// <summary>
        /// Property of the class and its attributes.
        /// The TrackingId for which journal should be queried against.
        /// </summary>
        [Display(Name = "Id")]
        [Required(ErrorMessage = "The id is required")]
        public string Id { get; set; }
    }
}
