using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using RPGame.Core.Util;

namespace RPGame.Core.UI
{
    public class rpPanel : rpElement
    {
        public Transform panel;
        public RectTransform _rect;
        public RectTransform rect {
            set { _rect = value; }
            get {
                
                rect = (_rect)      ? _rect :                                   // Rect is linked.
                       (panel)      ? panel.GetComponent<RectTransform>() :     // Panel is linked. Obtaining RectTransform.
                       (transform)  ? transform.GetComponent<RectTransform>() : // Panel isn't linked. Attempt to Find in transform
                       transform.parent.GetComponent<RectTransform>();          // Couldn't find in transform. Look in parent.
                return _rect;
            }
        }

        private Vector3 DefaultPosition = new Vector3(0, 0, 0);
        private float DefaultWidth = 100f, DefaultHeight = 50f;

        Vector2 _position2D;
        Vector3 _position3D;
        float _width, _height;
        
        public Vector3 Position {
            get {
                return rect.position;
            }
            set { rect.position = value; }
        }
        public float Width {
            get { return rect.sizeDelta.x; }
            set { rect.sizeDelta = new Vector2(value, Height); }
        }
        public float Height {
            get { return rect.sizeDelta.y; }
            set { rect.sizeDelta = new Vector2(Width, value); }
        }

        public void Resize(float width, float height) { Width = width; Height = height; }
        public void MoveTo(Vector3 position) { Position = position; }

        // Class Constructors
        /*
        public rpPanel(Vector3 position, float width, float height) {
            MoveTo(position);
            Resize(width, height);
        }
        public rpPanel(Vector3 position) {
            MoveTo(position);
            Resize(DefaultWidth, DefaultHeight);
        }
        public rpPanel(float width, float height) {
            MoveTo(DefaultPosition);
            Resize(width, height);
        }
        public rpPanel() {
            MoveTo(DefaultPosition);
            Resize(DefaultWidth, DefaultHeight);
        }
        */
        
        // Class Initializers
        new void Awake() {
            base.Awake();
        }
        new void Start() {
            base.Start();
            Init();
        }
        void Init() { DBG.Log(this,"Initializing");
            if (!panel) {
                DBG.Log("Panel Not Linked. Finding...");
                panel = transform;
                if (!panel) { DBG.Log(new Error().newError(Error.TYPE.UNABLE_TO_LOAD, name)); return; }
            }
            DBG.Log("Panel Found: " + panel.name +" ("+ panel.GetInstanceID()+") ");
            rect = panel.GetComponent<RectTransform>();
            DBG.Log("RectTransform Set: " + rect.name);
        }
    }
}