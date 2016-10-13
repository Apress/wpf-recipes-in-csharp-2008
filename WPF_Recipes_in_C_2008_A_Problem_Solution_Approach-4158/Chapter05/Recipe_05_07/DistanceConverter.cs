using System;

namespace Recipe_05_07
{
    public enum DistanceType
    {
        Miles,
        Kilometres
    }

    public class DistanceConverter
    {
        /// <summary>
        /// Convert miles to kilometres and vice versa.
        /// </summary>
        /// <param name="amount">The amount to convert.</param>
        /// <param name="distancetype">The units the amount is in.</param>
        /// <returns>A string containing the converted amount.</returns>
        public string Convert(
            double amount, 
            DistanceType distancetype)
        {
            if(distancetype == DistanceType.Miles)
                return (amount * 1.609344).ToString("0.##") + " km";

            if(distancetype == DistanceType.Kilometres)
                return (amount * 0.621371192).ToString("0.##") + " m";

            throw new ArgumentOutOfRangeException("distanceType");
        }
    }
}