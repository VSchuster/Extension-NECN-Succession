﻿using System;
using System.Collections.Generic;
using System.Linq;
//using System.Data;
using System.Text;
using Landis.Library.Metadata;
using Landis.Core;
using Edu.Wisc.Forest.Flel.Util;

namespace Landis.Extension.Succession.Century
{
    public class MetadataHandler
    {
        
        public static ExtensionMetadata Extension {get; set;}

        public static void InitializeMetadata(int timestep, ICore mCore, 
            string SoilCarbonMapNames, 
            string SoilNitrogenMapNames, 
            string ANPPMapNames, 
            string ANEEMapNames, 
            string TotalCMapNames)
        {
            ScenarioReplicationMetadata scenRep = new ScenarioReplicationMetadata() {
                RasterOutCellArea = PlugIn.ModelCore.CellArea,
                TimeMin = PlugIn.ModelCore.StartTime,
                TimeMax = PlugIn.ModelCore.EndTime,
            };

            Extension = new ExtensionMetadata(mCore){
                Name = "Century-Succession",
                TimeInterval = timestep, 
                ScenarioReplicationMetadata = scenRep
            };

            //---------------------------------------
            //          table outputs:   
            //---------------------------------------

            Outputs.primaryLog = new MetadataTable<PrimaryLog>("Century-succession-log.csv");
            Outputs.monthlyLog = new MetadataTable<MonthlyLog>("Century-succession-monthly-log.csv");

            OutputMetadata tblOut_monthly = new OutputMetadata()
            {
                Type = OutputType.Table,
                Name = "MonthlyLog",
                FilePath = Outputs.monthlyLog.FilePath,
                Visualize = true,
            };
            tblOut_monthly.RetriveFields(typeof(MonthlyLog));
            Extension.OutputMetadatas.Add(tblOut_monthly);

            OutputMetadata tblOut_primary = new OutputMetadata()
            {
                Type = OutputType.Table,
                Name = "PrimaryLog",
                FilePath = Outputs.primaryLog.FilePath,
                Visualize = true,
            };
            tblOut_primary.RetriveFields(typeof(PrimaryLog));
            Extension.OutputMetadatas.Add(tblOut_primary);

            //---------------------------------------            
            //          map outputs:         
            //---------------------------------------
            if (ANPPMapNames != null)
            {
                OutputMetadata mapOut_ANPP = new OutputMetadata()
                {
                    Type = OutputType.Map,
                    Name = "Aboveground Net Primary Production",
                    FilePath = @"century\AG_NPP-{timestep}.gis",  //century
                    Map_DataType = MapDataType.Continuous,
                    Map_Unit = FieldUnits.g_C_m2,
                    Visualize = true,
                };
                Extension.OutputMetadatas.Add(mapOut_ANPP);
            }

            if (ANEEMapNames != null)
            {
                OutputMetadata mapOut_Nee = new OutputMetadata()
                {
                    Type = OutputType.Map,
                    Name = "Net Ecosystem Exchange",
                    FilePath = @"century\NEE-{timestep}.gis",  //century
                    Map_DataType = MapDataType.Continuous,
                    Map_Unit = FieldUnits.g_C_m2,
                    Visualize = true,
                };
                Extension.OutputMetadatas.Add(mapOut_Nee);
            }
            if (SoilCarbonMapNames != null)
            {
                OutputMetadata mapOut_SOC = new OutputMetadata()
                {
                    Type = OutputType.Map,
                    Name = "Soil Organic Carbon",
                    FilePath = @"century\SOC-{timestep}.gis",  //century
                    Map_DataType = MapDataType.Continuous,
                    Map_Unit = FieldUnits.g_C_m2,
                    Visualize = true,
                };
                Extension.OutputMetadatas.Add(mapOut_SOC);
            }
            if (SoilNitrogenMapNames != null)
            {
                OutputMetadata mapOut_SON = new OutputMetadata()
                {
                    Type = OutputType.Map,
                    Name = "Soil Organic Nitrogen",
                    FilePath = @"century\SON-{timestep}.gis",  //century
                    Map_DataType = MapDataType.Continuous,
                    Map_Unit = FieldUnits.g_N_m2,
                    Visualize = true,
                };
                Extension.OutputMetadatas.Add(mapOut_SON);
            }
            if (TotalCMapNames != null)
            {
                OutputMetadata mapOut_TotalC = new OutputMetadata()
                {
                    Type = OutputType.Map,
                    Name = "Total Carbon",
                    FilePath = @"century\TotalC-{timestep}.gis",  //century
                    Map_DataType = MapDataType.Continuous,
                    Map_Unit = FieldUnits.g_C_m2,
                    Visualize = true,
                };
                Extension.OutputMetadatas.Add(mapOut_TotalC);
            }


            //---------------------------------------
            MetadataProvider mp = new MetadataProvider(Extension);
            mp.WriteMetadataToXMLFile("Metadata", Extension.Name, Extension.Name);




        }
    }
}
