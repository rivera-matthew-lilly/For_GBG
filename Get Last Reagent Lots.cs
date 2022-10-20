using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BioSero.GreenButtonGo.Scripting;
using System.Data;

namespace GreenButtonGo.Scripting
{
    public class Get_Last_Runs_Reagent_Lots : BioSero.GreenButtonGo.GBGScript
    {

        public void Run(Dictionary<String, Object> variables, RuntimeInfo runtimeInfo)
        {
           string tableName = "ReagentLots";
           DataTable runInfo = Database.GetTable(tableName);
           
           variables["growthMediaLot"] = runInfo.Rows[runInfo.Rows.Count - 1]["GrowthMediaLot"];
           variables["l_glutamineLot"] = runInfo.Rows[runInfo.Rows.Count - 1]["LGluatimineLot"];
           variables["choMediaLot"] = runInfo.Rows[runInfo.Rows.Count - 1]["CHOMediaLot"];
           variables["peiLot"] = runInfo.Rows[runInfo.Rows.Count - 1]["PEILot"];
           variables["xbp1Lot"] = runInfo.Rows[runInfo.Rows.Count - 1]["XBP1Lot"];
           variables["feed1Lot"] = runInfo.Rows[runInfo.Rows.Count - 1]["Feed1Lot"];
           variables["feed2Lot"] = runInfo.Rows[runInfo.Rows.Count - 1]["Feed2Lot"];
           variables["fillerDNALot"] = runInfo.Rows[runInfo.Rows.Count - 1]["FillerDNALot"];
           variables["dmaLot"] = runInfo.Rows[runInfo.Rows.Count - 1]["DMALot"];
           variables["antiboticLot"] = runInfo.Rows[runInfo.Rows.Count - 1]["AntiboticLot"];
           variables["facLot"] = runInfo.Rows[runInfo.Rows.Count - 1]["FACLot"];
           variables["glucoseLot"] = runInfo.Rows[runInfo.Rows.Count - 1]["GlucoseLot"];
           
        }
    }
}