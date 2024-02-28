using System;

public class Dice
{
    // サイコロの出目に出力する値
    public enum Pip
    {
        One = 1,
        Two,
        Three,
        Four,
        Five,
        Six
    }

    // 直前の出目を保持する変数
    private int value;

    // ランダマイザ
    private Random random;

    // コンストラクタ
    public Dice()
    {
        random = new Random();
    }

    // 前回の出目を取得する
    public int GetValue()
    {
        return value;
    }

    // サイコロを振り、更新されたランダム値を保持
    public void RollDice()
    {
        int rollNumber = GetRandomNumber();
        value = rollNumber;
    }

    // サイコロの出目をランダムに取得する
    private int GetRandomNumber()
    {
        int[] diceValues = Enum.GetValues(typeof(Pip)).Cast<int>().ToArray();
        int randomIndex = random.Next(diceValues.Length);
        return diceValues[randomIndex];
    }
}
