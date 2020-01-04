using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ViewModels
{
    public class ClientesVM
    {
        private List<Label> _labelCliente_Error;
        private List<TextBox> _textBoxCliente;

        public ClientesVM(List<TextBox> textBoxCliente, List<Label> labelCliente_Error)
        {
            _textBoxCliente = textBoxCliente;
            _labelCliente_Error = labelCliente_Error;
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
    }
}
