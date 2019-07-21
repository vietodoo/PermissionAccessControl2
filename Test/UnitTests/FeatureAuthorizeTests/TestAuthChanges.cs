﻿// Copyright (c) 2019 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT license. See License.txt in the project root for license information.

using CommonCache;
using Test.EfHelpers;
using Test.FakesAndMocks;
using Xunit;
using Xunit.Extensions.AssertExtensions;

namespace Test.UnitTests.FeatureAuthorizeTests
{
    public class TestAuthChanges
    {

        [Theory]
        [InlineData("test", "123", true)]
        [InlineData("test", "1234", false)]
        [InlineData("test", null, false)]
        public void TestIsLowerThan(string key, string ticksToTry, bool expectedResult )
        {
            //SETUP
            var fakeTimeStore = new FakeTimeStore();
            var cache = new AuthChanges(new FakeDistributedCache());
            cache.AddOrUpdate("test", 200, fakeTimeStore);

            //ATTEMPT
            var isHigher = cache.IsLowerThan(key, ticksToTry, fakeTimeStore);

            //VERIFY
            isHigher.ShouldEqual(expectedResult);
        }
    }
}