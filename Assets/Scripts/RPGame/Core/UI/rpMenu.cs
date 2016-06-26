using UnityEngine;
using System.Collections;

namespace RPGame.Core.UI
{
    public class rpMenu : rpPanel
    {
        public rpPanel refPanel;

        new void Awake() { base.Awake(); }
        new void Start() { base.Start(); }
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
 * LastUpdate
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