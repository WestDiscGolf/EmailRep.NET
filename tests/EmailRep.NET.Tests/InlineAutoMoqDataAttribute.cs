using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace EmailRep.NET.Tests
{
    public class InlineAutoMoqDataAttribute : InlineAutoDataAttribute
    {
        public InlineAutoMoqDataAttribute(params object[] values)
            : base(new AutoMoqDataAttribute(), values) { }


        private class AutoMoqDataAttribute : AutoDataAttribute
        {
            public AutoMoqDataAttribute() :
                base(() => new Fixture().Customize(new AutoMoqCustomization()))
            {
            }
        }
    }
}