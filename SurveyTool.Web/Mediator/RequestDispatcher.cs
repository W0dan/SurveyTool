using SurveyTool.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyTool.Web.Mediator
{
    public class RequestDispatcher : IRequestDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public RequestDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public TResponse Dispatch<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest
        {
            var handler = (IHandleRequest<TRequest, TResponse>)serviceProvider.GetService(typeof(IHandleRequest<TRequest, TResponse>));

            if (handler == null)
                throw new HandlerNotFoundException(typeof(IHandleRequest<TRequest, TResponse>));

            return handler.Handle(request);
        }
    }
}
