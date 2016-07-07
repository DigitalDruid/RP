using UnityEngine;
using System.Collections;
using Assets.Scripts.RPGame.Core.Util;
using UnityEngine.UI;

namespace Assets.Scripts.RPGame.Core.UI
{
    public class rpLabel :rpUIElement
    {
        public string Text { get { return GetComponent<Text>().text; } set { GetComponent<Text>().text = value; } }
        public Color color { get { return GetComponent<Text>().color; } set { GetComponent<Text>().color = value; } }

        public rpLabel() { }
        public rpLabel(string labelText) { Text = labelText; }
        
        public rpLabel(rpUIElement parent, string labelText)
        {
            ParentTransform = parent.transform;
            Text = labelText;

        }
        public rpLabel(GameObject parent, string labelText)
        {
            ParentTransform = parent.transform;
            Text = labelText;
        }

        public override void Start()
        {
            base.Start();
            color = (isEnabled) ? Color.white : new Color(0.25f,0.25f,0.5f);
        }
        void OnGUI()
        {
            //Text = GUI.TextField(new Rect(10, 10, 200, 20), Text);
        }
    }
}
