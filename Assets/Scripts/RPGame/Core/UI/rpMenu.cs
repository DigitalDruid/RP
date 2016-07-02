using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using Assets.Scripts.RPGame.Core.Util;
using System;
using UnityEngine.Events;

namespace Assets.Scripts.RPGame.Core.UI
{
    public class rpMenu : rpPanel
    {
        public rpPanel refPanel;
        public rpLabel refLabel;
        public rpButton refButton;

        public List<rpUIElement> elementList;

        public const string LABEL_TYPE = "Assets.Scripts.RPGame.Core.UI.rpLabel";
        public const string BUTTON_TYPE = "Assets.Scripts.RPGame.Core.UI.rpButton";

        public override void Awake() { base.Awake(); }
        public override void Start()
        {
            base.Start();
            transform.localScale = new Vector3(1, 1, 1);
        }
        
        public rpUIElement AddElement(string labelText)
        {
            return AddLabel(labelText);
        }
        public rpUIElement AddElement(string labelText, UnityAction call)
        {
            return AddButton(labelText, call);
        }
        public T AddElement<T>(string labelText, UnityAction call = null) where T : rpUIElement
        {
            DBG.Log("Generic Element Added");
            rpUIElement elm;
            switch (typeof(T).ToString())
            {
                case LABEL_TYPE:
                    DBG.Log("Generic rpLabel Created");
                    elm = Instantiate(refLabel) as rpLabel;
                    ((rpLabel)elm).Text = labelText;
                    break;
                case BUTTON_TYPE:
                    DBG.Log("Generic rpButton Created");
                    elm = Instantiate(refButton) as rpButton;
                    ((rpButton)elm).Text = labelText;
                    ((rpButton)elm).OnClick.AddListener(call);
                    break;
                default:
                    elm = null;
                    break;
            }
            elm.Parent = gameObject;
            elementList.Add(elm);
            return elm as T;
        }
        
        //public rpUIElement AddElement(rpUIElement element, string labelText)
        //{
        //    DBG.Log("Base Element Created");
        //    rpUIElement elm = Instantiate(element) as rpUIElement;
        //    return elm;
        //}
        //public rpUIElement AddElement(rpElemType type, string labelText, UnityAction call = null)
        //{
        //    switch (type)
        //    {
        //        case rpElemType.LABEL:
        //            return AddLabel(labelText);
        //        case rpElemType.BUTTON:
        //            return AddButton(labelText, call);
        //        default:
        //            return new rpUIElement();
        //    }
        //}

        public rpLabel AddLabel(string labelText)
        {
            DBG.Log("Label Created");
            rpLabel lbl = Instantiate(refLabel) as rpLabel;
            lbl.Text = labelText;
            lbl.Parent = gameObject;
            elementList.Add(lbl);
            return lbl;
        }
        public rpButton AddButton(string labelText, UnityAction call)
        {
            DBG.Log("Button Created");
            rpButton btn = Instantiate(refButton) as rpButton;
            btn.Text = labelText;
            btn.OnClick.AddListener(call);
            btn.Parent = gameObject;
            elementList.Add(btn);
            return btn;
        }

        public void layout()
        {
            int count = elementList.Count;
            float space = elementList[0].height;
            ResizeTo(250, (count * space));

            for (int i = 0; i < count; i++)
            {
                elementList[i].y = (i == 0) ?
                    (height - space) / 2 :
                    elementList[i - 1].y - space;
            }
        }
    }
}


/*
 * Execution Order of Event Functions
 * 
 * EDITOR
 * Reset
 * 
 * FIRST SCENE LOAD
 * Awake
 * OnEnable
 * OnLevelWasLoaded
 * 
 * BEFORE FIRST FRAME UPDATE
 * Start
 * 
 * IN BETWEEN FRAMES
 * OnApplicationPause
 * 
 * UPDATE ORDER
 * FixedUpdate
 * Update
 * LateUpdate
 * 
 * RENDERING
 * OnPreCull
 * OnBecameVisible
 * OnBecameInvisible
 * OnWillRenderObject
 * OnPreRender
 * OnRenderObject
 * OnPostRender
 * OnRenderImage
 * OnGUI
 * OnDrawGizmos
 * 
 * COROUTINES
 * yield
 * yield WaitForSeconds
 * yield WaitForFixedUpdate
 * yield WWW
 * yield StartCoroutine
 * 
 * WHEN OBJECT IS DESTROYED
 * OnDestroy
 * 
 * WHEN QUITTING
 * OnApplicationQuit
 * OnDisable
 * 
 * 
 * SCRIPT LIFECYCLE
 * 
 * Reset
 * 
 * Awake
 * OnEnable     << LoopStart: OnEnable
 * Start
 * 
 *      << LoopStart: Main
 *      << LoopStart: Physics
 *      
 * FixedUpdate
 * yield WaitForFixedUpdate
 * [Internal Physics Update]
 * OnTriggerXXX
 * OnCollisionXXX
 * 
 *      >> LoopReturn: Physics
 *      
 * OnMouseXXX
 * 
 * Update
 * yield null
 * yield WaitForSeconds
 * yield WWW
 * yield StartCoroutine
 * [Internal Animation Update]
 * LateUpdate
 * 
 * OnWillRenderObject
 * OnPreCull
 * OnBecameVisible
 * OnBecameInvisible
 * OnPreRender
 * OnRenderObject
 * OnPostRender
 * OnRenderImage
 * 
 * OnDrawGizmos
 * 
 * OnGUI << LoopStart: OnGUI
 * 
 *      >> LoopReturn: OnGUI
 * 
 * yield WaitForEndOfFrame
 * 
 * OnApplicationPause
 * 
 *      >> LoopReturn: Main
 * 
 * OnDisable    >> LoopReturn: OnEnable
 * 
 * OnApplicationQuit
 * OnDestroy
*/