using System;
using System.Threading;

namespace Rainnier.DesignPattern.ThreadSync.AtomicOperation
{
    internal class UsefulCode
    {
        //Atomic Maxium method
        public static int Maximum(ref int target, int value)
        {
            int currentVal = target, startVal, desiredVal;

            do
            {
                startVal = currentVal;

                desiredVal = Math.Max(startVal, value);

                currentVal = Interlocked.CompareExchange(ref target, desiredVal, startVal);
            }
            while (startVal != currentVal);

            return desiredVal;
        }

        //Swapped to common pattern code
        delegate int Morpher<TResult, TArgument>(int startVal, TArgument argument, out TResult morphResult);

        static TResult Morph<TResult, TArgument>(ref int target, TArgument argument, Morpher<TResult, TArgument> morpher)
        {
            TResult morphResult;

            int currentVal = target, startVal, desiredVal;

            do
            {
                startVal = currentVal;
                desiredVal = morpher(startVal, argument, out morphResult);
                currentVal = Interlocked.CompareExchange(ref target, desiredVal, startVal);

            }
            while (startVal != currentVal);

            return morphResult;
        }
    }
}
