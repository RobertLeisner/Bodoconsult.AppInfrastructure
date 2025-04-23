using NUnit.Framework;

namespace Bodoconsult.I18N.Test;

[TestFixture]
public abstract class BaseTest
{
    [SetUp]
    public void Init()
    {
        I18N.Current = new I18N();
    }


    [TearDown]
    public void Finish() =>
        I18N.Current?.Dispose();
}