using System;

public class GameFlow
{
    // cpuがサイコロを振るまでの待ち時間に必要な値
    private const int ThreeMinuteValue = 3000;

    private Player player;
    private Player cpu;

    public GameFlow()
    {
        player = new Player();
        cpu = new Player();
    }

    public void Flow()
    {
        // タイトルとゲーム開始を表示する
        OutputWords.GameTitle();

        // プレイヤーの順番であることを表示する
        OutputWords.PlayerDiceShake(player);

        // サイコロを振る
        player.RollDices();

        // サイコロの出目を表示する
        OutputWords.ShowPipDice(player.DiceValues());

        // プレイヤーの役を出力する
        OutputWords.ChangePlayerHand(player, cpu, true);

        // Enterキー押下で次へ
        OutputWords.PushKeyEnter();

        // cpuの順番であることを表示する
        OutputWords.CpuDiceShake(cpu);

        // cpuがサイコロを振るまでの待ち時間
        CpuWaitingTime();

        // サイコロを振る
        cpu.RollDices();

        // サイコロの出目を表示する
        OutputWords.ShowPipDice(cpu.DiceValues());

        // cpuの役を出力する
        OutputWords.ChangePlayerHand(player, cpu, false);

        // 役と数字で勝敗を判定する
        DetermineWinOrLose();

        // enterキー押下で終了
        OutputWords.PushKeyEnter();
    }

    // 役と数字で勝敗を判定する    
    public void DetermineWinOrLose()
    {
        if (player.GetHandRoll() == cpu.GetHandRoll())
        {
            if (player.GetHandValue() != cpu.GetHandValue())
            {
                if (player.GetHandValue() > cpu.GetHandValue())
                {
                    // 数値が相手より大きい場合「勝ち」
                    OutputWords.ResultWin();
                }
                else
                {
                    // 数値が相手より小さい場合「負け」
                    OutputWords.ResultLose();
                }
            }
            else
            {
                // 数値が一致する場合「引き分け」
                OutputWords.ResultDraw();
            }
        }
        else if (player.GetHandRoll() > cpu.GetHandRoll())
        {
            // 役が相手より強い場合「勝ち」
            OutputWords.ResultWin();
        }
        else
        {
            // 役が相手より弱い場合「負け」
            OutputWords.ResultLose();
        }
    }

    // cpuがサイコロを振るまでの待ち時間
    public void CpuWaitingTime()
    {
        System.Threading.Thread.Sleep(ThreeMinuteValue);
    }
}
