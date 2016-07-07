using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.RPGame.Core.Data
{
    /*
    public struct DataType
    {
        const string name = "type";

        public enum Race
        {
            INVALID = -1,
            HUMAN, RACE_B, RACE_C,
            COUNT
        }
        public enum Job
        {
            INVALID = -1,
            FIGHTER, MAGE, THIEF, RANGER, CLERIC, DRUID, BARD,
            COUNT
        }
        public struct Item
        {
            public enum Condition { INVALID=-1, POOR, NORMAL, GOOD, FINE, MINT, PERFECT, COUNT }
            public enum Bag { INVALID = -1, SMALL, MEDIUM, LARGE, VERY_LARGE, COUNT }
            public enum Usable { INVALID = -1, POTION, SHELTER, FOOD, TOOL, COMBAT, COUNT }

            public struct Equipment
            {
                public struct Weapon
                {
                    public enum Slot { INVALID = -1, ONE_HAND, MAIN_HAND, OFF_HAND, TWO_HAND, COUNT }
                    public enum Style { INVALID = -1, BLUNT, BLADED, RANGED, GROUND, COUNT }
                    public enum Type { INVALID = -1, WOOD, IRON, SILVER, GOLD, PLATINUM, STEEL, DIAMOND, ADAMANT, MAGIC, COUNT }
                }
                public struct Armor
                {
                    public enum Slot { INVALID = -1, HEAD, SHOULDER, CHEST, ARM, HAND, LEG, FOOT, COUNT }
                    public enum Type { CLOTH, LEATHER, WOOD, CHAIN, SCALE, PLATE, COUNT }
                }
                public enum Accessory { INVALID = -1, RING, WRIST, WAIST, ARM, NECK, BACK, COUNT }
            }
            public enum Material { INVALID = -1, CLOTH, LEATHER, WOOD, ORE, ROPE, OIL, COUNT }
            public enum Treasure { INVALID = -1, COIN, GEM, COUNT }
            
        }
    }*/
    public static class Data {

    }
    public struct Range {
        public float min, max;
        public Vector2 v2 { get { return new Vector2(min, max); } set { min = value.x; max = value.y; } }
        public float x { get { return v2.x; } set { v2 = new Vector2(value, v2.y); } }
        public float y { get { return v2.y; } set { v2 = new Vector2(v2.x, value); } }
    }
}