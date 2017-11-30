namespace Demo.PropertySearch.Domain
{
    public interface IContentResource
    {
        AssetType AssetType { get; set; }

        string Type { get; set; }

        string Caption { get; set; }

        string Url { get; set; }
    }
}