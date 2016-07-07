using UnityEngine;
using System.Collections;
using Assets.Scripts.RPGame.Core.Data;
using System;
using Assets.Scripts.RPGame.Core.Util;

namespace Assets.Scripts.RPGame.Core.Game
{
    class rpPlayer : MonoBehaviour, IActor
    {
        rpActor actor;
        
        public void Start() {
            DBG.Logging = true;
            DBG.Log("Player Started");
            if (actor) {
                DBG.Log(actor.name);
            } else
            {
                DBG.Log("No Actor Set");
                actor = new rpActor("Blah!", 99);
            }
        }

        public rpPlayer() { }
        public rpPlayer(string name, int level=1) {
            actor = new rpActor(name, level);
        }

        public void AttackAction() {
            throw new NotImplementedException();
        }
        public void AttackAction(rpActor defender) {
            throw new NotImplementedException();
        }
        public void DefendAction() {
            throw new NotImplementedException();
        }
        public void DefendAction(rpActor attacker) {
            throw new NotImplementedException();
        }
        public void MoveAction() {
            throw new NotImplementedException();
        }
        public void MoveAction(Vector2 direction) {
            throw new NotImplementedException();
        }
    }
}
