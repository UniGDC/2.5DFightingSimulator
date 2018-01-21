using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UniGDC.Unevolved.Utility
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Maps a float value to given float range.
        /// </summary>
        /// <param name="value">Value to map</param>
        /// <param name="beforeMin">Minimum of the input range</param>
        /// <param name="beforeMax">Maximum of the input range</param>
        /// <param name="afterMin">Minimum of the result range</param>
        /// <param name="afterMax">maximum of the result range</param>
        /// <returns>Mapped value in <see cref="float"/></returns>
        public static float Map(this float value, float beforeMin, float beforeMax, float afterMin, float afterMax)
        {
            if (beforeMin > beforeMax
                || afterMin > afterMax)
                throw new ArgumentException("Minimum values are larger than maximum values." +
                                            "Please check your arguments to proceed.");

            return afterMin
                   + (value - beforeMin)
                   * (beforeMax - beforeMin)
                   / (afterMax - afterMin);
        }

        /// <summary>
        /// Maps a float value to given integer range.
        /// </summary>
        /// <param name="value">Value to map</param>
        /// <param name="beforeMin">Minimum of the input range</param>
        /// <param name="beforeMax">Maximum of the input range</param>
        /// <param name="afterMin">Minimum of the result range</param>
        /// <param name="afterMax">maximum of the result range</param>
        /// <returns>Mapped value in <see cref="int"/></returns>
        public static int Map(this float value, float beforeMin, float beforeMax, int afterMin, int afterMax)
        {
            float result = value.Map(beforeMin, beforeMax, (float)afterMin, (float)afterMax);

            return Mathf.RoundToInt(result);
        }
    }
}
