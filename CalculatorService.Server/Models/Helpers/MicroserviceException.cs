namespace CalculatorService.Server.Models.Helpers
{
    /// <summary>
    /// Class for returning exceptions of the server
    /// </summary>
    public class MicroserviceException
    {
        /// <summary>
        /// Type of error.
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        /// Http status code associated to this error.
        /// </summary>
        public int ErrorStatus { get; set; }
        /// <summary>
        /// Inner message of the exception.
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
