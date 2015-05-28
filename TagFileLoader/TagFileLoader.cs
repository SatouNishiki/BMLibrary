using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace TagFileLoader
{
    /// <summary>
    /// タグつきファイルに関するクラス
    /// </summary>
    public class TagFileLoader
    {
        /// <summary>
        /// タグつきファイルの内容を読み込んで指定されたタグの部分だけをArrayListにして返す
        /// fileName: 読み込むファイルの名前
        /// tagName: タグ名
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="TagName"></param>
        /// <returns></returns>
        public ArrayList loadTagFile(string path, string tagName)
        {
            ArrayList al = new ArrayList();
            ArrayList rt = new ArrayList();

            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                while (true)
                {
                    var line = sr.ReadLine();

                    if (line == null) break;

                    al.Add(line);
                }
            }

            string startTag = "[" + tagName + "]";
            string endTag = "[/" + tagName + "]";

            //タグの位置を検出
            int startTagPoint = al.IndexOf(startTag);
            int endTagPoint = al.IndexOf(endTag);

            for (var i = startTagPoint + 1; i < endTagPoint; i++)
            {
                rt.Add(al[i]);
            }

                return rt;
        }


        /// <summary>
        /// タグつきファイルの内容を読み込んで指定されたタグの部分だけをArrayListにして返す
        /// fileName: 読み込むファイルの名前
        /// tagName: タグ名
        /// encording: ファイルのエンコーディング方式
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="TagName"></param>
        /// <returns></returns>
        public ArrayList loadTagFile(string path, string tagName, Encoding encoding)
        {
            ArrayList al = new ArrayList();
            ArrayList rt = new ArrayList();

            using (StreamReader sr = new StreamReader(path, encoding))
            {

                while (true)
                {
                    var line = sr.ReadLine();

                    if (line == null) break;

                    al.Add(line);
                }
            }

            string startTag = "[" + tagName + "]";
            string endTag = "[/" + tagName + "]";

            //タグの位置を検出
            int startTagPoint = al.IndexOf(startTag);
            int endTagPoint = al.IndexOf(endTag);

            for (int i = startTagPoint + 1; i < endTagPoint; i++)
            {
                rt.Add(al[i]);
            }

            return rt;
        }
    }
}
