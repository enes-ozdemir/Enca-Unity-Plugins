namespace Editor.Extensions
{
    public static class Random
    {
        public static float GetRandomNumber(float limitNumber) => UnityEngine.Random.Range(0, limitNumber);
    }
}