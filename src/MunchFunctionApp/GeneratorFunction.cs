using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using MunchBase.Processor;

namespace MunchFunctionApp
{
    public class GeneratorFunction
    {
        public GeneratorFunction(MunchGenerator generator)
        {

        }
        [FunctionName("Generator")]
        public void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
