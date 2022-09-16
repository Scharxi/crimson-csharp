using RpgGameCs.Entity.Item;

namespace RpgGameCs.Inventory;

public interface IItemContainer
{
    IItem GetItem(uint slot);
    void SetItem(uint slot, IItem item);
    Dictionary<uint, IItem> RemoveItem(params IItem[] items);

    void Clear(uint index);
    void Clear(); 

    void Remove(IItem item);
    void Remove(Material material);

    IEnumerable<IItem> GetContent();
    void SetContent(IEnumerable<IItem> content);
    Dictionary<uint, IItem> AddItem(params IItem[] items);
}