using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Runtime.Serialization;

namespace Dionysus.Models
{
    [DataContract]
    public class AuctionItem
    {
        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "auctionEndTime")]        
        private string AuctionEndTimeJSON { get; set; }
        
        [IgnoreDataMember]
        [Display(Name = "Auction End Time")]
        public DateTime AuctionEndTime
        {
            get
            {
                if (AuctionEndTimeJSON != null)
                    return DateTime.Parse(AuctionEndTimeJSON, CultureInfo.InvariantCulture);
                else
                    return DateTime.Now;
            }
        }
    }
}
