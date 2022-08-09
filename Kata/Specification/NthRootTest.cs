using FluentAssertions;
using System;
using Xunit;

namespace Kata
{
    public class NthRootTest
    {
        [Theory]
        [InlineData(2, 3)]
        [InlineData(2.52, 7)]
        [InlineData(56, 9)]
        public void Compute_Nth_Pow_of_integer(double number, int power)
        {
            var result = NthRootSolver.Pow(number, power);

            result.Should().Be(Math.Pow(number, power));
        }

        [Theory]
        [InlineData(2, 3)]
        [InlineData(5, 5)]
        public void Compute_Nth_Root_of_integer_at_pow_n_is_the_integer_itself(int number, int power)
        {
            var root = NthRootSolver.GetNthRoot(Math.Pow(number, power), power);

            root.Should().Be(number);
        }

        [Theory]
        [InlineData(2.41, 3)]
        [InlineData(5.0006, 5)]
        public void Compute_Nth_Root_of_double_at_pow_n_is_about_the_double_with_0_00001_precision(double number, int power)
        {
            var root = NthRootSolver.GetNthRoot(Math.Pow(number, power), power);

            root.Should().BeApproximately(number, 0_00001);
        }
    }
}
