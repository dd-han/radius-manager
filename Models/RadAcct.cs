using System;
using System.Collections.Generic;

namespace RadiusManager.Models
{
    public partial class RadAcct
    {
        public long RadAcctId { get; set; }
        public string AcctSessionId { get; set; }
        public string AcctUniqueId { get; set; }
        public string Username { get; set; }
        public string GroupName { get; set; }
        public string Realm { get; set; }
        public string NasIpAddress { get; set; }
        public string NasPortId { get; set; }
        public string NasPortType { get; set; }
        public DateTime? AcctStartTime { get; set; }
        public DateTime? AcctUpdateTime { get; set; }
        public DateTime? AcctStopTime { get; set; }
        public int? AcctInterval { get; set; }
        public uint? AcctSessionTime { get; set; }
        public string AcctAuthentic { get; set; }
        public string ConnectInfoStart { get; set; }
        public string ConnectInfoStop { get; set; }
        public long? AcctInputOctets { get; set; }
        public long? AcctOutputOctets { get; set; }
        public string CalledStationId { get; set; }
        public string CallingStationId { get; set; }
        public string AcctTerminateCause { get; set; }
        public string ServiceType { get; set; }
        public string FramedProtocol { get; set; }
        public string FramedIpAddress { get; set; }
    }
}
