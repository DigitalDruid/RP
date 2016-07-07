using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.RPGame.Core.Game {
    public enum rpStatType {
        INVALID = -1,
        LVL, XP, HP, SP, ATT, DEF, SPD, LCK, RXP, RGLD,
        COUNT 
    }   
    public class rpStatList : Dictionary<rpStatType, rpStat> {
        public void AddStat(rpStatType type, rpStat value) { Add(type, value); }
        public void AddStat(int type, rpStat value) { Add((rpStatType)type, value); }
        public void AddStat(string stat, rpStat value) {
            for (int i = 0; i < (int)rpStatType.COUNT; i++){
                rpStatType type = (rpStatType)i;
                if (stat == type.ToString()) Add(type, value);
            }
        }
        public rpStat GetStat(rpStatType type) { return this[type]; }
        public float GetStat(rpStatType type, bool value) { return this[type].Value; }
    }
    public class rpStat {

        // Private Variables
        float min, max, current;

        // Constructors
        public rpStat(float value, bool constant = true) {
            isConstant = constant;
            current = min = max = value;
        }
        public rpStat(float value, float max) {
            current = value;
            this.max = max;
        }
        public rpStat(float value, float max, float min) {
            current = value;
            this.max = max;
            this.min = min;
        }
        public rpStat() { }
        public static rpStat empty = null;

        // Public Accessors
        public bool isConstant;
        public float Value {
            get { return current; }
            set { current = (value > max) ? max : (value < min) ? min : value; }
        }
        public float MaxValue {
            get { return max; }
            set { max = value; Value = current; /*//if (current > maximum) current = maximum;//*/}
        }
        public float MinValue {
            get { return min; }
            set { min = value; Value = current; /*//if (current < minimum) current = minimum;//*/}
        }
    }
}