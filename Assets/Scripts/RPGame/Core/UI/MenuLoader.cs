using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using RPGame.Core.Util;

namespace RPGame.Core.UI {
    public class MenuLoader : MonoBehaviour {

        public rpPanel panelReference;
        public rpMenu menuReference;

        // Use this for initialization
        void Awake() {
            DBG.Logging = true;
            if (menuReference) {
                rpMenu menu = Instantiate(menuReference, new Vector3(), Quaternion.identity) as rpMenu;
                menu.name += " [Test Menu 1]";
                menu.Position = new Vector3(0, 0, 0);
                menu.Resize(4, 5);
            }
            if (panelReference) {
                rpPanel panel = Instantiate(panelReference, new Vector3(), Quaternion.identity) as rpPanel;
                panel.name += " [Test Panel 1]";
                
                //RectTransform tmpRect = panel.transform.GetComponent<RectTransform>();
                //panel.transform.localScale = new Vector3(1, 1, 1);
                
                panel.Position = new Vector3(0, 0, 0);
                panel.Resize(4,5);
            }
            else DBG.Log(new Error().newError(Error.TYPE.UNABLE_TO_LOAD, name, "Panel reference not linked in editor."));
        }
    }
}