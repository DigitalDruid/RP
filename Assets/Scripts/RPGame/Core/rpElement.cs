using UnityEngine;
using System.Collections;

using RPGame.Core.Util;

namespace RPGame.Core
{
    public class rpElement : MonoBehaviour
    {
        public Canvas canvas;
        public GameObject Parent {
            get { return transform.parent.gameObject; }
            set { transform.SetParent(value.transform); }
        }
        public string ID { get { return (gameObject.name + " [" + GetInstanceID() + "] : "); } }

        // Use this for initialization
        public void Awake()
        {
            DBG.Log(this,"Awake");
        }
        public void Start()
        {
            DBG.Log(this,"Start");
            Init();
        }
        void Init() {
            DBG.Log(this, "Initializing");
            if (!canvas)
            {
                DBG.Log("Canvas Not Linked. Finding...");
                canvas = FindObjectOfType<Canvas>();
                if (!canvas) { DBG.Log(new Error().newError(Error.TYPE.UNABLE_TO_LOAD, name, "Canvas Not Found! Aborting")); return; }
            }
            DBG.Log("Canvas Found: " + canvas.name);
            Parent = canvas.gameObject;
            DBG.Log("Parent Set: " + Parent.name);
        }
    }
}
