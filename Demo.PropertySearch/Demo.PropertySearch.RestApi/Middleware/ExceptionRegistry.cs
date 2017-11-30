using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Http.ExceptionHandling;

namespace Demo.PropertySearch.RestApi.Middleware
{
    internal class ExceptionRegistry : ReadOnlyDictionary<Type, Action<ExceptionHandlerContext>>
    {
        public ExceptionRegistry() : base(new Dictionary<Type, Action<ExceptionHandlerContext>>())
        {
//            // Course by seo name not found
//            Dictionary.Add(typeof(CustomException), context =>
//            {
//                context.Result = new CustomNotFoundResult(context);
//            });
//
//            // Call to an external API returned an unsuccessful response
//            Dictionary.Add(typeof(ExternalHttpClientException), context =>
//            {
//                var ex = (ExternalHttpClientException)context.Exception;
//
//                var message = $"GET {ex.Uri.AbsoluteUri} returned: {ex.Message}";
//
//                context.Result = new CustomExceptionResult(context, ex.StatusCode, message);
//            });
//
//            // No engage membership found
//            Dictionary.Add(typeof(NoMembershipFound), context =>
//            {
//                context.Result = new CustomExceptionResult(context, HttpStatusCode.Forbidden, context.Exception.Message);
//            });
        }

        public bool CanHandleException(ExceptionHandlerContext context)
        {
            var exceptionType = context.Exception.GetType();

            return ContainsKey(exceptionType);
        }

        public void HandleException(ExceptionHandlerContext context)
        {
            var exceptionType = context.Exception.GetType();

            var invoke = this[exceptionType];

            invoke(context);
        }
    }
}