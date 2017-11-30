using System.Collections.Generic;

namespace Demo.PropertySearch.Domain
{
    public interface IStockRepository
    {
        IEnumerable<IStock> GetAll();
        IStock GetByPropertyID(string id);
        IEnumerable<IStock> Search(SearchParams args);
    }
}