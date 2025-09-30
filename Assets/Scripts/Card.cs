public enum Letter
{
    A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z
}

public enum Type
{
    Arcane,
    Hemo,
    Holy,
    Unholy,
    Blight
}

public class Card
{
    public Type type;
    public Letter letter;

    public int drawnNum;
    public Event whenDrawn;
    public string drawnDescription;
        
    public bool retain;
    public Event? whenRetained;
    public string? retainedDescription;

    public bool discard;
    public Event? whenDiscarded;
    public string? discardedDescription;

    public bool swap;
    public Event? whenSwapped;
    public string? swappedDescription;

    public Card (
        Type type, Letter letter,
        int drawnNum, Event whenDrawn, string drawnDescription,
        bool retain = false, Event whenRetained = null, string retainedDescription = null,
        bool discard = false, Event whenDiscarded = null, string discardedDescription = null,
        bool swap = false, Event whenSwapped = null, string swappedDescription = null)
    {
        this.type = type;
        this.letter = letter;

        this.drawnNum = drawnNum;
        this.whenDrawn = whenDrawn;
        this.drawnDescription = drawnDescription;

        this.retain = retain;
        this.whenRetained = whenRetained;
        this.retainedDescription = retainedDescription;

        this.discard = discard;
        this.whenDiscarded = whenDiscarded;
        this.discardedDescription = discardedDescription;

        this.swap = swap;
        this.whenSwapped = whenSwapped;
        this.swappedDescription = swappedDescription;
    }
}
