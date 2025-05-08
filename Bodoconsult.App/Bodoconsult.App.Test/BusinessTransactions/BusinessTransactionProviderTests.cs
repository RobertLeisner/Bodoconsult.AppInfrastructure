// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.Test.SampleBusinessLogic;
using Bodoconsult.App.Test.TestData;

namespace Bodoconsult.App.Test.BusinessTransactions;

[TestFixture]
internal class BusinessTransactionProviderTests
{

    /// <summary>
    /// Helper method to set up provider. May require mocking of dependencies
    /// </summary>
    /// <returns></returns>
    private static TestBusinessTransactionProvider CreateProvider()
    {
        var dependency = new SampleBusinessLogicLayer();
        var prov = new TestBusinessTransactionProvider(dependency);
        return prov;
    }

    [Test]
    public void CheckAll_ValidSetup_Success()
    {
        // Arrange 
        var prov = CreateProvider();

        // Act  
        foreach (var item in prov.CreateBusinessTransactionDelegates)
        {

            var transaction = item.Value.Invoke();

            Assert.That(item.Key, Is.EqualTo(transaction.Id));

        }
    }

    [Test]
    public void CreateBusinessTransactionDelegates_DefaultSetup_ReturnsTransaction()
    {
        // Arrange 
        const int tnr = 1000;

        var prov = CreateProvider();

        // Act  
        prov.CreateBusinessTransactionDelegates.TryGetValue(tnr, out var test);
        prov = null; // Kill the provider to see if the static delegate method is called correctly

        // Assert
        Assert.That(test, Is.Not.Null);

        var result = test.Invoke();

        Assert.That(result, Is.Not.Null);

    }

    [Test]
    public void Ctor_ValidSetup_Success()
    {
        // Arrange
        var dependency = new SampleBusinessLogicLayer();
        // Act
        var prov = new TestBusinessTransactionProvider(dependency);

        // Assert
        Assert.That(prov.SampleBusinessLogic, Is.Not.Null);
        Assert.That(prov.SampleBusinessLogic, Is.SameAs(dependency));
    }

    [Test]
    public void Transaction1000_TestTransaction_ValidSetup_Success()
    {
        // Arrange 
        var prov = CreateProvider();

        // Act  
        var result = prov.CreateTnr1000();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(1000));
        Assert.That(result.RunBusinessTransactionDelegate, Is.Not.Null);
        Assert.That(result.AllowedRequestDataTypes.Count, Is.Not.EqualTo(0));
    }
}