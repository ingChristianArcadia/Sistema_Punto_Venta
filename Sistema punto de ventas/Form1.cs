using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModels;
using ViewModels.Libreria;


namespace Sistema_punto_de_ventas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*************************************
        *                                    *
        *       CODIGO DEL CLIENTES          *
        *                                    *
        **************************************/
        #region

        private ClientesVM clientes;        
        private void buttonCliente_Click(object sender, EventArgs e)
        {           

            tabControlPrincipal.SelectedIndex = 1;
        }
        
        private void pictureBoxCliente_Click(object sender, EventArgs e)
        {
            Objects.uploadimage.CargarImagen(pictureBoxCliente);     
        }        
        
        private void textBoxCliente_Nombre_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCliente_Nombre.Text.Equals(""))
            {
                labelCliente_Nombre.ForeColor = Color.LightSlateGray;
            }
            else
            {
                labelCliente_Nombre.Text = "Nombre(s)";
                labelCliente_Nombre.ForeColor = Color.Green;
            }
        }

        private void textBoxCliente_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objects.eventos.textKeyPress(e);
        }

        private void textBoxCliente_Apellido_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCliente_Apellido.Text.Equals(""))
            {
                labelCliente_Apellido.ForeColor = Color.LightSlateGray;
            }
            else
            {
                labelCliente_Apellido.Text = "Apellido(s)";
                labelCliente_Apellido.ForeColor = Color.Green;
            }

        }

        private void textBoxCliente_Apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objects.eventos.textKeyPress(e);
        }

        private void textBoxCliente_Email_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCliente_Email.Text.Equals(""))
            {
                labelCliente_Email.ForeColor = Color.LightSlateGray;
            }
            else
            {
                labelCliente_Email.Text = "Correo";
                labelCliente_Email.ForeColor = Color.Green;
            }
        }

        private void textBoxCliente_Email_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBoxCliente_Telefono_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCliente_Telefono.Text.Equals(""))
            {
                labelCliente_Telefono.ForeColor = Color.LightSlateGray;
            }
            else
            {
                labelCliente_Telefono.Text = "Telefono";
                labelCliente_Telefono.ForeColor = Color.Green;
            }

        }

        private void textBoxCliente_Telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objects.eventos.numberKeyPress(e);
        }

        private void textBoxCliente_Direccion_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCliente_Direccion.Text.Equals(""))
            {
                labelCliente_Direccion.ForeColor = Color.LightSlateGray;
            }
            else
            {
                labelCliente_Direccion.Text = "Direccion";
                labelCliente_Direccion.ForeColor = Color.Green;
            }

        }

        private void textBoxCliente_Direccion_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void buttonCliente_Agregar_Click(object sender, EventArgs e)
        {
            labelPrueba.Visible = false; //Eliminar al final
            clientes.limpiarLabelClienteError();               
            bool b1 =  clientes.EsVacio();            
            bool b2 = clientes.ValidarCorreo(textBoxCliente_Email.Text);
            if((b1 == true) && (b2 == true))
            {
                labelPrueba.Text = "Dato insertado";
                labelPrueba.Visible = true;
            }
            
        }

        private void buttonCliente_Cancelar_Click(object sender, EventArgs e)
        {

        }

        private void tabControlPrincipal_Selected(object sender, TabControlEventArgs e)
        {
            var textBoxCliente = new List<TextBox>();
            
            //textBoxCliente.Add(textBoxCliente_Nid);
            textBoxCliente.Add(textBoxCliente_Nombre);
            textBoxCliente.Add(textBoxCliente_Apellido);
            textBoxCliente.Add(textBoxCliente_Email);
            textBoxCliente.Add(textBoxCliente_Direccion);
            textBoxCliente.Add(textBoxCliente_Telefono);

            var labelCliente_Error = new List<Label>();
            labelCliente_Error.Add(labelCliente_Nombre_Error);
            labelCliente_Error.Add(labelCliente_Apellido_Error);
            labelCliente_Error.Add(labelCliente_Email_Error);
            labelCliente_Error.Add(labelCliente_Direccion_Error);
            labelCliente_Error.Add(labelCliente_Telefono_Error);
            clientes = new ClientesVM(textBoxCliente, labelCliente_Error);

        }

        #endregion


    }
}
