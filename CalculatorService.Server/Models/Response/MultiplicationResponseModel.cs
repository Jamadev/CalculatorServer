namespace CalculatorService.Server.Models
{
    /// <summary>
    /// Structure of the multiplication response in case the operation was correctly effected.
    /// </summary>
    public class MultiplicationResponseModel
    {
        /// <summary>
        /// Arithmetic operation result.
        /// </summary>
        public int Product { get; set; }
    }
}
