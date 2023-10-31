using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LibraryDB.Scripts
{
    internal class GetValue
    {
        public int GetId(ComboBox comboBox, string value)
        {
            comboBox.DisplayMemberPath = "id";
            int rezult = Convert.ToInt32(comboBox.Text);
            comboBox.DisplayMemberPath = value;
            return rezult;
        }
    }
}
