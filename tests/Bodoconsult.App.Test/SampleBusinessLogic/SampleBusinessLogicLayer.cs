﻿// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using Bodoconsult.App.BusinessTransactions.Replies;
using Bodoconsult.App.Interfaces;

namespace Bodoconsult.App.Test.SampleBusinessLogic;

internal class SampleBusinessLogicLayer
{

    public IBusinessTransactionReply EmptyRequest(IBusinessTransactionRequestData requestData)
    {

        return new DefaultBusinessTransactionReply
        {
            ErrorCode = 0,
            Message = "Testmessage on success"
        };
    }



}