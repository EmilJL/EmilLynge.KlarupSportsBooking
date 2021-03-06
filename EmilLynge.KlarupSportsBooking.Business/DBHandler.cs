﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmilLynge.KlarupSportsBooking.DAL.EF;

namespace EmilLynge.KlarupSportsBooking.Business
{
    public class DBHandler
    {
        private KlarupSportsBookingModel model = new KlarupSportsBookingModel();

        protected KlarupSportsBookingModel Model
        {
            get { return model; }
            set { model = value; }
        }

        protected bool SaveChangesToDB()
        {
            int i = model.SaveChanges();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
