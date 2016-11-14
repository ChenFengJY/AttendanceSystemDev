using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    //提取数据库数据,处理，导入数据库
    public class DatabaseToDatabase
    {
        static DataTable TabCourseSimple;
        public static string TabTeacherAllCourse()
        {
            
            //查找不重复的课程信息（课程信息 伪主键）sql语句去重查找↓
            string strSql = "select distinct [TimeAndArea],[TeacherDepartment],[TeacherID],[TeacherName] ,[TimeAndArea],[CourseID],[CourseName] ,[t1] ,[t2] ,[t3] ,[Class] from [TabAllCourses]";
            DataTable dt = ConnHelper.GetDistinceColoum(strSql);
            //DataTable TabCourseSimple = new DataTable();//中转作用，保存拆分

            dt.Columns.Add("SplitTimeAndArea");
            dt.Columns["SplitTimeAndArea"].SetOrdinal(4);
            TabCourseSimple = dt.Clone();//中转作用，保存拆分
            TabCourseSimple.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SplitTimeAndArea(dt.Rows[i]);
            }
            TabCourseSimple.Columns.RemoveAt(0);
            //表列结构[TeacherDepartment],[TeacherID],[TeacherName],[SplitTimeAndArea],[TimeAndArea]
            TabCourseSimple.Columns.Add("CourseAllWeek");//所有周
            TabCourseSimple.Columns.Add("CourseWeek");//星期数
            TabCourseSimple.Columns.Add("CourseTime");//节数
            TabCourseSimple.Columns.Add("CourseAddress");//教室地址
            TabCourseSimple.Columns["CourseAllWeek"].SetOrdinal(3);
            TabCourseSimple.Columns["CourseWeek"].SetOrdinal(4);
            TabCourseSimple.Columns["CourseTime"].SetOrdinal(5);
            TabCourseSimple.Columns["CourseAddress"].SetOrdinal(6);
            for(int i = 0; i < TabCourseSimple.Rows.Count; i++)
            {
                SplitTimeAndArea2(TabCourseSimple.Rows[i]);
            }

            TabCourseSimple.Columns.RemoveAt(7);

            return ConnHelper.DataTableToSQLServer("TabTeacherAllCourse", TabCourseSimple);
        }
        /// <summary>
        /// 多课程拆分为单课程，分配到多行
        /// </summary>
        /// <param name="dr"></param>
        private static void SplitTimeAndArea(DataRow dr)
        {
            string[] firseSplit =  dr[0].ToString().Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < firseSplit.Length; i++)
            {
                dr[4] = firseSplit[i];

                DataRow drow = dr;
                TabCourseSimple.Rows.Add(drow.ItemArray);
            }
            
        }
        /// <summary>
        /// 课程信息拆分为详细信息
        /// </summary>
        /// <param name="dr"></param>
        private static void SplitTimeAndArea2(DataRow dr)
        {
            string[] firstSplit = dr[7].ToString().Split(new char[] { '[', ']', '/' }, StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < firstSplit.Length; i++)
            {
                dr[i + 3] = firstSplit[i];
            }
            dr[3] = SplitTimeAndArea3(dr[3].ToString());


        }
        private static string SplitTimeAndArea3(string str)
        {
            //1-2,5-7,9-13,15-20单周
            //1-2,5-8,10-13,15-20双周
            //1-6,8-20周
            StringBuilder sbl = new StringBuilder();
            sbl.Remove(0, sbl.Length);
            if (str.IndexOf("单")!=-1){
                string[] weekSplit = str.Split(new char[] { ',','单','周' },StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < weekSplit.Length; i++)
                {
                    if (weekSplit[i].IndexOf('-') != -1)
                    {
                        string[] textIn2 = weekSplit[i].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = Convert.ToInt32(textIn2[0]); j <= Convert.ToInt32(textIn2[1]); j++)
                        {
                            if(j%2!=0)
                                sbl.Append(j + " ");

                        }
                    }
                    else
                    {
                        if(Convert.ToInt32(weekSplit[i]) % 2!=0)
                            sbl.Append(weekSplit[i] + ' ');
                    }
                }
                return sbl.ToString();

            }
            else if (str.IndexOf("双") != -1)
            {
                string[] textIn = str.Split(new char[] { ',','双', '周' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < textIn.Length; i++)
                {
                    if (textIn[i].IndexOf('-') != -1)
                    {
                        string[] textIn2 = textIn[i].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = Convert.ToInt32(textIn2[0]); j <= Convert.ToInt32(textIn2[1]); j++)
                        {
                            if(j%2==0)
                                sbl.Append(j + " ");
                        }
                    }
                    else
                    {
                        if(Convert.ToInt32(textIn[i])%2==0)
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
