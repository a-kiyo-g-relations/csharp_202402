using System;

public class Constants
{
    // 役を定義する値
    public enum HandRole
    {
        YakuNashi, // 役なし
        YakuAri,   // 役あり
        Zorome,    // ゾロ目
    }

    // 勝敗結果を定義する値
    public enum ResultRoll
    {
        Draw, // 役なし
        Lose,   // 役あり
        Win,    // ゾロ目
    }
}
