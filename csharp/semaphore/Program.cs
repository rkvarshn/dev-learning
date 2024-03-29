﻿class TheClub // No door lists!
{
    static SemaphoreSlim _sem = new SemaphoreSlim(3); // Capacity of 3
    static void Main()
    {
        for (int i = 1; i <= 5; i++)
        {
            int id = i;
            new Thread(() => {
                Enter(id);
            }).Start();
        }
    }
    static void Enter(object id)
    {
        Console.WriteLine(id + " wants to enter");
        _sem.Wait();
        Console.WriteLine(id + " is in!"); // Only three threads
        Thread.Sleep(1000 * (int)id); // can be here at
        Console.WriteLine(id + " is leaving"); // a time.
        _sem.Release();
    }
}
