using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModels.Libreria;

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

        public bool ImageSize()
        {

            var srcImagen = Objects.uploadimage.ResizeImage(_ImagePictureBox.Image,165,100);
            var imagen = Objects.uploadimage.ImageToByte(srcImagen);
            return false;
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
    }
}
