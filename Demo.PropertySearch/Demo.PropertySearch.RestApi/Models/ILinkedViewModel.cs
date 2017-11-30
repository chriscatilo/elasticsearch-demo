using System.Collections.Generic;
using Demo.PropertySearch.RestApi.Helpers;

namespace Demo.PropertySearch.RestApi.Models
{
    public interface ILinkedViewModel
    {
        IEnumerable<NavigationLink> Links { get; set; }
    }
}