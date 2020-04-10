﻿using Xunit;
using yaos.OpenApi.Diff.Tests._Base;

namespace yaos.OpenAPI.Diff.Tests.Tests
{
    public class BackwardCompatibilityTest : BaseTest
    {
        private const string OpenAPIDoc1 = "backwardCompatibility/bc_1.yaml";
        private const string OpenAPIDoc2 = "backwardCompatibility/bc_2.yaml";
        private const string OpenAPIDoc3 = "backwardCompatibility/bc_3.yaml";
        private const string OpenAPIDoc4 = "backwardCompatibility/bc_4.yaml";
        private const string OpenAPIDoc5 = "backwardCompatibility/bc_5.yaml";

        [Fact]
        public void TestNoChange()
        {
            TestUtils.AssertOpenAPIBackwardCompatible(OpenAPIDoc1, OpenAPIDoc1, false);
        }

        [Fact]
        public void TestAPIAdded()
        {
            TestUtils.AssertOpenAPIBackwardCompatible(OpenAPIDoc1, OpenAPIDoc2, true);
        }

        [Fact]
        public void TestAPIMissing()
        {
            TestUtils.AssertOpenAPIBackwardIncompatible(OpenAPIDoc2, OpenAPIDoc1);
        }

        [Fact]
        public void TestAPIChangedOperationAdded()
        {
            TestUtils.AssertOpenAPIBackwardCompatible(OpenAPIDoc2, OpenAPIDoc3, true);
        }

        [Fact]
        public void TestAPIChangedOperationMissing()
        {
            TestUtils.AssertOpenAPIBackwardIncompatible(OpenAPIDoc3, OpenAPIDoc2);
        }

        [Fact]
        public void TestAPIOperationChanged()
        {
            TestUtils.AssertOpenAPIBackwardCompatible(OpenAPIDoc2, OpenAPIDoc4, true);
        }

        [Fact]
        public void TestAPIReadWriteOnlyPropertiesChanged()
        {
            TestUtils.AssertOpenAPIBackwardCompatible(OpenAPIDoc1, OpenAPIDoc5, true);
        }
    }
}