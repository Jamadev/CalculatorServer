using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace CalculatorService.Client
{
    class Program
    {
        /// <summary>
        /// Main method, initiates the application.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {            
            StartMessage();
            MainAsync().Wait();
            EndMessage();
        }

        /// <summary>
        /// Method to manage asyncronous threads.
        /// </summary>
        /// <returns></returns>
        static async Task MainAsync()
        {
            bool on = true;
            while (on == true)
            {
                on = await Calculator();
            }
        }

        /// <summary>
        /// Welcoming message for the user.
        /// </summary>
        private static void StartMessage()
        {
            Console.WriteLine(
                "\n\n                         .NET CORE CALCULATOR                                   " +

                "\n\n                                                                                " +
                "\n\n Possible operators:      " +
                "\n\n\n\t\t\t\t Addition `+`                                                         " +
                "\n\n\n\t\t\t\t Substraction `-`                                                     " +
                "\n\n\n\t\t\t\t Multiplication `*`                                                   " +
                "\n\n\n\t\t\t\t Division `/`                                                         " +
                "\n\n\n\t\t\t\t Square Root `s`                                                         " +
                "\n\n Type `exit` if you want to leave the application                               " );
        }

        /// <summary>
        /// Good bye message for the user.
        /// </summary>
        private static void EndMessage()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("\n\n                     THANK YOU FOR USING .NET CORE CALCULATOR                                   " +
                              "\n\n                                    GOOD BYE                                                    " +
                              "\n\n");
            Thread.Sleep(4000);
        }

        /// <summary>
        /// Method to receive the users intended operation.
        /// </summary>
        /// <returns></returns>
        private static async Task<bool> Calculator()
        {
            Console.WriteLine("Please select an operation.");

            string Operator = Console.ReadLine();
            if (string.IsNullOrEmpty(Operator))
            {
                Console.WriteLine("Please select an operation.");
                return true;
            }
            else if (Operator.ToLower() == "exit")
            {
                return false;
            }
            else if (!Regex.IsMatch(Operator, @"[+-\/*s]"))
            {
                Console.WriteLine("Please select a valid operator.");
                return true;
            }
            else
            {
                switch (Operator)
                {
                    case "+":
                        {
                            await Sum();
                            break;
                        }
                    case "-":
                        {
                            await Sub();
                            break;
                        }
                    case "*":
                        {
                            await Mul();
                            break;
                        }
                    case "/":
                        {
                            await Div();
                            break;
                        }
                    case "s":
                        {
                            await Sqrt();
                            break;
                        }
                    default:
                        break;
                }
                

                Console.WriteLine("\n\n  Would you like to keep calculating or to see the journal?" +
                                  "\n\n  Press Enter to continue with the calculator" +
                                  "\n\n             or " +
                                  "\n\n  Press j to review the journal");
                string action = Console.ReadLine();
                if (action.Trim() == "j")
                {
                    await Journal();
                }
                return true;
            }
        }

        /// <summary>
        /// Method for finding the journal
        /// </summary>
        /// <returns></returns>
        private static async Task<bool> Journal()
        {
            Console.WriteLine("\n\n Enter your username.");
            string trackingId = Console.ReadLine();
            object content = new {
                Id = trackingId.Trim().ToLower()
            };
            string methodUrl = "journal/query";
            var result = await ExecuteHttpRequest<object, JObject>(content, methodUrl, "");
            var operations = result.Property("operations");
            if (operations == null)
            {
                Console.WriteLine("\n\nPlease enter a valid username or try adding it when calculating.");
                return true;
            }
            Console.WriteLine("\n\nThe contents in the journal are: " + operations.Value.ToString());
            return true;
        }

        /// <summary>
        /// Method for adding numbers
        /// </summary>
        /// <returns></returns>
        private static async Task<bool> Sum()
        {
            //seleccionar números
            Console.WriteLine("\n\n Enter the numbers you wish to add separated by spaces. " +
                              "\n\n Example: 2 3 4 5 6                                     ");
            string inputNumbers = Console.ReadLine();
            if (!Regex.IsMatch(inputNumbers, @"[0-9-]")) {
                Console.WriteLine("\n\nEnter just integrer numbers");
                return true;
            }
                string[] split = inputNumbers.Split(" ");
            List<int> numbers = split.Select(x => int.Parse(x)).ToList();
            if(numbers.Count < 2)
            {
                Console.WriteLine("\n\nEnter at least two numbers to add");
                return true;
            }
            Console.WriteLine("\n\n Enter a username to view your journal later.           " +
                              "\n\n Example: user1                                         ");
            string trackingId = Console.ReadLine();
            object content = new
            {
                Addends = numbers,
            };
            string methodUrl = "calculator/add";
            var result = await ExecuteHttpRequest<object, JObject>(content, methodUrl, trackingId.Trim().ToLower());
            var sumresult = result.Property("sum");
            if(sumresult == null)
            {
                Console.WriteLine(result.ToString());
                return true;
            }
            Console.WriteLine("\n\nThe result is: " + sumresult.Value);
            return true;
        }

        /// <summary>
        /// Method for substracting numbers
        /// </summary>
        /// <returns></returns>
        private static async Task<bool> Sub()
        {
            Console.WriteLine("\n\n Enter a minuend. ");
            string minuend = Console.ReadLine();
            if (!Regex.IsMatch(minuend, @"[0-9-]"))
            {
                Console.WriteLine("\n\nEnter just integrer numbers");
                return true;
            }
            Console.WriteLine("\n\n Enter a subtrahend. ");
            string subtrahend = Console.ReadLine();
            if (!Regex.IsMatch(subtrahend, @"[0-9-]"))
            {
                Console.WriteLine("\n\nEnter just integrer numbers");
                return true;
            }
            object content = new
            {
                Minuend = minuend,
                Subtrahend = subtrahend
            };
            Console.WriteLine("\n\n Enter a username to view your journal later.           " +
                              "\n\n Example: user1                                         ");
            string trackingId = Console.ReadLine();

            string methodUrl = "calculator/sub";

            var result = await ExecuteHttpRequest<object, JObject>(content, methodUrl, trackingId.Trim().ToLower());
            var subresult = result.Property("Difference");
            if (subresult == null)
            {
                Console.WriteLine(result.ToString());
                return true;
            }
            Console.WriteLine("\n\n The result is: " + subresult.Value);
            return true;
        }

        /// <summary>
        /// Method for dividing numbers
        /// </summary>
        /// <returns></returns>
        private static async Task<bool> Div()
        {
            Console.WriteLine("\n\n Enter a dividend. ");
            string dividend = Console.ReadLine();
            if (!Regex.IsMatch(dividend, @"[0-9-]"))
            {
                Console.WriteLine("\n\n Enter just integrer numbers");
                return true;
            }
            Console.WriteLine("\n\n Enter a divisor. ");
            string divisor = Console.ReadLine();
            if (!Regex.IsMatch(divisor, @"[0-9-]"))
            {
                Console.WriteLine("Enter just integrer numbers");
                return true;
            }
            Console.WriteLine("\n\n Enter a username to view your journal later.           " +
                              "\n\n Example: user1                                         ");
            string trackingId = Console.ReadLine();

            if (divisor.Trim() == "0")
            {
                Console.WriteLine("\n\n The result is: undefined");
                return true;
            }
            object content = new
            {
                Dividend = dividend,
                Divisor = divisor
            };
            string methodUrl = "calculator/div";
            var result = await ExecuteHttpRequest<object, JObject>(content, methodUrl, trackingId.Trim().ToLower());
            var quotient = result.Property("Quotient");
            var remainder = result.Property("remainder");

            if (quotient == null)
            {
                Console.WriteLine(result.ToString());
                return true;
            }
            Console.WriteLine("\n\n The result of the division is " + quotient.Value + " and the remainder " + remainder.Value);
            return true;
        }

        /// <summary>
        /// Method for multiplying numbers
        /// </summary>
        /// <returns></returns>
        private static async Task<bool> Mul()
        {
            Console.WriteLine("\n\n Enter the numbers you wish to multiply separated by spaces. " +
                             "\n\n Example: 2 3 4 5 6                                     ");
            string inputNumbers = Console.ReadLine();
            if (!Regex.IsMatch(inputNumbers, @"[0-9-]"))
            {
                Console.WriteLine("\n\n Enter just integrer numbers");
                return true;
            }
            string[] split = inputNumbers.Split(" ");
            List<int> numbers = split.Select(x => int.Parse(x)).ToList();

            if (numbers.Count < 2)
            {
                Console.WriteLine("\n\n Enter at least two numbers to multiply");
                return true;
            }

            Console.WriteLine("\n\n Enter a username to view your journal later.           " +
                              "\n\n Example: user1                                         ");
            string trackingId = Console.ReadLine();

            object content = new
            {
                Factors = numbers
            };
            string methodUrl = "calculator/mul";
            var result = await ExecuteHttpRequest<object, JObject>(content, methodUrl, trackingId.Trim().ToLower());
            var mulresult = result.Property("Product");

            if (mulresult == null)
            {
                Console.WriteLine(result.ToString());
                return true;
            }
            Console.WriteLine("\n\n The result is: " + mulresult.Value);
            return true;
        }

        /// <summary>
        /// Method for finding the square root of a number 
        /// </summary>
        /// <returns></returns>
        private static async Task<bool> Sqrt()
        {
            Console.WriteLine("\n\n Enter a number to calculate square root. ");
            string inputNumber = Console.ReadLine();
            if (!Regex.IsMatch(inputNumber, @"[0-9]"))
            {
                Console.WriteLine("\n\n Enter just integrer possitive numbers");
                return true;
            }
            
            Console.WriteLine("\n\n Enter a username to view your journal later.           " +
                              "\n\n Example: user1                                         ");
            string trackingId = Console.ReadLine();

            object content = new {
                Number = inputNumber
            };
            string methodUrl = "sqrt";
            var result = await ExecuteHttpRequest<object, JObject>(content, methodUrl, trackingId.Trim().ToLower());
            var sqrtresult = result.Property("square");

            if (sqrtresult == null)
            {
                Console.WriteLine(result.ToString());
                return true;
            }
            Console.WriteLine("\n\n The result is: " + sqrtresult.Value);
            return true;
        }
        /// <summary>
        /// Method for making http requests
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Treturn"></typeparam>
        /// <param name="model"></param>
        /// <param name="methodUrl"></param>
        /// <param name="trackingId"></param>
        /// <returns></returns>

        private static async Task<Treturn> ExecuteHttpRequest<T, Treturn>(T model, string methodUrl, string trackingId)
        {
            using (var clientHttp = new HttpClient())
            {
                clientHttp.BaseAddress = new Uri("http://localhost:49268/");
                clientHttp.DefaultRequestHeaders.Accept.Clear();
                clientHttp.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType: "application/json"));
                clientHttp.DefaultRequestHeaders.Add("X-Evi-Tracking-Id", trackingId);
                string json = JsonConvert.SerializeObject(model, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponse = new HttpResponseMessage();
                httpResponse = await clientHttp.PostAsync(methodUrl, httpContent);
                
                string reponse = await httpResponse.Content.ReadAsStringAsync();
                
                Treturn jsonResponse = JsonConvert.DeserializeObject<Treturn>(reponse);
                return jsonResponse;
            }
        }
    }
}