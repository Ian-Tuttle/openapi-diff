﻿using System.Collections.Generic;
using yaos.OpenAPI.Diff.Enums;
using yaos.OpenAPI.Diff.Extensions;

namespace yaos.OpenAPI.Diff.BusinessObjects
{
    public abstract class ChangedListBO<T> : ChangedBO
    {
        public readonly DiffContextBO Context;
        public readonly IList<T> OldValue;
        public readonly IList<T> NewValue;

        public List<T> Increased { get; set; }
        public List<T> Missing { get; set; }
        public List<T> Shared { get; set; }

        protected ChangedListBO(IList<T> oldValue, IList<T> newValue, DiffContextBO context)
        {
            OldValue = oldValue;
            NewValue = newValue;
            Context = context;
            Shared = new List<T>();
            Increased = new List<T>();
            Missing = new List<T>();
        }

        public override DiffResultBO IsChanged()
        {
            if (Missing.IsNullOrEmpty() && Increased.IsNullOrEmpty())
            {
                return new DiffResultBO(DiffResultEnum.NoChanges);
            }
            return IsItemsChanged();
        }

        public abstract DiffResultBO IsItemsChanged();

        public class SimpleChangedList : ChangedListBO<T>
        {
            protected SimpleChangedList(List<T> oldValue, List<T> newValue) : base(oldValue, newValue, null)
            {
            }

            public override DiffResultBO IsItemsChanged()
            {
                return new DiffResultBO(DiffResultEnum.Unknown);
            }
        }
    }
}