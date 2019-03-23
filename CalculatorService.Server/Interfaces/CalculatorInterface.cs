using CalculatorService.Server.Models;

namespace CalculatorService.Server.Interfaces
{
    /// <summary>
    /// Definition of methods.
    /// </summary>
    public interface ICalculatorInterface
    {
        /// <summary>
        /// Addition of two or more numeric operands
        /// </summary>
        /// <param name="addends"></param>
        /// <param name="trackingId"></param>
        /// <returns></returns>
        AdditionResponseModel Addition(AdditionModel addends, string trackingId);

        /// <summary>
        /// Subtraction of two numeric operands
        /// </summary>
        /// <param name="substraction"></param>
        /// <param name="trackingId"></param>
        /// <returns></returns>
        SubstractionResponseModel Substraction(SubstractionModel substraction, string trackingId);

        /// <summary>
        /// Multiply of two or more numeric operands
        /// </summary>
        /// <param name="factors"></param>
        /// <param name="trackingId"></param>
        /// <returns></returns>
        MultiplicationResponseModel Multiplication(MultiplicationModel factors, string trackingId);

        /// <summary>
        /// Division of two or more numeric operands
        /// </summary>
        /// <param name="division"></param>
        /// <param name="trackingId"></param>
        /// <returns></returns>
        DivisionResponseModel Division(DivisionModel division, string trackingId);

        /// <summary>
        /// Square root of a numeric operand
        /// </summary>
        /// <param name="sqrt"></param>
        /// <param name="trackingId"></param>
        /// <returns></returns>
        SqrtResponseModel Sqrt(SqrtModel sqrt, string trackingId);

        /// <summary>
        /// Query journal entries by TrackingId
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        QueryResponseModel FindJournal(QueryModel query);

    }
}
