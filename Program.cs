using System;
using System.Threading;
using System.Diagnostics;

namespace baggage_sorting;
class Program {
    // Shared resources
    static Queue<Baggage> counter = new Queue<Baggage>();
    static Queue<Baggage> terminal = new Queue<Baggage>();
    static Queue<Baggage> plane = new Queue<Baggage>();

    static void Main(string[] args) {

    }
}


// --- Baggage --- //
public class Baggage {
    static int baggageCount;

    private int id;
    private string destination;

    public Baggage(string destination) {
        baggageCount++;
        this.id = baggageCount;
        this.destination = destination;
    }
}


// --- Counter --- //
interface ICounter {
    Queue<Baggage> ProduceBaggage();
}

public abstract class Counter {
    private int number;
    private int countNumber;
    private string airline;
    private Queue<Baggage> baggageBuffer = new Queue<Baggage>();

    public Counter(string airline) {
        countNumber++;
        this.number = countNumber;
        this.airline = airline;
    }

    void ProduceBaggage(string airline) {
       while(true) {
            Monitor.Enter(baggageBuffer);
            try {
                while(baggageBuffer.Count == 3) {
                    Thread.Sleep(100/15);
                    Monitor.Wait(baggageBuffer);
                }

                if(Random.Shared.Next(0,100) == 14) {
                    Baggage baggage = new Baggage(airline);
                    baggageBuffer.Enqueue(baggage);

                    Debug.WriteLine($"{airline} has added baggage to their {baggageBuffer}");
                }
                
                Monitor.PulseAll(baggageBuffer);
            }
            finally {
                Monitor.Exit(baggageBuffer);
            }
        } 
    }
}

public class DefaultAirline : Counter {
    DefaultAirline() : base("default") { }
}


// --- Terminal --- //
