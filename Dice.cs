using System;

public class Dice
{
    // サイコロの出目に出力する値   
    public enum Pip
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6
    }

    // 直前の出目を保持する変数
    private int rollValue;

    // ランダマイザ
    private Random random;

    // コンストラクタ
    public Dice()
    {
        random = new Random();
    }

    // 前回の出目を取得する
    public int GetRollValue()
    {
        Roll();
        return rollValue;
    }

    // サイコロを振り、ランダム値をrollValueに保持
    public void Roll()
    {
        Pip rollNumber = GetRandomNumber(); // ランダム値を保持
        rollValue = (int)rollNumber; // 列挙型を整数にキャストして代入
    }

    // 乱数を生成して返す
    private Pip GetRandomNumber()
    {
        Array diceValues = Enum.GetValues(typeof(Pip)); // 列挙型の値を取得
        int randomIndex = random.Next(diceValues.Length);
        return (Pip)diceValues.GetValue(randomIndex); // 乱数を Pip 列挙型に変換して返す
    }
}
