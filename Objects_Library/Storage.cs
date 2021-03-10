using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects_Library
{
    public class Storage
    {
        public string Text { get; set; }
        public int Number { get; set; }

        public Storage(string text, int number)
        {
            this.Text = text;
            this.Number = number;
        }

        public override string ToString()
        {
            return string.Format("Product's code: {0} \nQuantity in storage: {1} ", Text, Number);
        }
    }
}
