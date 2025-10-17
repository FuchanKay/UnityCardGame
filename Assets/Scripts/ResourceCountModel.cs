    
using UnityEditor.Experimental.GraphView;

public class ResourceCountModel
{
    private int CAP = Constants.resourceCap;
    private GameModel game;
    public int arcaneCount;
    public int hemoCount;
    public int holyCount;
    public int unholyCount;

    public ResourceCountModel(GameModel game)
    {
        this.New(game);
    }

    public void New(GameModel game)
    {
        this.game = game;
        arcaneCount = 0;
        hemoCount = 0;
        holyCount = 0;
        unholyCount = 0;
    }

    public void AddResource(Type type, int num)
    {
        if (type == Type.Arcane)
        {
            arcaneCount += num;
            if (arcaneCount < 0) arcaneCount = 0;
            if (arcaneCount > CAP) arcaneCount = CAP;
        }
        else if (type == Type.Hemo)
        {
            hemoCount += num;
            if (hemoCount < 0) hemoCount = 0;
            if (hemoCount > CAP) hemoCount = CAP;
        }
        else if (type == Type.Holy)
        {
            holyCount += num;
            if (holyCount < 0) holyCount = 0;
            if (holyCount > CAP) holyCount = CAP;
        }
        else if (type == Type.Unholy)
        {
            unholyCount += num;
            if (unholyCount < 0) unholyCount = 0;
            if (unholyCount > CAP) unholyCount = CAP;
        }
    }

    public void SetToZero(Type type)
    {
        if (type == Type.Arcane)
        {
            arcaneCount = 0;
        }
        else if (type == Type.Hemo)
        {
            hemoCount = 0;
        }
        else if (type == Type.Holy)
        {
            holyCount = 0;
        }
        else if (type == Type.Unholy)
        {
            unholyCount = 0;
        }
    }
}