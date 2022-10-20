using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BioSero.GreenButtonGo.Scripting;
using System.Data;

namespace GreenButtonGo.Scripting
{
    public class RecordReagentLots : BioSero.GreenButtonGo.GBGScript
    {

        public void Run(Dictionary<String, Object> variables, RuntimeInfo runtimeInfo)
        {
            string tableName = "ReagentLots";
            DataTable reagentLots = Database.GetTable(tableName);
            DataRow row = reagentLots.NewRow();


            row[RunInfoTableColumns.GrowthMediaLot.ToString()] = variables["growthMediaLot"].ToUpper();
            row[RunInfoTableColumns.LGluatimineLot.ToString()] = variables["l_glutamineLot"].ToUpper();
            row[RunInfoTableColumns.CHOMediaLot.ToString()] = variables["choMediaLot"].ToUpper();
            row[RunInfoTableColumns.PEILot.ToString()] = variables["peiLo"].ToUpper();
            row[RunInfoTableColumns.XBP1Lot.ToString()] = variables["xbp1Lot"].ToUpper();
            row[RunInfoTableColumns.Feed1Lot.ToString()] = variables["feed1Lot"].ToUpper();
            row[RunInfoTableColumns.Feed2Lot.ToString()] = variables["feed2Lot"].ToUpper();
            row[RunInfoTableColumns.FillerDNALot.ToString()] = variables["fillerDNALot"].ToUpper();
            row[RunInfoTableColumns.DMALot.ToString()] = variables["dmaLot"].ToUpper();
            row[RunInfoTableColumns.AntiboticLot.ToString()] = variables["antiboticLot"].ToUpper();
            row[RunInfoTableColumns.FACLot.ToString()] = variables["facLot"].ToUpper();
            row[RunInfoTableColumns.GlucoseLot.ToString()] = variables["glucoseLot"].ToUpper();
            reagentLots.Rows.Add(row);

            Database.Save(tableName, reagentLots);
        }
        
        enum RunInfoTableColumns
        {
            ReagentsId,
            GrowthMediaLot, 
            LGluatimineLot, 
            CHOMediaLot,
            PEILot,
            XBP1Lot,
            Feed1Lot,
            Feed2Lot,
            FillerDNALot,
            DMALot,
            AntiboticLot,
            FACLot,
            GlucoseLot
        }
    }
}