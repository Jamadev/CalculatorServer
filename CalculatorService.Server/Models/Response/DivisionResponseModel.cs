namespace CalculatorService.Server.Models
{
    /// <summary>
    /// Structure of the division response in case the operation was correctly effected.
    /// </summary>
    public class DivisionResponseModel
    {
        /// <summary>
        /// Arithmetic operation result.
        /// </summary>
        public int Quotient { get; set; }
        /// <summary>
        /// The remainder of the arithmetic division.
        /// </summary>
        public int Remainder { get; set; }
    }
}
