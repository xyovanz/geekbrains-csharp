using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L8App01
{
    public class Question
    {
        public string Text { get; set; }

        public bool TrueFalse { get; set; }

        #region Constructors

        public Question()
        {

        }

        public Question(string text, bool trueFalse)
        {
            Text = text;
            TrueFalse = trueFalse;
        }

        #endregion
    }
}
