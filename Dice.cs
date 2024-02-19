using System;

public class Dice
{
    // サイコロの出目に出力する値   
    public enum PipDice
    {
        DicePipOne = 1,
        DicePipTwo = 2,
        DicePipThree = 3,
        DicePipFour = 4,
        DicePipFive = 5,
        DicePipSix = 6
    }
    
    // 直前の出目を保持する変数
    private PipDice rollNumber;
    // 前回の出目を保持する変数
    private int rollValue;
    
    // サイコロの出目の定数を入れるための配列
    private PipDice[] pipDice = new PipDice[] {
        PipDice.DicePipOne, PipDice.DicePipTwo, PipDice.DicePipThree,
        PipDice.DicePipFour, PipDice.DicePipFive, PipDice.DicePipSix };

    // ランダマイザ
    private Random random;

    // コンストラクタ
    public Dice()
    {
        random = new Random();
    }

    // サイコロを振り、ランダムな値を返し、RollNumberに保持
    public int Roll()
    {
        rollNumber = GetRandomNumber();
        int rollValue = (int)rollNumber; // 列挙型を整数にキャスト
        return rollValue;
    }

    // 前回の出目を取得する
    public int GetRollValue()
    {
            return rollValue;   
    }

    // 乱数を生成して返す
    public PipDice GetRandomNumber()
    {
        int randomIndex = random.Next(pipDice.Length);
        return pipDice[randomIndex];
    }
}

