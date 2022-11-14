using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
    public class InventorySO : ScriptableObject
    {
        [SerializeField] private List<InventoryItem> inventoryItems;

        [field: SerializeField] public int Size { get; private set; } = 10;

        public void Initialise()
        {
            inventoryItems = new List<InventoryItem>();
            for (int i = 0; i < Size; i++)
            {
                inventoryItems.Add(new InventoryItem());
            }
        }
    }

    [SerializeField]
    public struct InventoryItem
    {
        /// <summary>
        /// Item data stored in the inventory
        /// </summary>
        public ItemSO ItemData;

        /// <summary>
        /// Quantity of this item stored in the inventory
        /// </summary>
        public int Quantity;

        public InventoryItem SetQuantity(int newQuantity)
        {
            return new InventoryItem
            {
                ItemData = this.ItemData,
                Quantity = newQuantity
            };
        }
    }
}