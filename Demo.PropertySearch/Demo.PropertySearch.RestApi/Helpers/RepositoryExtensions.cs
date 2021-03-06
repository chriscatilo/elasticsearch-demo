﻿using Demo.PropertySearch.Domain;
using Demo.PropertySearch.RestApi.Models;
using System.Collections.Generic;

namespace Demo.PropertySearch.RestApi.Helpers
{
    public static class RepositoryExtensions
    {
        public static IEnumerable<IStock> Search(this IStockRepository repository, ApiRoute.StockSearch.StockSearchParams args)
        {
            return 
                args == null 
                ? repository.GetAll() 
                : repository.Search(args.ToDomainSearchArgs());
        }
    }
}