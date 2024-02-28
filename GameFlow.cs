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

    public void StartGame()
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
        OutputWord.ShowHand(player, true);

        // Enterキー押下で次へ
        OutputWord.ShowNextKeyEnter();
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
        OutputWord.ShowHand(cpu, false);
    }

    // ゲームの判定結果
    private void ExecuteResult()
    {
        // 役の強さの判定
        Constants.ResultRoll result = CompareHand();

        // 勝負の結果を表示する
        OutputWord.ShowResult(result);

        // enterキー押下で終了
        OutputWord.ShowEndKeyEnter();
    }

    // 役を比較し勝敗を決める
    private Constants.ResultRoll CompareHand()
    {
        // 役の強さで比較する
        if (player.GetHandRoll() > cpu.GetHandRoll())
        {
            // 役が相手より強い場合「勝ち」
            return Constants.ResultRoll.Win;
        }
        if (player.GetHandRoll() < cpu.GetHandRoll())
        {
            // 役が相手より弱い場合「負け」
            return Constants.ResultRoll.Lose;
        }

        // 役の強さが同じ場合は数値で比較する
        if (player.GetHandValue() > cpu.GetHandValue())
        {
            // 数値が相手より大きい場合「勝ち」
            return Constants.ResultRoll.Win;
        }
        if (player.GetHandValue() < cpu.GetHandValue())
        {
            // 数値が相手より小さい場合「負け」
            return Constants.ResultRoll.Lose;
        }

        // 勝敗が決まらない場合「引き分け」
        return Constants.ResultRoll.Draw;
    }

    // cpuがサイコロを振るまでの処理待ち
    private void WaitCpu()
    {
        System.Threading.Thread.Sleep(CpuWaitingTime);
    }
}
