using MediatR;
using Unclewood.Common.Domain.Abstraction;

namespace Unclewood.Common.Application.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
