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
    Empty,
    Blight
}

public class CardModel
{
    public Type type;
    public Letter letter;

    public bool selected = false;

    //amount of runes gained when card is drawn
    public int drawnNum;
    //event that is executed when card is drawn
    public Event? whenDrawn;
    public string drawnDescription;
        
    //determines whether card has a retain effect
    public bool retain;
    public Event? whenRetained;
    public string retainedDescription;

    //determines whether card has a discard effect
    public bool discard;
    public Event? whenDiscarded;
    public string discardedDescription;

    //determines whether card has a swap effect
    public bool swap;
    public Event? whenSwapped;
    public string swappedDescription;

    public CardModel (
        Type type, Letter letter = Letter.A,
        int drawnNum = 1, Event whenDrawn = null, string drawnDescription = "",
        bool retain = false, Event whenRetained = null, string retainedDescription = "",
        bool discard = false, Event whenDiscarded = null, string discardedDescription = "",
        bool swap = false, Event whenSwapped = null, string swappedDescription = "")
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
