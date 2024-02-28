using System;

public class OutputWord
{
    // タイトルとゲーム開始を表示する
    public static void ShowGameTitle()
    {
        Console.WriteLine("チンチロリン");
        Console.WriteLine("Enterキーでゲーム開始");
        Console.ReadKey();
    }

    // プレイヤーの順番であることを表示する
    public static void ShowPlayerTurn()
    {
        Console.WriteLine("あなたの番です");
        Console.WriteLine("Enterキーでサイコロを投げる");
        Console.ReadKey();
    }

    // cpuの順番であることを表示する
    public static void ShowCpuTurn()
    {
        Console.WriteLine("相手の番です");
        Console.WriteLine("サイコロを投げます");
    }

    // サイコロの出目の表示する
    public static void ShowPipDice(int[] numbers)
    {
        foreach (int number in numbers)
        {
            Console.Write($"[{number}]");
        }
        Console.WriteLine();
    }

    // 役を判断して返す
    public static void ShowHand(Player player, bool isPlayer)
    {
        string playerName;
        if (isPlayer)
        {
            playerName = "あなた";
        }
        else
        {
            playerName = "相手";
        }
        if (player.GetHandRoll() == Constants.HandRole.Zorome)
        {
            // プレイヤー、ゾロ目の場合"ゾロ目です"を返す
            Console.WriteLine($"{playerName}の手は[{player.GetHandValue()}]のゾロ目です");
        }
        else if (player.GetHandRoll() == Constants.HandRole.YakuAri)
        {
            // プレイヤー、役ありの場合"役ありです"を返す
            Console.WriteLine($"{playerName}の手は[{player.GetHandValue()}]の役ありです");
        }
        else
        {
            // プレイヤー、役なしの場合"役なしです"を返す
            Console.WriteLine($"{playerName}の手は役なしです");
        }
    }

    // 勝敗結果を表示する
    public static void ShowResult(Constants.ResultRoll result)
    {
        if(result == Constants.ResultRoll.Win)
        {
            Console.WriteLine("あなたの勝ちです");
        }
        else if(result == Constants.ResultRoll.Lose)
        {
            Console.WriteLine("あなたの負けです");
        }
        else
        {
            Console.WriteLine("引き分けです");
        }
    }

    // Enterキーで次へ
    public static void ShowNextKeyEnter()
    {
        Console.WriteLine("Enterキーで次へ");
        Console.ReadKey();
    }

    // Enterキーで終了する
    public static void ShowEndKeyEnter()
    {
        Console.WriteLine("Enterキーで終了");
        Console.ReadKey();
    }
}
