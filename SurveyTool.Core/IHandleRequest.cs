using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyTool.Core
{
    public interface IHandleRequest<TRequest, TResponse>
        where TRequest: IRequest
    {
        TResponse Handle(TRequest request);
    }
}
