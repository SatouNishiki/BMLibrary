using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMFileLibrary
{
    /// <summary>
    /// 新しいファイルを作成するためのクラス
    /// </summary>
    public class BMFile
    {
        //自分自身の実行ファイルのパスを取得する
        private static string appPath = System.Windows.Forms.Application.StartupPath;

        //作成するディレクトリ
        private static string directory = appPath + "\\";

        /// <summary>
        /// BM直下から指定された名前のディレクトリ(フォルダ)を探してその絶対パスを返す
        /// なければつくり、作ったディレクトリの絶対パスを返す
        /// </summary>
        /// <param name="name">ディレクトリ名</param>
        /// <returns>作ったディレクトリへの絶対パス</returns>
        public static string CreateDirectory(string name)
        {
            directory = appPath + "\\";

            directory += name;

            //エラーログ用のディレクトリが存在していなかったら作る
            if (!System.IO.Directory.Exists(directory))
            {
                System.IO.DirectoryInfo di = System.IO.Directory.CreateDirectory(directory);
            }

            return directory;
        }

        /// <summary>
        /// BM直下から指定された名前のディレクトリ(フォルダ)を探してその絶対パスを返す
        /// なければアプリケーションディレクトリを返す
        /// </summary>
        /// <param name="name">ディレクトリ名</param>
        /// <returns>絶対パス</returns>
        public static string FindDirectory(string name)
        {
            directory = appPath + "\\";

            directory += name;

            if (!System.IO.Directory.Exists(directory))
            {
                directory = directory = appPath + "\\";
            }

            return directory;
        }

        /// <summary>
        /// 指定されたパスを持つファイルを作成する
        /// </summary>
        /// <param name="name">作成するファイルの相対パス</param>
        /// <returns>ファイルの絶対パス</returns>
        public static string CreateFile(string name)
        {
            //なければ作る
            if (!System.IO.File.Exists(GetApplicationPass() + name))
            {
                // hStream が破棄されることを保証するために using を使用する
                // 指定したパスのファイルを作成する
                using (System.IO.FileStream hStream = System.IO.File.Create(GetApplicationPass() + name))
                {
                    // 作成時に返される FileStream を利用して閉じる
                    if (hStream != null)
                    {
                        hStream.Close();
                    }
                }

            }
            return GetApplicationPass() + name;
        }

        /// <summary>
        /// アプリケーションの実行パスを返す
        /// </summary>
        /// <returns>アプリケーションの実行パス</returns>
        public static string GetApplicationPass()
        {
            return appPath;
        }
    }
}
