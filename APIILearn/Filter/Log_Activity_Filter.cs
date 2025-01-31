using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace APIILearn.Filter
{
    public class Log_Activity_Filter : IActionFilter
    {
        private readonly ILogger<Log_Activity_Filter> logger;
        public Log_Activity_Filter(ILogger<Log_Activity_Filter>_logger)
        {
            logger = _logger;            
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation($"Excuting action {context.ActionDescriptor.DisplayName} on controller {context.Controller}");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.Result = new NotFoundResult();
        }
    }
}
