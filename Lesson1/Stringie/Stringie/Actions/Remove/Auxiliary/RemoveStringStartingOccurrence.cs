﻿using System;
using Stringie.Actions.Common;

namespace Stringie.Actions.Remove
{
    public class RemoveStringStartingOccurrence : ICaseIgnorable, IPositional
    {
        private readonly RemoveString _removeString;
        private readonly int _occurrenceCount;
        private readonly string _marker;
        private bool _ignoreCase;
        private The _position;

        internal RemoveStringStartingOccurrence(RemoveString removeString, int occurrenceCount, string marker)
        {
            _removeString = removeString;
            _occurrenceCount = occurrenceCount;
            _marker = marker;
            _ignoreCase = false;
            _position = The.Beginning;
        }

        internal RemoveString RemoveString { get { return _removeString; } }
        internal int OccurrenceCount { get { return _occurrenceCount; } }
        internal string Marker { get { return _marker; } }
        internal bool IgnoreCase { get { return _ignoreCase; } }
        internal The Position { get { return _position; } }

        public static implicit operator string(RemoveStringStartingOccurrence removeStringStartingOccurrence)
        {
            return removeStringStartingOccurrence.ToString();
        }

        public override string ToString()
        {
            return _occurrenceCount == 1
                ? _removeString.Source.RemoveStartingOrTo(_marker, _ignoreCase, _position, isStarting: true)
                : _removeString.Source.RemoveStartingOrTo(_occurrenceCount, _marker, _ignoreCase, _position, isStarting: true);
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
