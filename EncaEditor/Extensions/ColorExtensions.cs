using UnityEngine;

namespace Enca.Extensions
{
    public static class ColorExtensions
    {
        /// <summary>
        /// Gets a new color with the same RGB values as the given color, but with a specified alpha value.
        /// </summary>
        /// <param name="color">The original color.</param>
        /// <param name="alpha">The alpha value for the new color.</param>
        /// <returns>A new color with the specified alpha value.</returns>
        public static Color GetColorWithAlpha(this Color color, float alpha)
        {
            return new Color(color.r, color.g, color.b, alpha);
        }

        /// <summary>
        /// Returns a new color that is a blend between two colors, according to the alpha value.
        /// </summary>
        /// <param name="color">The original color.</param>
        /// <param name="target">The target color to blend with.</param>
        /// <param name="alpha">The ratio of blending between the original and the target color.</param>
        /// <returns>A new color that is a blend of the original and target color based on the alpha value.</returns>
        public static Color LerpAlpha(this Color color, Color target, float alpha)
        {
            return Color.Lerp(color, target, alpha);
        }

        /// <summary>
        /// Returns a new color that has its brightness increased by a specified factor.
        /// </summary>
        /// <param name="color">The original color.</param>
        /// <param name="factor">The factor to increase the brightness by. Should be a value between 0 and 1.</param>
        /// <returns>A new color with increased brightness.</returns>
        public static Color Brighten(this Color color, float factor)
        {
            return Color.Lerp(color, Color.white, factor);
        }
        
        /// <summary>
        /// Returns a new color that has its brightness decreased by a specified factor.
        /// </summary>
        /// <param name="color">The original color.</param>
        /// <param name="factor">The factor to decrease the brightness by. Should be a value between 0 and 1.</param>
        /// <returns>A new color with decreased brightness.</returns>
        public static Color Darken(this Color color, float factor)
        {
            return Color.Lerp(color, Color.black, factor);
        }
        
        /// <summary>
        /// Returns a random color;
        /// </summary>
        /// <returns>A new color with randomized RGB values.</returns>
        public static Color GetRandomColor()
        {
            return new Color(Random.GetRandomNumber(256), Random.GetRandomNumber(256), Random.GetRandomNumber(256));
        }
    }
}