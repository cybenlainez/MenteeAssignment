using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace MenteeAssignment.CommonFunctions
{
    public class MessageBox
    {
        public MessageBox()
	    {

	    }

        public enum PageMessage
        {
            LeftBlank,
            SuccessfullySaved
        }

        public static void ShowMessage(PageMessage PageMsg, Page objPage)
        {
            string strMessage = "";
            switch (PageMsg)
            {
                case PageMessage.LeftBlank:
                    strMessage = "Please check the required fields.";
                    break;
                case PageMessage.SuccessfullySaved:
                    strMessage = "The record is successfully saved.";
                    break;
            }

            string popupScript = "<script language='javascript'>" + "alert('" + strMessage + "') </script>";
            ScriptManager.RegisterStartupScript(objPage, objPage.GetType(), "popupScript", popupScript.ToString(), false);
        }

        public static string ShowPage(string PageName, Page objPage)
        {
            string features = " center: yes; " + " help: no; " + " resizable: no; " + " scroll:no;" + " status:no;" + " dialogWidth:550px;" + " dialogHeight:520px;";
            string popupScript = "javascript:" + "window.showModalDialog('" + PageName + "','','" + features.ToString() + "')";

            return popupScript.ToString();
        }

        public static void ShowMessage(string message, Page objPage)
        {
            string popupScript = "<script language='javascript'>" + "alert('" + message + "') </script>";
            popupScript = popupScript.Replace("\n", "");
            ScriptManager.RegisterStartupScript(objPage, objPage.GetType(), "popupScript", popupScript.ToString(), false);
        }

        public static void ClosePage(string PageName, Page objPage)
        {
            string popupScript = "<script language='javascript'>" + "window.close()</script>";
            ScriptManager.RegisterStartupScript(objPage, objPage.GetType(), "popupScript", popupScript.ToString(), false);
        }
    }
}