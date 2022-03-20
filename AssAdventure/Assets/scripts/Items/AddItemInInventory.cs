using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AddItemInInventory : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private int amount = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (!item) return;

        if (other.gameObject.TryGetComponent<PlayerInventory>(out PlayerInventory inventory))
        {
            if (inventory.AddItems(item,amount))
            {
                Destroy(gameObject);
            }
        }
    }

}
