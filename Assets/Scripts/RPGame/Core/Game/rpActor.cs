using UnityEngine;
using System;
using Assets.Scripts.RPGame.Core.Data;
using Assets.Scripts.RPGame.Core.Util;

namespace Assets.Scripts.RPGame.Core.Game {
    interface IActor    {
        /*
        // Lists     
        rpStatList Stats { get; set; }
        rpSkillList Skills { get; set; }
        rpItemList Items { get; set; }
        // Init      
        void setupStats(int level);
        // TryGet    
        rpStat TryGet(int type);
        rpStat TryGet(rpStatType type);
        // Accessors 
        int Level { get; set; }
        int XP { get; set; }
        int Health { get; set; }
        int Stamina { get; set; }
        int Attack { get; set; }
        int Defense { get; set; }
        int Speed { get; set; }
        int Luck { get; set; }
        int XPReward { get; set; }
        int GoldReward { get; set; }
        // Rollers   
        int rollStat();
        int rollStat(int level);
        int rollStat(float min, float max);
        int rollStat(Range range);
        //*/
        // Actions   
        void MoveAction();
        void MoveAction(Vector2 direction);
        void AttackAction();
        void AttackAction(rpActor defender);
        void DefendAction();
        void DefendAction(rpActor attacker);
    }
    public class rpActor : MonoBehaviour, IActor
    {
        
        // Lists    
        public virtual rpStatList Stats { get; set; }
        public virtual rpSkillList Skills { get; set; }
        public virtual rpItemList Items { get; set; }
        
        // Init     
        public virtual void init()                {
            DBG.Add(displayName() + " Created", true);
            makeNewLists();
            DBG.Add(displayLevel(), true);
            if(!DBG.Paused) DBG.Log();
            setupStats(_level);
        }
        public virtual void makeNewLists()        {
            if (Stats == null) Stats = new rpStatList();
            if (Skills == null) Skills = new rpSkillList();
            if (Items == null) Items = new rpItemList();
        }
        public virtual void setupStats(int level) {
            DBG.Add("<StatKVList>", true);
            for (int i = 0; i < numStats; i++) {
                rpStatType type = (rpStatType)i;
                switch (type) {
                    case rpStatType.INVALID:
                    case rpStatType.COUNT:
                        break;
                    case rpStatType.LVL:
                    case rpStatType.XP:
                        Stats.AddStat(type, new rpStat(level));
                        break;
                    case rpStatType.RXP:
                        Stats.AddStat(type, new rpStat(level * 3));
                        break;
                    case rpStatType.RGLD:
                        Stats.AddStat(type, new rpStat(rollStat(level, level * 100)));
                        break;
                    default:
                        Stats.AddStat(type, new rpStat(rollStat(level)));
                        break;
                }
                DBG.Add("[" + type + "]", true);
                DBG.Add(" : " + Stats[type].Value);
                //DBG.Add("\n");
            }
            if(!DBG.Paused) DBG.Log();
        }
        // TryGet   
        public virtual rpStat TryGet(int type) { return TryGet((rpStatType)type); }
        public virtual rpStat TryGet(rpStatType type) { rpStat tmp; return (Stats.TryGetValue(type, out tmp)) ? Stats[type] : tmp; }
        // ListCounts   
        public virtual int numStats  { get { return (int)rpStatType.COUNT; } }
        public virtual int numSkills { get { return (int)rpSkillType.COUNT; } }
        public virtual int numItems  { get { return (int)rpItemType.COUNT; } }
        
        // Accessors    
        public virtual int Level      {
            get { return Mathf.FloorToInt(Stats[rpStatType.LVL].Value); }
            set { Stats[rpStatType.LVL].Value = value; }
        }
        public virtual int XP         {
            get { return Mathf.FloorToInt(Stats[rpStatType.XP].Value); }
            set { Stats[rpStatType.XP].Value = value; }
        }
        public virtual int Health     {
            get { return Mathf.FloorToInt(Stats[rpStatType.HP].Value); }
            set { Stats[rpStatType.HP].Value = value; }
        }
        public virtual int Stamina    {
            get { return Mathf.FloorToInt(Stats[rpStatType.SP].Value); }
            set { Stats[rpStatType.SP].Value = value; }
        }
        public virtual int Attack     {
            get { return Mathf.FloorToInt(Stats[rpStatType.ATT].Value); }
            set { Stats[rpStatType.ATT].Value = value; }
        }
        public virtual int Defense    {
            get { return Mathf.FloorToInt(Stats[rpStatType.DEF].Value); }
            set { Stats[rpStatType.DEF].Value = value; }
        }
        public virtual int Speed      {
            get { return Mathf.FloorToInt(Stats[rpStatType.SPD].Value); }
            set { Stats[rpStatType.SPD].Value = value; }
        }
        public virtual int Luck       {
            get { return Mathf.FloorToInt(Stats[rpStatType.LCK].Value); }
            set { Stats[rpStatType.LCK].Value = value; }
        }
        public virtual int XPReward   {
            get { return Mathf.FloorToInt(Stats[rpStatType.RXP].Value); }
            set { Stats[rpStatType.RXP].Value = value; }
        }
        public virtual int GoldReward {
            get { return Mathf.FloorToInt(Stats[rpStatType.RGLD].Value); }
            set { Stats[rpStatType.RGLD].Value = value; }
        }
        
        // Rollers  
        public virtual int rollStat(int level) {
            int stat = 10;
            for (int i = 0; i < level; i++) { stat += rollStat(); }
            return stat;
        }
        public virtual int rollStat() { return rollStat(1, 5); }
        public virtual int rollStat(Range range) { return rollStat(range.min, range.max); }
        public virtual int rollStat(float min, float max) { return Mathf.FloorToInt(UnityEngine.Random.Range(min, max)); }
        
        // Actions  
        public virtual void MoveAction() { throw new NotImplementedException(); }
        public virtual void MoveAction(Vector2 direction) { throw new NotImplementedException(); }
        public virtual void AttackAction() { throw new NotImplementedException(); }
        public virtual void AttackAction(rpActor defender) { throw new NotImplementedException(); }
        public virtual void DefendAction() { throw new NotImplementedException(); }
        public virtual void DefendAction(rpActor attacker) { throw new NotImplementedException(); }
        
        // Display  
        public virtual string displayName()  {
            return (_name != "") ? "Actor: " + _name : "Nameless Actor";
        }
        public virtual string displayLevel() {
            return (_level < 1) ? "Actor has no level" : "Actor: " + _name + ", Level: " + _level;
        }

        public string _name;
        public int _level;

        public rpActor(string name = "", int level = 0) {
            _name = name; _level = level; init();
        }
        
    }
}
