using System.Collections;
using RpgGameCs.Entity.Item;

namespace RpgGameCs.Inventory;

public interface IInventory : IItemContainer, IEnumerable<IItem>
{
    IEnumerator<IItem> IEnumerable<IItem>.GetEnumerator()
    {
        return GetContent().GetEnumerator(); 
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator(); 
    }

    bool IsEmpty();

    virtual bool IsNotEmpty() => !IsEmpty();
}