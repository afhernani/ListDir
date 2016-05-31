/*
 * Created by SharpDevelop.
 * User: Hernani Aleman
 * Date: 29-10-2012
 * Time: 14:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace ListDir
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            FormAcceso fAcceso = new FormAcceso();
            if (fAcceso.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fAcceso.Close();
                Application.Run(new MainForm());
            }
        }
    }
}
