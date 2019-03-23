namespace CalculatorService.Server.Models
{
    /// <summary>
    /// Structure of the substraction response in case the operation was correctly effected.
    /// </summary>
    public class SubstractionResponseModel
    {
        /// <summary>
        /// Arithmetic operation result.
        /// </summary>
        public int Difference { get; set; }
    }
}
