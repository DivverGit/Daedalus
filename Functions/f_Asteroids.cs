using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Functions
{
    public static class f_Asteroids
    {
        // Variables
        public static List<Entity> AsteroidBelts = new List<Entity>();
        public static List<Entity> Asteroids = new List<Entity>();

        private static List<Entity> ProcessedAsteroidEntities = new List<Entity>();
        private static List<int> ProcessedAsteroidClusterSizes = new List<int>();

        static f_Asteroids()
        {
            // Init
        }

        public static void PopulateAsteroidBeltsList()
        {
            List<Entity> EntityQuery = f_Entities.GetAsteroidBelts();
            AsteroidBelts = new List<Entity>();
            foreach (Entity e in EntityQuery)
            {
                AsteroidBelts.Add(e);
            }
        }

        public static void RemoveAsteroidBelt(Entity e)
        {
            AsteroidBelts.Remove(e);
        }

        public static void PopulateAsteroidsList()
        {
            Asteroids = f_Entities.GetAsteroids();
        }

        public static void BestAsteroidCluster (double ClusterRadius)
        {
            DateTime StartTime = DateTime.Now;
            List<Entity> AsteroidsToProcess = new List<Entity>();

            AsteroidsToProcess = Asteroids;

            ProcessedAsteroidEntities = new List<Entity>();
            ProcessedAsteroidClusterSizes = new List<int>();

            int TotalProcessIndexes = (AsteroidsToProcess.Count - 1);
            foreach(Entity Asteroid in AsteroidsToProcess)
            {
                int ClusterSize = 0;
                int i;
                for(i = 0; i < TotalProcessIndexes; i++)
                {
                    if(AsteroidsToProcess[i] != Asteroid)
                    {
                        double DistanceBetween = f_Entities.DistanceBetween(Asteroid, AsteroidsToProcess[i]);
                        /* If "AsteroidToCompare" is in our range then increment "AsteroidsInRange" */
                        if (DistanceBetween < ClusterRadius) ClusterSize++;
                    }
                }
                ProcessedAsteroidEntities.Add(Asteroid);
                ProcessedAsteroidClusterSizes.Add(ClusterSize);
            }

            int IndexToReturn = 0;
            int HighestClusterSize = 0;
            int TotalClusterIndexes = (ProcessedAsteroidClusterSizes.Count - 1);

            int i2;
            for (i2 = 0; i2 < TotalClusterIndexes; i2++)
            {
                if (ProcessedAsteroidClusterSizes[i2] > HighestClusterSize)
                {
                    IndexToReturn = i2;
                    HighestClusterSize = ProcessedAsteroidClusterSizes[i2];
                }
            }
            ProcessedAsteroidEntities[IndexToReturn].Approach(500);
        }
    }
}
