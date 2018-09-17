using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmilLynge.KlarupSportsBooking.DAL.EF;

namespace EmilLynge.KlarupSportsBooking.Business
{
    public class ActitiviesHandler : DBHandler
    {
        public Activity GetActivity(int id)
        {
            return Model.Activities.Find(id);
        }
        public List<Activity> GetAllActivities()
        {
            return Model.Activities.ToList();
        }

        public bool AddActivity(Activity activity)
        {
            Model.Activities.Add(activity);
            return SaveChangesToDB();
        }
        public bool RemoveActivity(int id)
        {
            Model.Activities.Remove(Model.Activities.Find(id));
            return SaveChangesToDB();
        }
        public bool UpdateActivity(int id, Activity activity)
        {
            var acti = Model.Activities.Find(id);
            acti.Name = activity.Name;
            acti.SectionsRequired = activity.SectionsRequired;
            return SaveChangesToDB();
        }
    }
}
