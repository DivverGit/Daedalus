using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Functions
{
    public static class f_Bookmarks
    {
        public static List<BookMark> safeSpots;
        public static void GetSafeSpots()
        {
            safeSpots = new List<BookMark>();
            List<BookMark> allBookmarks = Daedalus.eve.GetBookmarks();
            foreach(BookMark bookmark in allBookmarks)
            {
                if(bookmark.Label.ToLower().Contains("safe") && bookmark.SolarSystemID == Daedalus.me.SolarSystemID)
                {
                    safeSpots.Add(bookmark);
                }
            }
        }
    }
}
