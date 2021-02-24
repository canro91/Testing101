using System;
using Stringie.Actions.Common;

namespace Stringie.Actions.Remove
{
    public class RemoveStringStartingOccurrenceToOccurrence : ICaseIgnorable, IPositional
    {
        private readonly RemoveStringStartingOccurrence _removeStringStartingOccurrence;
        private readonly int _occurrenceCount;
        private readonly string _marker;
        private bool _ignoreCase;
        private The _position;

        internal RemoveStringStartingOccurrenceToOccurrence(RemoveStringStartingOccurrence removeStringStartingOccurrence, int occurrenceCount, string marker)
        {
            _removeStringStartingOccurrence = removeStringStartingOccurrence;
            _occurrenceCount = occurrenceCount;
            _marker = marker;
            _ignoreCase = false;
            _position = The.Beginning;
        }

        public static implicit operator string(RemoveStringStartingOccurrenceToOccurrence removeStringStartingOccurrenceToOccurrence)
        {
            return removeStringStartingOccurrenceToOccurrence.ToString();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        #region ICaseIgnorable Members

        void ICaseIgnorable.IgnoreCase()
        {
            _ignoreCase = true;
        }

        #endregion

        #region IPositional Members

        void IPositional.Set(The position)
        {
            _position = position;
        }

        #endregion
    }
}
