﻿using System.Threading;
using Stringie.Actions.Remove.Resources;

namespace Stringie.Actions.Remove
{
    public class RemoveVowels
    {
        private readonly string _source;

        internal RemoveVowels(string source)
        {
            _source = source;
        }

        internal string Source { get { return _source; } }

        public static implicit operator string(RemoveVowels removeVowels)
        {
            return removeVowels.ToString();
        }

        public override string ToString()
        {
            var vowels = VowelsMap.GetFor(Thread.CurrentThread.CurrentCulture.Name);
            return _source.RemoveChars(vowels).IgnoringCase();
        }
    }
}
