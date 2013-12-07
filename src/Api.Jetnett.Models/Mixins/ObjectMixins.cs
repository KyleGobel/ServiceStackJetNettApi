using System.Collections;
using System.Collections.Generic;

namespace Api.JetNett.Models.Mixins
{
    public static class ObjectMixins
    {
        public static IEnumerable<T> ToEnumerable<T>(this T This) 
        {
            return new List<T> {This};
        }
    }
}