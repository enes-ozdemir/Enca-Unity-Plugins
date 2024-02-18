namespace Enca.Extensions
{
    public static class Random
    {
        /// <summary>
        /// Get random number from 0 to given number.
        /// </summary>
        /// <param name="limitNumber"></param>
        public static int GetRandomNumber(int limitNumber) => UnityEngine.Random.Range(0, limitNumber);
        
        /// <summary>
        /// Returns a random boolean value.
        /// </summary>
        public static bool GetRandomBool() => UnityEngine.Random.value > 0.5f;

    }
}