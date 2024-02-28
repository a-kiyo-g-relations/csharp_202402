using System;

public class GameFlow
{
    // cpuの待ち時間の値(ミリ)
    private const int CpuWaitingTime = 3000;

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
        OutputWord.ShowGameTitle();

        // プレイヤーの順番であることを表示する
        OutputWord.ShowPlayerTurn();

        // サイコロを振る
        player.RollDices();

        // サイコロの出目を表示する
        OutputWord.ShowPipDice(player.DiceValues());

        // 役を判断して表示する
        OutputWord.ReturnHandCompare(player, cpu, true);

        // Enterキー押下で次へ
        OutputWord.PushKeyEnter();

        // cpuの順番であることを表示する
        OutputWord.ShowCpuTurn();

        // cpuがサイコロを振るまでの処理待ち
        WaitCpu();

        // サイコロを振る
        cpu.RollDices();

        // サイコロの出目を表示する
        OutputWord.ShowPipDice(cpu.DiceValues());

        // 役を判断して表示する
        OutputWord.ReturnHandCompare(player, cpu, false);

        // 役と数字で勝敗を判定する
        CompareHand();

        // enterキー押下で終了
        OutputWord.PushKeyEnter();
    }

    // 役と数字で勝敗を判定する
    public void CompareHand()
    {
        if (player.GetHandRoll() == cpu.GetHandRoll())
        {
            if (player.GetHandValue() != cpu.GetHandValue())
            {
                if (player.GetHandValue() > cpu.GetHandValue())
                {
                    // 数値が相手より大きい場合「勝ち」
                    OutputWord.ShowReturnWin();
                }
                else
                {
                    // 数値が相手より小さい場合「負け」
                    OutputWord.ShowReturnLose();
                }
            }
            else
            {
                // 数値が一致する場合「引き分け」
                OutputWord.ShowReturnDraw();
            }
        }
        else if (player.GetHandRoll() > cpu.GetHandRoll())
        {
            // 役が相手より強い場合「勝ち」
            OutputWord.ShowReturnWin();
        }
        else
        {
            // 役が相手より弱い場合「負け」
            OutputWord.ShowReturnLose();
        }
    }

    // cpuがサイコロを振るまでの処理待ち
    public void WaitCpu()
    {
        System.Threading.Thread.Sleep(CpuWaitingTime);
    }
}
