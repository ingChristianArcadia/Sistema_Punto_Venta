using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ViewModels.Libreria;
using Models.Conexion;
using System.Data;
using System.Threading.Tasks;
using Models;

namespace ViewModels
{
    public class ClientesVM
    {
        private List<Label> _labelCliente_Error;
        private List<TextBox> _textBoxCliente;
        private PictureBox _ImagePictureBox;
        private CheckBox _checkBoxCredito;
        private Bitmap _imageBitmap;
        private static DataGridView _dataGridView_Cliente;
        private int _reg_por_pagina, _num_pagina = 1;




        public ClientesVM(object[] objetos,List<TextBox> textBoxCliente, List<Label> labelCliente_Error)
        {
            _textBoxCliente = textBoxCliente;
            _labelCliente_Error = labelCliente_Error;
            _ImagePictureBox = (PictureBox)objetos[0];
            _checkBoxCredito = (CheckBox)objetos[1];
            _imageBitmap = (Bitmap)objetos[2];
            _dataGridView_Cliente = (DataGridView)objetos[3];        
        }//Constructor
        public bool EsVacio()
        {
            var tam = _textBoxCliente.Count;
            bool b1 = true;
            for (var i = 0; i <= tam - 1; i++)
            {
                if (_textBoxCliente[i].Text.Equals(""))
                {
                    _labelCliente_Error[i].Text = "*Este campo es requerido";
                    _labelCliente_Error[i].ForeColor = Color.Red;
                    _labelCliente_Error[i].Visible = true;
                    _textBoxCliente[i].Focus();
                    b1 = false;                    
                }               
            }//for
            return b1;
        }//EsVacio()

        public void limpiarLabelClienteError()
        {
            var tam = _textBoxCliente.Count;
            for (var i = 0; i <=tam  - 1; i++)
            {                
                    _labelCliente_Error[i].Visible = false;   
            }

        }//LimpiarLabelCLienteError()

        public bool ValidarCorreo(string correo)
        {
            bool b2 = true;
            if (correo == "")
            {
                _labelCliente_Error[2].Text = "*Este campo es requerido";
                _labelCliente_Error[2].ForeColor = Color.Red;
                _labelCliente_Error[2].Visible = true;
                _textBoxCliente[2].Focus();
                b2 = false;
            }
            else if (new EmailAddressAttribute().IsValid(correo))
            {               
                _labelCliente_Error[2].Visible = false;                
            }else
            {
                
                _labelCliente_Error[2].Visible = true;
                _labelCliente_Error[2].Text = "*El correo no es valido";
                _labelCliente_Error[2].ForeColor = Color.Red;
                _textBoxCliente[2].Focus();
                b2 = false;

            }
            return b2;           
        }//ValidarCorreo()

        
        public void restablecer()
        {
            _num_pagina = 1;
            var tam = _textBoxCliente.Count;
            _ImagePictureBox.Image = _imageBitmap;
            _checkBoxCredito.Checked = false;                  
            for (var i = 0; i <= tam - 1; i++)
            {                                   
                _labelCliente_Error[i].Visible = false;
                _textBoxCliente[i].Text = "";                
            }//for
        }//restablecer()

        public bool checarCredito()
        {
            if (_checkBoxCredito.Checked)
            {
                return true;
            }else
            {
                return false;
            }
        }//checarCredito()

        public void nuevo_cliente()
        {
            var srcImagen = Objects.uploadimage.ResizeImage(_ImagePictureBox.Image, 165, 100);
            var imagen = Objects.uploadimage.ImageToByte(srcImagen);
            DateTime date = DateTime.UtcNow.Date;
            var fecha = date.ToString("yyyy/MM/dd");
            bool credito = checarCredito();
            
            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = ConexionSQL.conexion;
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("nuevo_cliente", connection);
                cmd.CommandType = CommandType.StoredProcedure;                
                
                cmd.Parameters.AddWithValue("@Nombre",_textBoxCliente[0].Text);
                cmd.Parameters.AddWithValue("@Apellido",_textBoxCliente[1].Text);
                cmd.Parameters.AddWithValue("@Correo", _textBoxCliente[2].Text);
                cmd.Parameters.AddWithValue("@Direccion", _textBoxCliente[4].Text);
                cmd.Parameters.AddWithValue("@Telefono", _textBoxCliente[3].Text);                
                cmd.Parameters.AddWithValue("@Fecha", fecha);
                cmd.Parameters.AddWithValue("@Credito", credito);
                cmd.Parameters.AddWithValue("@Imagen", imagen);
                cmd.ExecuteNonQuery();
                connection.Close();
                restablecer();
                llenarGridClientes();
                MessageBox.Show("El cliente se creo correctamente");

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }//nuevo_cliente()

        public void llenarGridClientes()
        {
            
            try
            {
                SqlConnection connection = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter sqlAdapter = new SqlDataAdapter();
                DataTable dataT = new DataTable();
                
                connection.ConnectionString = ConexionSQL.conexion;
                connection.Open();
                cmd = new SqlCommand("select_all_cliente", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                sqlAdapter.SelectCommand = cmd;
                sqlAdapter.Fill(dataT);
                _dataGridView_Cliente.DataSource = dataT;
                cmd.Dispose();
                connection.Close();
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }//BuscarCliente
    }
}
