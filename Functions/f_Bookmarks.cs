using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Functions
{
    public static class f_Bookmarks
    {
        public static List<BookMark> SafeSpots;

        public static void GetSafeSpots()
        {
            List<BookMark> SafeSpots = new List<BookMark>();
            List<BookMark> AllBookMarks = Daedalus.eve.GetBookmarks();
            foreach(BookMark Bkmk in AllBookMarks)
            {
                if(Bkmk.Label.ToLower().Contains("safe") && Bkmk.SolarSystemID == Daedalus.me.SolarSystemID)
                {
                    SafeSpots.Add(Bkmk);
                }
            }
        }
    }
}
