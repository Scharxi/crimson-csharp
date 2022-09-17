using RpgGameCs.Inventory;

namespace RpgGameCs.Item;

public interface IEquipable
{
    void Equip(ref PlayerInventory inv);
    void UnEquip(ref PlayerInventory inv); 
}