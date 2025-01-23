using MediatR;
using Unclewood.Modules.Ingredients.Domain;

namespace Unclewood.Modules.Ingredients.Application.Interfaces.Query;

public interface IQuery<TResponse>:IRequest<Result<TResponse>>
{
}