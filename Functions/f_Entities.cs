using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Functions
{
    public static class f_Entities
    {
        static f_Entities()
        {
            // Init
        }

        public static string GetEntityMode(Entity e)
        {
            int Mode = e.Mode;
            if (Mode == 0) /* Aligned */
            {
                return "Aligned";
            }
            else if (Mode == 1) /* Approaching */
            {
                return "Approaching";
            }
            else if(Mode == 2) /* Stopped */
            {
                return "Stopped";
            }
            else if(Mode == 3) /* Warping (In Warp) */
            {
                return "Warping";
            }
            else if(Mode == 4) /* Orbiting */
            {
                return "Orbiting";
            }
            else
            {
                return "NULL";
            }
        }

        public static List<Entity> GetStations()
        {
            return Daedalus.Eve.QueryEntities("GroupID = 15");
        }

        public static List<Entity> GetAsteroidBelts()
        {
            return Daedalus.Eve.QueryEntities("GroupID = 9");
        }

        public static List<Entity> GetAsteroids()
        {
            List<Entity> Asteroids = new List<Entity>();
            List<Entity> Entities = Daedalus.Eve.QueryEntities("CategoryID = 25");
            foreach (Entity e in Entities)
            {
                Asteroids.Add(e);
            }
            return Asteroids;
        }

        public static double DistanceFromPlayerToEntity(Entity e)
        {
            return Daedalus.Eve.DistanceBetween(Daedalus.Me.ToEntity.ID, e.ID);
        }

        public static double DistanceBetween(Entity e1, Entity e2)
        {
            return Daedalus.Eve.DistanceBetween(e1.ID, e2.ID);
        }
    }
}
