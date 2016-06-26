using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

namespace RPGame.Core.Data
{
    struct Data
    {
        public enum DataType { INVALID = -1,
            RACE, JOB, ITEM, BAG, USABLE, EQUIPMENT, MATERIAL, TREASURE,
            COUNT
        }
        public enum Race { INVALID = -1,
            HUMAN, RACE_B, RACE_C,
            COUNT
        }
        public enum Job { INVALID = -1,
            FIGHTER, MAGE, THIEF, RANGER, CLERIC, DRUID, BARD,
            COUNT
        }
        public enum Item { INVALID = -1,
            BAG, USABLE, EQUIPMENT, MATERIAL, TREASURE,
            COUNT
        }
        public enum Bag { INVALID = -1,
            SMALL, MEDIUM, LARGE, VERY_LARGE,
            COUNT
        }
        public enum Usable { INVALID = -1,
            POTION, SHELTER, FOOD, TOOL, COMBAT,
            COUNT
        }
        public enum Equipment { INVALID = -1,
            WEAPON, ARMOR, ACCESSORY, ARTIFACT,
            COUNT
        }
        public enum Weapon { INVALID = -1,
            ONE_HAND, MAIN_HAND, OFF_HAND, TWO_HAND,
            COUNT
        }
        public enum WeaponType { INVALID = -1,
            BLUNT, BLADED, RANGED, GROUND,
            COUNT
        }
        public enum Armor { INVALID = -1,
            HEAD, SHOULDER, CHEST, ARM, HAND, LEG, FOOT,
            COUNT
        }
        public enum ArmorType {
            CLOTH, LEATHER, WOOD, CHAIN, SCALE, PLATE,
            COUNT
        }
        public enum Accessory
        {
            RING, WRIST, WAIST, ARM, NECK, BACK,
            COUNT
        }
        public enum Material { INVALID = -1,
            CLOTH, LEATHER, WOOD, ORE, ROPE, OIL,
            COUNT
        }
        public enum Treasure { INVALID = -1,
            COIN, GEM,
            COUNT
        }
        public Data(DataType type) { }
    }

    public class GameData
    {
        Data[] gameData = new Data[(int)Data.DataType.COUNT];
    }
}