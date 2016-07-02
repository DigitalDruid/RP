using UnityEngine;
using System.Collections;
using Assets.Scripts.RPGame.Core.Game;
using Assets.Scripts.RPGame.Core.Util;

namespace Assets.Scripts.RPGame.Test
{
    public class TestActor : MonoBehaviour
    {
        rpPlayer player1, player2, player3, player4, player5, player6, player7;

        void Start() {
            DBG.Logging = true;
            DBG.Pause();
            DBG.Log("Test Start");
            player1 = new rpPlayer("Main Character", 1);
            player2 = new rpPlayer("Trusty Sidekick", 1);
            player3 = new rpPlayer("Shady Antihero", 1);
            player4 = new rpPlayer("Love Interest", 1);
            player5 = new rpPlayer("Plucky Child", 1);
            player6 = new rpPlayer("Brainy Knowitall", 1);
            player7 = new rpPlayer("Mystic Master", 1);
            DBG.Unpause();
            DBG.Log();
        }
    }
}
