using SurveyTool.Core;
using SurveyTool.EntityFramework;
using System;

namespace SurveyTool.Web.Mediator
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider serviceProvider;
        private readonly SurveyToolContext dbContext;

        public CommandDispatcher(IServiceProvider serviceProvider, SurveyToolContext dbContext)
        {
            this.serviceProvider = serviceProvider;
            this.dbContext = dbContext;
        }

        public Guid Dispatch<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            var handler = (IHandleCommand<TCommand>)serviceProvider.GetService(typeof(IHandleCommand<TCommand>));

            if (handler == null)
                throw new HandlerNotFoundException(typeof(IHandleCommand<TCommand>));

            // would be better to put transaction in interceptor
            // but as of now I don't know how to with the DI of Dotnet Core
            var myTransaction = false;
            try
            {
                if (dbContext.Database.CurrentTransaction == null)
                {
                    myTransaction = true;
                    dbContext.Database.BeginTransaction();
                }

                var result = handler.Handle(command);
                dbContext.SaveChanges();

                if (myTransaction)
                    dbContext.Database.CommitTransaction();

                return result;
            }
            catch (Exception)
            {
                dbContext.Database.CurrentTransaction?.Rollback();
                throw;
            }
        }
    }
}
