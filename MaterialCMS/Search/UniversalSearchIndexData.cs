using System;
using System.Collections.Generic;
using MaterialCMS.Helpers;
using MaterialCMS.Search.Models;

namespace MaterialCMS.Search
{
    public class UniversalSearchIndexData
    {
        public UniversalSearchItem UniversalSearchItem { get; set; }
        public UniversalSearchIndexAction Action { get; set; }

        public static IEqualityComparer<UniversalSearchIndexData> Comparer
        {
            get
            {
                return
                    new StrictKeyEqualityComparer<UniversalSearchIndexData, UniversalSearchIndexDataComparison>(
                        data => new UniversalSearchIndexDataComparison(data));
            }
        }

        public struct UniversalSearchIndexDataComparison : IEquatable<UniversalSearchIndexDataComparison>
        {
            private readonly UniversalSearchIndexAction _action;
            private readonly Guid _guid;

            public UniversalSearchIndexDataComparison(UniversalSearchIndexData data)
            {
                _guid = data.UniversalSearchItem.SearchGuid;
                _action = data.Action;
            }

            public bool Equals(UniversalSearchIndexDataComparison other)
            {
                return _guid == other._guid && _action == other._action;
            }
        }
    }
}