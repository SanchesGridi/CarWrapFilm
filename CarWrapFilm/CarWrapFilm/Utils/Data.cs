﻿using CarWrapFilm.Models;

namespace CarWrapFilm.Utils;

public static class Data
{
    public static List<FilmWrappingKit> GenerateKits() =>
        new()
        {
            new(1, "Минимум", 290, new[] { "Полоса на капот", "Полоса на крышу", "Фары" }),
            new(2, "Базовый", 375, new[] { "Полоса на капот", "Передние стойки", "Полоса на крышу", "Фары" }),
            new(3, "Стандарт", 875, new[] { "Капот полностью", "Передние крылья", "Передние стойки (лобового стекла)", "Полоса на крышу", "Фары" }),
            new(4, "Максимум", 3000, new[] { "Оклейка всего авто", "Конечная стоимость рассчитывается индивидуально" })
        };

    public static List<FilmWrappingKit> GenerateWorks() =>
        new()
        {
            new(5, "Багажник, зона погрузки", 50),
            new(6, "Глянцевые стойки дверей", 55),
            new(7, "Двери", 685),
            new(8, "Задняя часть арок", 85),
            new(9, "Зеркала", 85),
            new(10, "Зоны под ручками дверей, 4 штуки (маникюр)", 55),
            new(11, "Канты дверей, 4 штуки", 30),
            new(12, "Капот полностью", 360),
            new(13, "Низы дверей (20см)", 175),
            new(14, "Пароги, внутреняя часть, 4 штуки", 50),
            new(15, "Передние крылья", 260),
            new(16, "Передние стойки (лобового стекла)", 85),
            new(17, "Передний бампер", 400),
            new(18, "Передняя часть крыльев", 90),
            new(19, "Полоса на капот", 120),
            new(20, "Полоса на крышу", 85),
            new(21, "Фары", 85)
        };
}
