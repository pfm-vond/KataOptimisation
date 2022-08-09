namespace Kata
{
    public class NthRootSolver
    {
        public static double GetNthRoot(double number, int n)
        {
            return ComputeWithNewtownMethod(number, n, 0.00001);
        }

        public static double ComputeWithNewtownMethod(double number, int nAsInt, double precision)
        {
            double errorDelta = double.MaxValue;
            double lastApproximation = 2;
            double approximation = double.MaxValue;
            double n = nAsInt;
            double nminuone = n - 1;

            while (errorDelta > precision)
            {
                approximation = (nminuone * lastApproximation + (number / Pow(lastApproximation, nAsInt-1))) / n;
                errorDelta = approximation - lastApproximation;
                errorDelta = errorDelta < 0 ? -errorDelta : errorDelta;
                lastApproximation = approximation;
            }

            return approximation;
        }

        public static double Pow(double number, int power)
        {
            double ithPowerOfNumber = number;

            for (int i = 2; i <= power; i++)
                ithPowerOfNumber *= number;

            return ithPowerOfNumber;
        }
    }
}
