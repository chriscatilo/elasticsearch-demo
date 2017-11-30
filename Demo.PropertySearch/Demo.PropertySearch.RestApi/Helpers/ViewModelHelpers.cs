using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo.PropertySearch.RestApi.Models;
using Demo.PropertySearch.Utils;

namespace Demo.PropertySearch.RestApi.Helpers
{

    public static class ViewModelExtensions
    {
        public static QueryResults<TModel> CreateViewModel<TModel>
        (
            this IEnumerable<TModel> result,
            Action<QueryResults<TModel>> afterCreate = null
        )
        {
            var qr = new QueryResults<TModel> { Result = result };
            afterCreate?.Invoke(qr);
            return qr;
        }

        public static TViewModel AddLinks<TViewModel>(this TViewModel viewModel, params NavigationLink[] links)
            where TViewModel : class, ILinkedViewModel
        {
            var vmLinks = viewModel.Links?.ToList() ?? new List<NavigationLink>();

            vmLinks.AddRange(links.Where(l => l.Href.IsNotNullOrEmpty()));

            viewModel.Links = vmLinks.AsReadOnly();

            return viewModel;
        }

        public static TViewModel AddLinks<TViewModel>(this TViewModel viewModel, IEnumerable<NavigationLink> links)
            where TViewModel : class, ILinkedViewModel
        {
            return AddLinks(viewModel, links.ToArray());
        }
    }
}