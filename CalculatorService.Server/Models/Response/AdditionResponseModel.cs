namespace CalculatorService.Server.Models
{
    /// <summary>
    /// Structure of the addition response in case the operation was correctly effected.
    /// </summary>
    public class AdditionResponseModel
    {
        /// <summary>
        /// Arithmetic operation result.
        /// </summary>
        public int Sum { get; set; }
    }
}
