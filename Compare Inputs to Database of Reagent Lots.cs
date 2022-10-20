using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BioSero.GreenButtonGo.Scripting;
using System.Data;

namespace GreenButtonGo.Scripting
{
    public class Compare_Inputs_to_Database_of_Reagent_Lots : BioSero.GreenButtonGo.GBGScript
    {

        public void Run(Dictionary<String, Object> variables, RuntimeInfo runtimeInfo) {
            RecordReagentLots(variables);
        }

        public void RecordReagentLots(Dictionary<String, Object> variables) {
            string tableName = "ReagentLots";
            DataTable reagentLots = Database.GetTable(tableName);
            string currentGrowthMediaLot =  variables["growthMediaLot"] as string;
            string currentL_glutamineLot = variables["l_glutamineLot"] as string;
            string currentCHOMediaLot = variables["choMediaLot"] as string;
            string currentPEILot = variables["peiLot"] as string;
            string currentXBP1Lot = variables["xbp1Lot"] as string;
            string currentFeed1Lot = variables["feed1Lot"] as string; 
            string currentFeed2Lot = variables["feed2Lot"] as string;
            string currentFillerDNALot = variables["FillerDNALot"] as string;
            string curretDMALot = variables["DMALot"] as string;
            string currentAntiboticLot = variables["AntiboticLot"] as string;
            string currentFACLot = variables["FACLot"] as string;
            string currentGlucoseLot = variables["GlucoseLot"] as string;
            double primaryKey = 0;
            bool setNewReagentLots = true;

            for (int i = 0, i <= reagentLots.Rows.Count, i++) 
            {
                //dont understand why ReagentLotsTableColumns.GrowthMediaLot not ["GrowthMediaLot"]
                if (currentGrowthMediaLot == reagentLots.Rows[i][ReagentLotsTableColumns.GrowthMediaLot.ToString()].ToString() &&
                    currentL_glutamineLot == reagentLots.Rows[i][ReagentLotsTableColumns.LGluatimineLot.ToString()].ToString() &&
                    currentCHOMediaLot == reagentLots.Rows[i][ReagentLotsTableColumns.CHOMediaLot.ToString()].ToString() &&
                    currentPEILot == reagentLots.Rows[i][ReagentLotsTableColumns.PEILot.ToString()].ToString() &&
                    currentXBP1Lot == reagentLots.Rows[i][ReagentLotsTableColumns.XBP1Lot.ToString()].ToString() &&
                    currentFeed1Lot == reagentLots.Rows[i][ReagentLotsTableColumns.Feed1Lot.ToString()].ToString() &&
                    currentFeed2Lot == reagentLots.Rows[i][ReagentLotsTableColumns.Feed2Lot.ToString()].ToString() &&
                    currentFillerDNALot == reagentLots.Rows[i][ReagentLotsTableColumns.FillerDNALot.ToString()].ToString() &&
                    curretDMALot == reagentLots.Rows[i][ReagentLotsTableColumns.DMALot.ToString()].ToString() &&
                    currentAntiboticLot == reagentLots.Rows[i][ReagentLotsTableColumns.AntiboticLot.ToString()].ToString() &&
                    currentFACLot == reagentLots.Rows[i][ReagentLotsTableColumns.FACLot.ToString()].ToString() &&
                    currentGlucoseLot == reagentLots.Rows[i][ReagentLotsTableColumns.GlucoseLot.ToString()].ToString())
                    {
                        setNewReagentLots = false;
                        //why the (int)
                        primaryKey = Covert.ToDouble(reagentLots.Rows[i][(int)ReagentLotsTableColumns.ReagentLotId].ToString());
                        break;
                    }
            }

            if (setNewReagentLots) 
            {
                DataRow row = reagentLots.NewRow();
            
                row[ReagentLotsTableColumns.ReagentsId.ToString()] = (Covert.ToDouble(reagentLots.Rows[i][(int)ReagentLotsTableColumns.ReagentLotId].ToString())+1).ToString();
                row[ReagentLotsTableColumns.GrowthMediaLot.ToString()] = currentGrowthMediaLot;
                row[ReagentLotsTableColumns.LGluatimineLot.ToString()] = currentL_glutamineLot;
                row[ReagentLotsTableColumns.CHOMediaLot.ToString()] = currentCHOMediaLot;
                row[ReagentLotsTableColumns.PEILot.ToString()] = currentPEILot;
                row[ReagentLotsTableColumns.XBP1Lot.ToString()] = currentXBP1Lot;
                row[ReagentLotsTableColumns.Feed1Lot.ToString()] = currentFeed1Lot;
                row[ReagentLotsTableColumns.Feed2Lot.ToString()] = currentFeed2Lot;
                row[ReagentLotsTableColumns.FillerDNALot.ToString()] = currentFillerDNALot;
                row[ReagentLotsTableColumns.DMALot.ToString()] = curretDMALot;
                row[ReagentLotsTableColumns.AntiboticLot.ToString()] = currentAntiboticLot;
                row[ReagentLotsTableColumns.FACLot.ToString()] = currentFACLot;
                row[ReagentLotsTableColumns.GlucoseLot.ToString()] = currentGlucoseLot;
                reagentLots.Rows.Add(row);

                Database.Save(tableName, reagentLots);

            }

            variables["Reagent Lot Id"] = primaryKey
        
        }
        enum ReagentLotsTableColumns {
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