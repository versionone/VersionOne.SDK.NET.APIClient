using System;
using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests
{
    [TestFixture]
    public class AssetStatemanagerTester
    {
        [Test]
        public void GetAssetStateFromStringTest()
        {
            
            var state = AssetStateManager.GetAssetStateFromString("64");
            Assert.AreEqual(AssetStateManager.AssetState.Active, state);

            state = AssetStateManager.GetAssetStateFromString("0");
            Assert.AreEqual(AssetStateManager.AssetState.Future, state);

            state = AssetStateManager.GetAssetStateFromString("128");
            Assert.AreEqual(AssetStateManager.AssetState.Closed, state);

            state = AssetStateManager.GetAssetStateFromString("192");
            Assert.AreEqual(AssetStateManager.AssetState.Dead, state);

            state = AssetStateManager.GetAssetStateFromString("255");
            Assert.AreEqual(AssetStateManager.AssetState.Deleted, state);

        }

        [Test, ExpectedException(typeof (ArgumentNullException))]
        public void NullArgumentTest()
        {
            var state = AssetStateManager.GetAssetStateFromString(null);
        }

        [Test, ExpectedException(typeof(ArgumentNullException))]
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