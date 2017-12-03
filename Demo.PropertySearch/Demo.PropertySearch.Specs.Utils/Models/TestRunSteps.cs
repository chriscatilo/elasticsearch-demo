namespace Demo.PropertySearch.Specs.Utils.Models
{
    public abstract class TestRunSteps<TTestContext> where TTestContext : class, ISpecArgs<TTestContext>
    {
        protected TestRunSteps()
        {
            TestContext = SpecArgsFactory.CreateScenarioArgs<TTestContext>();
        }

        public TTestContext TestContext { get; set; }
    }
}