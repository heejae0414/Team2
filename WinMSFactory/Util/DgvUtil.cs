﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinMSFactory
{
    public static class DgvUtil
    {/// <summary>
    /// Columns (Text) 추가 확장 메서드
    /// </summary>
        public static void AddNewColumns(this DataGridView dgv, string HeaderText, string PropertyName, int Width = 100, bool Visible = true,
            DataGridViewContentAlignment Center = DataGridViewContentAlignment.MiddleCenter)
        {
            // 기본 셀 정렬 : 가운데정렬

            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = HeaderText;
            col.DataPropertyName = PropertyName;
            col.Width = Width;
            col.Visible = Visible;
            col.DefaultCellStyle.Alignment = Center;

            dgv.Columns.Add(col);
        }
        /// <summary>
        /// Columns (Button) 추가 확장 메서드
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="text">텍스트 지정</param>
        /// <param name="padding">여백 지정</param>
        public static void AddNewBtnCol(this DataGridView dgv, string text, Padding padding)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();

            btn.Text = text;
            btn.Width = 50;
            btn.DefaultCellStyle.Padding = padding;
            btn.UseColumnTextForButtonValue = true;

            dgv.Columns.Add(btn);
        }
        /// <summary>
        /// Columns (CheckBox) 추가 확장 메서드
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="HeaderChk_Clicked">Header 체크박스 이벤트</param>
        /// <param name="headerChk">CheckBox를 ref로 전송</param>
        public static void AddNewChkCol(this DataGridView dgv, EventHandler HeaderChk_Clicked, ref CheckBox headerChk)
        {
            // 데이터그리드뷰의 헤더의 위치할 체크박스
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.Width = 30;
            dgv.Columns.Add(chk);

            

            if (HeaderChk_Clicked != null) // 이벤트를 정의할 때
            {
                Point headerCell = dgv.GetCellDisplayRectangle(0, -1, true).Location;
                headerChk = new CheckBox();
                headerChk.Name = "headerChk";
                headerChk.Location = new Point(headerCell.X + 8, headerCell.Y + 4);
                headerChk.Size = new Size(15, 15);
                headerChk.BackColor = Color.White;
                headerChk.Click += HeaderChk_Clicked;

                dgv.Controls.Add(headerChk);
            }
        }

        /* 체크 박스용 Context 설정 (지우지 말고 사용할 것)
         - 체크박스는 사용가능하도록, 내용 수정은 불가능하도록 설정
         

         // 체크 부분은 ReadOnly false, 나머지 부분은 ReadOnly true로 지정
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (col.Index == 0)
                        dgv[col.Index, row.Index].ReadOnly = false;
                    else
                        dgv[col.Index, row.Index].ReadOnly = true;
                }
            }
        */


        /* 체크 박스 헤더 이벤트 (지우지 말고 사용할 것)
         * 
         
        //private void header(object sender, EventArgs e)
        //{
        //    dgv.EndEdit();

        //    //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
        //    foreach (DataGridViewRow row in dgv.Rows)
        //    {
        //        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
        //        chk.Value = HeaderChk.Checked;
        //    }
        //}


        */
    }
}
