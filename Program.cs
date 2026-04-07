using Frameworks2.Core;
using System.Reflection;

// 1. Чтение списка модулей из файла настроек
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
    .Build();

var enabled = configuration.GetSection("Modules").Get<string[]>() ?? Array.Empty<string>();

try
{
    // 2. Обнаружение и построение порядка
    var discovered = ModuleCatalog.DiscoverFromAssembly(Assembly.GetExecutingAssembly());
    var ordered = ModuleCatalog.BuildExecutionOrder(discovered, enabled);

    var services = new ServiceCollection();

    // 3. Регистрация служб
    foreach (var module in ordered)
    {
        module.RegisterServices(services);
    }

    var provider = services.BuildServiceProvider();

    // 4. Инициализация
    foreach (var module in ordered)
    {
        await module.InitializeAsync(provider, CancellationToken.None);
    }

    // 5. Выполнение действий
    var actions = provider.GetServices<IAppAction>().ToArray();

    Console.WriteLine("--- Запуск действий модулей ---");
    foreach (var action in actions)
    {
        Console.WriteLine($"\n>> Выполняется: {action.Title}");
        await action.ExecuteAsync(CancellationToken.None);
    }
}
catch (ModuleLoadException ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"ОШИБКА ЗАГРУЗКИ МОДУЛЕЙ: {ex.Message}");
    Console.ResetColor();
}