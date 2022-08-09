using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Kata
{
    public class SameHashCode
    {
        private readonly ITestOutputHelper output;

        public SameHashCode(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Produce_3_different_strings_with_the_same_hashcode()
        {
            (string stringA, string stringB, string stringC) = new HashcodeColisionViaBirthdayParadox().ComputeCollision();

            (stringA.GetHashCode() == stringB.GetHashCode()).Should().Be(true);

            (stringB.GetHashCode() == stringC.GetHashCode()).Should().Be(true);

            (!string.Equals(stringA, stringB)).Should().Be(true);

            (!string.Equals(stringB, stringC)).Should().Be(true);

            (!string.Equals(stringA, stringC)).Should().Be(true);

            output.WriteLine($"{stringA} {stringB} {stringC}");
        }
    }
}
