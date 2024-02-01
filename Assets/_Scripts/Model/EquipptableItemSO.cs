using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    public class EquipptableItemSO : ItemSO, IItemAction, IDestoryableItem
    {
        [SerializeField]
        private List<ModifierData> modifierDatas = new List<ModifierData>();
        public string ActionName => "Equip";

        public AudioClip actionSFX { get; private set; }

        public bool PerformAction(GameObject character, List<ItemParameter> itemState = null)
        {
            foreach (ModifierData data in modifierDatas)
            {
                data.statModifier.AffectCharacter(character, data.value);
            }
            return true;
        }
    }
}