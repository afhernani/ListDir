/*
 * Creado por SharpDevelop.
 * Usuario: hernani Aleman 
 * Fecha: 01-11-2012
 * Hora: 11:47
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar.
 * 
 * formulario, propiedades:
 * 		FormBorderStyle = FixedDialog.
 * 		ControlBox, MaximizeBox y MInimizeBox = false.
 * 		AccepButton = btnAceptar, del formulario.
 * 		CancelButton = btnCancelar.
 * textBox, name= txtClave, PasswordChar = *;
 * buttonBox, name = btnAceptar.
 * buttonBox, name = btnCancelar.
 * 
 * 
 * 
 * 
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ListDir
{
	/// <summary>
	/// Description of FormAcceso.
	/// </summary>
	public partial class FormAcceso : Form
	{
		int veces=0; //intento
		const int NumeroIntentos=3;//numero de intentos permitidos.
		public FormAcceso()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void BtnCancelarClick(object sender, EventArgs e)
		{
			// DialogResult, es el valor devuelto por el porpio dialogo.
			this.DialogResult= DialogResult.Cancel;
			//en vez de cerrarlo, lo ocultamos para que funcione mejor.
			Hide();
		}
		
		void BtnAceptarClick(object sender, EventArgs e)
		{
			//comporbamos si la clave escrita es la correcta: 123456
			if(txtClave.Text=="123456"){
				this.DialogResult=DialogResult.OK;
			}else{
				//permitir varios intentos.
				veces +=1;
				if(veces<NumeroIntentos){
					label1.Text = "Quedan "+ (NumeroIntentos-veces)+" intentos:";
					return;
				}
				this.DialogResult=DialogResult.No;
			}
			//ocultamos el formulario.
			Hide();
		}
	}
}
