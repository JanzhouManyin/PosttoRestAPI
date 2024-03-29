﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosttoRestAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region
        private void cmdGO_Click(object sender, EventArgs e)
        {
            RestClass rClient = new RestClass();
            rClient.endPoint = txtRequestURI.Text;
            switch (cboVerb.Text)
            {
                case "POST":
                    rClient.httpMethod = httpVerb.POST;
                    rClient.postJSON = txtPOSTData.Text;
                    break;
                default:
                    rClient.httpMethod = httpVerb.GET;
                    break;
            }
            rClient.userName = txtUserName.Text;
            rClient.userPassword = txtPassword.Text;
            string strResponse = string.Empty;
            strResponse = rClient.MakeRequest();
            debugOutput(strResponse);
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtResponse.Text = string.Empty;
        }

        private void cmdCopy_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(txtResponse.Text);
        }
        #endregion
        private void debugOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                txtResponse.Text = txtResponse.Text + strDebugText + Environment.NewLine;
                txtResponse.SelectionStart = txtResponse.TextLength;
                txtResponse.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }

        
    }
}
