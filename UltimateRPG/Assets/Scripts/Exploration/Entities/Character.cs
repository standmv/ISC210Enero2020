using System;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Exploration.Entities
{
    public class Character : BaseGameObject
    {
        public int Id;
        public string PrefabName;
        public string Tag;
        public int Coins;

        public Character(int id, string prefabName, string tag, GameObject prefab, string uniqueObjectName, float posX, float posY, int coins) : base(prefab, uniqueObjectName, posX, posY)
        {
            Id = id;
            PrefabName = prefabName;
            Tag = tag;
            Coins = coins;
        }
    }
}
