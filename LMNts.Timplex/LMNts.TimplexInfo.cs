using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace LMNts.Timplex
{
    public class TimplexInfo : GH_AssemblyInfo
      {
        public override string Name
        {
            get
            {
                return "Timplex";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "A single line font generator for fabrication";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("beb51f25-8642-4e19-a505-fb6ea1dba56d");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "Timothy Logan";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "tlogan@hksinc.com";
            }
        }
    }
}
