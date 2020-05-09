using System;
using System.Linq;
using System.Threading.Tasks;
using ExtractInformation.Implementations;
using ExtractInformation.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ExtractInformation
{
    public static class ExtractorFunction
    {
        [FunctionName("Extract")]
        public static void Run([TimerTrigger("0 0 5,10 * * *")]TimerInfo myTimer, ILogger log)
        {            
            var executors = new IExtractor[]
            {
                new Extractor(log)
            };

            Parallel.ForEach(executors.Where(e => e.IsEnabled()), async exec =>
            {
                await exec.ExecuteAsync();
            });
        }
    }
}
