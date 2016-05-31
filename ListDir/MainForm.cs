/*
 * Created by SharpDevelop.
 * User: Hernani Aleman
 * Date: 29-10-2012
 * Time: 14:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Linq;

namespace ListDir
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		//System.IO.DriveInfo driv;
		DirectoryInfo drivInfo;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			//limpia el trrepath, para dejarlo ok
			treePath.Nodes.Clear();
			//añadir cada una de las unidades lógicas
			foreach(string Unidad in Directory.GetLogicalDrives())
			{
				treePath.Nodes.Add(Unidad); //añade las raices que son
				//las distintas unidades.
				//if(Unidad =="C:\\") treePath.SelectedNode.Checked=true;
			}
			treePath.SelectedNode = treePath.Nodes[0];
			txtpath.Text=treePath.SelectedNode.Text;
		}
		//al seleccionar el archivo.
		void LtArchivosSelectedIndexChanged(object sender, EventArgs e)
		{
			/*
			//al selecionar un archivo
			//comprueba el nombre del archivo
			string NombreArchivo = cbUnidades.Text+treePath.SelectedNode.Text+
				Path.DirectorySeparatorChar+ ltArchivos.Text;
			//y lo abrimos para lectura
			StreamReader SRArchivo = File.OpenText(NombreArchivo);
			//se lee completo asignando el contenido a textbox
			tbTexto.Text=SRArchivo.ReadToEnd();
			SRArchivo.Close();//lo cerramos
			*/
		}
		
		void TreePathAfterSelect(object sender, TreeViewEventArgs e)
		{
			//limpia el treepath, txtpath y ltArchivos.
			ltArchivos.Items.Clear();
            flowPanel.Controls.Clear();
			//asigna texto a txtpath.
			txtpath.Text=treePath.SelectedNode.FullPath;
			//averiguamos si tiene hijos, si ya tiene entonces ya ha sido analizado.
			label1.Text = treePath.SelectedNode.GetNodeCount(true).ToString();
			//se establece la informacion de los ficheros.
			drivInfo= new DirectoryInfo(@treePath.SelectedNode.FullPath);
			//establecemos cualquier porblema, durante la lectura de ficheros.
            int children = treePath.SelectedNode.GetNodeCount(false);
			//problema: cuando selecciona un nudo inferior, ya scaneado, lo vuelve
			// a añadir, se soluciona averiguando el numero de nodos existentes,
            // si es cero se hace la lectura y no importa que sea el ultimo nodo, (no se añade nada).
			
			try
            {
				DirectoryInfo[] dirInfos = drivInfo.GetDirectories("*.*");
				if(dirInfos != null){
                    if (children ==0)
                    {
                        foreach (DirectoryInfo d in dirInfos)
                            treePath.SelectedNode.Nodes.Add(new TreeNode(d.Name));
                    }
				}
				treePath.SelectedNode.ExpandAll();
				label1.Text += "  : "+ treePath.SelectedNode.FullPath;
			
				FileInfo[] fileName = drivInfo.GetFiles("*.*");
				if(fileName != null)
                {
				    //para todo fichero existente adiciona a ltArchivo.
				    foreach(FileInfo fi in fileName)
					    ltArchivos.Items.Add(fi.Name);
				    // si existen ficheros no se puede igualar el inidce a cero
                    if (ltArchivos.Items.Count > 0) ltArchivos.SelectedIndex = 0;	
                    //añadiendo al flowLayoutPane - flowPanel
                    foreach (FileInfo fi in fileName)
                    {
                        
                        Button btn = new Button();
                        btn.Text = fi.FullName;
                        

                        btn.BackColor = Color.Yellow;
                        btn.Height = 80;
                        btn.Width = 115;
                        btn.Image = imageList1.Images[1];

                        btn.Click += button1_Click; 

                        flowPanel.Controls.Add(btn);
                        
                    }
                }
                
                //cargarFlowLayoutPanel();
                //carga con tarea sincronizada
                Task t = new Task(this.cargarFlowLayoutPanel);
                t.Start(TaskScheduler.FromCurrentSynchronizationContext());
                Task.WaitAll(t);     
			}
            catch (Exception ex)
            {
                
                MessageBox.Show("Algún error se ha producido... "+ ex.ToString());
			}
		}

        private void cargarFlowLayoutPanel()
        {
            DirectoryInfo[] dirInfos = drivInfo.GetDirectories("*.*");
            if (dirInfos != null)
            {
                foreach (DirectoryInfo d in dirInfos)
                {
                    /**
                    PictureBox _ptbox = new PictureBox();
                    _ptbox.Image = imageList1.Images[0];
                    _ptbox.Name = d.FullName;
                    _ptbox.Click += pictureBox_clik;

                    flowPanel.Controls.Add(_ptbox);
                     * */
                    Button btn = new Button();
                    btn.Text = d.FullName;


                    //btn.BackColor = Color.Yellow;
                    btn.Height = 80;
                    btn.Width = 115;
                    btn.Image = imageList1.Images[0];
                    btn.Click += button1_Click;

                    flowPanel.Controls.Add(btn);
                }
            }
        }
        private void taskLoadFlowLayoutPanel()
        {
            
            
        }

        private void pictureBox_clik(object sender, EventArgs e)
        {
            MessageBox.Show("se ha disparadoa el evento " + sender.ToString() +
                " Extension: " + Path.GetExtension(sender.ToString()));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("se ha disparadoa el evento "+ sender.ToString() +
                " Extension: "+Path.GetExtension(sender.ToString()));
        }
		private void RecursiveNode(TreeNode treenodo){
			//guarda la informacion en una cadena.
			System.Diagnostics.Debug.WriteLine(treenodo.Text);
			foreach(TreeNode tn in treenodo.Nodes) RecursiveNode(tn);
			
		}
		//llamada recursiva del nodo.
		private void CallRecursive(TreeView treeview){
			TreeNodeCollection nodos = treeview.Nodes;
			foreach(TreeNode n in nodos){
				RecursiveNode(n);
			}
		}
	}
}
