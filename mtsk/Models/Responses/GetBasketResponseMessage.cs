using System;
using System.Collections.Generic;

namespace mtsk.Models.Responses
{
    public class GetBasketResponseMessage
    {
        public int success { get; set; }
        public Data data { get; set; }

        public class Data
        {
            public List<SiparisData> siparisData { get; set; }
            public List<AddressData> addressData { get; set; }
        }
        public class SiparisData
        {
            public int USERID { get; set; }
            public string NAME_ { get; set; }
            public string SURNAME { get; set; }
            public int ORDERPIECE { get; set; }
            public int ORDERPRICE { get; set; }
            public int ORDERCASE { get; set; }
        }

        public class AddressData
        {
            public int USERID { get; set; }
            public string NAME_ { get; set; }
            public string SURNAME { get; set; }
            public string OPENADDRESS { get; set; }
            public string CITY { get; set; }
            public string DISTRICT { get; set; }
        }
    }
    

    
}
