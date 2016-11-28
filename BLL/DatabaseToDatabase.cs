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
        /// <summary>
        /// 数据表拆分主方法
        /// </summary>
        /// <returns></returns>
        public static string TabTeacherAllCourse()
        {
            
            //查找不重复的课程信息（课程信息 伪主键）sql语句去重查找↓
            string strSql = "select distinct [TimeAndArea],[TeacherDepartment],[TeacherID],[TeacherName],[CourseAllWeek],[CourseWeek],[CourseTime],[CourseAddress],[TimeAndArea],[CourseID],[CourseName] ,[t1] ,[t2] ,[t3] ,[Class] from [TabTeacherAllCourse]";
            DataTable dt = ConnHelper.GetDistinceColoum(strSql);
            dt.Columns.RemoveAt(0);
            //表列结构[TeacherDepartment],[TeacherID],[TeacherName],CourseAllWeek,CourseWeek,CourseTime,CourseAddress,[TimeAndArea]

            DataTable TabCourseSimple = dt.Clone();//中转作用，保存拆分
            TabCourseSimple.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SplitToDataTable.SplitTimeAndArea(dt.Rows[i], 3, TabCourseSimple, 3, new char[] { ' ' });
            }

            return ConnHelper.DataTableToSQLServer("TabTeacherCourseWeek", TabCourseSimple);
        }
        
        
    }
}
