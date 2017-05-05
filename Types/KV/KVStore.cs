﻿namespace Consul.Net.Types.KV
{
    public class KVStore
    {
        public string Key { get; set; }

        public ulong CreateIndex { get; set; }
        public ulong ModifyIndex { get; set; }
        public ulong LockIndex { get; set; }
        public ulong Flags { get; set; }

        public byte[] Value { get; set; }
        public string Session { get; set; }

        public KVStore(string key)
        {
            Key = key;
        }
    }
}