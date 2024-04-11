using UnityEngine;

namespace Skiing2
{
    public static class RandomColor
    {
        public static Color SetRandomColor()
        {
            float hue = Random.value;
            float saturation = Random.value;
            float value = Random.value * 0.5f + 0.5f;

            Color slimeColor = Color.HSVToRGB(hue, saturation, value);
            return slimeColor;
        }
    }
}