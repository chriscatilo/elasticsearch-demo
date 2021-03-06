﻿using Demo.PropertySearch.Domain;

namespace Demo.PropertySearch.Repository.Mock
{
    public class ContentResource : IContentResource
    {
        public AssetType AssetType { get; set; }

        public string Type { get; set; }

        public string Caption { get; set; }

        public string Url { get; set; }
    }
}