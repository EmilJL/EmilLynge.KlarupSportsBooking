using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmilLynge.KlarupSportsBooking.DAL.EF;

namespace EmilLynge.KlarupSportsBooking.Business
{
    public class SectionsHandler : DBHandler
    {
        public Section GetSection(int id)
        {
            return Model.Sections.Find(id);
        }
        public List<Section> GetAllSections()
        {
            return Model.Sections.ToList();
        }
        public bool AddSection(Section section)
        {
            Model.Sections.Add(section);
            return SaveChangesToDB();
        }
        public bool RemoveSection(int id)
        {
            Model.Sections.Remove(Model.Sections.Find(id));
            return SaveChangesToDB();
        }
    }
}
