﻿using Microsoft.OpenApi.Models;
using openapi_diff.DTOs;
using System.Collections.Generic;

namespace openapi_diff.BusinessObjects
{
    public class ChangedOAuthFlowsBO : ComposedChangedBO
    {
        private readonly OpenApiOAuthFlows _oldOAuthFlows;
        private readonly OpenApiOAuthFlows _newOAuthFlows;

        public ChangedOAuthFlowBO ImplicitOAuthFlow { get; set; }
        public ChangedOAuthFlowBO PasswordOAuthFlow { get; set; }
        public ChangedOAuthFlowBO ClientCredentialOAuthFlow { get; set; }
        public ChangedOAuthFlowBO AuthorizationCodeOAuthFlow { get; set; }
        public ChangedExtensionsBO Extensions { get; set; }

        public ChangedOAuthFlowsBO(OpenApiOAuthFlows oldOAuthFlows, OpenApiOAuthFlows newOAuthFlows)
        {
            _oldOAuthFlows = oldOAuthFlows;
            _newOAuthFlows = newOAuthFlows;
        }

        public override List<ChangedBO> GetChangedElements()
        {
            return new List<ChangedBO>
            {
                ImplicitOAuthFlow,
                PasswordOAuthFlow,
                ClientCredentialOAuthFlow,
                AuthorizationCodeOAuthFlow,
                Extensions
            };
        }

        public override DiffResultBO IsCoreChanged()
        {
            return new DiffResultBO(DiffResultEnum.NoChanges);
        }
    }
}