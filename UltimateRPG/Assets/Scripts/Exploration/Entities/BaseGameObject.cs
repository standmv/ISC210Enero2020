using System;
using UnityEngine;
namespace AssemblyCSharp.Assets.Scripts.Exploration.Entities
{
    public abstract class BaseGameObject
    {

        public string UniqueObjectName;
        public float PosX;
        public float PosY;
        private GameObject _gObjectRef;

        public BaseGameObject()
        {
        }

        public BaseGameObject(GameObject prefab, string uniqueObjectName, float posX, float posY)
        {
            _gObjectRef = UnityEngine.Object.Instantiate(prefab, new Vector3(posX, -posY), Quaternion.identity);
            _gObjectRef.name = uniqueObjectName;
        }

        ~BaseGameObject()
        {
            UnityEngine.Object.Destroy(_gObjectRef);
        }

        public void Active()
        {
            _gObjectRef.SetActive(true);
        }

        public void Inactive()
        {
            _gObjectRef.SetActive(false);
        }

        public GameObject GetObject()
        {
            return _gObjectRef;
        }
    }
}
