using Bunit;
using QuantumPMTestTask.Utils;


namespace TestNotesList
{
    public class ComponentTest
    {
        [Fact]
        public void ExpandableTextShowsMoreButtonWhenTextExceedsLimit()
        {
            // Fill note with test values
            using var ctx = new TestContext();
            var component = ctx.RenderComponent<ExpandableText>(parameters => parameters
                .Add(p => p.Text, "This is a long text that should be truncated initially.")
                .Add(p => p.MaxVisibleCharacters, 20));

            // Checking if component does not contain "show less" and contains "more" button
            Assert.DoesNotContain("show less", component.Markup);
            Assert.Contains("more", component.Markup);
        }

        [Fact]
        public void ToggleExpandableTextVisibility()
        {
            // Fill note with test values
            using var ctx = new TestContext();
            var component = ctx.RenderComponent<ExpandableText>(parameters => parameters
                .Add(p => p.Text, "This is a long text that should be truncated initially.")
                .Add(p => p.MaxVisibleCharacters, 20));

            component.Find("button").Click();

            // Checking if component contain "show less" button, does not contain "more" button and contain full text of note
            Assert.Contains("show less", component.Markup);
            Assert.DoesNotContain("more", component.Markup);
            Assert.Contains("This is a long text that should be truncated initially.", component.Markup);
        }

        [Fact]
        public void ExpandableTextShowsMoreOrLessTextCorrectly()
        {
            // Fill note with test values
            using var ctx = new TestContext();
            var component = ctx.RenderComponent<ExpandableText>(parameters => parameters
                .Add(p => p.Text, "This is a long text that should be truncated initially.")
                .Add(p => p.MaxVisibleCharacters, 20));

            component.Find("button").Click();
            component.Find("button").Click();

            // Checking if component contain "more" button, does not contain "show less" button and full text of note
            Assert.Contains("more", component.Markup);
            Assert.DoesNotContain("show less", component.Markup);
            Assert.DoesNotContain("This is a long text that should be truncated initially.", component.Markup);
        }
    }
}
