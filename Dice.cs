using System;

public class Dice
{
    //サイコロの出目に出力する値   
    private const int DicePipValue1 = 1;
    private const int DicePipValue2 = 2;
    private const int DicePipValue3 = 3;
    private const int DicePipValue4 = 4;
    private const int DicePipValue5 = 5;
    private const int DicePipValue6 = 6;

    private int[] numbers;
    private Random random;

    // コンストラクタ
    public Dice()
    {
        numbers = new int[] {
            DicePipValue1, DicePipValue2, DicePipValue3,
            DicePipValue4, DicePipValue5, DicePipValue6};
        random = new Random();
    }

    public Random Random { get => random; set => random = value; }

    public int GetRandomDiceNumber()
    {
        int randomIndex = random.Next(numbers.Length);
        return numbers[randomIndex];
    }
}