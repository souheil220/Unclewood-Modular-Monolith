using MediatR;
using Unclewood.Modules.Ingredients.Domain;

namespace Unclewood.Modules.Ingredients.Application.Interfaces.Command;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand,Result> 
    where TCommand : ICommand;
    
public interface ICommandHandler<TCommand,TResponse> : IRequestHandler<TCommand,Result<TResponse>> 
    where TCommand : ICommand<TResponse>;