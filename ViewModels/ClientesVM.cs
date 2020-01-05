using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ViewModels.Libreria;
using Models.Conexion;
using System.Data;

namespace ViewModels
{
    public class ClientesVM
    {
        private List<Label> _labelCliente_Error;
        private List<TextBox> _textBoxCliente;
        private PictureBox _ImagePictureBox;
        private CheckBox _checkBoxCredito;
        private Bitmap _imageBitmap;
        
       

        public ClientesVM(object[] objetos,List<TextBox> textBoxCliente, List<Label> labelCliente_Error)
        {
            _textBoxCliente = textBoxCliente;
            _labelCliente_Error = labelCliente_Error;
            _ImagePictureBox = (PictureBox)objetos[0];
            _checkBoxCredito = (CheckBox)objetos[1];
            _imageBitmap = (Bitmap)objetos[2];            
        }
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
        }

        public void limpiarLabelClienteError()
        {
            var tam = _textBoxCliente.Count;
            for (var i = 0; i <=tam  - 1; i++)
            {                
                    _labelCliente_Error[i].Visible = false;   
            }

        }

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
        }

        
        public void restablecer()
        {
            var tam = _textBoxCliente.Count;

            _ImagePictureBox.Image = _imageBitmap;
            _checkBoxCredito.Checked = false;                  
            for (var i = 0; i <= tam - 1; i++)
            {                                   
                _labelCliente_Error[i].Visible = false;
                _textBoxCliente[i].Text = "";                
            }//for
        }

        public int checarCredito()
        {
            if (_checkBoxCredito.Checked)
            {
                return 1;
            }else
            {
                return 0;
            }
        }

        public void nuevo_cliente()
        {
            var srcImagen = Objects.uploadimage.ResizeImage(_ImagePictureBox.Image, 165, 100);
            var imagen = Objects.uploadimage.ImageToByte(srcImagen);
            DateTime date = DateTime.UtcNow.Date;
            var fecha = date.ToString("yyyy/MM/dd");
            int credito = checarCredito();
            
            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = ConexionSQL.conexion;
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("nuevo_cliente", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                Console.WriteLine(_textBoxCliente[0].Text);
                
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
                MessageBox.Show("El cliente se guardo correctamente");

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
