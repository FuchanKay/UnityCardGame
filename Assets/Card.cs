namespace Card;
using System;
using Event;

public enum Type
{
    Arcane = "Arcane",
    Hemo = "Hemo",
    Holy = "Holy",
    Unholy = "Unholy",
    Blight = "Blight"
}

public enum Letter
{
    A = "A",
    B = "B",
    C = "C",
    D = "D",
    E = "E",
    F = "F",
    G = "G",
    H = "H",
    I = "I",
    J = "J",
    K = "K",
    L = "L",
    M = "M",
    N = "N",
    O = "O",
    P = "P",
    Q = "Q",
    R = "R",
    S = "S",
    T = "T",
    U = "U",
    V = "V",
    W = "W",
    X = "X",
    Y = "Y",
    Z = "Z"
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
        this.whenRetainedDescription = retainedDescription;

        this.discard = discard;
        this.whenDiscarded = whenDiscarded;
        this.discardedDescription = discardedDescription;

        this.swap = swap;
        this.whenSwapped = whenSwapped;
        this.swappedDescription = swappedDescription;
    }
}
