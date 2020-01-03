using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        *       CODIGO DEL CLIENTE           *
        *                                    *
        **************************************/
        #region
        private void buttonCliente_Click(object sender, EventArgs e)
        {
            tabControlPrincipal.SelectedIndex = 1;
        }



        

        private void pictureBoxCliente_Click(object sender, EventArgs e)
        {
            Objects.uploadimage.CargarImagen(pictureBoxCliente);     
        }

        
        private void textBoxCliente_Nid_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCliente_Nid.Text.Equals(""))
            {
                labelCliente_Nid.ForeColor = Color.LightSlateGray;
            }else
            {
                labelCliente_Nid.Text = "Numero  ID";
                labelCliente_Nid.ForeColor = Color.Green;
            }
        }
        

        private void textBoxCliente_Nid_KeyPress(object sender, KeyPressEventArgs e)
        {

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

        #endregion

       
    }
}
