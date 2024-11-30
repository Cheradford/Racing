
using System.ComponentModel;
using System.Reflection;

namespace Racing.View.UserInterface.Screens;

public enum ScreenType
{
    [Description("Выход")]
    None,
    [Description("Главное меню")]
    MainMenu,
    [Description("Выбор типа гонки")]
    RaceType,
    [Description("Определение дистанции")]
    RaceDistance,
    [Description("Выбор гонщиков")]
    RacersPeek,
    [Description("Гонка")]
    Racing,
    [Description("Итоги")]
    Summary,
    [Description("Ошибка")]
    Error,
    [Description("Тестовое окно")]
    Test
}