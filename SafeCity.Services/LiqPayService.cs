using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SafeCity.Services.DTOs;

namespace SafeCity.Services
{
    public class LiqPayService : ILiqPayService
    {
        private readonly string _publicKey;
        private readonly string _privateKey;
        private readonly JsonSerializerSettings _jsonSettings;

        public LiqPayService(string publicKey, string privateKey)
        {
            _publicKey = publicKey;
            _privateKey = privateKey;

            _jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
        }
        public DataSignatureResponse GenerateDataAndSignature(LiqPayRequest requestParams)
        {
            CheckCnbParams(requestParams);

            requestParams.PublicKey = _publicKey;

            var jsonString = SerializeToJson(requestParams);
            var data = jsonString.ToBase64String();
            var signature = CreateSignature(data);

            return new DataSignatureResponse()
            {
                Data = data,
                Signature = signature
            };
        }

        public string StrToSign(string str) => str.SHA1Hash().ToBase64String();

        public string CreateSignature(string base64EncodedData) => StrToSign(_privateKey + base64EncodedData + _privateKey);

        private string SerializeToJson(LiqPayRequest requestParams)
        {
            var json = JObject.FromObject(requestParams, new JsonSerializer { NullValueHandling = _jsonSettings.NullValueHandling });

            var jsonString = json.ToString();
            return jsonString;
        }

        public void CheckCnbParams(LiqPayRequest requestParams)
        {
            if (requestParams.Amount <= 0)
                throw new NullReferenceException("incorrect liqpay amount");

            if (string.IsNullOrEmpty(requestParams.Description))
                throw new NullReferenceException("liqpay description can't be null");
        }
    }

    public static class LiqPayUtil
    {
        public static string ToBase64String(this string text)
        {
            if (text == null)
            {
                return null;
            }

            byte[] textAsBytes = Encoding.UTF8.GetBytes(text);
            return ToBase64String(textAsBytes);
        }

        public static string ToBase64String(this byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        public static string DecodeBase64(this string encodedText)
        {
            if (encodedText == null)
            {
                return null;
            }

            byte[] textAsBytes = Convert.FromBase64String(encodedText);
            return Encoding.UTF8.GetString(textAsBytes);
        }

        public static byte[] SHA1Hash(this string stringToHash)
        {
            using var sha1 = new SHA1Managed();
            return sha1.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));
        }
    }
}
