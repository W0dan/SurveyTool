namespace SurveyTool.Web.Mediator
{
    public interface IRequestDispatcher
    {
        TResponse Dispatch<TRequest, TResponse>(TRequest request) where TRequest : Core.IRequest;
    }
}