namespace baggage_sorting;
internal class Baggage {
    static int baggageCount;

    private int id;
    private string destination;
    
    internal string Destination { get => destination; }

    internal Baggage() {
        baggageCount++;
        this.id = baggageCount;
        this.destination = destinationRnd();
    }

    private string destinationRnd() {
        switch(Random.Shared.Next(0,4)) {
            case 0:
                return "Amsterdam";
            case 1:
                return "Washington";
            case 2:
                return "Columbus";
            default:
                return "Portugal";
        }
    }
}
