using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using Assets.Scripts.RPGame.Core.Util;

namespace Assets.Scripts.RPGame.Core.UI {
    public class MenuLoader : MonoBehaviour {

        //public rpPanel panelReference;
        public rpMenu menuReference;

        // Use this for initialization
        void Awake() {
            DBG.Logging = true;
            if (menuReference) {
                rpMenu menu = Instantiate(menuReference, new Vector3(), Quaternion.identity) as rpMenu;
                menu.name += " [Test Menu 1]";
                menu.ResizeTo(250, 200);
                
                rpButton b1 = menu.AddButton("New Game", startGame);
                rpButton b2 = menu.AddButton("Continue", continueGame);
                rpButton b3 = menu.AddButton("Options", gotoOptions);

                b2.isEnabled = false;

                menu.layout();

                //DBG.Log(((RectTransform)menu.ParentCanvas.transform).sizeDelta.x.ToString());

                // menu w:250, h:200, minimum
                //menu.top += 3.3f;
                //menu.left -= 3.9f;
                // menu w:250, h:200, maximum
                //menu.top -= 3.3f;
                //menu.left += 3.9f;
                //menu.anchor = new Vector2(0, 0);
            }
        }
        void startGame()
        {
            DBG.Log("Simulated Game Start");
        }
        void continueGame()
        {
            DBG.Log("Simulated Game Continue");
        }
        void gotoOptions()
        {
            DBG.Log("Simulated Options Menu");
        }
    }
}