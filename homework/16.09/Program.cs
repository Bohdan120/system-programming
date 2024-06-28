using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        int n = 5; // Кількість стільців для очікування клієнтів
        var barberChair = new SemaphoreSlim(1); // Семафор для крісла перукаря
        var waitingChairs = new SemaphoreSlim(n); // Семафор для стільців очікування
        var clientsQueue = new ConcurrentQueue<int>(); // Черга клієнтів

        var barberTask = Task.Run(async () =>
        {
            while (true)
            {
                await waitingChairs.WaitAsync(); // Перукар займає стілець очікування, якщо він вільний
                Console.WriteLine("Barber is awake and waiting for a client.");
                await barberChair.WaitAsync(); // Перукар займає своє крісло
                int clientId;
                if (clientsQueue.TryDequeue(out clientId))
                {
                    Console.WriteLine($"Barber is cutting hair for client {clientId}.");
                    await Task.Delay(TimeSpan.FromSeconds(new Random().Next(1, 5))); // Час стрижки
                    Console.WriteLine($"Barber finished cutting hair for client {clientId}.");
                    barberChair.Release(); // Перукар звільняє своє крісло
                    waitingChairs.Release(); // Перукар звільняє стілець очікування
                }
                else
                {
                    Console.WriteLine("Barber falls asleep because there are no clients.");
                    barberChair.Release(); // Перукар звільняє своє крісло
                    await Task.Delay(TimeSpan.FromSeconds(1)); // Перукар спить
                }
            }
        });

        var clientTasks = new Task[10]; // Кількість клієнтів

        for (int i = 0; i < clientTasks.Length; i++)
        {
            int clientId = i + 1;
            clientTasks[i] = Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(new Random().Next(1, 10))); // Випадковий час приходу клієнта
                if (waitingChairs.Wait(0)) // Клієнт перевіряє наявність вільних стільців очікування
                {
                    Console.WriteLine($"Client {clientId} enters the barber shop and sits in a waiting chair.");
                    clientsQueue.Enqueue(clientId); // Клієнт додається до черги
                    barberChair.Release(); // Клієнт будить перукаря
                }
                else
                {
                    Console.WriteLine($"Client {clientId} leaves because there are no available waiting chairs.");
                }
            });
        }

        await Task.WhenAll(clientTasks);
    }
}
