using System.Collections.Generic;
using Demo.PropertySearch.Domain;
using Demo.PropertySearch.RestApi.Models;

namespace Demo.PropertySearch.RestApi.Helpers
{
    public static class RepositoryExtensions
    {
        public static IEnumerable<IStock> Search(this IStockRepository repository, StockSearchParams args)
        {
            return 
                args == null 
                ? repository.GetAll() 
                : repository.Search(args.ToDomainSearchArgs());
        }
    }
}