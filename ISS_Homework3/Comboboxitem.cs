using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISS_Homework3
{
    public class ComboboxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public int p_id { get; set; }
        public bool full;
        public bool read;
        public bool write;
        public bool modify;
        public bool delete;
        public bool execute;

        public override string ToString()
        {
            return Text;
        }
    }
}
