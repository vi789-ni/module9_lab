using System;


public class AudioSystem
{
    public void TurnOn() => Console.WriteLine("Аудиосистема включена.");
    public void SetVolume(int level) => Console.WriteLine($"Громкость установлена на {level}.");
    public void TurnOff() => Console.WriteLine("Аудиосистема выключена.");
}

public class VideoProjector
{
    public void TurnOn() => Console.WriteLine("Видеопроектор включён.");
    public void SetResolution(string resolution) => Console.WriteLine($"Разрешение установлено: {resolution}.");
    public void TurnOff() => Console.WriteLine("Видеопроектор выключен.");
}

public class LightingSystem
{
    public void TurnOn() => Console.WriteLine("Освещение включено.");
    public void SetBrightness(int level) => Console.WriteLine($"Яркость установлена на {level}.");
    public void TurnOff() => Console.WriteLine("Освещение выключено.");
}

public class HomeTheaterFacade
{
    private AudioSystem _audioSystem;
    private VideoProjector _videoProjector;
    private LightingSystem _lightingSystem;

    public HomeTheaterFacade(AudioSystem audioSystem, VideoProjector videoProjector, LightingSystem lightingSystem)
    {
        _audioSystem = audioSystem;
        _videoProjector = videoProjector;
        _lightingSystem = lightingSystem;
    }

    public void StartMovie()
    {
        Console.WriteLine("\nПодготовка к просмотру фильма...");
        _lightingSystem.TurnOn();
        _lightingSystem.SetBrightness(5);
        _audioSystem.TurnOn();
        _audioSystem.SetVolume(8);
        _videoProjector.TurnOn();
        _videoProjector.SetResolution("HD");
        Console.WriteLine("Фильм запущен!\n");
    }

    public void EndMovie()
    {
        Console.WriteLine("\nЗавершение сеанса...");
        _videoProjector.TurnOff();
        _audioSystem.TurnOff();
        _lightingSystem.TurnOff();
        Console.WriteLine("Фильм завершён.\n");
    }
}

class Program
{
    static void Main(string[] args)
    {
        AudioSystem audio = new AudioSystem();
        VideoProjector video = new VideoProjector();
        LightingSystem lights = new LightingSystem();

        HomeTheaterFacade homeTheater = new HomeTheaterFacade(audio, video, lights);

        while (true)
        {
            Console.WriteLine(" Домашний кинотеатр ");
            Console.WriteLine("1 — Запустить фильм");
            Console.WriteLine("2 — Завершить фильм");
            Console.WriteLine("0 — Выход");
            Console.Write("Ваш выбор: ");
            string choice = Console.ReadLine();

            if (choice == "1")
                homeTheater.StartMovie();
            else if (choice == "2")
                homeTheater.EndMovie();
            else if (choice == "0")
                break;
            else
                Console.WriteLine("Неверный ввод. Попробуйте снова.\n");
        }
    }
}
