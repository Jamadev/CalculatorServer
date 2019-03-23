using CalculatorService.Server.Models.Helpers;
using System.Collections.Generic;

namespace CalculatorService.Server.Models
{
    /// <summary>
    /// Response for a successful request of the journal history.
    /// </summary>
    public class QueryResponseModel
    {
        /// <summary>
        /// List of all the operations performed with the specified TrackingId.
        /// </summary>
        public List<LogModel> Operations { get; set; }
    }
}
