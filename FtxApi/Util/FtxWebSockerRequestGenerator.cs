﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace FtxApi
{
    public static class FtxWebSockerRequestGenerator
    {
        public static string GetAuthRequest(Client client)
        {
            var time = Util.Util.GetMillisecondsFromEpochStart();
            var sig = GenerateSignature(client, time);
            var s = "{" +
                    "\"args\": {" +
                    $"\"key\": \"{client.ApiKey}\"," +
                    $"\"sign\": \"{sig}\"," +
                    $"\"time\": {time}" +
                    "}," +
                    "\"op\": \"login\"}";
            return s;
        }

        private static string GenerateSignature(Client client, long time)
        {
            var _hashMaker = new HMACSHA256(Encoding.UTF8.GetBytes(client.ApiSecret));
            var signature = $"{time}websocket_login";
            var hash = _hashMaker.ComputeHash(Encoding.UTF8.GetBytes(signature));
            var hashStringBase64 = BitConverter.ToString(hash).Replace("-", string.Empty);
            return hashStringBase64.ToLower();
        }

        public static string GetSubscribeRequest(string channel)
        {
            return $"{{\"op\": \"subscribe\", \"channel\": \"{channel}\"}}";
        }

        public static string GetUnsubscribeRequest(string channel)
        {
            return $"{{\"op\": \"unsubscribe\", \"channel\": \"{channel}\"}}";
        }

        public static string GetSubscribeRequest(string channel, string instrument)
        {
            return $"{{\"op\": \"subscribe\", \"channel\": \"{channel}\", \"Market\": \"{instrument}\"}}";
        }

        public static string GetUnsubscribeRequest(string channel, string instrument)
        {
            return $"{{\"op\": \"unsubscribe\", \"channel\": \"{channel}\", \"Market\": \"{instrument}\"}}";
        }
    }
}