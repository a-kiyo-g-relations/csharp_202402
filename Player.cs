using System;
using System.Linq;

public class Player
{
    // サイコロの出目から役を判定するための値   
    public enum RoleDecision
    {
        One = 1,
        Two = 2
    }

    //サイコロの乱数を保持するための配列
    private int[] diceValue = new int[3];

    Dice dice = new Dice();

    // 指定の数ループし、取得した値を保持
    public void GenerateRandomNumbers()
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
    public int EvaluateHand(int[] numbers)
    {
        if (numbers.Distinct().Count() == (int)RoleDecision.One)
        {
            return 2; // 全ての値が一致する場合
        }
        else if (numbers.Distinct().Count() == (int)RoleDecision.Two)
        {
            return 1; // 二つの値が一致する場合
        }
        else
        {
            return 0; // 全ての値が一致しない場合
        }
    }
}

