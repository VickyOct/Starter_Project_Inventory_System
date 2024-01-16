using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    public abstract class ItemSO : ScriptableObject
    {
        [field: SerializeField]
        public bool IsStackable { get; set; }
        public int ID => GetInstanceID();

        [field: SerializeField]
        public int MaxStackSize { set; get; } = 1;

        [field: SerializeField]
        public string Name { set; get; }

        [field: SerializeField]
        [field: TextArea]
        public string Description { set; get; }

        [field: SerializeField]
        public Sprite ItemImage { set; get; }

    }
}