using RpgGameCs.Entity.Item;

namespace RpgGameCs.Inventory;

public interface IItemContainer
{
    /// <summary>
    /// Returns the Item found in the slot at the given index
    /// </summary>
    /// <param name="slot">The index of the Slot's Item to return</param>
    /// <returns>The Item in the slot</returns>
    IItem GetItem(uint slot);

    /// <summary>
    /// Stores the Item at the given index of the inventory.
    /// </summary>
    /// <param name="slot">The index where to put the Item</param>
    /// <param name="item">The Item to set</param>
    void SetItem(uint slot, IItem item);

    /// <summary>
    /// Clears out a particular slot in the index.
    /// </summary>
    /// <param name="index">The index to empty.</param>
    void Clear(uint index);

    /// <summary>
    /// Clears out the whole Inventory.
    /// </summary>
    void Clear();

    /// <summary>
    /// <para>Removes all stacks in the inventory matching the given stack.</para>
    /// <para>This will only match a slot if both the type and the amount of the stack match</para>
    /// </summary>
    /// <param name="item">The Item to match against</param>
    void Remove(IItem item);

    /// <summary>
    /// Removes all stacks in the inventory matching the given material.
    /// </summary>
    /// <param name="material">The material to remove</param>
    void Remove(Material material);

    /// <summary>
    /// Returns all Items from the inventory
    /// </summary>
    /// <returns>An Enumerable of Items from the inventory</returns>
    IEnumerable<IItem> GetContent();

    /// <summary>
    /// Completely replaces the inventory's contents. Removes all existing contents and replaces it with the Items given in the array.
    /// </summary>
    /// <param name="content">A complete replacement for the contents; the length must be less than or equal to Size.</param>
    void SetContent(IEnumerable<IItem> content);
}