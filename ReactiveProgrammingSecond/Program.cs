using System.Reactive.Linq;

// Создаем источник данных
var numbers = Observable.Range(1, 10);

// Применяем операторы Rx (выбираем каждый второй и умножаем его на 2 )
var evenNumbers = numbers
    .Where(x => x % 2 == 0)
    .Select(x => x * 2);

// Подписываемся на результат
var subscription = evenNumbers
    .Subscribe(
    onNext: x => Console.WriteLine($"Next: {x}"),
    onError: ex => Console.WriteLine($"Error: {ex.Message}"),
    onCompleted: () => Console.WriteLine("Completed"));


// Освобождаем ресурсы
subscription.Dispose();