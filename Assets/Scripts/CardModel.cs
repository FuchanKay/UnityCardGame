using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.Rendering.Universal.Internal;
public enum Type
{
    Arcane,
    Hemo,
    Holy,
    Unholy,
    Empty,
    Blight
}

public abstract class CardModel
{
    private const int MAX_UPGRADE_NUM = 5;

    protected GameModel game;
    public bool selected = false;
    public Type type;
    public string letter;
    public int level;

    public bool hasDrawEffect = false;

    public bool hasRetainEffect = false;

    public bool hasDiscardEffect = false;

    public bool hasSwapEffect = false;

    public abstract string GenerateDescription();

    public abstract void WhenDrawn();

    public abstract void WhenRetained();

    public abstract void whenDiscarded();

    public abstract void Upgrade();

    public abstract void Unupgrade();

    public abstract void Reset();

}

//for empty card slots in hand
public class CardModelEmpty : CardModel
{
    public CardModelEmpty()
    {
        this.type = Type.Empty;
        this.letter = "";
    }

    public override string GenerateDescription()
    {
        return "";
    }

    public override void Reset()
    {
        throw new System.NotImplementedException();
    }

    public override void Unupgrade()
    {
        throw new System.NotImplementedException();
    }

    public override void Upgrade()
    {
        throw new System.NotImplementedException();
    }

    public override void whenDiscarded()
    {
        throw new System.NotImplementedException();
    }

    public override void WhenDrawn()
    {
        throw new System.NotImplementedException();
    }

    public override void WhenRetained()
    {
        throw new System.NotImplementedException();
    }

}


//gives X resources when drawn. no special effects 
public class CardModelA : CardModel
{
    private int[] upgrades = { 2, 3, 4, 6, 8 };
    private int whenDrawnNum;
    public CardModelA(GameModel game, Type type, int level = 1)
    {
        this.game = game;
        this.type = type;
        this.letter = "A";
        this.level = level;

        this.whenDrawnNum = upgrades[this.level - 1];
        
        this.hasDrawEffect = true;

    }

    public override string GenerateDescription()
    {
        return $"When Drawn, Draw {whenDrawnNum} {type.ToString()}";
    }

    public override void Reset()
    {
        return;
    }

    public override void Unupgrade()
    {
        if (this.level > 1)
        {
            this.level--;
            this.whenDrawnNum = upgrades[this.level - 1];
        }
    }

    public override void Upgrade()
    {
        if (this.level < Constants.maxCardLevel)
        {
            this.level++;
            this.whenDrawnNum = upgrades[this.level - 1];
        }
    }

    public override void whenDiscarded()
    {
        throw new System.NotImplementedException();
    }

    public override void WhenDrawn()
    {
        this.game.AddResourceQ(this.type, whenDrawnNum);
    }

    public override void WhenRetained()
    {
        throw new System.NotImplementedException();
    }
}

// gives X resources and does X damage to a random when drawn
public class CardModelB : CardModel
{
    private int[] resUpgrades = {1, 2, 3, 4, 5};
    private int[] dmgUpgrades = {2, 4, 6, 9, 12};
    private int whenDrawnNum;
    private int dmgNum;

    public CardModelB(GameModel game, Type type, int level = 1)
    {
        this.game = game;
        this.letter = "B";
        this.type = type;
        this.level = level;

        this.hasDrawEffect = true;

        this.whenDrawnNum = resUpgrades[level - 1];
        this.dmgNum = resUpgrades[level - 1];
    }

    public override string GenerateDescription()
    {
        return $"When Drawn: Gain {whenDrawnNum} {this.type.ToString()} and Deal {dmgNum} Damage to a random enemy";
    }

    public override void Reset()
    {
        return;
    }

    public override void Unupgrade()
    {
        if (this.level > 1)
        {
            this.level--;
            this.whenDrawnNum = resUpgrades[this.level - 1];
            this.dmgNum = dmgUpgrades[this.level - 1];
        }
    }

    public override void Upgrade()
    {
        if (this.level < Constants.maxCardLevel)
        {
            this.level++;
            this.whenDrawnNum = resUpgrades[this.level - 1];
            this.dmgNum = dmgUpgrades[this.level - 1];
        }
    }

    public override void whenDiscarded()
    {
        throw new System.NotImplementedException();
    }

    public override void WhenDrawn()
    {
        this.game.AddResourceQ(this.type, this.whenDrawnNum);
        this.game.RandomDamageQ(this.dmgNum);
    }

    public override void WhenRetained()
    {
        throw new System.NotImplementedException();
    }
}

//Does not give resources when drawn. Every X times this card is drawn, draw another card. useful for filling up hand
public class CardModelC : CardModel
{
    //TODO: Reset this back to 3
    private int[] frequencyUpgrades = {3, 3, 2, 2, 1};
    private int frequency;
    private int countTemp;
    private bool firstTimeTemp;
    public CardModelC(GameModel game, Type type, int level = 1)
    {
        this.game = game;
        this.type = type;
        this.letter = "C";
        this.level = level;

        this.hasDrawEffect = true;

        this.firstTimeTemp = true;
        this.countTemp = 0;

        this.frequency = frequencyUpgrades[this.level - 1];

    }


    public override string GenerateDescription()
    {
        string description;
        if (this.frequency > 1)
        {
            description = $"When Drawn: Every {frequency} Times This Card is Drawn, Draw Another Card (Current: {countTemp % frequency})";
        }
        else
        {
            description = "When Drawn: Draw Another Card";
        }
        return description;
    }

    public override void Reset()
    {
        this.countTemp = 0;
        this.firstTimeTemp = true;
    }

    public override void Unupgrade()
    {
        if (this.level > 1)
        {
            this.level--;
            this.frequency = frequencyUpgrades[this.level - 1];
        }
    }

    public override void Upgrade()
    {
        if (this.level < Constants.maxCardLevel)
        {
            this.level++;
            this.frequency = frequencyUpgrades[this.level - 1];
        }
    }

    public override void whenDiscarded()
    {
        throw new System.NotImplementedException();
    }

    public override void WhenDrawn()
    {
        bool drawExtra = false;
        countTemp++;
        if ((countTemp % frequency == 0 && !firstTimeTemp) || frequency == 1)
        {
            countTemp = 0;
            firstTimeTemp = false;
            drawExtra = true;
        }
        firstTimeTemp = false;
        if (drawExtra)
        {
            game.DrawCardQ();
        }

    }

    public override void WhenRetained()
    {
        throw new System.NotImplementedException();
    }
}

public class CardModelD : CardModel 
{
    private int[] discardUpgrades = {3, 4, 6, 8, 11};
    private int discardNum;

    public CardModelD(GameModel game, Type type, int level = 1)
    {
        this.game = game;
        this.type = type;
        this.level = level;
        this.letter = "D";

        this.discardNum = discardUpgrades[this.level - 1];
        this.hasDiscardEffect = true;

    }

    public override string GenerateDescription()
    {
        return $"When Discarded: Gain {this.discardNum} {type.ToString()}";
    }

    public override void Reset()
    {
        return;
    }

    public override void Unupgrade()
    {
        if (this.level > 1)
        {
            this.level--;
            this.discardNum = discardUpgrades[this.level - 1];
        }
    }

    public override void Upgrade()
    {
        if (this.level < Constants.maxCardLevel)
        {
            this.level++;
            this.discardNum = discardUpgrades[this.level - 1];
        }
    }

    public override void whenDiscarded()
    {
        this.game.AddResourceQ(this.type, discardNum);
    }

    public override void WhenDrawn()
    {
        throw new System.NotImplementedException();
    }

    public override void WhenRetained()
    {
        throw new System.NotImplementedException();
    }
}

