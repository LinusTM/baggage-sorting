using System.Diagnostics;

namespace baggage_sorting;
internal abstract class Gate {
    internal Queue<Baggage> baggageBuffer = new Queue<Baggage>();
    private string destination;

    internal Gate(string destination) {
        this.destination = destination;
    }
}
