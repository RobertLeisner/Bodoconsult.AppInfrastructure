// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.Text.Documents;
using Bodoconsult.Text.Test.Helpers;

namespace Bodoconsult.Text.Test.TestData;

/// <summary>
/// Test class for a real world report factory
/// </summary>
internal class RealWorldSampleReportFactory : DocumentFactoryBase
{
    /// <summary>
    /// Create the full report. Implement all logic needed to create the full report you want to get
    /// </summary>
    public override void CreateDocument()
    {
        TestDataHelper.CreateRealWorldReportContent(Document);
    }
}