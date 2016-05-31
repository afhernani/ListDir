/*
 * Created by SharpDevelop.
 * User: Amigo
 * Date: 29-10-2012
 * Time: 14:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ListDir
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtpath = new System.Windows.Forms.TextBox();
            this.treePath = new System.Windows.Forms.TreeView();
            this.ltArchivos = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // txtpath
            // 
            this.txtpath.Location = new System.Drawing.Point(11, 11);
            this.txtpath.Name = "txtpath";
            this.txtpath.Size = new System.Drawing.Size(537, 20);
            this.txtpath.TabIndex = 2;
            // 
            // treePath
            // 
            this.treePath.Location = new System.Drawing.Point(11, 38);
            this.treePath.Name = "treePath";
            this.treePath.Size = new System.Drawing.Size(247, 355);
            this.treePath.TabIndex = 3;
            this.treePath.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreePathAfterSelect);
            // 
            // ltArchivos
            // 
            this.ltArchivos.FormattingEnabled = true;
            this.ltArchivos.Location = new System.Drawing.Point(264, 38);
            this.ltArchivos.Name = "ltArchivos";
            this.ltArchivos.Size = new System.Drawing.Size(284, 355);
            this.ltArchivos.TabIndex = 4;
            this.ltArchivos.SelectedIndexChanged += new System.EventHandler(this.LtArchivosSelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 403);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(861, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // flowPanel
            // 
            this.flowPanel.AutoScroll = true;
            this.flowPanel.BackColor = System.Drawing.SystemColors.Control;
            this.flowPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowPanel.Location = new System.Drawing.Point(555, 12);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flowPanel.Size = new System.Drawing.Size(378, 415);
            this.flowPanel.TabIndex = 6;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "archivos-04.png");
            this.imageList1.Images.SetKeyName(1, "archivos-91.png");
            this.imageList1.Images.SetKeyName(2, "imagen-i-02.png");
            this.imageList1.Images.SetKeyName(3, "Movie.png");
            this.imageList1.Images.SetKeyName(4, "Cabinet.png");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 439);
            this.Controls.Add(this.flowPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ltArchivos);
            this.Controls.Add(this.treePath);
            this.Controls.Add(this.txtpath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "ListDir";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox ltArchivos;
		private System.Windows.Forms.TreeView treePath;
		private System.Windows.Forms.TextBox txtpath;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private System.Windows.Forms.ImageList imageList1;
	}
}
