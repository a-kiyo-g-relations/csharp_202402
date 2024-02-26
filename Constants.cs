using System;

public class Constants
{
    // 役を定義する値 
    public enum ToDecideMeans
    {
        YakuNashi, // 出目が0種類 =「役：役なし」
        YakuAri,   // 出目が2種類 =「役：役あり」
        Zorome,    // 出目が1種類 =「役：ゾロ目」
    }
}

