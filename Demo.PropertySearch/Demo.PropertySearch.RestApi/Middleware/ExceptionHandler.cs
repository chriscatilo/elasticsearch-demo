using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace Demo.PropertySearch.RestApi.Middleware
{
    public class ExceptionHandler : IExceptionHandler
    {
        private static readonly ExceptionRegistry ExceptionRegistry = new ExceptionRegistry();

        public virtual Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            return !ShouldHandle(context)
                ? Task.FromResult(0)
                : HandleAsyncCore(context, cancellationToken);
        }

        public virtual Task HandleAsyncCore(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            HandleCore(context);
            return Task.FromResult(0);
        }

        public virtual void HandleCore(ExceptionHandlerContext context)
        {
            if (ExceptionRegistry.CanHandleException(context))
            {
                ExceptionRegistry.HandleException(context);
            }
        }

        public virtual bool ShouldHandle(ExceptionHandlerContext context)
        {
            return context.ExceptionContext.CatchBlock.IsTopLevel;
        }
    }
}