using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InventorySystem {

    public class InventoryInputHandler : MonoBehaviour
    {
        private Inventory _inventory;

        private void Awake()
        {
            _inventory = GetComponent<Inventory>();
        }

        private void OnEnable()
        {
            
        }
        private void OnDisable()
        {

        }
        private void OnThrowItem(InputAction.CallbackContext ctx)
        {

        }
        private void OnNextItem(InputAction.CallbackContext ctx)
        {
            _inventory.ActivateSlot(_inventory.ActiveSlotIndex + 1);
        }
        private void OnPreviousItem(InputAction.CallbackContext ctx)
        {
            _inventory.ActivateSlot(_inventory.ActiveSlotIndex - 1);
        }
    }
}