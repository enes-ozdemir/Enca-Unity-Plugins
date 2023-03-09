namespace Enca.Extensions
{
    public static class Random
    {
        /// <summary>
        ///     Get random number from 0 to given number.
        /// </summary>
        /// <param name="limitNumber"></param>
        public static float GetRandomNumber(float limitNumber) => UnityEngine.Random.Range(0, limitNumber);
    }
}