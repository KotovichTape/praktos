using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktos
{
    internal class Data
    {
        public List<string> chosedPositions;
        public DateTime date;
        public int Index;

        public Data(List<string> pos_, DateTime date_, int index)
        {
            chosedPositions = pos_;
            date = date_;
            Index = index;
        }
    }
}
