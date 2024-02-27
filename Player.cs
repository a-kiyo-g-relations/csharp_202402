using System;
using System.Linq;

public class Player
{
    // 役を決めるための出目の種類の値
    private const int RoleZorome = 1;
    private const int RoleYakuAri = 2;

    // サイコロの数
    private const int DiceNumber = 3;

    private Dice[] dices = new Dice[DiceNumber];


    public bool IsPlayer { get; set; }

    public Player(bool isPlayer)
    {
        IsPlayer = isPlayer;
        for (int i = 0; i < dices.Length; i++)
        {
            dices[i] = new Dice();
        }
    }

    // サイコロを振る
    public void RollDices()
    {
        foreach (Dice dice in dices)
        {
            dice.RollDice();
        }
    }

    // サイコロの出目を取得する
    public int[] DiceValues()
    {
        return dices.Select(dice => dice.GetValue()).ToArray();
    }

    // 役の強さを取得する
    public int GetHandValue()
    {
        int[] values = DiceValues();
        if (GetHandRoll() == Constants.HandRole.YakuNashi)
        {
            // 役なしの場合、0を返す
            return 0;
        }
        else if (GetHandRoll() == Constants.HandRole.Zorome)
        {
            // ゾロ目の場合、配列の先頭の数字を返す
            return values.First();
        }
        else if (GetHandRoll() == Constants.HandRole.YakuAri)
        {
            // 役ありの場合、一つしかない数字を返す
            foreach (int val in values)
            {
                int count = values.Count(x => x == val);
                if (count > 1)
                {
                    return values.First(x => x != val);
                }
            }
        }
        return 0;
    }

    // 取得した出目と出目の種類を比較し役を取得する
    public Constants.HandRole GetHandRoll()
    {
        int compValue = DiceValues().Distinct().Count();
        if (compValue == RoleZorome)
        {
            // 出目が1種類 =「役：ゾロ目」
            return Constants.HandRole.Zorome;
        }
        else if (compValue == RoleYakuAri)
        {
            // 出目が2種類 =「役：役あり」
            return Constants.HandRole.YakuAri;
        }
        else
        {
            // 出目が3種類 =「役：役なし」
            return Constants.HandRole.YakuNashi;
        }
    }
}
