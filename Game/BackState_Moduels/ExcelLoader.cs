using System.IO;
using AssetsPackage.Scripts.Utils;
using OfficeOpenXml;
using UnityEngine;

namespace AssetsPackage.Scripts.Game.BackState_Moduels
{
    public class ExcelLoader : UnitySingleton<ExcelLoader>
    {
        private static string path = "Assets/AssetsPackage/8. Excels/GameLevelInfo.xlsx";
        private static FileInfo fileInfo = new FileInfo(path);
        private static ExcelPackage saveDataPackage = new ExcelPackage(fileInfo);
        
        private ExcelWorksheet saveData = saveDataPackage.Workbook.Worksheets[1];
        private readonly int dataInfoIndex      = 2;
        private readonly int gameLevelInfoIndex = 3;
        private int currentGameLevel = 1;
        
        public int GetAllLevelNums => int.Parse(saveData.Cells[dataInfoIndex, 1].Value.ToString());
        
        public bool CheckLevelCanBeAccess(string levelName)
        {
            return true;
        }
        
        public void ReleaseExcel()
        {
            saveDataPackage.Stream.Close();
        }

        public void ReadGameLevelProperty(int level)
        {
            int Column = int.Parse(saveData.Cells[dataInfoIndex, 2].Value.ToString());
            for (int j = 1; j <= Column; j++)
            {
                Debug.Log(saveData.Cells[gameLevelInfoIndex + level, j].Value.ToString());
            }
        }
        
        public int GetEnemyNums(string levelName)
        {
            int level = PlayerPrefs.GetInt(levelName + "Index");
            int nums = int.Parse(saveData.Cells[gameLevelInfoIndex + level, 3].Value.ToString());
            return nums;
        }
        
        public int GetMainCharactorNums(int level)
        {
            int nums = int.Parse(saveData.Cells[gameLevelInfoIndex + level, 2].Value.ToString());
            return nums;
        }
    }
}