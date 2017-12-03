using Demo.PropertySearch.Utils;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Demo.PropertySearch.Specs.Utils
{
    [Binding]
    public class DemoTestSteps
    {
        [Given(@"Baz is (.*)")]
        public void GivenBazIs(int value)
        {
            var featureArgs = SpecArgsFactory.CreateFeatureArgs<IFooFeatureArgs>();

            if (featureArgs.Baz != null)
            {
                return;
            }

            featureArgs.Baz = value;
        }

        [When(@"I set Foo to (.*)")]
        public void WhenISetFooTo(int value)
        {
            var scenarioArgs = SpecArgsFactory.CreateScenarioArgs<FooScenarioArgs>();
            scenarioArgs.Foo = value;
        }

        [When(@"I set Bar to (.*)")]
        public void WhenISetBarTo(int value)
        {
            var scenarioArgs = SpecArgsFactory.CreateScenarioArgs<FooScenarioArgs>();
            scenarioArgs.Bar = value;
        }

        [When(@"I set Qux to (.*)")]
        public void WhenISetQuxTo(int value)
        {
            var scenarioArgs = SpecArgsFactory.CreateScenarioArgs<FooScenarioArgs>();
            scenarioArgs.Qux = value;
        }

        [Then(@"Foo is (.*)")]
        public void ThenFooIs(int value)
        {
            var scenarioArgs = SpecArgsFactory.CreateScenarioArgs<FooScenarioArgs>();
            Assert.That(scenarioArgs.Foo, Is.EqualTo(value));
        }

        [Then(@"Foo (has been|has not been) set")]
        public void ThenFooHasBeenSet(string condition)
        {
            var scenarioArgs = SpecArgsFactory.CreateScenarioArgs<FooScenarioArgs>();

            var hasBeenSet = scenarioArgs.HasBeenSet<FooScenarioArgs, int?>(args => args.Foo);

            Assert.That(hasBeenSet, Is.EqualTo(condition.EqualsCaseInsensitive("has been")));
        }

        [Then(@"Bar is (.*)")]
        public void ThenBarIs(int value)
        {
            var scenarioArgs = SpecArgsFactory.CreateScenarioArgs<FooScenarioArgs>();
            Assert.That(scenarioArgs.Bar, Is.EqualTo(value));
        }

        [Then(@"Bar (has been|has not been) set")]
        public void ThenBarHasBeenSet(string condition)
        {
            var scenarioArgs = SpecArgsFactory.CreateScenarioArgs<FooScenarioArgs>();

            var hasBeenSet = scenarioArgs.HasBeenSet<FooScenarioArgs, int?>(args => args.Bar);

            Assert.That(hasBeenSet, Is.EqualTo(condition.EqualsCaseInsensitive("has been")));
        }

        [Then(@"Baz is (.*)")]
        public void ThenBazIs(int value)
        {
            var featureArgs = SpecArgsFactory.CreateFeatureArgs<IFooFeatureArgs>();
            Assert.That(featureArgs.Baz, Is.EqualTo(value));
        }

        [Then(@"Baz (has been|has not been) set")]
        public void ThenBazHasBeenSet(string condition)
        {
            var featureArgs = SpecArgsFactory.CreateFeatureArgs<IFooFeatureArgs>();

            var hasBeenSet = featureArgs.HasBeenSet<IFooFeatureArgs, int?>(args => args.Baz);

            Assert.That(hasBeenSet, Is.EqualTo(condition.EqualsCaseInsensitive("has been")));
        }

        [Then(@"Qux is (.*)")]
        public void ThenQuxIs(int value)
        {
            var scenarioArgs = SpecArgsFactory.CreateScenarioArgs<FooScenarioArgs>();
            Assert.That(scenarioArgs.Qux, Is.EqualTo(value));
        }

        [Then(@"Qux (has been|has not been) set")]
        public void ThenQuxHasBeenSet(string condition)
        {
            var scenarioArgs = SpecArgsFactory.CreateScenarioArgs<FooScenarioArgs>();

            var hasBeenSet = scenarioArgs.HasBeenSet<FooScenarioArgs, int?>(args => args.Qux);

            Assert.That(hasBeenSet, Is.EqualTo(condition.EqualsCaseInsensitive("has been")));
        }

        [Then(@"Norf (has been|has not been) set")]
        public void ThenNorfHasBeenSet(string condition)
        {
            var featureArgs = SpecArgsFactory.CreateFeatureArgs<IFooFeatureArgs>();

            var hasBeenSet = featureArgs.HasBeenSet<IFooFeatureArgs, string>(args => args.Norf);

            Assert.That(hasBeenSet, Is.EqualTo(condition.EqualsCaseInsensitive("has been")));
        }
    }
}