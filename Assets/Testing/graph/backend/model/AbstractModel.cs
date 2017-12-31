using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblyCSharp
{
    public class AbstractModel
    {
        protected long mId;
        public long Id
        {
            get
            {
                return mId;
            }

            set
            {
                mId = value;
            }
        }
    }
}
