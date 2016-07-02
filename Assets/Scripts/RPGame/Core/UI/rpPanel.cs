using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using Assets.Scripts.RPGame.Core.Util;

namespace Assets.Scripts.RPGame.Core.UI
{
    public class rpPanel : rpUIElement
    {
        //Transform panel;
        private Vector3 DefaultPosition = new Vector3(0, 0, 0);
        //private float DefaultWidth = 100f, DefaultHeight = 50f;

        // Class Initializers
        public override void Awake() {
            base.Awake();
        }
        public override void Start() {
            base.Start();
            Init();
        }
        void Init() { DBG.Log(this,"Initializing");
            if (!canvas)
            {
                DBG.Log("Canvas Not Linked. Finding...");
                canvas = FindObjectOfType<Canvas>();
                if (!canvas) { DBG.Log(new Error().newError(Error.TYPE.UNABLE_TO_LOAD, name, "Canvas Not Found! Aborting")); return; }
            }
            DBG.Log("Canvas Found: " + canvas.name);
            //Parent = canvas.gameObject;
            ParentCanvas = canvas;
            DBG.Log("Parent Set: " + Parent.name);
            rectTransform = (RectTransform)transform;
            DBG.Log("RectTransform Set: " + rectTransform.name);
        }
    }
}