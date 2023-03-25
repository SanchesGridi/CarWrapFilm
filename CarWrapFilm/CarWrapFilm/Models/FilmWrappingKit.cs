namespace CarWrapFilm.Models;

public class FilmWrappingKit
{
    private readonly uint _id;
    private readonly string _name;
    private readonly uint _price;
    private readonly string[]? _composition;

    public uint Id => _id;
    public string Name => _name;
    public uint Price => _price;
    public string[]? Composition => _composition;

    public FilmWrappingKit(uint id, string name, uint price, string[]? composition = null)
    {
        _id = id;
        _name = name;
        _price = price;
        _composition = composition;
    }
}
