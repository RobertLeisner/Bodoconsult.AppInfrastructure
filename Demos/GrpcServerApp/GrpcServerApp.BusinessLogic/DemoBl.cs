// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH.  All rights reserved.

using Bodoconsult.App.BusinessTransactions.Replies;
using Bodoconsult.App.Interfaces;

namespace GrpcServerApp.BusinessLogic
{
    public class DemoBl
    {

        public DefaultBusinessTransactionReply DoSomething(IBusinessTransactionRequestData data)
        {
            var reply = new DefaultBusinessTransactionReply();
            return reply;
        }


        public ObjectIdBusinessTransactionReply DoSomethingElse(IBusinessTransactionRequestData data)
        {
            var reply = new ObjectIdBusinessTransactionReply
            {
                ObjectId = 99
            };
            return reply;
        }

    }
}
