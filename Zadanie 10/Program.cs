using System;
using System.Collections.Generic;

public interface IObserver
{
    void Update(Dictionary<string, int> scores);
}

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void NotifyObservers();
}

public class Player : IObserver
{
    private string name;
    private ISubject game;

    public Player(string name, ISubject game)
    {
        this.name = name;
        this.game = game;
        game.Attach(this);
    }

    public void Update(Dictionary<string, int> scores)
    {
        Console.WriteLine($"{name}'s updated score board:");
        foreach (var score in scores)
        {
            Console.WriteLine($"Player: {score.Key}, Score: {score.Value}");
        }
        Console.WriteLine();
    }
}

public class Game : ISubject
{
    private List<IObserver> observers;
    private Dictionary<string, int> scores;

    public Game()
    {
        observers = new List<IObserver>();
        scores = new Dictionary<string, int>();
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(scores);
        }
    }

    public void SetScore(string playerName, int score)
    {
        if (scores.ContainsKey(playerName))
        {
            scores[playerName] = score;
        }
        else
        {
            scores.Add(playerName, score);
        }
        NotifyObservers();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game();

        Player player1 = new Player("Asia", game);
        Player player2 = new Player("Kasia", game);
        Player player3 = new Player("Basia", game);

        game.SetScore("Asia", 10);
        game.SetScore("Kasia", 15);
        game.SetScore("Basia", 8);
        game.SetScore("Asia", 20);
    }
}
