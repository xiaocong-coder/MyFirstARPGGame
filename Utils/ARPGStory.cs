using System.Collections.Generic;
using System.Text;

namespace AssetsPackage.Scripts.Utils
{
    public class ARPGStory
    {
        public static StringBuilder GameLevel1Story = new StringBuilder("  Block enemies attacked your village, now you must find out the truth about the attack.");
        public static StringBuilder GameLevel2Story = new StringBuilder("  You've found a clue. Follow that clue to the enemy's true purpose.");
        public static StringBuilder GameLevel3Story = new StringBuilder("  You know where the enemy is coming from. Now go kill them.");
        public static StringBuilder GameLevel4Story = new StringBuilder("  You have met the leader who attacked the village. Now defeat him.");
        public static StringBuilder GameLevel5Story = new StringBuilder("  Now that you know the reason why the enemy attacked mankind is because mankind overused the resources of the region, please defeat the last enemy and appeal to mankind to protect the earth. ");
        
        public static Dictionary<string, StringBuilder> GameLevelStory = new Dictionary<string, StringBuilder>()
        {
            { "GameLevel1", GameLevel1Story },
            { "GameLevel2", GameLevel2Story },
            { "GameLevel3", GameLevel3Story },
            { "GameLevel4", GameLevel4Story },
            { "GameLevel5", GameLevel5Story }
        };
    }
}