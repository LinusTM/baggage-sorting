using System;
using System.Threading;
using System.Diagnostics;

namespace baggage_sorting;
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
