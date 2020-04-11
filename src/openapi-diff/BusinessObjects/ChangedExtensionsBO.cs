﻿using openapi_diff.DTOs;
using System.Collections.Generic;

namespace openapi_diff.BusinessObjects
{
    public class ChangedExtensionsBO : ComposedChangedBO
    {
        private readonly Dictionary<string, object> _oldExtensions;
        private readonly Dictionary<string, object> _newExtensions;
        private readonly DiffContextBO _context;

        private Dictionary<string, ChangedBO> Increased { get; set; }
        private Dictionary<string, ChangedBO> Missing { get; set; }
        private Dictionary<string, ChangedBO> Changed { get; set; }

        public ChangedExtensionsBO(Dictionary<string, object> oldExtensions, Dictionary<string, object> newExtensions, DiffContextBO context)
        {
            _oldExtensions = oldExtensions;
            _newExtensions = newExtensions;
            _context = context;
            Increased = new Dictionary<string, ChangedBO>();
            Missing = new Dictionary<string, ChangedBO>();
            Changed = new Dictionary<string, ChangedBO>();
        }

        public override List<ChangedBO> GetChangedElements()
        {
            var list = new List<ChangedBO>();
            list.AddRange(Increased.Values);
            list.AddRange(Missing.Values);
            list.AddRange(Changed.Values);
            return list;
        }

        public override DiffResultBO IsCoreChanged()
        {
            return new DiffResultBO(DiffResultEnum.NoChanges);
        }
    }
}