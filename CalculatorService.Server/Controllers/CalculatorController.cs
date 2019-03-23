using System;
using CalculatorService.Server.Interfaces;
using CalculatorService.Server.Models;
using CalculatorService.Server.Models.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Serilog;

namespace CalculatorService.Server.Controllers
{
    /// <summary>
    /// Application controller. Handles browser requests and returns a response.
    /// </summary>
    [Produces("application/json")]
    public class CalculatorController : ControllerBase
    {
        #region Internals
        /// <summary>
        /// Dependency injection. By creating a dependency to the interface containing the methods.
        /// </summary>
        private readonly ICalculatorInterface _calculatorService;

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor of the controller. 
        /// The container resolves the dependencies in the graph and returns the fully resolved service.
        /// </summary>
        public CalculatorController(ICalculatorInterface service)
        {
            _calculatorService = service;
        }
        #endregion

        /// <summary>
        /// Adds two or more operands and retrieve the result
        /// </summary>
        /// <param name="addends"></param>
        /// <returns></returns>


        [HttpPost, Route("[controller]/[action]")]
        public ActionResult Add([FromBody] AdditionModel addends)
        {
            try
            {
                // Verifies if the model is valid, if not, returns a bad request response.
                // the verification is based on the attributes defined in the DTO.
                if (!ModelState.IsValid)
                {
                    MicroserviceException badRequestResponse = new MicroserviceException()
                    {
                        ErrorCode = "InternalError",
                        ErrorMessage = "Unable to process request:" + ModelState.Count,
                        ErrorStatus = 400
                    };
                    return BadRequest(badRequestResponse);
                }
                else
                {
                    // Finds the value of the header with the tracking id
                    StringValues trackingId;
                    Request.Headers.TryGetValue("X-Evi-Tracking-Id", out trackingId);
                    var response = _calculatorService.Addition(addends, trackingId);
                    return Ok(response);
                }
            }
            // Catches and manages all of the server's errors and responds the client with a controlled object.
            catch (Exception err)
            {
                MicroserviceException internalServerErrorResponse = new MicroserviceException()
                {
                    ErrorCode = "InternalError",
                    ErrorMessage = "An unexpected error condition was triggered which made impossible to fulfill the request. Please try again or contact support" + err.InnerException,
                    ErrorStatus = 500
                };
                Log.Error($"Calculator::Exception:: {internalServerErrorResponse}");

                return StatusCode(500, internalServerErrorResponse);
            }
        }

        /// <summary>
        /// Sub two operands and retrieve the result.
        /// </summary>
        /// <param name="substraction"></param>
        /// <returns></returns>
        [HttpPost, Route("[controller]/[action]")]
        public ActionResult Sub([FromBody] SubstractionModel substraction)
        {
            try
            {
                // Verifies if the model is valid, if not, returns a bad request response.
                // the verification is based on the attributes defined in the DTO.
                if (!ModelState.IsValid)
                {
                    MicroserviceException badRequestResponse = new MicroserviceException()
                    {
                        ErrorCode = "InternalError",
                        ErrorMessage = "Unable to process request:" + ModelState.Values,
                        ErrorStatus = 400
                    };
                    return BadRequest(badRequestResponse);
                }
                else
                {
                    // Finds the value of the header with the tracking id
                    StringValues trackingId;
                    Request.Headers.TryGetValue("X-Evi-Tracking-Id", out trackingId);
                    var response = _calculatorService.Substraction(substraction, trackingId);
                    return Ok(response);
                }
            }
            // Catches and manages all of the server's errors and responds the client with a controlled object.
            catch (Exception err)
            {
                MicroserviceException internalServerErrorResponse = new MicroserviceException()
                {
                    ErrorCode = "InternalError",
                    ErrorMessage = "An unexpected error condition was triggered which made impossible to fulfill the request. Please try again or contact support" + err.InnerException,
                    ErrorStatus = 500
                };
                Log.Error($"Calculator::Exception:: {internalServerErrorResponse}");
                return StatusCode(500, internalServerErrorResponse);
            }

        }

        /// <summary>
        /// Multiply two or more operands and retrieve the result.
        /// </summary>
        /// <param name="factors"></param>
        /// <returns></returns>
        [HttpPost, Route("[controller]/[action]")]
        public ActionResult Mult([FromBody] MultiplicationModel factors)
        {
            try
            {
                // Verifies if the model is valid, if not, returns a bad request response.
                // the verification is based on the attributes defined in the DTO.
                if (!ModelState.IsValid)
                {
                    MicroserviceException badRequestResponse = new MicroserviceException()
                    {
                        ErrorCode = "InternalError",
                        ErrorMessage = "Unable to process request:" + ModelState.Values,
                        ErrorStatus = 400
                    };
                    return BadRequest(badRequestResponse);
                }
                else
                {
                    // Finds the value of the header with the tracking id
                    StringValues trackingId;
                    Request.Headers.TryGetValue("X-Evi-Tracking-Id", out trackingId);
                    var response = _calculatorService.Multiplication(factors, trackingId);
                    return Ok(response);
                }
            }
            // Catches and manages all of the server's errors and responds the client with a controlled object.
            catch (Exception err)
            {
                MicroserviceException internalServerErrorResponse = new MicroserviceException()
                {
                    ErrorCode = "InternalError",
                    ErrorMessage = "An unexpected error condition was triggered which made impossible to fulfill the request. Please try again or contact support" + err.InnerException,
                    ErrorStatus = 500
                };
                Log.Error($"Calculator::Exception:: {internalServerErrorResponse}");
                return StatusCode(500, internalServerErrorResponse);
            }

        }

        /// <summary>
        /// Divide two operands and retrieve the result.
        /// </summary>
        /// <param name="division"></param>
        /// <returns></returns>
        [HttpPost, Route("[controller]/[action]")]
        public ActionResult Div([FromBody] DivisionModel division)
        {
            try
            {
                // Verifies if the model is valid, if not, returns a bad request response.
                // the verification is based on the attributes defined in the DTO.
                if (!ModelState.IsValid)
                {
                    MicroserviceException badRequestResponse = new MicroserviceException()
                    {
                        ErrorCode = "InternalError",
                        ErrorMessage = "Unable to process request:" + ModelState.Values,
                        ErrorStatus = 400
                    };
                    return BadRequest(badRequestResponse);
                }
                else
                {
                    // Finds the value of the header with the tracking id
                    StringValues trackingId;
                    Request.Headers.TryGetValue("X-Evi-Tracking-Id", out trackingId);
                    var response = _calculatorService.Division(division, trackingId);
                    return Ok(response);
                }
            }
            // Catches and manages all of the server's errors and responds the client with a controlled object.
            catch (Exception err)
            {
                MicroserviceException internalServerErrorResponse = new MicroserviceException()
                {
                    ErrorCode = "InternalError",
                    ErrorMessage = "An unexpected error condition was triggered which made impossible to fulfill the request. Please try again or contact support" + err.InnerException,
                    ErrorStatus = 500
                };
                Log.Error($"Calculator::Exception:: {internalServerErrorResponse}");
                return StatusCode(500, internalServerErrorResponse);
            }

        }

        /// <summary>
        /// Square root a number and retrieve the result.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>

        [HttpPost, Route("[action]")]
        public ActionResult Sqrt([FromBody] SqrtModel number)
        {
            try
            {
                // Verifies if the model is valid, if not, returns a bad request response.
                // the verification is based on the attributes defined in the DTO.
                if (!ModelState.IsValid)
                {
                    MicroserviceException badRequestResponse = new MicroserviceException()
                    {
                        ErrorCode = "InternalError",
                        ErrorMessage = "Unable to process request:" + ModelState.Values,
                        ErrorStatus = 400
                    };
                    return BadRequest(badRequestResponse);
                }
                else
                {
                    // Finds the value of the header with the tracking id
                    StringValues trackingId;
                    Request.Headers.TryGetValue("X-Evi-Tracking-Id", out trackingId);
                    var response = _calculatorService.Sqrt(number, trackingId);
                    return Ok(response);
                }
            }
            // Catches and manages all of the server's errors and responds the client with a controlled object.
            catch (Exception err)
            {
                MicroserviceException internalServerErrorResponse = new MicroserviceException()
                {
                    ErrorCode = "InternalError",
                    ErrorMessage = "An unexpected error condition was triggered which made impossible to fulfill the request. Please try again or contact support" + err.InnerException,
                    ErrorStatus = 500
                };
                Log.Error($"Calculator::Exception:: {internalServerErrorResponse}");
                return StatusCode(500, internalServerErrorResponse);
            }

        }


        /// <summary>
        /// Request all operations for a TrackingId  since the last application restart.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost, Route("journal/query")]
        public ActionResult FindJournal([FromBody] QueryModel query)
        {
            try
            {
                // Verifies if the model is valid, if not, returns a bad request response.
                // the verification is based on the attributes defined in the DTO.
                if (!ModelState.IsValid)
                {
                    MicroserviceException badRequestResponse = new MicroserviceException()
                    {
                        ErrorCode = "InternalError",
                        ErrorMessage = "Unable to process request:" + ModelState.Values,
                        ErrorStatus = 400
                    };
                    return BadRequest(badRequestResponse);
                }
                else
                {
                    var response = _calculatorService.FindJournal(query);
                    return Ok(response);
                }
            }
            // Catches and manages all of the server's errors and responds the client with a controlled object.
            catch (Exception err)
            {
                MicroserviceException internalServerErrorResponse = new MicroserviceException()
                {
                    ErrorCode = "InternalError",
                    ErrorMessage = "An unexpected error condition was triggered which made impossible to fulfill the request. Please try again or contact support" + err.InnerException,
                    ErrorStatus = 500
                };
                Log.Error($"Calculator::Exception:: {internalServerErrorResponse}");
                return StatusCode(500, internalServerErrorResponse);
            }

        }

    }
}
