using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Common.EntitySql;
using System.Linq;
using System.Web;
using System.Xml;
using WebShop2.App_Start.HelpClasses;
using WebShop2.Models.Payex;
using WebShop2.Payex;

namespace WebShop2.DAL
{
    public class PayexProvider
    {
        private PxOrderSoapClient payexClient = new PxOrderSoapClient("PxOrderSoap");
        private ParseResult parser = new ParseResult();

        public InitalizeResponse Initialize8(Initialize initialize)
        {
            var response = payexClient.Initialize8(
                initialize.AccountNumber,
                initialize.PurchaseOperation,
                initialize.Price,
                initialize.PriceArgList,
                initialize.Currency,
                initialize.Vat,
                initialize.OrderId,
                initialize.ProductNumber,
                initialize.Description,
                initialize.ClientIPAddress,
                initialize.ClientIdentifier,
                initialize.AdditionalValues,
                initialize.ExternalID,
                initialize.ReturnUrl,
                initialize.View,
                initialize.AgreementRef,
                initialize.CancelUrl,
                initialize.ClientLanguage,
                initialize.Hash
        );

            var initResponse = new InitalizeResponse();

            initResponse.ErrorCode = parser.ParseRes(response, "/payex/status/errorCode");
            initResponse.Description = parser.ParseRes(response, "/payex/status/description");
            initResponse.OrderRef = parser.ParseRes(response, "/payex/orderRef");
            initResponse.RedirectURL = parser.ParseRes(response, "/payex/redirectUrl");

            return initResponse;
        }

        public PayexCompleteResponse Complete(string orderRef)
        {
            PayexComplete payexComplete = new PayexComplete()
            {
                OrderRef = orderRef,
                AccountNumber = Convert.ToInt64(ConfigurationManager.AppSettings["PayexAccountNumber"]),
               
            };

            var key = ConfigurationManager.AppSettings["PayexEncryptionKey"];
            CreateMD5Hash MD5hash = new CreateMD5Hash(payexComplete.AccountNumber + payexComplete.OrderRef + key);
            payexComplete.Hash = MD5hash.getHash();

            var response = payexClient.Complete(payexComplete.AccountNumber, payexComplete.OrderRef, payexComplete.Hash);

            var completeResponse = new PayexCompleteResponse();
            try
            {
                completeResponse.ErrorCode = parser.ParseRes(response, "/payex/status/errorCode");
                completeResponse.Description = parser.ParseRes(response, "/payex/status/description");
                completeResponse.TransactionStatus = parser.ParseRes(response, "/payex/transactionStatus");
                completeResponse.TransactionNumber = parser.ParseRes(response, "/payex/transactionNumber");
                completeResponse.TransactionRef = parser.ParseRes(response, "/payex/transactionRef");
                completeResponse.OrderID = parser.ParseRes(response, "/payex/orderId");
            }
            catch
            {
                completeResponse.ErrorCode = parser.ParseRes(response, "/payex/status/errorCode");
                completeResponse.Description = parser.ParseRes(response, "/payex/status/description"); 
            }

            return completeResponse;

        }
    }

    public class ParseResult
    {
        //Retrieve specific XML node from XML tree
        public string ParseRes(string xmlText, string node)
        {
            string nodeRes = "";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlText);
            XmlNode myNode = doc.SelectSingleNode(node);
            nodeRes = myNode.InnerText.ToString();
            return nodeRes;
        }
    }
}