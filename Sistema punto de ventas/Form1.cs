﻿using System;
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
            
            clientes.limpiarLabelClienteError();               
            bool b1 =  clientes.EsVacio();            
            bool b2 = clientes.ValidarCorreo(textBoxCliente_Email.Text);           
            
            if((b1 == true) && (b2 == true))
            {
                
                clientes.nuevo_cliente();
            }
            
        }

        private void buttonCliente_Cancelar_Click(object sender, EventArgs e)
        {
            clientes.restablecer();
        }

        private void tabControlPrincipal_Selected(object sender, TabControlEventArgs e)
        {
            var textBoxCliente = new List<TextBox>();

         
            textBoxCliente.Add(textBoxCliente_id);
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
            labelCliente_Error.Add(labelCliente_Mensaje_Error);


            object[] objetos =
            {
                pictureBoxCliente,
                checkBoxCliente_Credito,
                Properties.Resources.select,
                dataGridView_Cliente
            };

            clientes = new ClientesVM(objetos,textBoxCliente, labelCliente_Error);
            clientes.llenarGridClientes();
        }


        

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'punto_VentasDataSet1.select_all_cliente' Puede moverla o quitarla según sea necesario.
            this.select_all_clienteTableAdapter1.Fill(this.punto_VentasDataSet1.select_all_cliente);
            // TODO: esta línea de código carga datos en la tabla 'punto_VentasDataSet.select_all_cliente' Puede moverla o quitarla según sea necesario.
            this.select_all_clienteTableAdapter.Fill(this.punto_VentasDataSet.select_all_cliente);

        }

        private void dataGridView_Cliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_Cliente.Rows.Count != 0)
            {
                clientes.getClienteDeGridViewCliente();
            }
            
        }

        private void dataGridView_Cliente_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridView_Cliente.Rows.Count != 0)
            {
                clientes.getClienteDeGridViewCliente();
            }
        }
        

        private void textBoxCliente_Buscar_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCliente_Buscar.Text.Equals(""))
            {
                clientes.llenarGridClientes();
            }
            else
            {
                clientes.llenarGridClientesBuscar(textBoxCliente_Buscar.Text);
            }
            
        }
      

        private void tabControIizq_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControlizq.SelectedIndex)
            {
                case 0:
                    tabControlDer.SelectedIndex = 0;
                    break;
                case 1:
                    tabControlDer.SelectedIndex = 1;
                    break;
            }
        }

        private void tabControlDer_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControlDer.SelectedIndex)
            {
                case 0:
                    tabControlizq.SelectedIndex = 0;
                    break;
                case 1:
                    tabControlizq.SelectedIndex = 1;
                    break;
            }
        }
        #endregion
    }
}
