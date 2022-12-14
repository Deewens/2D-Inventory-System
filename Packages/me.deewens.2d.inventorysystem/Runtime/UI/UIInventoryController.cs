using System;
using InventorySystem.Interfaces;
using InventorySystem.ScriptableObjects;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InventorySystem.UI
{
    /// <summary>
    /// Instantiate and manage the Inventory attached to any GameObject that needs an inventory with a UI
    /// </summary>
    public class UIInventoryController : MonoBehaviour
    {
        // TODO: Create a base InventoryController class that can be attached to GameObject that does not need any UI

        // ReSharper disable once InconsistentNaming
        [SerializeField] protected UIInventory UIInventory;
        [SerializeField] private bool isActiveOnStart = true;
        [SerializeField] private InputAction openCloseInventoryAction;

        [field: SerializeField] public InventorySO InventorySO { get; private set; }

        protected virtual void Start()
        {
            // Instantiate an empty inventory when starting the game
            if (UIInventory != null)
            {
                UIInventory.Inventory = InventorySO;
                UIInventory.gameObject.SetActive(isActiveOnStart);
            }

            openCloseInventoryAction.performed += OnOpenInventory;
        }

        private void OnEnable()
        {
            openCloseInventoryAction.Enable();
        }

        private void OnDisable()
        {
            openCloseInventoryAction.Disable();
        }

        private void OnOpenInventory(InputAction.CallbackContext ctx)
        {
            if (UIInventory.gameObject.activeSelf)
            {
                UIInventory.Hide();
            }
            else
            {
                UIInventory.Show();
            }
        }
    }
}