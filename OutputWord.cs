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

    // プレイヤーか判断して順番を表示する
    public static void ShowPlayerTurn(bool isPlayer)
    {
        string playerName;
        if (isPlayer)
        {
            playerName = "あなた";
            Console.WriteLine($"{playerName}の番です");
        }
        else
        {
            playerName = "相手";
            Console.WriteLine($"{playerName}の番です");
        }
    }


    // Enterキーでサイコロを投げるを表示する
    public static void ShowThrowDicePlayer()
    {
        Console.WriteLine("Enterキーでサイコロを投げる");
        Console.ReadKey();
    }

    // サイコロを投げますを表示する
    public static void ShowThrowDiceCpu()
    {
        Console.WriteLine("サイコロを投げます");
    }

    // 何回目のサイコロを投げるかを表示する
    public static void ShowHowManyThrow(bool isPlayer, int number)
    {
        string playerName;
        if (isPlayer)
        {
            playerName = "あなた";
            // trueだった場合あなたの順番であることを返す
        }
        else
        {
            playerName = "相手";
            // falseだった場合相手の順番であることを返す
        }
        Console.WriteLine($"{playerName}の{number}投目です");
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

    // プレイヤーのサイコロの出目の表示する
    public static void ShowPipDicePlayer(int[] numbers)
    {
        Console.Write("あなた : ");
        foreach (int number in numbers)
        {
            Console.Write($"[{number}] ");
        }
        Console.WriteLine();
    }

    // cpuのサイコロの出目の表示する
    public static void ShowPipDiceCpu(int[] numbers)
    {
        Console.Write("相手   : ");
        foreach (int number in numbers)
        {
            Console.Write($"[{number}] ");
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
        if (result == Constants.ResultRoll.Win)
        {
            Console.WriteLine("あなたの勝ちです");
        }
        else if (result == Constants.ResultRoll.Lose)
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
