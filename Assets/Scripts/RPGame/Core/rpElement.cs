using UnityEngine;
using System.Collections;

using Assets.Scripts.RPGame.Core.Util;

namespace Assets.Scripts.RPGame.Core
{
    public class rpElement : MonoBehaviour
    {
        public GameObject Parent {
            get { return transform.parent.gameObject; }
            set { transform.SetParent(value.transform); }
        }
        public Transform ParentTransform
        {
            get { return transform.parent; }
            set { transform.SetParent(value); }
        }
        rpElement _parentElement;
        public rpElement ParentElement
        {
            get { return _parentElement /*Parent.GetComponent<rpElement>()*/; }
            set { _parentElement = value; ParentTransform = value.transform; }
        }
        public string ID { get { return (gameObject.name + " [" + GetInstanceID() + "] : "); } }

        // Use this for initialization
        public virtual void Awake()
        {
            DBG.Log(this,"Awake");
        }
        public virtual void Start()
        {
            DBG.Log(this,"Start");
            Init();
        }
        void Init() { }
    }
}
