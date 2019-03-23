using System;

namespace CalculatorService.Server.Models.Helpers
{
    /// <summary>
    /// Class for defining the structure of logs storage and in which journals are kept.
    /// </summary>
    public class LogModel
    {
        /// <summary>
        /// Refers to the type of arithmetic operation.
        /// </summary>
        public string Operation { get; set; }
        /// <summary>
        /// The operation made and its result.
        /// </summary>
        public string Calculation { get; set; }
        /// <summary>
        /// Date and time in which the calculation was effected. 
        /// </summary>
        public DateTime Date { get; set; }

    }
}
