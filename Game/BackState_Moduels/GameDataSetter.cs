using UnityEngine;

namespace AssetsPackage.Scripts.Game.BackState_Moduels
{
    public class GameDataSetter : MonoBehaviour
    {
        private void Start()
        {
            //InitLevelDataByOnce();
            //PrintAllLevelData();
        }

        private void OnEnable()
        {
            Destroy(this);
        }

        public static void InitLevelDataByOnce()
        {
            int levelNum = ExcelLoader.Singleton.GetAllLevelNums;
        
            PlayerPrefs.DeleteAll();
            for (int i = 1; i <= levelNum; i++)
            {
                string levelName = "GameLevel" + i;
                
                PlayerPrefs.SetInt(levelName, 0);
                PlayerPrefs.SetInt(levelName + "Index", i);
                
                Debug.Log(levelName + "Index" + " : " + i);
            }
            
            PlayerPrefs.SetInt("GameLevel" + 1, 1);
            
            Debug.Log("Init Done");
        }
        
        public static void LevelAccess(string levelName)
        {
            if (PlayerPrefs.GetInt(levelName) != null)
            {
                PlayerPrefs.SetInt(levelName, 1);
            }
        }
        
        public static void PrintAllLevelData()
        {
            int levelNum = ExcelLoader.Singleton.GetAllLevelNums;
            
            for (int i = 1; i <= levelNum; i++)
            {
                string levelName = "GameLevel" + i.ToString();
                int saveData = PlayerPrefs.GetInt(levelName);
                
                Debug.Log(levelName + " Access data: " + saveData);
            }
            
            for (int i = 1; i <= levelNum; i++)
            {
                string levelName = "GameLevel" + i.ToString();
                int saveData = PlayerPrefs.GetInt(levelName + "Index");
                
                Debug.Log(levelName + " Index data: " + saveData);
            }
        }
    }
}