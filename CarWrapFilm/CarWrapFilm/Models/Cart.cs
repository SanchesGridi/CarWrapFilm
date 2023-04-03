namespace CarWrapFilm.Models;

public class Cart
{
    private readonly List<CartLine> _lines;

    public Cart() => _lines = new List<CartLine>();

    public void Add(int positionId)
    {
        var line = _lines.FirstOrDefault(x => x.GetPositionId() == positionId);
        if (line != null)
        {
            line.Add(1);
        }
        else
        {
            _lines.Add(new CartLine(positionId));
        }
    }
    
    public void Remove(int positionId)
    {
        var line = _lines.FirstOrDefault(x => x.GetPositionId() == positionId);
        line?.Remove(1);
    }

    public List<CartLine> GetCartLines() => _lines;
}
