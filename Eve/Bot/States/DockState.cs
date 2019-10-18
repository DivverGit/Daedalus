using Daedalus.Eve.Cache;
using Daedalus.Eve.Wrappers;
using EVE.ISXEVE;
using LavishVMAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus.Eve.Bot.States
{
    class DockState : State
    {
        int StationID = -1;

        public override bool DoWork()
        {
            using (new FrameLock(true))
            {
                if (StationID == -1)
                {
                    // Dock at top station if avaliable
                    List<DEntity> entities = EveCache.Instance.EntityCache.AllEntities;

                    // Shouldn't use GetRaw, should expose the data through DEntity
                    DEntity station = entities.Where(e => e.CategoryType == CategoryType.Station).FirstOrDefault();

                    if (station != null)
                    {
                        station.GetRaw().WarpToAndDock();
                        return true;
                    }
                        
                    
                }
            }
            return false;
        }
    }
}
