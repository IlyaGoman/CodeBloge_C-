using System;

namespace ExtentionMethodApp
{
    public sealed class Road
    {
        public int Number { get; set; }
        public int Length { get; set; }

        public override string ToString()
        {
            return $"Road №{Number} Length:{Length}";
        }
    }
}
