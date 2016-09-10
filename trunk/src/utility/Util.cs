//  Copyright 2007-2016 Portland State University
//  Author: Robert Scheller

using Landis.Core;
using Landis.SpatialModeling;
using Landis.Library.LeafBiomassCohorts;
using Edu.Wisc.Forest.Flel.Util;
using System.IO;

namespace Landis.Extension.Succession.Century
{
    /// <summary>
    /// Utility methods.
    /// </summary>
    public static class Util
    {

        /// <summary>
        /// Converts a table indexed by species and ecoregion into a
        /// 2-dimensional array.
        /// </summary>
        public static T[,] ToArray<T>(Species.AuxParm<Ecoregions.AuxParm<T>> table)
        {
            T[,] array = new T[PlugIn.ModelCore.Ecoregions.Count, PlugIn.ModelCore.Species.Count];
            foreach (ISpecies species in PlugIn.ModelCore.Species) {
                foreach (IEcoregion ecoregion in PlugIn.ModelCore.Ecoregions) {
                    array[ecoregion.Index, species.Index] = table[species][ecoregion];
                }
            }
            return array;
        }
        //---------------------------------------------------------------------

        public static void ReadSoilDepthMap(string path)
        {
            IInputRaster<DoublePixel> map;

            try
            {
                map = PlugIn.ModelCore.OpenRaster<DoublePixel>(path);
            }
            catch (FileNotFoundException)
            {
                string mesg = string.Format("Error: The file {0} does not exist", path);
                throw new System.ApplicationException(mesg);
            }

            if (map.Dimensions != PlugIn.ModelCore.Landscape.Dimensions)
            {
                string mesg = string.Format("Error: The input map {0} does not have the same dimension (row, column) as the ecoregions map", path);
                throw new System.ApplicationException(mesg);
            }

            using (map)
            {
                DoublePixel pixel = map.BufferPixel;
                foreach (Site site in PlugIn.ModelCore.Landscape.AllSites)
                {
                    map.ReadBufferPixel();
                    int mapValue = (int) pixel.MapCode.Value;
                    if (site.IsActive)
                    {
                            if (mapValue < 1 || mapValue > 200)
                                throw new InputValueException(mapValue.ToString(),
                                                              "{0} is not between {1:0.0} and {2:0.0}",
                                                              mapValue, 1, 200);
                        SiteVars.SoilDepth[site] = mapValue;
                    }
                }
            }
        }
        //---------------------------------------------------------------------

        public static void ReadSoilDrainMap(string path)
        {
            IInputRaster<DoublePixel> map;

            try
            {
                map = PlugIn.ModelCore.OpenRaster<DoublePixel>(path);
            }
            catch (FileNotFoundException)
            {
                string mesg = string.Format("Error: The file {0} does not exist", path);
                throw new System.ApplicationException(mesg);
            }

            if (map.Dimensions != PlugIn.ModelCore.Landscape.Dimensions)
            {
                string mesg = string.Format("Error: The input map {0} does not have the same dimension (row, column) as the ecoregions map", path);
                throw new System.ApplicationException(mesg);
            }

            using (map)
            {
                DoublePixel pixel = map.BufferPixel;
                foreach (Site site in PlugIn.ModelCore.Landscape.AllSites)
                {
                    map.ReadBufferPixel();
                    double mapValue = pixel.MapCode.Value;
                    if (site.IsActive)
                    {
                        if (mapValue < 0.0 || mapValue > 1.0)
                            throw new InputValueException(mapValue.ToString(),
                                                          "{0} is not between {1:0.0} and {2:0.0}",
                                                          mapValue, 0.0, 1.0);
                        SiteVars.SoilDrain[site] = mapValue;
                    }
                }
            }
        }
        //---------------------------------------------------------------------

        public static void ReadSoilBaseFlowMap(string path)
        {
            IInputRaster<DoublePixel> map;

            try
            {
                map = PlugIn.ModelCore.OpenRaster<DoublePixel>(path);
            }
            catch (FileNotFoundException)
            {
                string mesg = string.Format("Error: The file {0} does not exist", path);
                throw new System.ApplicationException(mesg);
            }

            if (map.Dimensions != PlugIn.ModelCore.Landscape.Dimensions)
            {
                string mesg = string.Format("Error: The input map {0} does not have the same dimension (row, column) as the ecoregions map", path);
                throw new System.ApplicationException(mesg);
            }

            using (map)
            {
                DoublePixel pixel = map.BufferPixel;
                foreach (Site site in PlugIn.ModelCore.Landscape.AllSites)
                {
                    map.ReadBufferPixel();
                    double mapValue = pixel.MapCode.Value;
                    if (site.IsActive)
                    {
                        if (mapValue < 0.0 || mapValue > 1.0)
                            throw new InputValueException(mapValue.ToString(),
                                                          "{0} is not between {1:0.0} and {2:0.0}",
                                                          mapValue, 0.0, 1.0);
                        SiteVars.SoilBaseFlowFraction[site] = mapValue;
                    }
                }
            }
        }
        //---------------------------------------------------------------------

        public static void ReadSoilStormFlowMap(string path)
        {
            IInputRaster<DoublePixel> map;

            try
            {
                map = PlugIn.ModelCore.OpenRaster<DoublePixel>(path);
            }
            catch (FileNotFoundException)
            {
                string mesg = string.Format("Error: The file {0} does not exist", path);
                throw new System.ApplicationException(mesg);
            }

            if (map.Dimensions != PlugIn.ModelCore.Landscape.Dimensions)
            {
                string mesg = string.Format("Error: The input map {0} does not have the same dimension (row, column) as the ecoregions map", path);
                throw new System.ApplicationException(mesg);
            }

            using (map)
            {
                DoublePixel pixel = map.BufferPixel;
                foreach (Site site in PlugIn.ModelCore.Landscape.AllSites)
                {
                    map.ReadBufferPixel();
                    double mapValue = pixel.MapCode.Value;
                    if (site.IsActive)
                    {
                        if (mapValue < 0.0 || mapValue > 1.0)
                            throw new InputValueException(mapValue.ToString(),
                                                          "{0} is not between {1:0.0} and {2:0.0}",
                                                          mapValue, 0.0, 1.0);
                        SiteVars.SoilStormFlowFraction[site] = mapValue;
                    }
                }
            }
        }
        //---------------------------------------------------------------------

        public static void ReadFieldCapacityMap(string path)
        {
            IInputRaster<DoublePixel> map;

            try
            {
                map = PlugIn.ModelCore.OpenRaster<DoublePixel>(path);
            }
            catch (FileNotFoundException)
            {
                string mesg = string.Format("Error: The file {0} does not exist", path);
                throw new System.ApplicationException(mesg);
            }

            if (map.Dimensions != PlugIn.ModelCore.Landscape.Dimensions)
            {
                string mesg = string.Format("Error: The input map {0} does not have the same dimension (row, column) as the ecoregions map", path);
                throw new System.ApplicationException(mesg);
            }

            using (map)
            {
                DoublePixel pixel = map.BufferPixel;
                foreach (Site site in PlugIn.ModelCore.Landscape.AllSites)
                {
                    map.ReadBufferPixel();
                    double mapValue = pixel.MapCode.Value;
                    if (site.IsActive)
                    {
                        if (mapValue < 0.0 || mapValue > 0.5)
                            throw new InputValueException(mapValue.ToString(),
                                                          "{0} is not between {1:0.0} and {2:0.0}",
                                                          mapValue, 0.0, 0.5);
                        SiteVars.SoilFieldCapacity[site] = mapValue;
                    }
                }
            }
        }
        //---------------------------------------------------------------------

        public static void ReadWiltingPointMap(string path)
        {
            IInputRaster<DoublePixel> map;

            try
            {
                map = PlugIn.ModelCore.OpenRaster<DoublePixel>(path);
            }
            catch (FileNotFoundException)
            {
                string mesg = string.Format("Error: The file {0} does not exist", path);
                throw new System.ApplicationException(mesg);
            }

            if (map.Dimensions != PlugIn.ModelCore.Landscape.Dimensions)
            {
                string mesg = string.Format("Error: The input map {0} does not have the same dimension (row, column) as the ecoregions map", path);
                throw new System.ApplicationException(mesg);
            }

            using (map)
            {
                DoublePixel pixel = map.BufferPixel;
                foreach (Site site in PlugIn.ModelCore.Landscape.AllSites)
                {
                    map.ReadBufferPixel();
                    double mapValue = pixel.MapCode.Value;
                    if (site.IsActive)
                    {
                        if (mapValue < 0.0 || mapValue > 1.0)
                            throw new InputValueException(mapValue.ToString(),
                                                          "{0} is not between {1:0.0} and {2:0.0}",
                                                          mapValue, 0.0, 1.0);
                        if (mapValue > SiteVars.SoilFieldCapacity[site])
                            throw new InputValueException(mapValue.ToString(),
                                                          "{0} is greater than field capacity {1:0.0} at this site",
                                                          mapValue, SiteVars.SoilFieldCapacity[site]);
                        SiteVars.SoilWiltingPoint[site] = mapValue;
                    }
                }
            }
        }
        //---------------------------------------------------------------------

        public static void ReadPercentSandMap(string path)
        {
            IInputRaster<DoublePixel> map;

            try
            {
                map = PlugIn.ModelCore.OpenRaster<DoublePixel>(path);
            }
            catch (FileNotFoundException)
            {
                string mesg = string.Format("Error: The file {0} does not exist", path);
                throw new System.ApplicationException(mesg);
            }

            if (map.Dimensions != PlugIn.ModelCore.Landscape.Dimensions)
            {
                string mesg = string.Format("Error: The input map {0} does not have the same dimension (row, column) as the ecoregions map", path);
                throw new System.ApplicationException(mesg);
            }

            using (map)
            {
                DoublePixel pixel = map.BufferPixel;
                foreach (Site site in PlugIn.ModelCore.Landscape.AllSites)
                {
                    map.ReadBufferPixel();
                    double mapValue = pixel.MapCode.Value;
                    if (site.IsActive)
                    {
                        if (mapValue < 0.0 || mapValue > 1.0)
                            throw new InputValueException(mapValue.ToString(),
                                                          "{0} is not between {1:0.0} and {2:0.0}",
                                                          mapValue, 0.0, 1.0);
                        SiteVars.SoilPercentSand[site] = mapValue;
                    }
                }
            }
            //foreach (Site site in PlugIn.ModelCore.Landscape.AllSites)
            //{
            //    SiteVars.SoilPercentSand[site] = 0.591;
            //}
        }
        //---------------------------------------------------------------------

        public static void ReadPercentClayMap(string path)
        {
            foreach (Site site in PlugIn.ModelCore.Landscape.AllSites)
            {
                SiteVars.SoilPercentClay[site] = 0.069;
            }
        }
        //---------------------------------------------------------------------
    }
}
