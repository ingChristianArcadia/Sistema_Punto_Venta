using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Libreria
{
    public class TextBoxEvent
    {
        public void textKeyPress(KeyPressEventArgs e)
        {
            //Condicion que solo nos permite ingresar dato de tipo texto
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }else if(e.KeyChar == Convert.ToChar(Keys.Enter)) //Condicion que permite no dar daltos de linea cuando se oprime Enter.
            {
                e.Handled = true;
            }else if (char.IsControl(e.KeyChar)) //Condicion que permite utilizar la tecla backspace
            {
                e.Handled = false;
            }else if (char.IsSeparator(e.KeyChar)) //Condicion que permite utilizar la tecla espacio
            {
                e.Handled = false;
            }else
            {
                e.Handled = true;
            }
        }

        public void numberKeyPress(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Enter)) //Condicion que permite no dar daltos de linea cuando se oprime Enter.
            {
                e.Handled = true;
            }
            else if (char.IsLetter(e.KeyChar))//No permite ingresar datos de tipo texto
            {
                e.Handled = true;
            }
            else if (char.IsControl(e.KeyChar)) //Condicion que permite utilizar la tecla backspace
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar)) //Condicion que permite utilizar la tecla espacio
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        public bool comprobarFormatoEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
