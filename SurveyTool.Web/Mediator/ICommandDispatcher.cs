using System;
using SurveyTool.Core;

namespace SurveyTool.Web.Mediator
{
    public interface ICommandDispatcher
    {
        Guid Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}