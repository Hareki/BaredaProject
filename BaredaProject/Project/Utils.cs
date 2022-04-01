using BaredaProject.Project.Dialogs;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaredaProject.Project
{
    class Utils
    {
        public static readonly string SQL_DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        public static void ShowInfoMessage(string title, string message, InformationForm.FormType type)
        {
            InformationForm form = new InformationForm(title, message, type);
            form.ShowDialog();
        }
        public static bool ShowConfirmMessage(string title, string message)
        {
            ConfirmationForm form = new ConfirmationForm(title, message);
            form.ShowDialog();
            return form.Continue;
        }
        public static string GetCellStringBds(BindingSource bds, GridColumn column, int rowIndex)
        {
            if (rowIndex >= 0)
                return (bds[rowIndex] as DataRowView)[column.Name].ToString().Trim();
            else
                return (bds[bds.Position] as DataRowView)[column.Name].ToString().Trim();
        }
        public static object GetCellValueBds(BindingSource bds, GridColumn column, int rowIndex)
        {
            if (rowIndex >= 0)
                return (bds[rowIndex] as DataRowView)[column.Name];
            else
                return (bds[bds.Position] as DataRowView)[column.Name];
        }

        public static string ConvertDateTimeToMilisString(DateTime date)
        {
            return ((long)(date - new DateTime(1970, 1, 1)).TotalMilliseconds).ToString();
        }

        public static DateTime ConvertMilisStringToDateTime(string milis)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(milis)).UtcDateTime;
        }

    }
}
