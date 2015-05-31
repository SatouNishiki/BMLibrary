using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace BMErrorLibrary
{
    /// <summary>
    /// エラーメッセージに関するクラス
    /// </summary>
    public class BMError
    {
        //自分自身の実行ファイルのパスを取得する
        private static string appPath = System.Windows.Forms.Application.StartupPath;

        //エラーファイルを出力するディレクトリ
        private static string errorDirectory = appPath + "\\Log";

        private static string errorFileName = errorDirectory + "\\Log_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + ".txt";

        /// <summary>
        /// 引数で受け取ったエラーメッセージをログファイルに出力する
        /// </summary>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <param name="showMessageBox">MessageBoxを出すかどうか</param>
        public static void ErrorMessageOutput(string errorMessage, bool showMessageBox)
        {
            //エラーログ用のディレクトリが存在していなかったら作る
            if (!System.IO.Directory.Exists(errorDirectory))
            {
                System.IO.DirectoryInfo di = System.IO.Directory.CreateDirectory(errorDirectory);
            }

            //エラーログ用のファイルが存在しなかったら作る
            if (!System.IO.File.Exists(errorFileName))
            {
                // hStream が破棄されることを保証するために using を使用する
                // 指定したパスのファイルを作成する
                using (System.IO.FileStream hStream = System.IO.File.Create(errorFileName))
                {
                    // 作成時に返される FileStream を利用して閉じる
                    if (hStream != null)
                    {
                        hStream.Close();
                    }
                }
            }

            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");

            using (StreamWriter writer = new StreamWriter(errorFileName, true, sjisEnc))
            using (TextWriter writerSync = TextWriter.Synchronized(writer))
            {

                //一つ前のスタックを取得
                StackFrame callerFrame = new StackFrame(1);

                //このメソッドの呼び出し元のメソッド名
                string methodName = callerFrame.GetMethod().Name;

                //このメソッドの呼び出し元のクラス名
                string className = callerFrame.GetMethod().ReflectedType.FullName;

                //出力用のテキストを定義
                //現在の日付、呼び出し元情報、エラーメッセージ(引数)をくっつけてエラー文とする
                string outputString = "[" + DateTime.Now + "]" + "Class = " + className + " ,"
                    + "Method = " + methodName + " " + errorMessage + "\n";

                if (showMessageBox)
                    MessageBox.Show(errorMessage);

                //ファイルに書き込み
             //   writer.WriteLine(outputString);
                writerSync.WriteLine(outputString);

            }
        }
    }
}
