﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

namespace osu.Game.Rulesets.UI.Scrolling.Algorithms
{
    public class ConstantScrollAlgorithm : IScrollAlgorithm
    {
        public double GetDisplayStartTime(double time, double timeRange) => time - timeRange;

        public float GetLength(double startTime, double endTime, double timeRange, float scrollLength)
        {
            // At the hitobject's end time, the hitobject will be positioned such that its end rests at the origin.
            // This results in a negative-position value, and the absolute of it indicates the length of the hitobject.
            return -PositionAt(startTime, endTime, timeRange, scrollLength);
        }

        public float PositionAt(double time, double currentTime, double timeRange, float scrollLength)
            => (float)((time - currentTime) / timeRange * scrollLength);

        public void Reset()
        {
        }
    }
}