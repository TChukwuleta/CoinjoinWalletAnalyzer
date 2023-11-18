using Application.Common.Interfaces;
using Application.Common.Models;
using Core.Model;
using Microsoft.Extensions.Configuration;
using NBitcoin;
using NBitcoin.RPC;
using System.Net;

namespace Infrastructure.Services
{
    public class BitcoinService : IBitcoinService
    {
        private readonly IConfiguration _config;
        private readonly Network _network;
        private List<BitcoinAddress> addresses;
        public ApiRequestDto apiRequestDto { get; set; }
        private readonly string serverIp;
        private readonly string username;
        private readonly string password;
        public BitcoinService()
        {
            _network = Network.RegTest;
            serverIp = _config["Bitcoin:URL"];
            username = _config["Bitcoin:username"];
            password = _config["Bitcoin:password"];
        }
        public string GenerateNewAddress()
        {
            Key key = new Key();
            var address = key.PubKey.GetAddress(ScriptPubKeyType.Legacy, _network);
            addresses.Add(address);
            return address.ToString();
        }

        private async Task<RPCClient> CreateRpcClient(string walletname = null)
        {
            NetworkCredential credential = new NetworkCredential
            {
                UserName = username,
                Password = password
            };
            try
            {
                RPCClient rpc = default;
                if (string.IsNullOrEmpty(walletname))
                {
                    rpc = new RPCClient(credential, $"{serverIp}", _network);
                }
                else
                {
                    rpc = new RPCClient(credential, $"{serverIp}/wallet/{walletname}", _network);
                }
                return rpc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
