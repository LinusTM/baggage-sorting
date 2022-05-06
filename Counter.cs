using System;
using System.Threading;
using System.Diagnostics;

namespace baggage_sorting;
internal abstract class Counter {
    private int number;
    private int countNumber;
    protected string airline;
    private Queue<Baggage> baggageBuffer = new Queue<Baggage>();

    internal Counter(string airline) {
        countNumber++;
        this.number = countNumber;
        this.airline = airline;
    }

    internal virtual void ProduceBaggage(string airline) {
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

internal class DefaultAirline : Counter {
    internal DefaultAirline() : base("default") { }
    override internal void ProduceBaggage(string airline) { }
}

internal class KLM : Counter {
    internal KLM() : base("KLM") { }
    override internal void ProduceBaggage(string airline) { }
}

internal class SAS : Counter {
    internal SAS() : base("SAS") { }
    override internal void ProduceBaggage(string airline) { }
}

internal class TAP: Counter {
    internal TAP() : base("TAP") { }
    override internal void ProduceBaggage(string airline) { }
}
