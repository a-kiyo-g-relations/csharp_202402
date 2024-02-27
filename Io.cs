
using System;

public class Io
{
    // タイトルとゲーム開始を表示する
    public void GameTitle()
    {
        Console.WriteLine("チンチロリン");
        Console.WriteLine("Enterキーでゲーム開始");
        Console.ReadKey();
    }

    // プレイヤーがサイコロを振るか判断し出力する
    public void IsPlayerDiceShake(Player player)
    {
        if (player.IsPlayer)
        {
            // プレイヤーの場合、出力する
            Console.WriteLine("あなたの番です");
            Console.WriteLine("Enterキーでサイコロを投げる");
            Console.ReadKey();
        }
        else
        {
            // cpuの場合、出力する
            Console.WriteLine("相手の番です");
            Console.WriteLine("サイコロを投げます");
        }
    }

    // 出目の表示する
    public void ShowPipDice(int[] numbers)
    {
        foreach (int number in numbers)
        {
            Console.Write("[" + number + "]");
        }
        Console.WriteLine();
    }

    // プレイヤー、役を判断しを出力する
    public void IsPlayerHand(Player player, Constants.HandRole number, int hand)
    {
        if (player.IsPlayer)
        {
            if (number == Constants.HandRole.Zorome)
            {
                // プレイヤー、ゾロ目の場合"あなたの手はゾロ目です"を返す
                Console.WriteLine($"あなたの手は[{hand}]のゾロ目です");
            }
            else if (number == Constants.HandRole.YakuAri)
            {
                // プレイヤー、役ありの場合"あなたの手は役ありです"を返す
                Console.WriteLine($"あなたの手は[{hand}]の役ありです");
            }
            else
            {
                // プレイヤー、役なしの場合"あなたの手は役なしです"を返す
                Console.WriteLine("あなたの手は役なしです");
            }
        }
        else if (number == Constants.HandRole.Zorome)
        {
            // cpu、ゾロ目の場合"相手の手はゾロ目です"を返す
            Console.WriteLine($"相手の手は[{hand}]のゾロ目です");
        }
        else if (number == Constants.HandRole.YakuAri)
        {
            // cpu、役ありの場合"相手の手は役ありです"を返す
            Console.WriteLine($"相手の手は[{hand}]の役ありです");
        }
        else
        {
            // cpu、役なしの場合"相手の手は役なしです"を返す
            Console.WriteLine("相手の手は役なしです");
        }
    }

    // Enterキーで終了する
    public void KeyEnter()
    {
        Console.WriteLine("Enterキーで次へ");
        Console.ReadKey();
    }
}
