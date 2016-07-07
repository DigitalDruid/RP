using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.RPGame.Core.Game
{
    public enum rpSkillType
    {
        INVALID = -1,
        COUNT
    }
    public class rpSkillList : Dictionary<rpSkillType, rpSkill>
    {
        public void AddSkill(rpSkillType type, rpSkill skill) { Add(type, skill); }
        public void AddSkill(int type, rpSkill skill) { Add((rpSkillType)type, skill); }
    }
    public class rpSkill
    {
        public rpSkill() { }
    }
}
