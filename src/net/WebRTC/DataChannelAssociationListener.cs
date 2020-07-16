﻿
using Microsoft.Extensions.Logging;
using SIPSorcery.Net.Sctp;
using SIPSorcery.Sys;

namespace SIPSorcery.Net
{
    public class DataChannelAssociationListener : AssociationListener
    {
        private static ILogger logger = Log.Logger;

        public void onAssociated(Association a)
        {
            logger.LogDebug($"Data Channel onAssociated.");
        }

        public void onDCEPStream(SCTPStream s, string label, int type)
        {
            logger.LogDebug($"Data Channel onDCEPStream.");
            string test = "Test message";
            //SCTPMessage m = s.getAssociation().makeMessage(test, (SIPSorcery.Net.small.BlockingSCTPStream)s);
            //SCTPMessage m = instanceLeft.makeMessage(test, (BlockingSCTPStream)s);
            s.send(test);

            s.setSCTPStreamListener(new DataChannelStreamListener());
        }

        public void onDisAssociated(Association a)
        {
            logger.LogDebug($"Data Channel onDisAssociated.");
        }

        public void onRawStream(SCTPStream s)
        {
            logger.LogDebug($"Data Channel onRawStream.");
        }
    }

    public class DataChannelStreamListener : SCTPStreamListener
    {
        private static ILogger logger = Log.Logger;

        public void close(SCTPStream aThis)
        {
            logger.LogDebug("Data channel stream closed.");
        }

        public void onMessage(SCTPStream s, string message)
        {
            logger.LogDebug($"Data channel stream message {message}.");
        }
    }
}
