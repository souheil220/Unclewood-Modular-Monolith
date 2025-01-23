using MediatR;
using Unclewood.Modules.Ingredients.Domain;

namespace Unclewood.Modules.Ingredients.Application.Interfaces.Command;

public interface ICommand : IRequest<Result> , IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>,IBaseCommand;

public interface IBaseCommand;