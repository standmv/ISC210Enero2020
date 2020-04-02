using System;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Exploration.Entities
{
    public class Item : BaseGameObject
    {
        public int Id;
        public string PrefabName;
        public string Tag;

        public Item(int id, string prefabName, string tag, GameObject prefab, string uniqueObjectName, float posX, float posY) : base(prefab, uniqueObjectName, posX, posY)
        {
            Id = id;
            PrefabName = prefabName;
            Tag = tag;
        }
    }
}
