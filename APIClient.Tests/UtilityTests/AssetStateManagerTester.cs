using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests
{
    [TestClass]
    public class AssetStateManagerTester
    {
        [TestMethod]
        public void GetAssetStateFromStringTest()
        {

            var state = AssetStateManager.GetAssetStateFromString("64");
            Assert.AreEqual(AssetState.Active, state);

            state = AssetStateManager.GetAssetStateFromString("0");
            Assert.AreEqual(AssetState.Future, state);

            state = AssetStateManager.GetAssetStateFromString("128");
            Assert.AreEqual(AssetState.Closed, state);

            state = AssetStateManager.GetAssetStateFromString("192");
            Assert.AreEqual(AssetState.Dead, state);

            state = AssetStateManager.GetAssetStateFromString("255");
            Assert.AreEqual(AssetState.Deleted, state);

        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void NullArgumentTest()
        {
            var state = AssetStateManager.GetAssetStateFromString(null);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void EmptyStringTest()
        {
            AssetStateManager.GetAssetStateFromString(string.Empty);
        }

        public void NonExistantEnumValueTest()
        {
            var state = AssetStateManager.GetAssetStateFromString("1");
            Assert.AreEqual(1, state);
        }
    }
}
