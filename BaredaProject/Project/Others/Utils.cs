using BaredaProject.Project.Dialogs;
using DevExpress.XtraGrid.Columns;
using System;
using System.Data;
using System.Windows.Forms;

namespace BaredaProject.Project
{
    class Utils
    {
        public static readonly string SQL_DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";


        /*----MESSAGE DIALOG----*/
        public static void ShowInfoMessage(string title, string message, InformationForm.FormType type)
        {
            InformationForm form = new InformationForm(title, message, type);
            form.ShowDialog();
        }
        public static bool ShowConfirmMessage(string title, string message, bool wide = false)
        {
            ConfirmationForm form = new ConfirmationForm(title, message, wide);
            form.ShowDialog();
            return form.Continue;
        }


        /*----GET BDS VALUE----*/
        public static string GetCellStringBds(BindingSource bds, GridColumn column, int rowIndex)
        {
            if (rowIndex >= 0)
                return (bds[rowIndex] as DataRowView)[column.FieldName].ToString().Trim();
            else
                return (bds[bds.Position] as DataRowView)[column.FieldName].ToString().Trim();
        }
        public static object GetCellValueBds(BindingSource bds, GridColumn column, int rowIndex)
        {
            if (rowIndex >= 0)
                return (bds[rowIndex] as DataRowView)[column.FieldName];
            else
                return (bds[bds.Position] as DataRowView)[column.FieldName];
        }


        /*----DATE PROCESSING----*/
        public static string ConvertDateTimeToMilisString(DateTime date)
        {
            return new DateTimeOffset(date).ToUnixTimeMilliseconds().ToString();
        }
        public static DateTime ConvertMilisStringToDateTime(string milis)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(milis)).LocalDateTime;
        }

    }
}
