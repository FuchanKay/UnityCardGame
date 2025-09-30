
using UnityEditor.Experimental.GraphView;

public class ResourceCount
{
    public int arcaneCount;
    public int hemoCount;
    public int holyCount;
    public int unholyCount;

    public ResourceCount(int initArcane = 0, int initHemo = 0, int initHoly = 0, int initUnholy = 0)
    {
        arcaneCount = initArcane;
        hemoCount = initHemo;
        holyCount = initHoly;
        unholyCount = initUnholy;
    }
    public void AddResource(Type type, int num)
    {
        if (type == Type.Arcane)
        {
            arcaneCount += num;
        }
        else if (type == Type.Hemo)
        {
            hemoCount += num;
        }
        else if (type == Type.Holy) {
            holyCount += num;
        }
        else
        {
            unholyCount += num;
        }
    }
}