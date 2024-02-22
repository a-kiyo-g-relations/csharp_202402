using System;
using System.Linq;

public class Player
{
    // サイコロの乱数を保持するための配列
    private int[] diceValues = new int[3];

    // サイコロを振った結果の出目数値
    private int value;



    Dice diceOne = new Dice();
    Dice diceTwo = new Dice();
    Dice diceThree = new Dice();
    Constants constants = new Constants();

    // サイコロを振り、取得した出目の値を配列に保持
    public void RollDiceHoldingValue()
    {
        int i = 0;
        foreach (Dice dice in new Dice[] { diceOne, diceTwo, diceThree })
        {
            dice.RollDice();
            diceValues[i++] = dice.GetValue();
        }
    }

    // 重複した値を除去し、残った数値を取得する
    public void GetValueDice()
    {
        List<int> array = new List<int>();
        List<int> diceValuesList = new List<int>(diceValues);
        diceValuesList.Sort();
        IEnumerable<int> duplicates = diceValuesList.GroupBy(x => x)
                        .Where(group => group.Count() > 1)
                        .Select(group => group.Key);
        if (duplicates.Any())
        {
            array = diceValuesList.Except(duplicates).ToList();
            value = array[0];
        }
        else
        {
            value = 0;
        }
    }

    // 出目の種類の数によって役を判定する
    public int ComparisonPipTypeCount()
    {
        int compValue = diceValues.Distinct().Count();

        if (compValue == EnumToInt(Constants.JudgeValue.Zorome))
        {
            int Zorome = EnumToInt(Constants.JudgeValue.Zorome);
            return Zorome; // 出目が1種類 =「役：ゾロ目」
        }
        else if (compValue == EnumToInt(Constants.JudgeValue.YakuAri))
        {
            int YakuAri = EnumToInt(Constants.JudgeValue.YakuAri);
            return YakuAri; // 出目が2種類 =「役：役あり」
        }
        else
        {
            int YakuNashi = EnumToInt(Constants.JudgeValue.YakuNashi);
            return YakuNashi; // 出目が3種類 =「役：役なし」
        }
    }

    // 前回の出目を取得する
    public int[] GetValue()
    {
        return diceValues;
    }

    // サイコロを振った結果の出目数値を取得する
    public int GetDiceValue()
    {
        return value;
    }

    // enum型をobject型を経由してint型に変換する
    private int EnumToInt<I>(I value) where I : Enum
    {
        return (int)(object)value;
    }
}
