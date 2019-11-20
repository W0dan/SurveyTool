using System;

namespace SurveyTool.Core
{
    public interface IHandleCommand<TCommand>
        where TCommand : ICommand
    {
        Guid Handle(TCommand command);
    }
}
