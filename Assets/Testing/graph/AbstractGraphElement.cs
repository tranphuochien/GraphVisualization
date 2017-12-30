using System;

namespace AssemblyCSharp
{
	public abstract class AbstractGraphElement
	{
		public abstract long GetId();

        public virtual string GetUrl() { return ""; }
	}
}

