using System;
using System.Linq;


public class Player
{
    // 役を決めるための出目の種類の値
    private const int RoleZorome = 1;
    private const int RoleYakuAri = 2;

    private Dice[] dices = new Dice[] { new Dice(), new Dice(), new Dice() };

    // 三つのサイコロを振る
    public void RollDices()
    {
        foreach (Dice dice in dices)
        {
            dice.RollDice();
        }
    }

    // 三つのサイコロをint型配列に格納する
    public int[] DicesToInt()
    {
        int[] diceValues = dices.Select(dice => dice.GetValue()).ToArray();
        return diceValues;
    }

    // 取得した値と出目の種類と比較、重複しない値を取得する
    public int IsDiceValue(int[] values)
    {
        if (values.Distinct().Count() == values.Length)
        {
            return 0;
        }
        else if (values.Distinct().Count() == RoleZorome)
        {
            return values.First();
        }
        foreach (int val in values)
        {
            int count = values.Count(x => x == val);
            if (count == RoleYakuAri)
            {
                int uniqueValue = values.First(x => x != val);
                return uniqueValue;
            }
        }
        return 0;
    }

    // 取得した出目と出目の種類を比較し役を取得する
    public Constants.ToDecideMeans IsHand(int[] number)
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


