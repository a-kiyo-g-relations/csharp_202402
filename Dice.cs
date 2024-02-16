using System;

public class Dice
{
    // サイコロの出目に出力する値   
    private const int DicePip1 = 1;
    private const int DicePip2 = 2;
    private const int DicePip3 = 3;
    private const int DicePip4 = 4;
    private const int DicePip5 = 5;
    private const int DicePip6 = 6;

    // サイコロの出目の定数を入れるための配列
    private int[] pipDice = new int[] { 
        DicePip1, DicePip2, DicePip3, 
        DicePip4, DicePip5, DicePip6 };

    //サイコロの乱数を保持するための配列
    private int[] diceNumbers = new int[3];

    // ランダマイザ
    private Random random;

    // コンストラクタ
    public Dice()
    {
        random = new Random();
    }

    // 乱数を生成する
    public int GetRandomDiceNumber()
    {
        int randomIndex = random.Next(pipDice.Length);
        return pipDice[randomIndex];
    }

    // 乱数を指定の数ループし格納
    public int[] GenerateRandomNumbers()
    {
        int count = 3; // 生成する乱数の数
        for (int i = 0; i < count; i++)
        {
            diceNumbers[i] = GetRandomDiceNumber();
        }
        return diceNumbers;
    }
}