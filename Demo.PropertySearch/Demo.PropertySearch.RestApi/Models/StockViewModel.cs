using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo.PropertySearch.RestApi.Helpers;

namespace Demo.PropertySearch.RestApi.Models
{
    public class ViewModel<TBody> : ILinkedViewModel
    {
        public ViewModel(TBody body)
        {
            Body = body;
        }

        public IEnumerable<NavigationLink> Links { get; set; }

        public TBody Body { get; private set; }
    }


}