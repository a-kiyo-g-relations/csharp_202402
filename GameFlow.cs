using System;

public class GameFlow
{
    // cpuの待ち時間の値(ミリ秒)
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

        // プレイヤーのターン処理
        ExecutePlayerTurn();

        // cpuのターン処理
        ExecuteCpuTurn();

        //ゲームの判定結果
        ExecuteResult();
    }

    // プレイヤーのターン
    private void ExecutePlayerTurn()
    {
        // プレイヤーの順番であることを表示する
        OutputWord.ShowPlayerTurn();

        // サイコロを振る
        player.RollDices();

        // サイコロの出目を表示する
        OutputWord.ShowPipDice(player.DiceValues());

        // 役を判断して表示する
        OutputWord.ReturnHandCompare(player, true);

        // Enterキー押下で次へ
        OutputWord.PushKeyEnter();
    }

    // cpuのターン
    private void ExecuteCpuTurn()
    {
        // cpuの順番であることを表示する
        OutputWord.ShowCpuTurn();

        // cpuがサイコロを振るまでの処理待ち
        WaitCpu();

        // サイコロを振る
        cpu.RollDices();

        // サイコロの出目を表示する
        OutputWord.ShowPipDice(cpu.DiceValues());

        // 役を判断して表示する
        OutputWord.ReturnHandCompare(cpu, false);
    }

    // ゲームの判定結果
    private void ExecuteResult()
    {
        // 役の強さの判定
        Constants.ResultRoll result = OutputWord.CompareHand(player, cpu);

        // 勝負の結果を表示する
        OutputWord.ShowResult(result);

        // enterキー押下で終了
        OutputWord.PushKeyEnter();
    }

    // cpuがサイコロを振るまでの処理待ち
    private void WaitCpu()
    {
        System.Threading.Thread.Sleep(CpuWaitingTime);
    }
}
