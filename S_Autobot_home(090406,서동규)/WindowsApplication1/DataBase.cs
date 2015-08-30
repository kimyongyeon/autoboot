using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

//using System.Collections;
//using System.IO;
//using System.IO.Ports;
//using System.Threading;
//using System.Drawing.Printing;
//using System.Diagnostics;
//using System.ComponentModel;
//using System.Data;
//using System.Data.OleDb;
//using System.Drawing;

namespace WindowsApplication1
{
    class DataBase
    {
        public MySqlConnection mConnection = new MySqlConnection();
        
        #region DB 연결

        public void Open()
        {
            mConnection.ConnectionString = "Persist Security Info=true;Data Source=localhost; Initial Catalog=navi_info; user Id=root; Password=tpakfl;Protocol=tcp;";
            
            try
            {
                mConnection.Open();
                //MessageBox.Show("DB 연결 성공");
            }
            catch (Exception e)
            {
                MessageBox.Show("DB 접속 실패" + e.StackTrace);
            }
            finally
            {
                if (mConnection == null)
                {
                    mConnection.Close();

                }
            }
        }

        public void Dispose()
        {
            if (mConnection != null)
            {
                mConnection.Close();
                mConnection.Dispose();
            }
        }

        #endregion

        // 등록된 경로 리스트 불러오기
        public MySqlDataReader Search_Navilist(string TB_name, string Field_Name)
        {
            MySqlCommand mCommand = new MySqlCommand();
            string strSQL = "SELECT * ";
                  strSQL += "FROM " + TB_name + " ";
                  strSQL += "ORDER BY " + Field_Name + " ASC";

            mCommand.CommandText = strSQL;
            mCommand.Connection = mConnection;

            MySqlDataReader mReader = mCommand.ExecuteReader();
            mCommand.Dispose();

            return mReader;
        }

        // 경로 좌표 불러오기
        public MySqlDataReader Search_Navi_Info(string TB_name, string Field_Name)
        {
            MySqlCommand mCommand = new MySqlCommand();
            string strSQL = "SELECT * ";
                  strSQL += "FROM " + TB_name + " ";
                  strSQL += "WHERE Loca_Name = '" + Field_Name + "'";

            mCommand.CommandText = strSQL;
            mCommand.Connection = mConnection;

            MySqlDataReader mReader = mCommand.ExecuteReader();
            mCommand.Dispose();

            return mReader;
        }

        // Autobot에서 수신된 값 저장
        public void Save_Data(int NO, string Date, string MSG, int Turn)
        {
            MySqlCommand mCommand = new MySqlCommand();

            string strSQL = "INSERT INTO sensing";
            strSQL += "(Node_Num, Sens_Date, Sens_Val, Navi_Turn) ";
            strSQL += "VALUES('" + NO + "','" + Date + "','" + MSG + "', '" + Turn + "')";

            mCommand.CommandText = strSQL;
            mCommand.Connection = mConnection;
            mCommand.ExecuteNonQuery();
            mCommand.Dispose();
        }        

        // 주행 경로 정보 저장
        public void Save_Navi(string Date, string Time, string name1, string name2, string name3)
        {
            MySqlCommand mCommand = new MySqlCommand();

            string strSQL = "INSERT INTO setting";
                   strSQL += "(Date, Datetime, First, Second, Third) ";
                   strSQL += "VALUES('" + Date + "', '" + Time + "', '" + name1 + "', '" + name2 + "', '" + name3 + "')";

            mCommand.CommandText = strSQL;
            mCommand.Connection = mConnection;
            mCommand.ExecuteNonQuery();
            mCommand.Dispose();
        }

        // 주행 경로 정보 저장2
        public void Save_Navi2(string Latitude, string Gradient, int Turn)
        {
            MySqlCommand mCommand = new MySqlCommand();

            string strSQL = "SELECT Node_Num ";
            strSQL += "FROM fixed_set ";
            strSQL += "WHERE Latitude = '" + Latitude + "' ";
            strSQL += "and Gradient = '" + Gradient + "'";

            mCommand.CommandText = strSQL;
            mCommand.Connection = mConnection;

            int No = Convert.ToInt32(mCommand.ExecuteScalar());

            strSQL = "INSERT INTO setting2";
            strSQL += "(Node_Num, Navi_Turn) ";
            strSQL += "VALUES('" + No + "', '" + Turn + "')";

            mCommand.CommandText = strSQL;
            mCommand.Connection = mConnection;
            mCommand.ExecuteNonQuery();
            mCommand.Dispose();
        }

        // 주행 순서 불러오기
        public int Search_Turn(int Num)
        {
            MySqlCommand mCommand = new MySqlCommand();

            string strSQL = "SELECT Navi_Turn ";
            strSQL += "FROM setting2 ";
            strSQL += "WHERE Node_Num = '" + Num + "'";

            mCommand.CommandText = strSQL;
            mCommand.Connection = mConnection;

            int No = Convert.ToInt32(mCommand.ExecuteScalar());
            mCommand.Dispose();

            return No;
        }

        // 위치 이름 불러오기
        public string Search_Name(string Latitude, string Gradient)
        {
            MySqlCommand mCommand = new MySqlCommand();

            string strSQL = "SELECT Loca_Name ";
            strSQL += "FROM fixed_set ";
            strSQL += "WHERE Latitude = '" + Latitude + "' ";
            strSQL += "and Gradient = '" + Gradient + "'";

            mCommand.CommandText = strSQL;
            mCommand.Connection = mConnection;

            string name = mCommand.ExecuteScalar().ToString();
            mCommand.Dispose();

            return name;
        }

        // 주행 정보 삭제
        public void Del_Navi(int No)
        {
            MySqlCommand mCommand = new MySqlCommand();

            string strSQL = "Delete From setting2 Where Node_Num = '" + No +"'";

            mCommand.CommandText = strSQL;
            mCommand.Connection = mConnection;
            mCommand.ExecuteNonQuery();
            mCommand.Dispose();
        }
    }
}
