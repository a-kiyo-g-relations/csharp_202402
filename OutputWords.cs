
using System;

public class OutputWords
{
    // タイトルとゲーム開始を表示する
    public static void GameTitle()
    {
        Console.WriteLine("チンチロリン");
        Console.WriteLine("Enterキーでゲーム開始");
        Console.ReadKey();
    }

    // プレイヤーの順番であることを表示する
    public static void PlayerDiceShake(Player player)
    {
        Console.WriteLine("あなたの番です");
        Console.WriteLine("Enterキーでサイコロを投げる");
        Console.ReadKey();
    }

    // cpuの番であることを表示する
    public static void CpuDiceShake(Player cpu)
    {
        Console.WriteLine("相手の番です");
        Console.WriteLine("サイコロを投げます");
    }

    // サイコロを振って出た出目の表示する
    public static void ShowPipDice(int[] numbers)
    {
        foreach (int number in numbers)
        {
            Console.Write($"[{number}]");
        }
        Console.WriteLine();
    }

    // プレイヤー、役を判断しを手の結果を返す
    public static void ChangePlayerHand(Player player, Player cpu, bool isPlayer)
    {
        string playerName = "あなた";
        string cpuName = "相手";
        if (isPlayer)
        {
            if (player.GetHandRoll() == Constants.HandRole.Zorome)
            {
                // プレイヤー、ゾロ目の場合"あなたの手はゾロ目です"を返す
                Console.WriteLine($"{playerName}の手は[{player.GetHandValue()}]のゾロ目です");
            }
            else if (player.GetHandRoll() == Constants.HandRole.YakuAri)
            {
                // プレイヤー、役ありの場合"あなたの手は役ありです"を返す
                Console.WriteLine($"{playerName}の手は[{player.GetHandValue()}]の役ありです");
            }
            else
            {
                // プレイヤー、役なしの場合"あなたの手は役なしです"を返す
                Console.WriteLine($"{playerName}の手は役なしです");
            }
        }
        else
        {
            if (cpu.GetHandRoll() == Constants.HandRole.Zorome)
            {
                // cpu、ゾロ目の場合"相手の手はゾロ目です"を返す
                Console.WriteLine($"{cpuName}の手は[{cpu.GetHandValue()}]のゾロ目です");
            }
            else if (cpu.GetHandRoll() == Constants.HandRole.YakuAri)
            {
                // cpu、役ありの場合"相手の手は役ありです"を返す
                Console.WriteLine($"{cpuName}の手は[{cpu.GetHandValue()}]の役ありです");
            }
            else
            {
                // cpu、役なしの場合"相手の手は役なしです"を返す
                Console.WriteLine($"{cpuName}の手は役なしです");
            }
        }
    }

    // 結果「勝ち」を返す
    public static void ResultWin()
    {
        Console.WriteLine("あなたの勝ちです");
    }

    // 結果「負け」を返す
    public static void ResultLose()
    {
        Console.WriteLine("あなたの負けです");
    }

    // 結果「引き分け」を返す
    public static void ResultDraw()
    {
        Console.WriteLine("引き分けです");
    }

    // Enterキーで終了する
    public static void KeyEnter()
    {
        Console.WriteLine("Enterキーで次へ");
        Console.ReadKey();
    }
}
