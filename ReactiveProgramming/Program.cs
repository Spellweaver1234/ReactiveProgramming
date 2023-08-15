using System.Reactive.Linq;

//Создаём Observable последовательность:
var numbers = new int[] { 1, 2, 3, 4, 5 };
var observable = numbers.ToObservable();

//Подписываемся на события, чтобы получать данные:
var subscription = observable
    .Subscribe(
    x => Console.WriteLine($"Next: {x}"), // Действие при получении нового элемента
    ex => Console.WriteLine($"Error: {ex}"), // Действие при возникновении ошибки
    () => Console.WriteLine("Completed")); // Действие при завершении потока данных

//Выполните некоторые операции над данными, используя операторы Rx, например, фильтрацию и преобразование:
var filtered = observable.Where(x => x % 2 == 0);
var transformed = filtered.Select(x => x * 2);

//Подпишитесь на преобразованные данные:
var subscription2 = transformed
    .Subscribe(
    x => Console.WriteLine($"Transformed: {x}"),
    ex => Console.WriteLine($"Error: {ex}"),
    () => Console.WriteLine("Transformation completed"));

//Не забывайте отменять подписки при необходимости:
subscription.Dispose();
subscription2.Dispose();