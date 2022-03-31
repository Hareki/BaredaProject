using BaredaProject.Project.Dialogs;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaredaProject.Project
{
    class Utils
    {

        public static void ShowInfoMessage(string title, string message, InformationForm.FormType type)
        {
            //MessageBoxIcon icon = MessageBoxIcon.Information;
            //switch (type)
            //{
            //    case MessageType.Error:
            //        icon = MessageBoxIcon.Error;
            //        break;
            //    case MessageType.Information:
            //        icon = MessageBoxIcon.Information;
            //        break;
            //}
            //MessageBox.Show(message, title,
            //             MessageBoxButtons.OK, icon);

            InformationForm form = new InformationForm(title, message, type);
            form.ShowDialog();
        }
        public static bool ShowConfirmMessage(string title, string message)
        {
            //MessageBoxIcon icon = MessageBoxIcon.Question;
            //var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, icon);
            //return result == DialogResult.Yes;

            ConfirmationForm form = new ConfirmationForm(title, message);
            form.ShowDialog();
            return form.Continue;


        }
        public static string GetCellStringGridView(GridView view, GridColumn column, int row)
        {
            if (row < 0)
                return view.GetRowCellValue(view.FocusedRowHandle, column).ToString().Trim();
            else
                return view.GetRowCellValue(row, column).ToString().Trim();
        }
        public static object GetCellValueGridView(GridView view, GridColumn column, int row)
        {
            if (row < 0)
                return view.GetRowCellValue(view.FocusedRowHandle, column);
            else
                return view.GetRowCellValue(row, column);
        }

    }
}
