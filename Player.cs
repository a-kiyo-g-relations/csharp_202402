using System;
using System.Linq;

public class Player
{
    // サイコロの出目から役を判定するための値   
    public enum DetermineValue
    {
        One = 1,
        Two = 2
    }

    Dice dice = new Dice();

    // サイコロの乱数を保持するための配列
    private int[] diceValue = new int[3];

    // 指定の数ループし、取得した値を保持
    public void LoopCountNumber()
    {
        int count = 3;
        for (int i = 0; i < count; i++)
        {
            dice.RollDice();
            diceValue[i] = dice.GetValue();
        }
    }

    // 前回の出目を取得する
    public int[] GetValue()
    {
        return diceValue;
    }

    // サイコロの出目の役を判定する
    public int DetermineDicPip(int[] numbers)
    {
        if (numbers.Distinct().Count() == (int)DetermineValue.One)
        {
            return 2;
        }
        else if (numbers.Distinct().Count() == (int)DetermineValue.Two)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}

