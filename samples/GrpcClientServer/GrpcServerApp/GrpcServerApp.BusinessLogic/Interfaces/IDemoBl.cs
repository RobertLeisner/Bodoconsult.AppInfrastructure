// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.BusinessTransactions.Replies;
using Bodoconsult.App.Interfaces;

namespace GrpcServerApp.BusinessLogic.Interfaces;

public interface IDemoBl
{
    DefaultBusinessTransactionReply DoSomething(IBusinessTransactionRequestData request);

    ObjectIdBusinessTransactionReply DoSomethingElse(IBusinessTransactionRequestData request);
}