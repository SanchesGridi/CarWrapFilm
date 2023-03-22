namespace CarWrapFilm.Models;

public class FilmWrappingKit
{
    private readonly string _name;
    private readonly uint _price;
    private readonly string[]? _composition;

    public string Name => _name;
    public uint Price => _price;
    public string[]? Composition => _composition;

    public FilmWrappingKit(string name, uint price, string[]? composition = null)
    {
        _name = name;
        _price = price;
        _composition = composition;
    }
}
