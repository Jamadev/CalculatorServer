using CalculatorService.Server.Interfaces;
using CalculatorService.Server.Models;
using CalculatorService.Server.Models.Helpers;
using Serilog;
using System;
using System.Collections.Generic;

namespace CalculatorService.Server.Services
{
    /// <summary>
    /// Implementation of the interface's methods. 
    /// </summary>
    public class CalculatorService : ICalculatorInterface
    {
        /// <summary>
        /// Journal where the operations are saved in every request that requires so.
        /// </summary>
        public List<KeyValuePair<string, LogModel>> Journal = new List<KeyValuePair<string, LogModel>>();

        /// <summary>
        /// Implementation of addition method.
        /// </summary>
        /// <param name="addends"></param>
        /// <param name="trackingId"></param>
        /// <returns></returns>
        public AdditionResponseModel Addition(AdditionModel addends, string trackingId)
        {
            // Sums all the numbers in the array.
            int sum = 0;
            foreach (int i in addends.Addends)
            {
                sum += i;
            }

            LogModel logModel = new LogModel()
            {
                Operation = "Sum",
                Calculation = $"{string.Join("+", addends.Addends)} = {sum.ToString()}",
                Date = DateTime.Now
            };
            //if there is a tracking id, save operation in journal.
            if (!string.IsNullOrEmpty(trackingId))
            {
                Journal.Add(new KeyValuePair<string, LogModel>(trackingId, logModel));
            }
            // saves data in the log
            Log.Information($"Calculator::Add:: {logModel}");

            return new AdditionResponseModel() { Sum = sum };

        }

        /// <summary>
        /// Implementation of division method.
        /// </summary>
        /// <param name="division"></param>
        /// <param name="trackingId"></param>
        /// <returns></returns>
        public DivisionResponseModel Division(DivisionModel division, string trackingId)
        {
            //calculates the division and the remainder.
            int quotient = division.Dividend / division.Divisor;
            int remainder = division.Dividend % division.Divisor;

            LogModel logModel = new LogModel()
            {
                Operation = "Div",
                Calculation = $"{division.Dividend} / {division.Divisor} = {quotient}",
                Date = DateTime.Now
            };
            //if there is a tracking id, save operation in journal.
            if (!string.IsNullOrEmpty(trackingId))
            {
                Journal.Add(new KeyValuePair<string, LogModel>(trackingId, logModel));
            }
            // saves data in the log
            Log.Information($"Calculator::Div:: {logModel}");

            return new DivisionResponseModel()
            {
                Quotient = quotient,
                Remainder = remainder
            };
        }

        /// <summary>
        /// Implementation of multiplication method.
        /// </summary>
        /// <param name="factors"></param>
        /// <param name="trackingId"></param>
        /// <returns></returns>
        public MultiplicationResponseModel Multiplication(MultiplicationModel factors, string trackingId)
        {
            //Calculates the product of the numbers in the array
            int product = 0;
            foreach (int i in factors.Factors)
            {
                product *= i;
            }

            LogModel logModel = new LogModel()
            {
                Operation = "Mul",
                Calculation = $"{string.Join("*", factors.Factors)}",
                Date = DateTime.Now
            };

            //if there is a tracking id, save operation in journal.
            if (!string.IsNullOrEmpty(trackingId))
            {
                Journal.Add(new KeyValuePair<string, LogModel>(trackingId, logModel));
            }
            // saves data in the log
            Log.Information($"Calculator::Mul:: {logModel}");

            return new MultiplicationResponseModel() { Product = product };

        }

        /// <summary>
        /// Implementation of square root method.
        /// </summary>
        /// <param name="sqrt"></param>
        /// <param name="trackingId"></param>
        /// <returns></returns>
        public SqrtResponseModel Sqrt(SqrtModel sqrt, string trackingId)
        {
            //Finds square root of input number
            double square = Math.Sqrt(sqrt.Number);
            LogModel logModel = new LogModel()
            {
                Operation = "Sqrt",
                Calculation = $"sqrt({sqrt.Number}) = {square}",
                Date = DateTime.Now
            };

            //if there is a tracking id, save operation in journal.
            if (!string.IsNullOrEmpty(trackingId))
            {
                Journal.Add(new KeyValuePair<string, LogModel>(trackingId, logModel));
            }
            // saves data in the log
            Log.Information($"Calculator::Sqrt:: {logModel}");
            return new SqrtResponseModel() { Square = square };

        }

        /// <summary>
        /// Implementation of substraction method.
        /// </summary>
        /// <param name="substraction"></param>
        /// <param name="trackingId"></param>
        /// <returns></returns>
        public SubstractionResponseModel Substraction(SubstractionModel substraction, string trackingId)
        {
            //calculates the difference between the inputs.
            int difference = substraction.Minuend - substraction.Subtrahend;

            LogModel logModel = new LogModel()
            {
                Operation = "Sub",
                Calculation = $"{ substraction.Minuend} - {substraction.Subtrahend} = {difference}",
                Date = DateTime.Now
            };

            //if there is a tracking id, save operation in journal.
            if (!string.IsNullOrEmpty(trackingId))
            {
                Journal.Add(new KeyValuePair<string, LogModel>(trackingId, logModel));
            }
            // saves data in the log
            Log.Information($"Calculator::Sub:: {logModel}");

            return new SubstractionResponseModel() { Difference = difference };

        }

        /// <summary>
        /// Implementation of journal method.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public QueryResponseModel FindJournal(QueryModel query)
        {
            List<LogModel> operationsUser = new List<LogModel>();

            //Finds all of the key value pairs in the journal list that have the id entered by the user.
            var found = Journal.FindAll(kvp => kvp.Key == query.Id);

            //Then add the value of each pair found to the list that is returned.
            foreach (KeyValuePair<string, LogModel> element in found)
            {
                operationsUser.Add(element.Value);
            }
            return new QueryResponseModel() { Operations = operationsUser};
        }

       
    }
}
