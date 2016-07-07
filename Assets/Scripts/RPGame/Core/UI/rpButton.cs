using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Assets.Scripts.RPGame.Core.UI
{
    public class rpButton : rpUIElement
    {
        public Button.ButtonClickedEvent OnClick
        {
            get { return GetComponent<Button>().onClick; }
            set { GetComponent<Button>().onClick = value; }
        }
        public rpLabel Label
        {
            get { return GetComponentInChildren<rpLabel>(); }
        }
        public string Text
        {
            get { return Label.Text; }
            set { Label.Text = value; }
        }
        public override void Start()
        {
            Label.isEnabled = isEnabled;
            base.Start();
        }
    }
}
