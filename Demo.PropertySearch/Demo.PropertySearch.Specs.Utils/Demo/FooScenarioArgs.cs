namespace Demo.PropertySearch.Specs.Utils
{
    public interface IFooFeatureArgs : ISpecArgs<IFooFeatureArgs>
    {
        int? Baz { get; set; }

        string Norf { get; set; }
    }

    public class FooScenarioArgs : ISpecArgs<FooScenarioArgs>
    {
        public virtual int? Foo { get; set; }

        public virtual int? Bar { get; set; }

        public virtual int? Qux { get; set; }
    }
}
