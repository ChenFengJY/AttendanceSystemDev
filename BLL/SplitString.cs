using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SplitString
    {
        public static List<string> GetSplitCountAndDetails(string str)
        {
            List<string> str1 = new List<string>();//按照@符号，第一次拆分TimeAndArea
            List<string> strResult = new List<string>();//元素0表示总次数+1，1至以后表示各个Details
            str1 = SplitTimeAndAreaString(str); 
            //strResult.Add(str1.Count.ToString);
            for (int i=0;i<str1.Count;i++)
            {
                List<string> str0 = new List<string>();
                str0 = GetSplitCountAndDetails(str1[i]);
                for (int j=0;j<str0.Count;j++)
                {
                    strResult.Add(str0[j]);
                }
            }
            return strResult; 
        }
        public static List<string> SplitTimeAndAreaString(string str)
        {
            List<string> strList = new List<string>();
            string[] strTemp = str.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i=0;i<strTemp.Length;i++)
            {
                strList.Add(strTemp[i]);

            }
            return strList;
        }
        public static List<string> GetTimeAndAreaDetails(string str)
        {
            List<string> strList = new List<string>();
            if(str.IndexOf("CAD/CAM一体化室")!=-1)
            {
                str = str.Replace("CAD/CAM一体化室", "CAD与CAM一体化室");

            }
            string[] strTemp = str.Split(new char[] { '[',']','/'},StringSplitOptions.RemoveEmptyEntries);
            for (int i=0;i<strTemp.Length;i++)
            {
                strList.Add(strTemp[i]);

            }
            return strList;
        }
        public static string GetWithoutWeek(string str)
        {
            int v = 0;
            if(str.IndexOf("单周")!=-1)
            {
                v = 1;
            }
            if(str.IndexOf("双周")!=-1)
            {
                v = 2;
            }
            StringBuilder sb = new StringBuilder();
            if (sb.Length>0)
            {
                sb.Remove(0, sb.Length);

            }
            string[] strTemp = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i=0;i<strTemp.Length;i++)
            {
                string[] s1 = strTemp[i].Split(new char[] { '-', '周', '单', '双' }, StringSplitOptions.RemoveEmptyEntries);
                if (s1.Length==1)
                {
                    sb.Append("" + s1[0].ToString() + "");
                }
                else
                {
                    for (int j=Convert.ToInt32(s1[0]);j<Convert.ToInt32(s1[1]);j++)
                    {
                        sb.Append(""+j.ToString()+"");

                    }
                    sb.Append(Convert.ToInt32(s1[1]).ToString());
                }

            }
            if (v == 1)
            {
                string[] ss1 = sb.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                sb.Remove(0,sb.Length);
                for (int i=0;i<ss1.Length;i++)
                {
                    int t = Convert.ToInt32(ss1[i]);
                    if (t % 2 != 0)
                        sb.Append(ss1[i] + "");

                }
            }
            if(v==2)
            {
                string[] ss1 = sb.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                sb.Remove(0, sb.Length);
                for (int i=0;i<ss1.Length;i++)
                {
                    int t = Convert.ToInt32(ss1[i]);
                    if (t % 2 == 0)
                        sb.Append(ss1[i] + "");

                }
            }
            return sb.ToString();
        }
    }
}
