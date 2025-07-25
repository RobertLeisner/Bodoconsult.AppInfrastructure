using Bodoconsult.App.Interfaces;
using Bodoconsult.App.Test.SampleBusinessLogic;

namespace Bodoconsult.App.Test.TestData;

internal class TestBusinessTransactionLoader: IBusinessTransactionLoader
{
    /// <summary>
    /// Default ctor
    /// </summary>
    public TestBusinessTransactionLoader(IBusinessTransactionManager businessTransactionManager, SampleBusinessLogicLayer sampleBusinessLogicLayer)
    {
        BusinessTransactionManager = businessTransactionManager;
        SampleBusinessLogic = sampleBusinessLogicLayer;
    }

    /// <summary>
    /// Current <see cref="IBusinessTransactionManager"/> impl to load the providers in
    /// </summary>
    public IBusinessTransactionManager BusinessTransactionManager { get; }

    /// <summary>
    /// Business logic dependency
    /// </summary>
    public SampleBusinessLogicLayer SampleBusinessLogic { get; }

    /// <summary>
    /// Load the providers
    /// </summary>
    public void LoadProviders()
    {
        var provider = new TestBusinessTransactionProvider(SampleBusinessLogic);
        BusinessTransactionManager.AddProvider(provider);

        // Add more providers
    }
}