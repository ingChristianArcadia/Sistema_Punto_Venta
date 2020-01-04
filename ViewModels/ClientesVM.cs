using System;
using System.Collections.Generic;
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
        public void guardarCliente()
        {
            var tam = _textBoxCliente.Count;
            
            for(var i = 0; i <= tam - 1; i++)
            {
                if (_textBoxCliente[i].Text.Equals(""))
                {
                    _labelCliente_Error[i].Text = "*Este campo es requerido";
                    _labelCliente_Error[i].ForeColor = Color.Red;
                    _labelCliente_Error[i].Visible = true;
                    _textBoxCliente[i].Focus();
                }   
            }    
        }
    }
}
