using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Dionysus.Models
{
    [DataContract]
    public class Offer
    {

        [DataMember(Name = "auctionItemID")]
        public int ID { get; set; }

        [Display(Name = "Buyer Name")]
        [DataMember(Name = "buyerName")]
        public string BuyerName { get; set; }

        [Display(Name = "Offer Amount")]
        [DataMember(Name = "offerAmount")]
        public decimal OfferAmount { get; set; }

        [DataMember(Name = "offerTime")]
        public DateTime OfferTime { get; set; }
    }
}
