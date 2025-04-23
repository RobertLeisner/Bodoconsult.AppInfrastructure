// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Test.TestData;

namespace Bodoconsult.App.Test.BusinessTransactions;

[TestFixture]
internal class UnitTestTestTransactionProvider
{


    [Test]
    public void TestCreateBusinessTransactionDelegates()
    {
        // Arrange 
        const int tnr = 1000;

        var prov = new TestTransactionProvider();

        // Act  
        prov.CreateBusinessTransactionDelegates.TryGetValue(tnr, out var test);
        prov = null; // Kill the provider to see if the static delegate method is called correctly

        // Assert
        Assert.That(test, Is.Not.Null);

        var result = test?.Invoke();

        Assert.That(result, Is.Not.Null);

    }
        

}