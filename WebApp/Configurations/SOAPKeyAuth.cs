using Business.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace WebApp.Configurations
{
    public class SOAPKeyAuth : SoapHeader
    {
        public string Key { get; set; }

        public SOAPKeyAuth()
        {

        }

        public SOAPKeyAuth(string key)
        {
            Key = key;
        }
        
        public bool IsAuthorized()
        {
            if (string.IsNullOrWhiteSpace(Key))
                return false;

            string keyHeader = Useful.GetAppSettings("KeyHeader");
            if (keyHeader != Key)
                return false;

            string secretKey = Useful.GetAppSettings("SecretKey");
            string encryptKeyHeader = Useful.ConvertSHA256(keyHeader);

            return secretKey == encryptKeyHeader;
        }
    }
}