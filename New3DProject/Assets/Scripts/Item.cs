using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        MaleWeapon,
        Clothes,
    }
    public string Name { get; set; }
    public int Id { get; }
    public ItemType itemType { get; }
    public Sprite ItemIcon { get; }

    public Item(string name, int id, ItemType _itemType, string pathToIcon)
    {
        Name = name;
        Id = id;
        itemType = _itemType;
        ItemIcon = Resources.Load<Sprite>(pathToIcon);
    }
}
class MaleWeaponItem : Item
{
    public enum WeaponType
    {
        Knife,
        OneHandSword,
        TwoHandSword,
    }
    public WeaponType weaponType { get; }
    public float damage { get; set; }
    public GameObject itemPrefab { get; }
    public MaleWeaponItem(string name, int id, WeaponType _weaponType, string pathToIcon, float _damage, string pathToPrefab)
        : base(name, id, Item.ItemType.MaleWeapon, pathToIcon)
    {
        weaponType = _weaponType;
        damage = _damage;
        itemPrefab = Resources.Load<GameObject>(pathToPrefab);
    }
}

