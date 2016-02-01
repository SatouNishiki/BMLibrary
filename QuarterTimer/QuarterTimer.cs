using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuarterTimer
{
    public partial class QuarterTimer : Label
    {

        /// <summary>
        /// 試合の開始時間
        /// </summary>
        public DateTime startTime { get; set; }

        public DateTime endTime { get; set; }

        /// <summary>
        /// 1クォーターの時間
        /// </summary>
        private TimeSpan quartTimeLimit = new TimeSpan(0, 10, 0);

        /// <summary>
        /// 現在のクォーターの開始時間
        /// </summary>
        public DateTime quartStartTime { get; set; }

        /// <summary>
        /// クォーターの残り時間
        /// </summary>
        public TimeSpan remainingTime { get; set; }

        /// <summary>
        /// クォーターの経過時間
        /// </summary>
        public TimeSpan elapsedTime { get; set; }

        /// <summary>
        /// 現在のクォーター
        /// </summary>
        public int quarter { get; set; }

        /// <summary>
        /// 表示されるクォーター数(延長は4クォーターとして扱うため別に必要)
        /// </summary>
        public string displayQuarter { get; set; }

        /// <summary>
        /// trueでタイマー加速
        /// </summary>
        public bool fastFowardFlag { get; set; }

        /// <summary>
        /// trueでタイマー巻き戻し
        /// </summary>
        public bool rewindFlag { get; set; }

        public bool changeSpeedPermit { get; set; }

        private TimeSpan displayRemainingTime { get; set; }

        private TimeSpan displayElapsedTime { get; set; }

        private Timer RemainingTimer = new Timer();

        private Timer ChangeSpeedTimer = new Timer();

        public QuarterTimer()
        {
            InitializeComponent();

            startTime = new DateTime();
            endTime = new DateTime();
            quartStartTime = new DateTime();
            remainingTime = new TimeSpan(10,0,0);
            elapsedTime = new TimeSpan(0,0,0);
            displayRemainingTime = new TimeSpan();
            displayElapsedTime = new TimeSpan();
            displayQuarter = "1";

            quarter = 1;

            fastFowardFlag = false;
            rewindFlag = false;

            RemainingTimer.Tick += new EventHandler(RemainingTimer_Tick);
            RemainingTimer.Interval = 1000;
            RemainingTimer.Enabled = false;

            ChangeSpeedTimer.Tick += new EventHandler(ChangeSpeedTimer_Tick);
            ChangeSpeedTimer.Interval = 100;
            ChangeSpeedTimer.Enabled = true;
            
        }

        /// <summary>
        /// ゲーム開始時に初期化、およびタイマーの起動を行う
        /// </summary>
        public void StartGame()
        {
            startTime = DateTime.Now;

            quartStartTime = DateTime.Now;

            quarter = 1;

            displayQuarter = "1";

            quartTimeLimit = new TimeSpan(0, 10, 0);

            RemainingTimer.Enabled = true;

            elapsedTime = new TimeSpan(0, 0, 0);
            displayElapsedTime = new TimeSpan(0, 0, 0);

        }

        /// <summary>
        /// タイマーの処理
        /// 時間を経過させて残り時間を表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemainingTimer_Tick(object sender, EventArgs e)
        {
            //とりあえず巻き戻し中は処理しないようにしとく
            if (!rewindFlag)
            {
                //クォーターの時間経過
                elapsedTime = elapsedTime.Add(new TimeSpan(0, 0, 1));
                displayElapsedTime = displayElapsedTime.Add(new TimeSpan(0, 0, 1));

                if (displayElapsedTime > quartTimeLimit)
                {
                    //次クォーターまでタイマー停止
                    RemainingTimer.Enabled = false;
                }
                else
                {
                    //残り時間
                    remainingTime = quartTimeLimit - elapsedTime;
                    displayRemainingTime = quartTimeLimit - displayElapsedTime;

                    //残り時間表示
                    this.Text = (displayRemainingTime.Minutes).ToString() + "." + (displayRemainingTime.Seconds).ToString();
                }
            }
        }

        private void ChangeSpeedTimer_Tick(object sender, EventArgs e)
        {
            if (RemainingTimer.Enabled)
            {

                if (fastFowardFlag)
                {
                    RemainingTimer_Tick(sender, e);
                }
                else if (rewindFlag)
                {
                    if (elapsedTime > new TimeSpan(0, 0, 0))
                    {
                        elapsedTime = elapsedTime.Subtract(new TimeSpan(0, 0, 1));
                        displayElapsedTime = displayElapsedTime.Subtract(new TimeSpan(0, 0, 1));

                        //残り時間
                        remainingTime = quartTimeLimit - elapsedTime;
                        displayRemainingTime = quartTimeLimit - displayElapsedTime;

                        //残り時間表示
                        this.Text = (displayRemainingTime.Minutes).ToString() + "." + (displayRemainingTime.Seconds).ToString();
                    }
                }
            }
        }

        public void SetChangeSpeedTimerInterval(int interval)
        {
            ChangeSpeedTimer.Interval = interval;
        }

        /// <summary>
        /// クォーターが進んだときの処理
        /// 内部のクォーターカウントを進めタイマーを有効化する
        /// </summary>
        public void GoNextQuarter()
        {
            if (quarter <= 3)
            {
                quarter++;

                displayQuarter = quarter.ToString();
                
                elapsedTime = new TimeSpan(0, 0, 0);

                quartStartTime = DateTime.Now;
 
            }
            else
            {
                //内部的には延長は5クォーター目、6クォーター目と数える
                quarter++;

                //時間は5分
                quartTimeLimit = new TimeSpan(0, 5, 0);

            }

            if (quarter > 4)
            {
                displayQuarter = "延長" + (quarter - 4);
            }

            displayElapsedTime = new TimeSpan(0, 0, 0);

            RemainingTimer.Enabled = true;
        }

        /// <summary>
        /// ゲームが一時停止したとき
        /// タイマーをいったん無効化する
        /// </summary>
        public void StopGame()
        {
            RemainingTimer.Enabled = false;
        }

        /// <summary>
        /// ゲームが再開したとき
        /// タイマーを有効化する
        /// </summary>
        public void RestartGame()
        {
            RemainingTimer.Enabled = true;
        }


        /// <summary>
        /// ゲームが終了したとき
        /// 表示を切り替え、タイマーを無効化する
        /// </summary>
        public void EndGame()
        {
            remainingTime = new TimeSpan(0, 10, 0);
            displayRemainingTime = new TimeSpan(0, 10, 0);
            this.quarter = 1;

            this.Text = (displayRemainingTime.Minutes).ToString() + "." + (displayRemainingTime.Seconds).ToString();

            RemainingTimer.Enabled = false;
            endTime = DateTime.Now;
        }

         
    }
}
