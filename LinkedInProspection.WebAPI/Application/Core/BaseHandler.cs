namespace LinkedInProspection.WebAPI.Application.Core;

public interface IHandler<in TQuery, TResult> where TQuery : IQuery
{
    Task<TResult> Handle(TQuery query);
}

public interface IQuery;