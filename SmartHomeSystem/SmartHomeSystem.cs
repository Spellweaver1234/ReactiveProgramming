using System.Reactive.Linq;

namespace SmartHomeSystem;

public class SmartHomeSystem
{
    public IObservable<bool> MotionSensor { get; set; }
    public IObservable<bool> LightSwitch { get; set; }

    public SmartHomeSystem()
    {
        // Имитация данных от датчиков
        MotionSensor = Observable
            .Interval(TimeSpan.FromSeconds(1))
            .Select(x => x % 2 == 0);

        LightSwitch = Observable
            .Interval(TimeSpan.FromSeconds(2))
            .Select(x => x % 2 == 0);
    }

    public void Start()
    {
        var automation = LightSwitch
            .CombineLatest(MotionSensor, (l, m) => new { LightSwitch = l, MotionSensor = m })
            .Throttle(TimeSpan.FromSeconds(1))
            .DistinctUntilChanged()
            .Subscribe(
            onNext: data =>
            {
                if (data.MotionSensor && data.LightSwitch)
                {
                    Console.WriteLine("Включение света во время движения");
                }
                else if (!data.MotionSensor && !data.LightSwitch)
                {
                    Console.WriteLine("Выключение света после окончания движения");
                }
            },
            onError: ex => Console.WriteLine(ex.Message),
            onCompleted: () => Console.WriteLine("Completed"));

        // Остановка системы через 10 секунд
        Observable
            .Timer(TimeSpan.FromSeconds(10))
            .Subscribe(_ => automation.Dispose());
    }
}