using MediatR;
using Unclewood.Common.Domain.Abstraction;

namespace Unclewood.Common.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
