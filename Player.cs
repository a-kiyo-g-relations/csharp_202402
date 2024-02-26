using System;
using System.Linq;


public class Player
{
    private const int RoleZorome = 1;
    private const int RoleYakuAri = 2;

    private Dice[] dices = new Dice[] { new Dice(), new Dice(), new Dice() };

    // サイコロを振り、取得した出目の値を配列に保持
    public void RollDices()
    {
        foreach (Dice dice in dices)
        {
            dice.RollDice();
        }
    }

    // 取得したサイコロ三つの値のint型配列を作成する
    public int[] GetDices()
    {
        int[] diceValues = dices.Select(dice => dice.GetValue()).ToArray();
        return diceValues;
    }

    // 重複した値を除去し、残った数値を取得する
    public int GetDiceValue(int[] values)
    {
        if (values.Distinct().Count() == values.Length)
        {
            return 0;
        }
        foreach (int val in values)
        {
            int count = values.Count(x => x == val);
            if (count == RoleZorome)
            {
                return val;
            }
            else if (count == RoleYakuAri)
            {
                int uniqueValue = values.First(x => x != val);
                return uniqueValue;
            }
        }
        return 0;
    }

    // 出目の種類の数によって役を取得する
    public Constants.ToDecideMeans GetHand(int[] number)
    {
        int compValue = number.Distinct().Count();

        if (compValue == RoleZorome)
        {
            return Constants.ToDecideMeans.Zorome; // 出目が1種類 =「役：ゾロ目」
        }
        else if (compValue == RoleYakuAri)
        {
            return Constants.ToDecideMeans.YakuAri; // 出目が2種類 =「役：役あり」
        }
        else
        {
            return Constants.ToDecideMeans.YakuNashi; // 出目が3種類 =「役：役なし」
        }
    }
}

