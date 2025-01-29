using MediatR;
using Unclewood.Modules.Ingredients.Domain;

namespace Unclewood.Common.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
