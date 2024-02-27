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
        OutputWord.GameTitle();

        // プレイヤーの順番であることを表示する
        OutputWord.PlayerDiceShake(player);

        // サイコロを振る
        player.RollDices();

        // サイコロの出目を表示する
        OutputWord.ShowPipDice(player.DiceValues());

        // プレイヤーの役を出力する
        OutputWord.ChangePlayerHand(player, cpu, true);

        // Enterキー押下で次へ
        OutputWord.PushKeyEnter();

        // cpuの順番であることを表示する
        OutputWord.CpuDiceShake(cpu);

        // cpuがサイコロを振るまでの待ち時間
        CpuWaitingTime();

        // サイコロを振る
        cpu.RollDices();

        // サイコロの出目を表示する
        OutputWord.ShowPipDice(cpu.DiceValues());

        // cpuの役を出力する
        OutputWord.ChangePlayerHand(player, cpu, false);

        // 役と数字で勝敗を判定する
        DetermineWinOrLose();

        // enterキー押下で終了
        OutputWord.PushKeyEnter();
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
                    OutputWord.ResultWin();
                }
                else
                {
                    // 数値が相手より小さい場合「負け」
                    OutputWord.ResultLose();
                }
            }
            else
            {
                // 数値が一致する場合「引き分け」
                OutputWord.ResultDraw();
            }
        }
        else if (player.GetHandRoll() > cpu.GetHandRoll())
        {
            // 役が相手より強い場合「勝ち」
            OutputWord.ResultWin();
        }
        else
        {
            // 役が相手より弱い場合「負け」
            OutputWord.ResultLose();
        }
    }

    // cpuがサイコロを振るまでの待ち時間
    public void CpuWaitingTime()
    {
        System.Threading.Thread.Sleep(ThreeMinuteValue);
    }
}
