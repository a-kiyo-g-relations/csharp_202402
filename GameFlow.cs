using System;

public class GameFlow
{
    // 3
    private const int MilliSeconds = 3000;

    Player player;
    Player cpu;
    Io outPut;

    public GameFlow()
    {
        player = new Player(true);
        cpu = new Player(false);
        outPut = new Io();
    }

    public void Flow()
    {
        // タイトルとゲーム開始を表示する
        outPut.GameTitle();

        // プレイヤーがサイコロを振るか判断し出力する
        outPut.IsPlayerDiceShake(player);

        // サイコロを振る
        player.RollDices();

        // サイコロの出目を表示する
        outPut.ShowPipDice(player.DiceValues());

        // プレイヤーの役の強さを取得する
        int playerHand = player.GetHandValue();

        // プレイヤーの役を取得する
        Constants.HandRole playerHandRole = player.GetHandRoll();

        // プレイヤー判断し役を出力する
        outPut.IsPlayerHand(player, playerHandRole, playerHand);

        // Enterキーで次へ
        outPut.KeyEnter();

        // cpuがサイコロを振るか判断し、出力する
        outPut.IsPlayerDiceShake(cpu);

        // 三秒間の処理待ち
        WaitThreeSeconds();

        // サイコロを振る
        cpu.RollDices();

        // サイコロの出目を表示する
        outPut.ShowPipDice(cpu.DiceValues());

        // cpuの役の強さを取得する
        int cpuHand = cpu.GetHandValue();

        // cpuの役を取得する
        Constants.HandRole cpuHandRole = cpu.GetHandRoll();

        // cpuか判断し役を出力する
        outPut.IsPlayerHand(cpu, cpuHandRole, cpuHand);

        // 役と数字で勝敗を判定する
        DetermineWinOrLose(playerHandRole, playerHand, cpuHandRole, cpuHand);

        outPut.KeyEnter();
    }

    // 役と数字で勝敗を判定する    
    public void DetermineWinOrLose(Constants.HandRole playerRole, int playerHand,
                                        Constants.HandRole cpuRole, int cpuHand)
    {
        if (playerRole == cpuRole)
        {
            if (playerHand != cpuHand)
            {
                if (playerHand > cpuHand)
                {
                    // 数値が相手より大きい場合
                    Console.WriteLine("あなたの勝ちです");
                }
                else
                {
                    // 数値が相手より小さい場合
                    Console.WriteLine("あなたの負けです");
                }
            }
            else
            {
                // 数値が一致する場合
                Console.WriteLine("引き分けです");
            }
        }
        else if (playerRole > cpuRole)
        {
            // 役が相手より強い場合
            Console.WriteLine("あなたの勝ちです");
        }
        else
        {
            // 役が相手より弱い場合
            Console.WriteLine("あなたの負けです");
        }
    }

    // 三秒間待つ
    public void WaitThreeSeconds()
    {
        System.Threading.Thread.Sleep(MilliSeconds);
    }
}
