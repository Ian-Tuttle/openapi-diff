﻿using yaos.OpenAPI.Diff.Enums;

namespace yaos.OpenAPI.Diff.BusinessObjects
{
    public class ChangedMetadataBO : ChangedBO
    {
        public string Left { get; set; }
        public string Right { get; set; }

        public override DiffResultBO IsChanged()
        {
            return Left == Right ? new DiffResultBO(DiffResultEnum.NoChanges) : new DiffResultBO(DiffResultEnum.Metadata);
        }
    }
}