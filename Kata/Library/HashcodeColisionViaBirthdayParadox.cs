using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace Kata
{
    public class HashcodeColisionViaBirthdayParadox
    {
        private bool stillLookingForHashcodeCollision = true;
        private (string, string, string) result;

        private readonly ConcurrentDictionary<int, ConcurrentBag<string>> _exploredStringPerHash = new ();
        
        public (string, string, string) ComputeCollision()
        {
            return ComputeCollision(2, 16);
        }

        public (string, string, string) ComputeCollision(int minLength, int maxLength)
        {

            Parallel.For(minLength, maxLength, GenerateRandomHash);

            return result;
        }

        private void GenerateRandomHash(int length, ParallelLoopState parallelLoop)
        {
            Random generator = new ();

            while (stillLookingForHashcodeCollision)
            {
                string randomOne = GenerateString(length, generator);

                ConcurrentBag<string> UpdateBag(int currentHashcode, ConcurrentBag<string> bag)
                {
                    if(!bag.Any(s => s.Equals(randomOne)))
                    {
                        bag.Add(randomOne);
                    }

                    if(bag.Count >= 3)
                    {
                        var arrayResult = bag.Take(3).ToArray();
                        result = (arrayResult[0], arrayResult[1], arrayResult[2]);
                        stillLookingForHashcodeCollision = false;
                        parallelLoop.Stop();
                    }

                    return bag;
                }

                _exploredStringPerHash.AddOrUpdate(
                    randomOne.GetHashCode(),
                    new ConcurrentBag<string>() { randomOne },
                    UpdateBag);
            }
        }

        private static string GenerateString(int length, Random generator)
        {
            return string.Concat(
            Enumerable.Range(0, length)
                    .Select(i => (char)generator.Next('!', '~' + 1)));
        }
    }
}
