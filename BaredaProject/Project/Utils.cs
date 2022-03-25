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
        public enum MessageType
        {
            Error,
            Confirmation,
            Information
        }

        public static void ShowInfoMessage(string title, string message, MessageType type)
        {
            MessageBoxIcon icon = MessageBoxIcon.Information;
            switch (type)
            {
                case MessageType.Error:
                    icon = MessageBoxIcon.Error;
                    break;
                case MessageType.Information:
                    icon = MessageBoxIcon.Information;
                    break;
            }
            MessageBox.Show(message, title,
                         MessageBoxButtons.OK, icon);
        }
        public static bool ShowConfirmMessage(string title, string message)
        {
            MessageBoxIcon icon = MessageBoxIcon.Question;
            var result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, icon);
            return result == DialogResult.Yes;

        }
        public static string GetCellStringGridView(GridView view, GridColumn column, int row)
        {
            if (row < 0)
                return view.GetRowCellValue(view.FocusedRowHandle, column).ToString().Trim();
            else
                return view.GetRowCellValue(row, column).ToString().Trim();
        }
    }
}
