using System;

public class Constants
{
    // 出目の種類によって役を判断するための値 
    public enum JudgeValue
    {
        Zorome = 1, // 出目が1種類 =「役：ゾロ目」
        YakuAri = 2, // 出目が2種類 =「役：役あり」
        YakuNashi = 0 // 出目が3種類 =「役：役なし」
    }

    // ゾロ目を値「1」として取得する
    public JudgeValue GetZorome()
    {
        return JudgeValue.Zorome;
    }

    // 役ありを値「2」として取得する
    public JudgeValue GetYakuAri()
    {
        return JudgeValue.YakuAri;
    }

    // 役なしを値「0」として取得する
    public JudgeValue GetYakuNashi()
    {
        return JudgeValue.YakuNashi;
    }
}

