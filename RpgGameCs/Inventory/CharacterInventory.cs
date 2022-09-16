using RpgGameCs.Entity.Item;

namespace RpgGameCs.Inventory;

public class CharacterInventory : IInventory
{
    private Dictionary<uint, IItem> _localStorage;

    public CharacterInventory()
    {
        _localStorage = new Dictionary<uint, IItem>();
    }

    public IItem GetItem(uint slot)
    {
        return _localStorage[slot];
    }

    public void SetItem(uint slot, IItem item)
    {
        if (_localStorage.Count == 0)
            _localStorage[slot] = item;
        
        if (!_localStorage.ContainsKey(slot))
            return;
        _localStorage[slot] = item;
    }

    public Dictionary<uint, IItem> RemoveItem(params IItem[] items)
    {
        throw new NotImplementedException();
    }

    public void Clear(uint index)
    {
        _localStorage.Remove(index);
    }

    public void Clear()
    {
        _localStorage.Clear();
    }

    public void Remove(IItem item)
    {
        _localStorage.ToList().FindAll(pair => pair.Value == item)
            .ForEach(pair => { _localStorage.ToList().Remove(pair); });
    }

    public void Remove(Material material)
    {
        _localStorage.ToList().FindAll(pair => pair.Value.MaterialType == material)
            .ForEach(pair => { _localStorage.ToList().Remove(pair); });
    }

    public IEnumerable<IItem> GetContent()
    {
        return _localStorage.Values.ToList();
    }

    public void SetContent(IEnumerable<IItem> content)
    {
        _localStorage.Clear();
        for (uint i = 1; i <= 36; i++)
        {
            _localStorage.Add(i, content.ToArray()[i]);
        }
    }

    public Dictionary<uint, IItem> AddItem(params IItem[] items)
    {
        throw new NotImplementedException();
    }

    public bool IsEmpty() => _localStorage.Count == 0; 


}