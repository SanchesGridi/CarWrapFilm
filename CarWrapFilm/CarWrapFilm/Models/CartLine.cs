namespace CarWrapFilm.Models;

public class CartLine
{
    private readonly int _positionId;

    private uint _quantity;

    public CartLine(int positionId)
    {
        _positionId = positionId;
        _quantity = 0;
    }

    public int GetPositionId() => _positionId;

    public (int PositionId, uint Quantity) Get() => (_positionId, _quantity);

    public void Add(uint quantity) => _quantity += quantity;

    public void Remove(uint quantity) => _quantity -= quantity;
}
