﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    public class DataAnalysis
    {
        public static DataTable CreateDateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Week");//周次
            dt.Columns["Week"].SetOrdinal(0);
            dt.Columns.Add("Department");//系部
            dt.Columns["Department"].SetOrdinal(1);
            dt.Columns.Add("Late");//迟到
            dt.Columns["Late"].SetOrdinal(2);
            dt.Columns.Add("Early");//早退
            dt.Columns["Early"].SetOrdinal(3);
            dt.Columns.Add("Attendance");
            dt.Columns["Attendance"].SetOrdinal(4);
            dt.Columns.Add("Leave");
            dt.Columns["Leave"].SetOrdinal(5);
            dt.Columns.Add("Suming");
            dt.Columns["Suming"].SetOrdinal(6);
            return dt;
        }

        //统计此系每周缺勤人数，放到一张表，每周一行
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Department">当前系名</param>
        /// <param name="week">当前周次</param>
        /// <param name="weekEnd">从几周开始</param>
        /// <returns>返回一个系所有考勤统计</returns>
        private static DataTable InitialDataTable(string Department,int week,int weekEnd)
        {
            DataTable dt = CreateDateTable();//储存每周人数情况
            StringBuilder sbl = new StringBuilder();
            //当前周次
            for (int i = week; i > weekEnd-1; i--)
            {
                sbl.Remove(0, sbl.Length);
                DataRow drs = dt.NewRow();
                drs[0] = i;//周次
                drs[1] = Department;
                sbl.Append("SELECT COUNT(*) AS LateMount FROM TabStudentAttendance where StudentDepartment = '" + Department + "' and CourseAllWeek = " + i + " and AttendanceType = '迟到' ");
                sbl.Append("SELECT COUNT(*) AS EarlyMount FROM TabStudentAttendance where StudentDepartment = '" + Department + "' and CourseAllWeek = " + i + " and AttendanceType = '早退' ");
                sbl.Append("SELECT COUNT(*) AS EarlyMount FROM TabStudentAttendance where StudentDepartment = '" + Department + "' and CourseAllWeek = " + i + " and AttendanceType = '旷课' ");
                sbl.Append("SELECT COUNT(*) AS EarlyMount FROM TabStudentAttendance where StudentDepartment = '" + Department + "' and CourseAllWeek = " + i + " and AttendanceType = '请假' ");
                DataSet ds = AddSQLStringToDAL.GetDsBySql(sbl.ToString());

                int Late = Convert.ToInt32(ds.Tables[0].Rows[0][0]);//获取此系此周迟到的人数
                drs[2] = Late;
                int Early = Convert.ToInt32(ds.Tables[1].Rows[0][0]);//获取此系此周早退的人数
                drs[3] = Early;
                int Attendance = Convert.ToInt32(ds.Tables[2].Rows[0][0]);//获取此系此周旷课的人数
                drs[4] = Attendance;
                int Leave = Convert.ToInt32(ds.Tables[3].Rows[0][0]);//获取此系此周请假的人数
                drs[5] = Leave;
                drs[6] = Late + Early + Attendance + Leave;//缺勤的总人数
                dt.Rows.Add(drs);
            }
            return dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Department"></param>
        /// <param name="startWeek"></param>
        /// <param name="EndWeek"></param>
        private static string[] AllWeekInitial(string Department,int startWeek,int EndWeek)
        {
            StringBuilder sbder = new StringBuilder();
            sbder.Remove(0, sbder.Length);
            sbder.Append("SELECT COUNT(*) AS LateMount FROM TabStudentAttendance where StudentDepartment = '" + Department + "' and CourseAllWeek in" + SqlList(startWeek, EndWeek) + " and AttendanceType = '迟到' ");
            sbder.Append("SELECT COUNT(*) AS LateMount FROM TabStudentAttendance where StudentDepartment = '" + Department + "' and CourseAllWeek in" + SqlList(startWeek, EndWeek) + " and AttendanceType = '早退' ");
            sbder.Append("SELECT COUNT(*) AS LateMount FROM TabStudentAttendance where StudentDepartment = '" + Department + "' and CourseAllWeek in" + SqlList(startWeek, EndWeek) + " and AttendanceType = '旷课' ");
            sbder.Append("SELECT COUNT(*) AS LateMount FROM TabStudentAttendance where StudentDepartment = '" + Department + "' and CourseAllWeek in" + SqlList(startWeek, EndWeek) + " and AttendanceType = '请假' ");
            sbder.Append("SELECT COUNT(*) AS LateMount FROM TabStudentAttendance where StudentDepartment = '" + Department + "' and CourseAllWeek in" + SqlList(startWeek, EndWeek) + " ");//所有

            DataSet ds = AddSQLStringToDAL.GetDsBySql(sbder.ToString());
            //所有周缺勤人数
            string[] departmentInfo = { ds.Tables[0].Rows[0][0].ToString(), ds.Tables[1].Rows[0][0].ToString(), ds.Tables[2].Rows[0][0].ToString(), ds.Tables[3].Rows[0][0].ToString(), ds.Tables[4].Rows[0][0].ToString() };
            return departmentInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="allDepartment">系部</param>
        /// <param name="allCount">每个系部总人数</param>
        /// <param name="allAttendance">旷课</param>
        /// <param name="allLate">迟到</param>
        /// <param name="allEarly">早退</param>
        /// <param name="allLeave"></param>
        /// <param name="allData">缺勤总数</param>
        /// <returns></returns>
        public static DataTable CreateDataTableReplaceChart(string[] allDepartment, string[] allCount, string[] allLate, string[] allEarly, string[] allAttendance, string[] allLeave, string[] allData)
        {
            DataTable ChartData = BuildDataTableForSum();

            for (int i=0;i< allDepartment.Length; i++)
            {
                DataRow dr = ChartData.NewRow();
                dr["Department"] = allDepartment[i];
                dr["Number"] = allCount[i];
                dr["Late"] = allLate[i];
                dr["LateRate"] = PercentNum(allLate[i], allCount[i]);//换算百分比
                dr["Early"] = allEarly[i];
                dr["EarlyRate"] = PercentNum(allEarly[i], allCount[i]);
                dr["Attendance"] = allAttendance[i];//旷课
                dr["AttendanceRate"] = PercentNum(allAttendance[i], allCount[i]);
                dr["Leave"] = allLeave[i];
                dr["LeaveRate"]= PercentNum(allAttendance[i], allCount[i]);

                dr["Sum"] = allData[i];
                dr["SumRate"] = PercentNum(allData[i], allCount[i]);
                ChartData.Rows.Add(dr);
            }
            return ChartData;
        }


        //换算为百分比
        private static string PercentNum(string one,string two)
        {
            if(Convert.ToInt32(two) != 0)
            {
                string percent = ((Convert.ToDouble(one) / Convert.ToDouble(two)) * 100).ToString("0.00") + "%";
                return percent; 
            }
            else
            {
                return "0";
            }
        }
        public static DataTable BuildDataTableForSum()
        {
            //返回GridView中需要的表
            DataTable ChartData = new DataTable();
            ChartData.Columns.Add("Department");//系部
            ChartData.Columns["Department"].SetOrdinal(0);

            ChartData.Columns.Add("Number");//在校生人数
            ChartData.Columns["Number"].SetOrdinal(1);

            ChartData.Columns.Add("Late");//迟到
            ChartData.Columns["Late"].SetOrdinal(2);
            ChartData.Columns.Add("LateRate");//迟到率
            ChartData.Columns["LateRate"].SetOrdinal(3);

            ChartData.Columns.Add("Early");//早退
            ChartData.Columns["Early"].SetOrdinal(4);
            ChartData.Columns.Add("EarlyRate");//早退率
            ChartData.Columns["EarlyRate"].SetOrdinal(5);

            ChartData.Columns.Add("Attendance");//旷课
            ChartData.Columns["Attendance"].SetOrdinal(6);
            ChartData.Columns.Add("AttendanceRate");//旷课率
            ChartData.Columns["AttendanceRate"].SetOrdinal(7);

            ChartData.Columns.Add("Leave");//请假
            ChartData.Columns["Leave"].SetOrdinal(8);
            ChartData.Columns.Add("LeaveRate");//请假率
            ChartData.Columns["LeaveRate"].SetOrdinal(9);

            ChartData.Columns.Add("Sum");//缺勤总数
            ChartData.Columns["Sum"].SetOrdinal(10);
            ChartData.Columns.Add("SumRate");//总缺勤率
            ChartData.Columns["SumRate"].SetOrdinal(11);
            return ChartData;
        }

        /// <summary>
        /// 本系缺勤总值
        /// </summary>
        /// <param name="Department"></param>
        /// <param name="week"></param>
        /// <returns>包含总值的dt</returns>
        public static DataTable SumData(string Department,int week,int weekEnd)
        {
            DataTable dt = InitialDataTable(Department,week,weekEnd);
            DataRow dr = dt.NewRow();//计算总值
            dr[0] = "周次";
            dr[1] = Department;
            for (int j = 2; j < dt.Columns.Count; j++)
            {
                int sum = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sum += Convert.ToInt32(dt.Rows[i][j]);
                }
                dr[j] = sum;
            }
            dt.Rows.Add(dr);
            return dt;
        }

        /// <summary>
        /// 只查找从某周到某周
        /// </summary>
        /// <param name="startWeek"></param>
        /// <param name="WeekEnd"></param>
        /// <returns></returns>
        public static DataTable GetDataAndCreateChartBySum(int startWeek,int WeekEnd)
        {
            string strSql = "select * from TabDepartment";//每个系部总人数
            DataTable dtCount = AddSQLStringToDAL.GetDtBySQL(strSql);
            string[] AllCount = new string[dtCount.Rows.Count];//保存每个系部总人数
            for (int i = 0; i < dtCount.Rows.Count; i++)
            {
                AllCount[i] = dtCount.Rows[i]["sum"].ToString();
            }

            string[] AllDepartment = { "会计系", "信息工程系", "经济管理系", "食品工程系", "机械工程系", "商务外语系", "建筑工程系" };
            string[] AllData = new string[AllDepartment.Length];
            string[] AllLate = new string[AllDepartment.Length];
            string[] AllAttendance = new string[AllDepartment.Length];
            string[] AllEarly = new string[AllDepartment.Length];
            string[] AllLeave = new string[AllDepartment.Length];
            //储存每个系合计后的考勤情况
            for (int i = 0; i < AllDepartment.Length; i++)
            {
                string[] allWeek =  AllWeekInitial(AllDepartment[i], startWeek, WeekEnd);
                AllData[i] = allWeek[4]; //各种缺勤合计
                AllLeave[i] = allWeek[3];//请假合计
                AllAttendance[i] = allWeek[2];//旷课
                AllEarly[i] = allWeek[1];//早退
                AllLate[i] = allWeek[0];//迟到
                
            }
            //储存所有系考勤合计和缺勤率
            DataTable gridViewDt = CreateDataTableReplaceChart(AllDepartment, AllCount, AllLate, AllEarly, AllAttendance, AllLeave, AllData);
            return gridViewDt;
            
        }

        private static string SqlList( int startweek, int weekEnd)
        {
            string sql = "(";
            for(int i = startweek; i < weekEnd; i++)
            {
                sql += i + ",";
            }
            sql += weekEnd + ")";
            return sql;
        }

    }
}
