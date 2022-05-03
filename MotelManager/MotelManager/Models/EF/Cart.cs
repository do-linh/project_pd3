using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotelManager.Models.EF
{
    public class Cart
    {
        DBContext db = new DBContext();

        public int imotel { get; set; }
        public string nameMotel { get; set; }
        public double dprice { get; set; }
        public int quantity { get; set; }
        public double money
        {
            get { return quantity * dprice; }
        }
        public Cart(int motel_id)
        {
            imotel = motel_id;
            Motel mt = db.Motels.Single(n => n.motel_id == imotel);
            nameMotel = mt.address;
            dprice = double.Parse(mt.price.ToString());
            quantity = 1;
        }
    }
}