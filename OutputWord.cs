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
    public static void ReturnHandCompare(Player player, bool isPlayer)
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

    // 役を比較し勝敗を決める    
    public static Constants.ResultRoll CompareHand(Player player, Player cpu)
    {
        if (player.GetHandRoll() == cpu.GetHandRoll())
        {
            if (player.GetHandValue() > cpu.GetHandValue())
            {
                // 数値が相手より大きい場合「勝ち」
                return Constants.ResultRoll.Win;
            }
            else if (player.GetHandValue() < cpu.GetHandValue())
            {
                // 数値が相手より小さい場合「負け」
                return Constants.ResultRoll.Lose;
            }
            else
            {
                // 数値が一致する場合「引き分け」
                return Constants.ResultRoll.Draw;
            }
        }
        else if (player.GetHandRoll() > cpu.GetHandRoll())
        {
            // 役が相手より強い場合「勝ち」
            return Constants.ResultRoll.Win;
        }
        else
        {
            // 役が相手より弱い場合「負け」
            return Constants.ResultRoll.Lose;
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

    // Enterキーで終了する
    public static void PushKeyEnter()
    {
        Console.WriteLine("Enterキーで次へ");
        Console.ReadKey();
    }
}
