using RpgGameCs.Entity;
using RpgGameCs.Entity.Item;

namespace RpgGameCs.Inventory;

public abstract class AbstractInventory : IInventory
{
    private readonly Dictionary<uint, IItem> _localStorage;

    protected AbstractInventory()
    {
        _localStorage = new Dictionary<uint, IItem>();
    }


    /// <summary>
    /// Returns the Item found in the slot at the given index
    /// </summary>
    /// <param name="slot">The index of the Slot's Item to return</param>
    /// <returns>The Item in the slot</returns>
    public IItem GetItem(uint slot)
    {
        return _localStorage[slot];
    }

    /// <summary>
    /// Stores the Item at the given index of the inventory.
    /// </summary>
    /// <param name="slot">The index where to put the Item</param>
    /// <param name="item">The Item to set</param>
    public void SetItem(uint slot, IItem item)
    {
        if (_localStorage.Count == 0)
            _localStorage[slot] = item;

        if (!_localStorage.ContainsKey(slot))
            return;
        _localStorage[slot] = item;
    }

    /// <summary>
    /// Clears out a particular slot in the index.
    /// </summary>
    /// <param name="index">The index to empty.</param>
    public void Clear(uint index)
    {
        _localStorage.Remove(index);
    }

    /// <summary>
    /// Clears out the whole Inventory.
    /// </summary>
    public void Clear()
    {
        _localStorage.Clear();
    }

    /// <summary>
    /// <para>Removes all stacks in the inventory matching the given stack.</para>
    /// <para>This will only match a slot if both the type and the amount of the stack match</para>
    /// </summary>
    /// <param name="item">The Item to match against</param>
    public void Remove(IItem item)
    {
        _localStorage.ToList().FindAll(pair => pair.Value == item)
            .ForEach(pair => { _localStorage.ToList().Remove(pair); });
    }

    /// <summary>
    /// Removes all stacks in the inventory matching the given material.
    /// </summary>
    /// <param name="material">The material to remove</param>
    public void Remove(Material material)
    {
        _localStorage.ToList().FindAll(pair => pair.Value.MaterialType == material)
            .ForEach(pair => { _localStorage.ToList().Remove(pair); });
    }

    /// <summary>
    /// Returns all Items from the inventory
    /// </summary>
    /// <returns>An Enumerable of Items from the inventory</returns>
    public IEnumerable<IItem> GetContent()
    {
        return _localStorage.Values.ToList();
    }

    /// <summary>
    /// Completely replaces the inventory's contents. Removes all existing contents and replaces it with the Items given in the array.
    /// </summary>
    /// <param name="content">A complete replacement for the contents; the length must be less than or equal to Size.</param>
    public void SetContent(IEnumerable<IItem> content)
    {
        _localStorage.Clear();
        for (uint i = 1; i <= 36; i++)
        {
            _localStorage.Add(i, content.ToArray()[i]);
        }
    }

    /// <summary>
    /// Returns whether the inventory is empty 
    /// </summary>
    /// <returns>True if the count of the private local storage is 0, false otherwise</returns>
    public bool IsEmpty() => _localStorage.Count == 0;
}