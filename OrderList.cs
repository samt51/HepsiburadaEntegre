using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace EfasisCMS.entegrasyon.pazaryeri.Hepsiburada
{
    public class OrderList
    {
        public class TotalPrice
        {
            public string currency { get; set; }
            public double amount { get; set; }
        }

        public class UnitPrice
        {
            public string currency { get; set; }
            public double amount { get; set; }
        }

        public class HbDiscount
        {
            public TotalPrice totalPrice { get; set; }
            public UnitPrice unitPrice { get; set; }
        }

        public class ShippingAddress
        {
            public string addressId { get; set; }
            public string address { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string countryCode { get; set; }
            public string phoneNumber { get; set; }
            public string alternatePhoneNumber { get; set; }
            public string district { get; set; }
            public string city { get; set; }
            public string town { get; set; }
        }

        public class Address
        {
            public string addressId { get; set; }
            public string address { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string countryCode { get; set; }
            public string phoneNumber { get; set; }
            public string alternatePhoneNumber { get; set; }
            public string district { get; set; }
            public string city { get; set; }
            public string town { get; set; }
        }

        public class Invoice
        {
            public string turkishIdentityNumber { get; set; }
            public string taxNumber { get; set; }
            public string taxOffice { get; set; }
            public Address address { get; set; }
        }

        public class Commission
        {
            public string currency { get; set; }
            public int amount { get; set; }
        }

        public class CargoCompanyModel
        {
            public int id { get; set; }
            public string name { get; set; }
            public string shortName { get; set; }
            public string logoUrl { get; set; }
            public string trackingUrl { get; set; }
        }

        public class PurchasePrice
        {
            public string currency { get; set; }
            public int amount { get; set; }
        }

        public class DeliveryNote
        {
        }

        public class Item
        {
            public DateTime dueDate { get; set; }
            public DateTime lastStatusUpdateDate { get; set; }
            public string id { get; set; }
            public string sku { get; set; }
            public string orderId { get; set; }
            public string orderNumber { get; set; }
            public DateTime orderDate { get; set; }
            public int quantity { get; set; }
            public string merchantId { get; set; }
            public TotalPrice totalPrice { get; set; }
            public UnitPrice unitPrice { get; set; }
            public HbDiscount hbDiscount { get; set; }
            public int vat { get; set; }
            public int vatRate { get; set; }
            public string customerName { get; set; }
            public string customerId { get; set; }
            public string status { get; set; }
            public ShippingAddress shippingAddress { get; set; }
            public Invoice invoice { get; set; }
            public string sapNumber { get; set; }
            public int dispatchTime { get; set; }
            public Commission commission { get; set; }
            public int paymentTermInDays { get; set; }
            public int commissionType { get; set; }
            public CargoCompanyModel cargoCompanyModel { get; set; }
            public string cargoCompany { get; set; }
            public string customizedText01 { get; set; }
            public string customizedText02 { get; set; }
            public string customizedText03 { get; set; }
            public string customizedText04 { get; set; }
            public string customizedTextX { get; set; }
            public object creditCardHolderName { get; set; }
            public bool isCustomized { get; set; }
            public bool canCreatePackage { get; set; }
            public bool isCancellable { get; set; }
            public bool isCancellableByHbAdmin { get; set; }
            public string deliveryType { get; set; }
            public int deliveryOptionId { get; set; }
            public object slot { get; set; }
            public object pickUpTime { get; set; }
            public List<object> discountInfo { get; set; }
            public string merchantSKU { get; set; }
            public PurchasePrice purchasePrice { get; set; }
            public DeliveryNote deliveryNote { get; set; }
        }

        public class Root
        {
            public int totalCount { get; set; }
            public long limit { get; set; }
            public int offset { get; set; }
            public int pageCount { get; set; }
            public List<Item> items { get; set; }

            public Root roots()
            {
                string merchandid = "d9bd5627-23de-471e-b956-ae7f756d27d5";
                string loginname = "bebekmamadeposu_dev";
                string password = "Hb12345!";
                JavaScriptSerializer js = new JavaScriptSerializer();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.Expect100Continue = true;
                WebClient wc = new WebClient();
                wc.Encoding = Encoding.UTF8;
                string authKey = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("UTF-8").GetBytes(loginname + ":" + password));
                wc.Headers.Add("Authorization", "Basic"+" " + authKey);
                wc.Headers.Add("Accept", "application/json");
                var data = wc.DownloadString(
                    $"https://oms-external-sit.hepsiburada.com/orders/merchantid/{merchandid}");
                 
                Root root = js.Deserialize<Root>(data);

                return root;
            }
                 

           
        }
    }
}