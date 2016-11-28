using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class SplitToDataTable
    {

        /// <summary>
        /// 根据[]拆分教师Excel第二列教师ID和教师名，并添加到yuanbiao 拆分第6列课程列
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DataTable SplitTeacherIDAndTeacherName(DataRow dr)
        {
            //   ds.Tables["ExcelInfo"].Rows[i][1];
            string[] newStr = dr[3].ToString().Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
            string[] newStr2 = dr[7].ToString().Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
            dr.BeginEdit();
            for (int i = 0; i < newStr.Length; i++)
            {
                dr[i + 1] = newStr[i];
                dr[i + 5] = newStr2[i];
            }

            dr.EndEdit();
            return null;
        }

        /// <summary>
        /// 字符串多段拆分，按行插入到目标表
        /// </summary>
        /// <param name="dr">需要拆分的行</param>
        /// <param name="dt">导入目标表</param>
        /// <param name="excrete">要拆分第几列</param>
        /// <param name="ar">拆分字符集</param>
        /// <param name="columnss"></param>
        public static void SplitTimeAndArea(DataRow dr, int excrete, DataTable dt, int columnss, char[] ar)
        {
            string[] firseSplit = dr[excrete].ToString().Split(ar, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < firseSplit.Length; i++)
            {
                DataRow drow = dr;
                drow[columnss] = firseSplit[i];
                dt.Rows.Add(drow.ItemArray);
            }

        }

        /// <summary>
        /// 课程信息拆分为详细信息
        /// </summary>
        /// <param name="dr"></param>
        public static void SplitTimeAndArea2(DataRow dr)
        {
            string[] firstSplit = dr[7].ToString().Split(new char[] { '[', ']', '/' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < firstSplit.Length; i++)
            {
                dr[i + 3] = firstSplit[i];
            }
            dr[3] = SplitTimeAndArea3(dr[3].ToString());
        }
        /// <summary>
        /// 对周次单双周的拆分
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string SplitTimeAndArea3(string str)
        {
            //1-2,5-7,9-13,15-20单周
            //1-2,5-8,10-13,15-20双周
            //1-6,8-20周
            StringBuilder sbl = new StringBuilder();
            sbl.Remove(0, sbl.Length);
            if (str.IndexOf("单") != -1)
            {
                string[] weekSplit = str.Split(new char[] { ',', '单', '周' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < weekSplit.Length; i++)
                {
                    if (weekSplit[i].IndexOf('-') != -1)
                    {
                        string[] textIn2 = weekSplit[i].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = Convert.ToInt32(textIn2[0]); j <= Convert.ToInt32(textIn2[1]); j++)
                        {
                            if (j % 2 != 0)
                                sbl.Append(j + " ");

                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(weekSplit[i]) % 2 != 0)
                            sbl.Append(weekSplit[i] + ' ');
                    }
                }
                return sbl.ToString();

            }
            else if (str.IndexOf("双") != -1)
            {
                string[] textIn = str.Split(new char[] { ',', '双', '周' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < textIn.Length; i++)
                {
                    if (textIn[i].IndexOf('-') != -1)
                    {
                        string[] textIn2 = textIn[i].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = Convert.ToInt32(textIn2[0]); j <= Convert.ToInt32(textIn2[1]); j++)
                        {
                            if (j % 2 == 0)
                                sbl.Append(j + " ");
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(textIn[i]) % 2 == 0)
                            sbl.Append(textIn[i] + ' ');
                    }
                }
                return sbl.ToString();
            }
            else
            {

                string[] textIn = str.Split(new char[] { ',', '周' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < textIn.Length; i++)
                {
                    if (textIn[i].IndexOf('-') != -1)
                    {
                        string[] textIn2 = textIn[i].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = Convert.ToInt32(textIn2[0]); j <= Convert.ToInt32(textIn2[1]); j++)
                        {
                            sbl.Append(j + " ");
                        }
                    }
                    else
                    {
                        sbl.Append(textIn[i] + ' ');
                    }
                }
                return sbl.ToString();
            }

        }

    }
}
