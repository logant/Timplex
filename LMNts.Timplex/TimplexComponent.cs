using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace LMNts.Timplex
{
    public class TimplexComponent : GH_Component
    {
        Point3d currentPt;
        Point3d origPt;
        Point3d lineOrigin;
        double kerning;
        double textHeight;

        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public TimplexComponent()
          : base("Single Line Font", "Timplex",
              "Single Line Font Generator",
              "Sets", "Text")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Text", "T", "Text to convert to single line font stlye.", GH_ParamAccess.item);
            pManager.AddNumberParameter("Size", "S", "Hight of the font.", GH_ParamAccess.item, 1.0);
            pManager.AddPlaneParameter("Location", "L", "Location of left side of the Single Line Font curves.", GH_ParamAccess.item, Plane.WorldXY);
            pManager.AddNumberParameter("Kerning", "K", "Adjust the kerning of the curves.", GH_ParamAccess.item, 1.0);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddCurveParameter("Curves", "C", "Single line font curves representing the incoming text.", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string text = string.Empty;
            textHeight = 1;
            Plane plane = Plane.WorldXY;
            double k = 1;

            DA.GetData(0, ref text);
            DA.GetData(1, ref textHeight);
            DA.GetData(2, ref plane);
            DA.GetData(3, ref k);

            string upperText = text.ToUpper();
            char[] chars = upperText.ToCharArray();
            kerning = k / 2;
            List<Curve> fontCrvs = new List<Curve>();
            for(int i = 0; i < chars.Length; i++)
            {
                // Assign the origin
                if(i == 0)
                {
                    currentPt = Point3d.Origin;
                    lineOrigin = Point3d.Origin;
                }

                List<Curve> charCrvs = new List<Curve>();
                switch(chars[i])
                {
                    case 'A':
                        charCrvs = LetterA(currentPt);
                        break;
                    case 'B':
                        charCrvs = LetterB(currentPt);
                        break;
                    case 'C':
                        charCrvs = LetterC(currentPt);
                        break;
                    case 'D':
                        charCrvs = LetterD(currentPt);
                        break;
                    case 'E':
                        charCrvs = LetterE(currentPt);
                        break;
                    case 'F':
                        charCrvs = LetterF(currentPt);
                        break;
                    case 'G':
                        charCrvs = LetterG(currentPt);
                        break;
                    case 'H':
                        charCrvs = LetterH(currentPt);
                        break;
                    case 'I':
                        charCrvs = LetterI(currentPt);
                        break;
                    case 'J':
                        charCrvs = LetterJ(currentPt);
                        break;
                    case 'K':
                        charCrvs = LetterK(currentPt);
                        break;
                    case 'L':
                        charCrvs = LetterL(currentPt);
                        break;
                    case 'M':
                        charCrvs = LetterM(currentPt);
                        break;
                    case 'N':
                        charCrvs = LetterN(currentPt);
                        break;
                    case 'O':
                        charCrvs = LetterO(currentPt);
                        break;
                    case 'P':
                        charCrvs = LetterP(currentPt);
                        break;
                    case 'Q':
                        charCrvs = LetterQ(currentPt);
                        break;
                    case 'R':
                        charCrvs = LetterR(currentPt);
                        break;
                    case 'S':
                        charCrvs = LetterS(currentPt);
                        break;
                    case 'T':
                        charCrvs = LetterT(currentPt);
                        break;
                    case 'U':
                        charCrvs = LetterU(currentPt);
                        break;
                    case 'V':
                        charCrvs = LetterV(currentPt);
                        break;
                    case 'W':
                        charCrvs = LetterW(currentPt);
                        break;
                    case 'X':
                        charCrvs = LetterX(currentPt);
                        break;
                    case 'Y':
                        charCrvs = LetterY(currentPt);
                        break;
                    case 'Z':
                        charCrvs = LetterZ(currentPt);
                        break;
                    case '0':
                        charCrvs = Zero(currentPt);
                        break;
                    case '1':
                        charCrvs = One(currentPt);
                        break;
                    case '2':
                        charCrvs = Two(currentPt);
                        break;
                    case '3':
                        charCrvs = Three(currentPt);
                        break;
                    case '4':
                        charCrvs = Four(currentPt);
                        break;
                    case '5':
                        charCrvs = Five(currentPt);
                        break;
                    case '6':
                        charCrvs = Six(currentPt);
                        break;
                    case '7':
                        charCrvs = Seven(currentPt);
                        break;
                    case '8':
                        charCrvs = Eight(currentPt);
                        break;
                    case '9':
                        charCrvs = Nine(currentPt);
                        break;
                    case '.':
                        charCrvs = Period(currentPt);
                        break;
                    case ',':
                        charCrvs = Comma(currentPt);
                        break;
                    case ':':
                        charCrvs = Colon(currentPt);
                        break;
                    case ';':
                        charCrvs = SemiColon(currentPt);
                        break;
                    case '\'':
                        charCrvs = Apostrophe(currentPt);
                        break;
                    case '\"':
                        charCrvs = dQuotes(currentPt);
                        break;
                    case '\\':
                        charCrvs = bSlash(currentPt);
                        break;
                    case '/':
                        charCrvs = fSlash(currentPt);
                        break;
                    case '?':
                        charCrvs = Question(currentPt);
                        break;
                    case '-':
                        charCrvs = Hyphen(currentPt);
                        break;
                    case '_':
                        charCrvs = Underscore(currentPt);
                        break;
                    case '+':
                        charCrvs = Plus(currentPt);
                        break;
                    case '=':
                        charCrvs = Equal(currentPt);
                        break;
                    case '<':
                        charCrvs = Less(currentPt);
                        break;
                    case '>':
                        charCrvs = Greater(currentPt);
                        break;
                    case '!':
                        charCrvs = Exclaim(currentPt);
                        break;
                    case '@':
                        charCrvs = At(currentPt);
                        break;
                    case '#':
                        charCrvs = Pound(currentPt);
                        break;
                    case '$':
                        charCrvs = Dollar(currentPt);
                        break;
                    case '%':
                        charCrvs = Percent(currentPt);
                        break;
                    case '^':
                        charCrvs = Caret(currentPt);
                        break;
                    case '&':
                        charCrvs = Amp(currentPt);
                        break;
                    case '*':
                        charCrvs = Ast(currentPt);
                        break;
                    case '(':
                        charCrvs = oPar(currentPt);
                        break;
                    case ')':
                        charCrvs = cPar(currentPt);
                        break;
                    case '|':
                        charCrvs = Pipe(currentPt);
                        break;
                    case '[':
                        charCrvs = lBraket(currentPt);
                        break;
                    case ']':
                        charCrvs = rBraket(currentPt);
                        break;
                    case '{':
                        charCrvs = lCurly(currentPt);
                        break;
                    case '}':
                        charCrvs = rCurly(currentPt);
                        break;
                    case '`':
                        charCrvs = Accent(currentPt);
                        break;
                    case '~':
                        charCrvs = Tilde(currentPt);
                        break;
                    case '°':
                        charCrvs = Degree(currentPt);
                        break;
                    case '±':
                        charCrvs = PlusMinus(currentPt);
                        break;
                    case '²':
                        charCrvs = Squared(currentPt);
                        break;
                    case '³':
                        charCrvs = Cubed(currentPt);
                        break;
                    case '÷':
                        charCrvs = Division(currentPt);
                        break;
                    case '¢':
                        charCrvs = Cent(currentPt);
                        break;
                    case '£':
                        charCrvs = BPound(currentPt);
                        break;
                    case '¥':
                        charCrvs = Yen(currentPt);
                        break;
                    case '€':
                        charCrvs = Euro(currentPt);
                        break;
                    case '≠':
                        charCrvs = NotEqual(currentPt);
                        break;
                    case '≤':
                        charCrvs = LessEqual(currentPt);
                        break;
                    case '≥':
                        charCrvs = GreaterEqual(currentPt);
                        break;
                    case (char)13:
                        charCrvs = CR(currentPt);
                        i++;
                        break;
                    case ' ':
                        charCrvs = Spacebar(currentPt);
                        break;
                    default:
                        charCrvs = Unknown(currentPt);
                        break;
                }

                if(charCrvs != null && charCrvs.Count > 0)
                {
                    fontCrvs.AddRange(charCrvs);
                }
            }

            if(fontCrvs.Count > 0)
            {
                // Orient the curves to the new plane
                Grasshopper.Kernel.Types.Transforms.ITransform transform = new Grasshopper.Kernel.Types.Transforms.Orientation(Plane.WorldXY, plane);
                List<Curve> orientCrvs = new List<Curve>();
                foreach (Curve c in fontCrvs)
                {
                    // Scale to match textHeight
                    c.Scale(textHeight);
                    Grasshopper.Kernel.Types.GH_Curve ghCrv = new Grasshopper.Kernel.Types.GH_Curve(c);

                    Grasshopper.Kernel.Types.IGH_GeometricGoo baseGoo = ghCrv as Grasshopper.Kernel.Types.IGH_GeometricGoo;
                    Grasshopper.Kernel.Types.IGH_GeometricGoo dupGoo = baseGoo.DuplicateGeometry();
                    dupGoo = dupGoo.Transform(transform.ToMatrix());
                    Grasshopper.Kernel.Types.GH_Curve orientedCrv = dupGoo as Grasshopper.Kernel.Types.GH_Curve;
                    orientCrvs.Add(orientedCrv.Value);
                }
                DA.SetDataList(0, orientCrvs);
            }
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return Properties.Resources.slf;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("{ec3a767b-2038-49b1-a58e-3fb3dd1b0363}"); }
        }

        public override GH_Exposure Exposure
        {
            get
            {
                return GH_Exposure.quarternary | GH_Exposure.obscure;
            }
        }

        private List<Curve> Unknown(Point3d pt)
        {
            List<Curve> crvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 0, 0);
            Point3d pt2 = pt1 + new Vector3d(0.625, 0, 0);
            Point3d pt3 = pt2 + new Vector3d(0, 1.0, 0);
            Point3d pt4 = pt3 + new Vector3d(-0.625, 0, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt2, pt3);
            Line ln3 = new Line(pt3, pt4);
            Line ln4 = new Line(pt4, pt1);
            crvs.Add(ln1.ToNurbsCurve());
            crvs.Add(ln2.ToNurbsCurve());
            crvs.Add(ln3.ToNurbsCurve());
            crvs.Add(ln4.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return crvs;
        }

        private List<Curve> Zero(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.625 + kerning, 0.3125, 0);
            Point3d pt2a = pt1 + new Vector3d(0, 0.375, 0);
            Point3d pt2b = pt2a + new Vector3d(-0.3125, 0.3125, 0);
            Point3d pt2c = pt2b + new Vector3d(-0.3125, -0.3125, 0);
            Point3d pt3a = pt2c + new Vector3d(0, -0.375, 0);
            Point3d pt3b = pt3a + new Vector3d(0.3125, -0.3125, 0);
            Line ln1 = new Line(pt1, pt2a);
            Arc arc1 = new Arc(pt2a, pt2b, pt2c);
            Line ln2 = new Line(pt2c, pt3a);
            Arc arc2 = new Arc(pt3a, pt3b, pt1);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(arc1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(arc2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> One(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 0.8125, 0);
            Point3d pt2 = pt1 + new Vector3d(0.1875, 0.1875, 0);
            Point3d pt3 = pt2 + new Vector3d(0, -1.0, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt2, pt3);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.1875 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Two(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1a = pt + new Vector3d(kerning, 0.6875, 0);
            Point3d pt1b = pt1a + new Vector3d(0.3125, 0.3125, 0);
            Point3d pt1c = pt1b + new Vector3d(0.3125, -0.3125, 0);
            Point3d pt2 = pt + new Vector3d(kerning, 0, 0);
            Point3d pt3 = pt2 + new Vector3d(0.625, 0, 0);
            Arc arc1 = new Arc(pt1a, pt1b, pt1c);
            Line ln1 = new Line(pt1c, pt2);
            Line ln2 = new Line(pt2, pt3);
            letterCrvs.Add(arc1.ToNurbsCurve());
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Three(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 1.0, 0);
            Point3d pt2 = pt1 + new Vector3d(0.625, 0, 0);
            Point3d pt3a = pt + new Vector3d(0.3125 + kerning, 0.625, 0);
            Point3d pt3b = pt3a + new Vector3d(0, -0.625, 0);
            Point3d pt3c = pt3b + new Vector3d(-0.3125, 0.3125, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt2, pt3a);
            Arc arc1 = new Arc(pt3a, pt3b, pt3c);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(arc1.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Four(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.5625 + kerning, (double)(1.0 / 3.0), 0);
            Point3d pt2 = pt1 + new Vector3d(-0.5625, 0, 0);
            Point3d pt3 = pt2 + new Vector3d(0.5, (double)(2.0 / 3.0), 0);
            Point3d pt4 = pt3 + new Vector3d(0, -1.0, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt2, pt3);
            Line ln3 = new Line(pt3, pt4);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.5625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Five(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, ((0.75 - (2.0 * 0.375 * (Math.Sin((2 * Math.Acos((0.375 - 0.125) / 0.375)) / 2)))) / 2), 0);
            Point3d pt1b = pt + new Vector3d(0.5625 + kerning, 0.5625, 0);
            Point3d pt1c = pt + new Vector3d(kerning, 0.75 - ((0.75 - (2.0 * 0.375 * (Math.Sin((2 * Math.Acos((0.375 - 0.125) / 0.375)) / 2)))) / 2), 0);
            Point3d pt2 = pt + new Vector3d(kerning, 1.0, 0);
            Point3d pt3 = pt2 + new Vector3d(0.5625, 0, 0);
            Arc arc1 = new Arc(pt1, pt1b, pt1c);
            Line ln1 = new Line(pt1c, pt2);
            Line ln2 = new Line(pt2, pt3);
            letterCrvs.Add(arc1.ToNurbsCurve());
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Six(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.3125 + kerning, 0.3125, 0);
            Point3d pt2 = pt1 + new Vector3d(Math.Sin(Math.PI / 4) * -0.3125, Math.Sin(Math.PI / 4) * 0.3125, 0);
            Point3d pt3 = pt2 + new Vector3d(1.0 - (0.3125 + (Math.Sin(Math.PI / 4) * 0.3125)), 1.0 - (0.3125 + (Math.Sin(Math.PI / 4) * 0.3125)), 0);
            Line ln1 = new Line(pt3, pt2);
            Circle c1 = new Circle(pt1, 0.3125);
            Transform xform = Transform.Rotation(Math.Sin((Math.PI / 4) * 3), Math.Cos((Math.PI / 4) * 3), new Vector3d(0, 0, 1), pt1);
            c1.Transform(xform);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(c1.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Seven(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 1.0, 0);
            Point3d pt2 = pt1 + new Vector3d(0.625, 0, 0);
            Point3d pt3 = pt + new Vector3d(kerning, 0, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt2, pt3);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Eight(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.3125 + kerning, 0.3125, 0);
            Point3d pt2 = pt + new Vector3d(0.3125 + kerning, 0.8125, 0);
            Circle c1 = new Circle(pt1, 0.3125);
            Circle c2 = new Circle(pt2, 0.1875);
            Transform xform = Transform.Rotation(Math.Sin(Math.PI / 2), Math.Cos(Math.PI / 2), new Vector3d(0, 0, 1), pt1);
            c1.Transform(xform);
            c1.Reverse();
            xform = Transform.Rotation(Math.Sin(-Math.PI / 2), Math.Cos(-Math.PI / 2), new Vector3d(0, 0, 1), pt2);
            c2.Transform(xform);
            letterCrvs.Add(c1.ToNurbsCurve());
            letterCrvs.Add(c2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Nine(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.3125 + kerning, 0.6875, 0);
            Point3d pt2 = pt1 + new Vector3d(Math.Sin(Math.PI / 4) * 0.3125, Math.Sin(Math.PI / 4) * -0.3125, 0);
            Point3d pt3 = pt2 + new Vector3d(-(1.0 - (0.3125 + (Math.Sin(Math.PI / 4) * 0.3125))), -(1.0 - (0.3125 + (Math.Sin(Math.PI / 4) * 0.3125))), 0);
            Line ln1 = new Line(pt3, pt2);
            Circle c1 = new Circle(pt1, 0.3125);
            Transform xform = Transform.Rotation(Math.Sin(-Math.PI / 4), Math.Cos(-Math.PI / 4), new Vector3d(0, 0, 1), pt1);
            c1.Transform(xform);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(c1.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Period(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.03125 + kerning, 0.03125, 0);
            Circle c1 = new Circle(pt1, 0.03125);
            letterCrvs.Add(c1.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.0625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Comma(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 0.0625, 0);
            Point3d pt2 = pt1 + new Vector3d(0.0625, 0, 0);
            Point3d pt3 = pt2 + new Vector3d(-0.0625, -0.125, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt2, pt3);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.0625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Colon(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.03125 + kerning, 0.25, 0);
            Point3d pt2 = pt1 + new Vector3d(0, 0.5, 0);
            Circle c1 = new Circle(pt1, 0.03125);
            Circle c2 = new Circle(pt2, 0.03125);
            letterCrvs.Add(c1.ToNurbsCurve());
            letterCrvs.Add(c2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.0625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> SemiColon(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 0.0625, 0);
            Point3d pt2 = pt1 + new Vector3d(0.0625, 0, 0);
            Point3d pt3 = pt2 + new Vector3d(-0.0625, -0.125, 0);
            Point3d pt4 = pt1 + new Vector3d(0.03125, 0.1875, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt2, pt3);
            Circle c1 = new Circle(pt4, 0.03125);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(c1.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.0625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Apostrophe(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 1.0, 0);
            Point3d pt2 = pt1 + new Vector3d(0.0625, 0, 0);
            Point3d pt3 = pt2 + new Vector3d(-0.0625, -0.125, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt2, pt3);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.0625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> dQuotes(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 1.0, 0);
            Point3d pt2 = pt1 + new Vector3d(0.0625, 0, 0);
            Point3d pt3 = pt2 + new Vector3d(-0.0625, -0.125, 0);
            Point3d pt4 = pt1 + new Vector3d(0.09375, 0, 0);
            Point3d pt5 = pt2 + new Vector3d(0.09375, 0, 0);
            Point3d pt6 = pt3 + new Vector3d(0.09375, 0, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt2, pt3);
            Line ln3 = new Line(pt4, pt5);
            Line ln4 = new Line(pt5, pt6);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            letterCrvs.Add(ln4.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.15625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> fSlash(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 0, 0);
            Point3d pt2 = pt1 + new Vector3d(0.375, 1.0, 0);
            Line ln1 = new Line(pt1, pt2);
            letterCrvs.Add(ln1.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.375 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> bSlash(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.375 + kerning, 0, 0);
            Point3d pt2 = pt1 + new Vector3d(-0.375, 1.0, 0);
            Line ln1 = new Line(pt1, pt2);
            letterCrvs.Add(ln1.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.375 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Question(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1a = pt + new Vector3d(kerning, 0.6875, 0);
            Point3d pt1b = pt1a + new Vector3d(0.3125, 0.3125, 0);
            Point3d pt1c = pt1b + new Vector3d(0, -0.625, 0);
            Point3d pt2 = pt1c + new Vector3d(0, -0.25, 0);
            Point3d pt3 = pt1b + new Vector3d(0, -0.96875, 0);
            Arc arc1 = new Arc(pt1a, pt1b, pt1c);
            Line ln1 = new Line(pt1c, pt2);
            Circle c1 = new Circle(pt3, 0.03125);
            letterCrvs.Add(arc1.ToNurbsCurve());
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(c1.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Hyphen(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 0.5, 0);
            Point3d pt2 = pt1 + new Vector3d(0.5, 0, 0);
            Line ln1 = new Line(pt1, pt2);
            letterCrvs.Add(ln1.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.5 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Underscore(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 0, 0);
            Point3d pt2 = pt1 + new Vector3d(0.5, 0, 0);
            Line ln1 = new Line(pt1, pt2);
            letterCrvs.Add(ln1.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.5 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Plus(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 0.5, 0);
            Point3d pt2 = pt1 + new Vector3d(0.5, 0, 0);
            Point3d pt3 = pt1 + new Vector3d(0.25, 0.25, 0);
            Point3d pt4 = pt3 + new Vector3d(0, -0.5, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt3, pt4);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.5 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Equal(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 1.00 / 3.00, 0);
            Point3d pt2 = pt1 + new Vector3d(0.5, 0, 0);
            Point3d pt3 = pt1 + new Vector3d(0, 1.00 / 3.00, 0);
            Point3d pt4 = pt2 + new Vector3d(0, 1.00 / 3.00, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt3, pt4);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.5 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Less(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.5625 + kerning, 0.75, 0);
            Point3d pt2 = pt1 + new Vector3d(-0.5, -0.25, 0);
            Point3d pt3 = pt2 + new Vector3d(0.5, -0.25, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt2, pt3);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.5 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Greater(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 0.75, 0);
            Point3d pt2 = pt1 + new Vector3d(0.5, -0.25, 0);
            Point3d pt3 = pt2 + new Vector3d(-0.5, -0.25, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt2, pt3);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.5 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Exclaim(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.03125 + kerning, 0.03125, 0);
            Point3d pt2 = pt1 + new Vector3d(0, 0.96875, 0);
            Point3d pt3 = pt2 + new Vector3d(0, -0.75, 0);
            Circle c1 = new Circle(pt1, 0.03125);
            Line ln1 = new Line(pt3, pt2);
            letterCrvs.Add(c1.ToNurbsCurve());
            letterCrvs.Add(ln1.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.0625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> At(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.625 + kerning, 0.25, 0);
            Point3d pt2a = pt1 + new Vector3d(0, 0.5, 0);
            Point3d pt2b = pt2a + new Vector3d(-0.3125, 0.3125, 0);
            Point3d pt2c = pt2b + new Vector3d(-0.3125, -0.3125, 0);
            Point3d pt3a = pt2c + new Vector3d(0, -0.375, 0);
            Point3d pt3b = pt3a + new Vector3d(0.3125, -0.3125, 0);
            Point3d pt3c = pt3b + new Vector3d(Math.Sin(Math.PI / 4) * 0.3125, Math.Tan(Math.PI / 8) * (Math.Sin(Math.PI / 4) * 0.3125), 0);
            Point3d pt4 = pt1 + new Vector3d(0, 0.0625, 0);
            Point3d pt5a = pt4 + new Vector3d(-0.1875, 0, 0);
            Point3d pt5b = pt5a + new Vector3d(-0.1875, 0.1875, 0);
            Point3d pt5c = pt5a + new Vector3d(0, 0.375, 0);
            Point3d pt6 = pt5c + new Vector3d(0.1875, 0, 0);
            Line ln1 = new Line(pt1, pt2a);
            Arc arc1 = new Arc(pt2a, pt2b, pt2c);
            Line ln2 = new Line(pt2c, pt3a);
            Arc arc2 = new Arc(pt3a, pt3b, pt3c);
            Line ln3 = new Line(pt4, pt5a);
            Arc arc3 = new Arc(pt5a, pt5b, pt5c);
            Line ln4 = new Line(pt5c, pt6);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(arc1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(arc2.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            letterCrvs.Add(arc3.ToNurbsCurve());
            letterCrvs.Add(ln4.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Pound(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1a = pt + new Vector3d(0.28125 + kerning, 1.0, 0);
            Point3d pt1b = pt1a + new Vector3d(-0.1875, -1.0, 0);
            Point3d pt2a = pt1b + new Vector3d(0.25, 0, 0);
            Point3d pt2b = pt2a + new Vector3d(0.1875, 1.0, 0);
            Point3d pt3a = pt + new Vector3d(kerning, (1.00 / 3.00), 0);
            Point3d pt3b = pt3a + new Vector3d(0.5625, 0, 0);
            Point3d pt4a = pt2b + new Vector3d(0.09375, -(1.00 / 3.00), 0);
            Point3d pt4b = pt4a + new Vector3d(-0.5625, 0, 0);
            Line ln1 = new Line(pt1a, pt1b);
            Line ln2 = new Line(pt2a, pt2b);
            Line ln3 = new Line(pt4a, pt4b);
            Line ln4 = new Line(pt3a, pt3b);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            letterCrvs.Add(ln4.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Dollar(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.5 + kerning, 0.71875, 0);
            Point3d pt2 = pt1 + new Vector3d(-(Math.Tan(Math.PI / 8) * (Math.Sin(Math.PI / 4 * 0.21875))), (Math.Sin(Math.PI / 4) * 0.21875), 0);
            Point3d pt3 = pt1 + new Vector3d(-0.21875, 0.21875, 0);
            Point3d pt4 = pt3 + new Vector3d(-0.0625, 0, 0);
            Point3d pt5 = pt4 + new Vector3d(-0.21875, -0.21875, 0);
            Point3d pt6 = pt5 + new Vector3d(0.21875, -0.21875, 0);
            Point3d pt7 = pt6 + new Vector3d(0.0625, 0, 0);
            Point3d pt8 = pt7 + new Vector3d(0.21875, -0.21875, 0);
            Point3d pt9 = pt8 + new Vector3d(-0.21875, -0.21875, 0);
            Point3d pt10 = pt9 + new Vector3d(-0.0625, 0, 0);

            Point3d pt11 = pt10 + new Vector3d(-(Math.Sin(Math.PI / 4) * 0.21875), Math.Tan(Math.PI / 8) * (Math.Sin(Math.PI / 4) * 0.21875), 0);
            Point3d pt12 = pt10 + new Vector3d(-0.21875, 0.21875, 0);
            Point3d pt13 = pt + new Vector3d(0.25 + kerning, 0, 0);
            Point3d pt14 = pt13 + new Vector3d(0, 1.0, 0);
            Arc arc1 = new Arc(pt1, pt2, pt3);
            Line ln1 = new Line(pt3, pt4);
            Arc arc2 = new Arc(pt4, pt5, pt6);
            Line ln2 = new Line(pt6, pt7);
            Arc arc3 = new Arc(pt7, pt8, pt9);
            Line ln3 = new Line(pt9, pt10);
            Arc arc4 = new Arc(pt10, pt11, pt12);
            Line ln4 = new Line(pt14, pt13);
            letterCrvs.Add(arc1.ToNurbsCurve());
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(arc2.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(arc3.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            letterCrvs.Add(arc4.ToNurbsCurve());
            letterCrvs.Add(ln4.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.5 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Percent(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 0.25, 0);
            Point3d pt2 = pt1 + new Vector3d(0.5, 0.5, 0);
            Point3d pt3 = pt1 + new Vector3d(0.125, 0.5, 0);
            Point3d pt4 = pt1 + new Vector3d(0.375, 0, 0);
            Line ln1 = new Line(pt1, pt2);
            Circle c1 = new Circle(pt3, 0.125);
            Circle c2 = new Circle(pt4, 0.125);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(c1.ToNurbsCurve());
            letterCrvs.Add(c2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.5 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Caret(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 2.00 / 3.00, 0);
            Point3d pt2 = pt1 + new Vector3d(0.25, 1.00 / 3.00, 0);
            Point3d pt3 = pt1 + new Vector3d(0.5, 0, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt2, pt3);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.5 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Amp(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            double length = Math.Sqrt(Math.Pow(0.1875, 2.0) + Math.Pow(0.1875, 2.0));
            Point3d pt0 = pt + new Vector3d(0.25 + kerning, 0.25, 0);
            Point3d pt1 = pt0 + new Vector3d(0.375, 0.25 - ((0.25 - (Math.Sin(Math.PI / 4) * 0.25)) + (0.375 - (Math.Sin(Math.PI / 4) * 0.25))), 0);
            Point3d pt2 = pt0 + new Vector3d(Math.Sin(Math.PI / 4) * 0.25, -Math.Sin(Math.PI / 4) * 0.25, 0);
            Point3d pt3 = pt0 + new Vector3d(0, -0.25, 0);
            Point3d pt4 = pt0 + new Vector3d(-Math.Sin(Math.PI / 4) * 0.25, Math.Sin(Math.PI / 4) * 0.25, 0);
            Point3d pt0b = pt4 + new Vector3d(length - (Math.Sin(Math.PI / 4) * 0.1875), length + (Math.Sin(Math.PI / 4) * 0.1875), 0);
            Point3d pt5 = pt0b + new Vector3d(Math.Sin(Math.PI / 4) * 0.1875, -(Math.Sin(Math.PI / 4) * 0.1875), 0);
            Point3d pt6 = pt0b + new Vector3d(0, 0.1875, 0);
            Point3d pt7 = pt0b + new Vector3d(-(Math.Sin(Math.PI / 4) * 0.1875), -(Math.Sin(Math.PI / 4) * 0.1875), 0);
            Point3d pt8 = pt7 + new Vector3d((0.625 + kerning) - (pt7.X - pt.X), -((0.625 + kerning) - (pt7.X - pt.X)), 0);
            Line ln1 = new Line(pt1, pt2);
            Arc arc1 = new Arc(pt2, pt3, pt4);
            Line ln2 = new Line(pt4, pt5);
            Arc arc2 = new Arc(pt5, pt6, pt7);
            Line ln3 = new Line(pt7, pt8);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(arc1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(arc2.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Ast(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            double length = 0.3125 / Math.Cos(Math.PI / 10);
            Point3d pt1 = pt + new Vector3d(0.3125 + kerning, 0.5, 0);
            Point3d pt2 = pt1 + new Vector3d(0.3125, Math.Tan(Math.PI / 10) * 0.3125, 0);
            Point3d pt3 = pt1 + new Vector3d(0, length, 0);
            Point3d pt4 = pt1 + new Vector3d(-0.3125, Math.Tan(Math.PI / 10) * 0.3125, 0);
            Point3d pt5 = pt1 + new Vector3d(-Math.Sin(Math.PI / 5) * length, -Math.Cos(Math.PI / 5) * length, 0);
            Point3d pt6 = pt1 + new Vector3d(Math.Sin(Math.PI / 5) * length, -Math.Cos(Math.PI / 5) * length, 0);
            Line ln1 = new Line(pt2, pt1);
            Line ln2 = new Line(pt1, pt3);
            Line ln3 = new Line(pt4, pt1);
            Line ln4 = new Line(pt1, pt5);
            Line ln5 = new Line(pt1, pt6);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            letterCrvs.Add(ln4.ToNurbsCurve());
            letterCrvs.Add(ln5.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> oPar(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.25 + kerning, 0, 0);
            Point3d pt2 = pt1 + new Vector3d(-0.25, 0.5, 0);
            Point3d pt3 = pt2 + new Vector3d(0.25, 0.5, 0);
            Arc arc1 = new Arc(pt1, pt2, pt3);
            letterCrvs.Add(arc1.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.3125 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> cPar(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 0, 0);
            Point3d pt2 = pt1 + new Vector3d(0.25, 0.5, 0);
            Point3d pt3 = pt2 + new Vector3d(-0.25, 0.5, 0);
            Arc arc1 = new Arc(pt1, pt2, pt3);
            letterCrvs.Add(arc1.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.3125 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Pipe(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.0625 + kerning, -0.125, 0);
            Vector3d v1 = new Vector3d(0, 1.25, 0);
            Line ln1 = new Line(pt1, v1, 1.25);
            letterCrvs.Add(ln1.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.125 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> lBraket(Point3d pt)
        {
            List<Curve> crvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.25 + kerning, 1.0, 0);
            Point3d pt2 = pt1 + new Vector3d(-0.25, 0, 0);
            Point3d pt3 = pt2 + new Vector3d(0, -1.0, 0);
            Point3d pt4 = pt3 + new Vector3d(0.25, 0, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt2, pt3);
            Line ln3 = new Line(pt3, pt4);
            crvs.Add(ln1.ToNurbsCurve());
            crvs.Add(ln2.ToNurbsCurve());
            crvs.Add(ln3.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.25 + (2 * kerning), 0, 0);
            return crvs;
        }

        private List<Curve> rBraket(Point3d pt)
        {
            List<Curve> crvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 1.0, 0);
            Point3d pt2 = pt1 + new Vector3d(0.25, 0, 0);
            Point3d pt3 = pt2 + new Vector3d(0, -1.0, 0);
            Point3d pt4 = pt3 + new Vector3d(-0.25, 0, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt2, pt3);
            Line ln3 = new Line(pt3, pt4);
            crvs.Add(ln1.ToNurbsCurve());
            crvs.Add(ln2.ToNurbsCurve());
            crvs.Add(ln3.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.25 + (2 * kerning), 0, 0);
            return crvs;
        }

        private List<Curve> lCurly(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.5 + kerning, 1.0, 0);
            Point3d pt1a = pt1 + new Vector3d(Math.Sin(Math.PI / 4) * (-1.0 / 3.0), -((1.0 / 3.0) - Math.Sin(Math.PI / 4) * (1.0 / 3.0)), 0);
            Point3d pt2 = pt1 + new Vector3d(-(1.0 / 3.0), -(1.0 / 3.0), 0);
            Point3d pt3 = pt2 + new Vector3d(0, -((1.0 / 3.0) / 4), 0);
            Point3d pt4 = pt + new Vector3d(kerning, 0.5, 0);
            Point3d pt7 = pt + new Vector3d(0.5 + kerning, 0, 0);
            Point3d pt7a = pt7 + new Vector3d(Math.Sin(Math.PI / 4) * (-1.0 / 3.0), ((1.0 / 3.0) - Math.Sin(Math.PI / 4) * (1.0 / 3.0)), 0);
            Point3d pt6 = pt7 + new Vector3d(-(1.0 / 3.0), (1.0 / 3.0), 0);
            Point3d pt5 = pt6 + new Vector3d(0, (1.0 / 3.0) / 4, 0);
            Arc a1 = new Arc(pt1, pt1a, pt2);
            Line ln1 = new Line(pt2, pt3);
            Line ln2 = new Line(pt3, pt4);
            Line ln3 = new Line(pt4, pt5);
            Line ln4 = new Line(pt5, pt6);
            Arc a2 = new Arc(pt6, pt7a, pt7);
            letterCrvs.Add(a1.ToNurbsCurve());
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            letterCrvs.Add(ln4.ToNurbsCurve());
            letterCrvs.Add(a2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.5 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> rCurly(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 1.0, 0);
            Point3d pt1a = pt1 + new Vector3d(Math.Sin(Math.PI / 4) * (1.0 / 3.0), -((1.0 / 3.0) - Math.Sin(Math.PI / 4) * (1.0 / 3.0)), 0);
            Point3d pt2 = pt1 + new Vector3d((1.0 / 3.0), -(1.0 / 3.0), 0);
            Point3d pt3 = pt2 + new Vector3d(0, -((1.0 / 3.0) / 4), 0);
            Point3d pt4 = pt + new Vector3d(kerning + 0.5, 0.5, 0);
            Point3d pt7 = pt + new Vector3d(kerning, 0, 0);
            Point3d pt7a = pt7 + new Vector3d(Math.Sin(Math.PI / 4) * (1.0 / 3.0), ((1.0 / 3.0) - Math.Sin(Math.PI / 4) * (1.0 / 3.0)), 0);
            Point3d pt6 = pt7 + new Vector3d(1.0 / 3.0, (1.0 / 3.0), 0);
            Point3d pt5 = pt6 + new Vector3d(0, (1.0 / 3.0) / 4, 0);
            Arc a1 = new Arc(pt1, pt1a, pt2);
            Line ln1 = new Line(pt2, pt3);
            Line ln2 = new Line(pt3, pt4);
            Line ln3 = new Line(pt4, pt5);
            Line ln4 = new Line(pt5, pt6);
            Arc a2 = new Arc(pt6, pt7a, pt7);
            letterCrvs.Add(a1.ToNurbsCurve());
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            letterCrvs.Add(ln4.ToNurbsCurve());
            letterCrvs.Add(a2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.5 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Accent(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 1.0, 0);
            Point3d pt2 = pt1 + new Vector3d(0.25, -0.25, 0);
            Line ln1 = new Line(pt1, pt2);
            letterCrvs.Add(ln1.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.25 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Tilde(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 0.5, 0);
            Point3d pt2 = pt1 + new Vector3d(0.125, 0.0625, 0);
            Point3d pt3 = pt2 + new Vector3d(0.125, -0.0625, 0);
            Point3d pt4 = pt3 + new Vector3d(0.125, -0.0625, 0);
            Point3d pt5 = pt4 + new Vector3d(0.125, 0.0625, 0);
            List<Point3d> points = new List<Point3d>();
            points.Add(pt1);
            points.Add(pt2);
            points.Add(pt3);
            points.Add(pt4);
            points.Add(pt5);
            NurbsCurve nc1 = NurbsCurve.Create(false, 3, points);
            letterCrvs.Add(nc1);
            currentPt = pt + new Vector3d(0.5 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Degree(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.125 + kerning, 0.875, 0);
            Circle c1 = new Circle(pt1, 0.125);
            letterCrvs.Add(c1.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.25 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> PlusMinus(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 0.5, 0);
            Point3d pt2 = pt1 + new Vector3d(0.5, 0, 0);
            Point3d pt3 = pt1 + new Vector3d(0.25, 0.25, 0);
            Point3d pt4 = pt3 + new Vector3d(0, -0.5, 0);
            Point3d pt5 = pt + new Vector3d(kerning, 0, 0);
            Point3d pt6 = pt5 + new Vector3d(0.5, 0, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt3, pt4);
            Line ln3 = new Line(pt5, pt6);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.5 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Squared(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 0.875, 0);
            Point3d pt2 = pt1 + new Vector3d(0.125, 0.125, 0);
            Point3d pt3 = pt2 + new Vector3d(0.125, -0.125, 0);
            Point3d pt4 = pt + new Vector3d(kerning, 2.0 / 3.0, 0);
            Point3d pt5 = pt4 + new Vector3d(0.25, 0, 0);
            Arc a1 = new Arc(pt1, pt2, pt3);
            Line ln1 = new Line(pt3, pt4);
            Line ln2 = new Line(pt4, pt5);
            letterCrvs.Add(a1.ToNurbsCurve());
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.25 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Cubed(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 1.0, 0);
            Point3d pt2 = pt1 + new Vector3d(0.625, 0, 0);
            Point3d pt3a = pt + new Vector3d(0.3125 + kerning, 0.625, 0);
            Point3d pt3b = pt3a + new Vector3d(0, -0.625, 0);
            Point3d pt3c = pt3b + new Vector3d(-0.3125, 0.3125, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt2, pt3a);
            Arc arc1 = new Arc(pt3a, pt3b, pt3c);
            Transform xform = Transform.Scale(pt1, 1.0 / 3.0);
            ln1.Transform(xform);
            ln2.Transform(xform);
            arc1.Transform(xform);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(arc1.ToNurbsCurve());
            currentPt = pt + new Vector3d(((5.0 / 8.0) * (1.0 / 3.0)) + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Division(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 0.5, 0);
            Point3d pt2 = pt1 + new Vector3d(0.5, 0, 0);
            Point3d pt3 = pt + new Vector3d(0.25 + kerning, 0.25, 0);
            Point3d pt4 = pt3 + new Vector3d(0, 0.5, 0);
            Line ln1 = new Line(pt1, pt2);
            Circle c1 = new Circle(pt3, 0.03125);
            Circle c2 = new Circle(pt4, 0.03125);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(c1.ToNurbsCurve());
            letterCrvs.Add(c2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.5 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Cent(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.5 + kerning, 2.0 / 3.0, 0);
            Point3d pt2 = pt + new Vector3d(kerning, 0.5, 0);
            Point3d pt3 = pt + new Vector3d(0.5 + kerning, 1.0 / 3.0, 0);
            Point3d pt4 = pt + new Vector3d(0.375 + kerning, 1.0, 0);
            Point3d pt5 = pt + new Vector3d(0.125 + kerning, 0, 0);
            Arc a1 = new Arc(pt1, pt2, pt3);
            Line ln1 = new Line(pt4, pt5);
            letterCrvs.Add(a1.ToNurbsCurve());
            letterCrvs.Add(ln1.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.5 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> NotEqual(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 1.00 / 3.00, 0);
            Point3d pt2 = pt1 + new Vector3d(0.5, 0, 0);
            Point3d pt3 = pt1 + new Vector3d(0, 1.00 / 3.00, 0);
            Point3d pt4 = pt2 + new Vector3d(0, 1.00 / 3.00, 0);
            Point3d pt5 = pt + new Vector3d(0.375 + kerning, 0.875, 0);
            Point3d pt6 = pt + new Vector3d(0.125 + kerning, 0.125, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt3, pt4);
            Line ln3 = new Line(pt5, pt6);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.5 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> LessEqual(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.5 + kerning, 0.75, 0);
            Point3d pt2 = pt1 + new Vector3d(-0.5, -0.25, 0);
            Point3d pt3 = pt2 + new Vector3d(0.5, -0.25, 0);
            Point3d pt4 = pt + new Vector3d(0.5 + kerning, 0, 0);
            Point3d pt5 = pt4 + new Vector3d(-0.5, 0, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt2, pt3);
            Line ln3 = new Line(pt4, pt5);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.5 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> GreaterEqual(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 0.75, 0);
            Point3d pt2 = pt1 + new Vector3d(0.5, -0.25, 0);
            Point3d pt3 = pt2 + new Vector3d(-0.5, -0.25, 0);
            Point3d pt4 = pt + new Vector3d(kerning, 0, 0);
            Point3d pt5 = pt4 + new Vector3d(0.5, 0, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt2, pt3);
            Line ln3 = new Line(pt4, pt5);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.5 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> BPound(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.5 + kerning, 0.75, 0);
            Point3d pt2 = pt1 + new Vector3d(-0.5, 0, 0);
            Point3d pt3 = pt2 + new Vector3d(0.25 - (Math.Sin(Math.PI / 4) * 0.25), Math.Sin(Math.PI / 4) * -0.25, 0);
            Point3d pt4 = pt + new Vector3d(0.1796875 + kerning, 0.31640625, 0);
            Point3d pt5 = pt + new Vector3d(kerning, 0, 0);
            Point3d pt6 = pt5 + new Vector3d(0.625, 0, 0);
            Point3d pt7 = pt5 + new Vector3d(0, 0.5, 0);
            Point3d pt8 = pt7 + new Vector3d(0.25, 0, 0);
            Arc a1 = new Arc(pt1, pt2, pt3);
            Arc a2 = new Arc(pt3, new Vector3d(1.0, -1.0, 0), pt5);
            //Arc a2 = new Arc(pt3, pt4, pt5);
            Line ln1 = new Line(pt5, pt6);
            Line ln2 = new Line(pt7, pt8);
            letterCrvs.Add(a1.ToNurbsCurve());
            letterCrvs.Add(a2.ToNurbsCurve());
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Yen(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.3125 + kerning, 0, 0);
            Line ln1 = new Line(pt1, new Vector3d(0, 0.5, 0), 0.5);
            Point3d pt2 = pt1 + new Vector3d(0, 0.5, 0);
            Point3d pt3 = pt + new Vector3d(0.125 + kerning, 0.5, 0);
            Point3d pt4 = pt3 + new Vector3d(0.375, 0, 0);
            Point3d pt5 = pt3 + new Vector3d(0, -0.25, 0);
            Point3d pt6 = pt4 + new Vector3d(0, -0.25, 0);
            Line ln2 = new Line(pt2, new Vector3d(-0.3125, 0.5, 0), Math.Sqrt(Math.Pow(0.3125, 2.0) + Math.Pow(0.5, 2.0)));
            Line ln3 = new Line(pt2, new Vector3d(0.3125, 0.5, 0), Math.Sqrt(Math.Pow(0.3125, 2.0) + Math.Pow(0.5, 2.0)));
            Line ln4 = new Line(pt4, pt3);
            Line ln5 = new Line(pt5, pt6);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            letterCrvs.Add(ln4.ToNurbsCurve());
            letterCrvs.Add(ln5.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Euro(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.625 + kerning, 0.9375, 0);
            Point3d pt2 = pt1 + new Vector3d(-0.1875, 0.0625, 0);
            Point3d pt3 = pt2 + new Vector3d(-0.3125, -0.3125, 0);
            Point3d pt4 = pt3 + new Vector3d(0, -0.375, 0);
            Point3d pt5 = pt4 + new Vector3d(0.3125, -0.3125, 0);
            Point3d pt6 = pt5 + new Vector3d(0.1875, 0.0625, 0);
            Point3d pt7 = pt + new Vector3d(kerning, 0.625, 0);
            Point3d pt8 = pt7 + new Vector3d(0.5, 0, 0);
            Point3d pt9 = pt7 + new Vector3d(0, -0.25, 0);
            Point3d pt10 = pt8 + new Vector3d(0, -0.25, 0);
            Arc a1 = new Arc(pt1, pt2, pt3);
            Line ln1 = new Line(pt3, pt4);
            Arc a2 = new Arc(pt4, pt5, pt6);
            Line ln2 = new Line(pt8, pt7);
            Line ln3 = new Line(pt9, pt10);
            letterCrvs.Add(a1.ToNurbsCurve());
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(a2.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> Spacebar(Point3d pt)
        {
            currentPt = pt + new Vector3d(0.375 + (2 * kerning), 0, 0);
            return null;
        }

        private List<Curve> CR(Point3d pt)
        {
            currentPt = lineOrigin + new Vector3d(0, -1.25, 0);
            lineOrigin = currentPt;
            return null;
        }

        private List<Curve> LetterA(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 0, 0);
            Line ln1 = new Line(pt1, new Vector3d(0.3125, 1.0, 0), Math.Sqrt(Math.Pow(0.3125, 2.0) + Math.Pow(1.0, 2.0)));
            Point3d pt2 = pt1 + new Vector3d(0.3125, 1, 0);
            Line ln2 = new Line(pt2, new Vector3d(0.3125, -1.0, 0), Math.Sqrt(Math.Pow(0.3125, 2.0) + Math.Pow(1.0, 2.0)));
            Point3d pt3 = pt + new Vector3d((5.0 / 16.0) * (1.0 / 3.0) + kerning, (double)(1.0 / 3.0), 0);
            Line ln3 = new Line(pt3, new Vector3d(1.0, 0, 0), ((double)(5.0 / 8.0) * (double)(2.0 / 3.0)));
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + 2 * kerning, 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterB(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 0, 0);
            Point3d pt2 = pt1 + new Vector3d(0.0, 1.0, 0);
            Point3d pt3a = pt2 + new Vector3d(0.3125, 0.0, 0);
            Point3d pt3b = pt3a + new Vector3d(0.25, -0.25, 0);
            Point3d pt3c = pt3b + new Vector3d(-0.25, -0.25, 0);
            Point3d pt4 = pt3c + new Vector3d(-0.3125, 0, 0);
            Point3d pt5a = pt4 + new Vector3d(0.375, 0, 0);
            Point3d pt5b = pt5a + new Vector3d(0.25, -0.25, 0);
            Point3d pt5c = pt5b + new Vector3d(-0.25, -0.25, 0);
            Line ln1 = new Line(pt1, new Vector3d(0.0, 1.0, 0), 1.0);
            Line ln2 = new Line(pt2, new Vector3d(0.375, 0.0, 0), 0.3125);
            Arc arc1 = new Arc(pt3a, pt3b, pt3c);
            Line ln3 = new Line(pt4, new Vector3d(0.375, 0, 0), 0.375);
            Arc arc2 = new Arc(pt5a, pt5b, pt5c);
            Line ln4 = new Line(pt5c, pt1);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(arc1.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            letterCrvs.Add(arc2.ToNurbsCurve());
            letterCrvs.Add(ln4.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterC(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1a = pt + new Vector3d(0.625 + kerning, 0.6875, 0);
            Point3d pt1b = pt1a + new Vector3d(-0.3125, 0.3125, 0);
            Point3d pt1c = pt1b + new Vector3d(-0.3125, -0.3125, 0);
            Arc arc1 = new Arc(pt1a, pt1b, pt1c);
            Point3d pt2a = pt1c + new Vector3d(0, -0.375, 0);
            Point3d pt2b = pt2a + new Vector3d(0.3125, -0.3125, 0);
            Point3d pt2c = pt2b + new Vector3d(0.3125, 0.3125, 0);
            Line ln1 = new Line(pt1c, pt2a);
            Arc arc2 = new Arc(pt2a, pt2b, pt2c);
            letterCrvs.Add(arc1.ToNurbsCurve());
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(arc2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterD(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 0, 0);
            Line ln1 = new Line(pt1, new Vector3d(0, 1.0, 0), 1.0);
            Point3d pt2 = pt1 + new Vector3d(0, 1.0, 0.0);
            Line ln2 = new Line(pt2, new Vector3d(1, 0, 0), 0.3125);
            Point3d pt3 = pt2 + new Vector3d(0.3125, -0.3125, 0);
            Arc arc1 = new Arc(pt3, 0.3125, Math.PI / 2);
            Point3d pt4 = pt3 + new Vector3d(0.3125, 0, 0);
            Line ln3 = new Line(pt4, new Vector3d(0, -0.375, 0), 0.375);
            Point3d pt5 = pt4 + new Vector3d(-0.3125, -0.375, 0);
            Arc arc2 = new Arc(pt5, 0.3125, -Math.PI / 2);
            Point3d pt6 = pt5 + new Vector3d(0, -0.3125, 0);
            Line ln4 = new Line(pt6, new Vector3d(-0.3125, 0, 0), 0.3125);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(arc1.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            letterCrvs.Add(arc2.ToNurbsCurve());
            letterCrvs.Add(ln4.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterE(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.5 + kerning, 1.0, 0);
            Line ln1 = new Line(pt1, new Vector3d(-0.5, 0, 0), 0.5);
            Point3d pt2 = pt1 + new Vector3d(-0.5, 0, 0);
            Line ln2 = new Line(pt2, new Vector3d(0, -1.0, 0), 1.0);
            Point3d pt3 = pt2 + new Vector3d(0, -1.0, 0);
            Line ln3 = new Line(pt3, new Vector3d(0.5, 0, 0), 0.5);
            Point3d pt4 = pt2 + new Vector3d(0, -0.5, 0);
            Line ln4 = new Line(pt4, new Vector3d(0.4375, 0, 0), 0.4375);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            letterCrvs.Add(ln4.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.5 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterF(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.5 + kerning, 1.0, 0);
            Line ln1 = new Line(pt1, new Vector3d(-0.5, 0, 0), 0.5);
            Point3d pt2 = pt1 + new Vector3d(-0.5, 0, 0);
            Line ln2 = new Line(pt2, new Vector3d(0, -1.0, 0), 1.0);
            Point3d pt4 = pt2 + new Vector3d(0, -0.5, 0);
            Line ln4 = new Line(pt4, new Vector3d(0.4375, 0, 0), 0.4375);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(ln4.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.5 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterG(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1a = pt + new Vector3d(0.625 + kerning, 0.6875, 0);
            Point3d pt1b = pt1a + new Vector3d(-0.3125, 0.3125, 0);
            Point3d pt1c = pt1b + new Vector3d(-0.3125, -0.3125, 0);
            Arc arc1 = new Arc(pt1a, pt1b, pt1c);
            Point3d pt2a = pt1c + new Vector3d(0, -0.375, 0);
            Point3d pt2b = pt2a + new Vector3d(0.3125, -0.3125, 0);
            Point3d pt2c = pt2b + new Vector3d(0.3125, 0.3125, 0);
            Line ln1 = new Line(pt1c, pt2a);
            Arc arc2 = new Arc(pt2a, pt2b, pt2c);
            Line ln2 = new Line(pt2c, new Vector3d(0, (double)(0.5 - (1.0 / 3.0)), 0), (double)(0.5 - (1.0 / 3.0)));
            Point3d pt3 = pt2c + new Vector3d(0, (double)(0.5 - (1.0 / 3.0)), 0);
            Line ln3 = new Line(pt3, new Vector3d(-0.25, 0, 0), 0.25);
            letterCrvs.Add(arc1.ToNurbsCurve());
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(arc2.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + 2 * kerning, 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterH(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 0, 0);
            Line ln1 = new Line(pt1, new Vector3d(0, 1.0, 0), 1.0);
            Point3d pt2 = pt1 + new Vector3d((double)(5.0 / 8.0), 0, 0);
            Line ln2 = new Line(pt2, new Vector3d(0, 1.0, 0), 1.0);
            Point3d pt4 = pt1 + new Vector3d(0, 0.5, 0);
            Line ln4 = new Line(pt4, new Vector3d(0.625, 0, 0), 0.625);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(ln4.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterI(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.03125 + kerning, 0, 0);
            Vector3d v1 = new Vector3d(0, 1.0, 0);
            Line ln1 = new Line(pt1, v1, 1.0);
            letterCrvs.Add(ln1.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.0625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterJ(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.5 + kerning, 1.0, 0);
            Line ln1 = new Line(pt1, new Vector3d(0, -0.6875, 0), 0.6875);
            Point3d pt2 = pt1 + new Vector3d(-0.3125, -0.6875, 0);
            Arc arc1 = new Arc(pt2, 0.3125, -2.21429922);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(arc1.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.5 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterK(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt0 = pt + new Vector3d(kerning, 0, 0);
            Line ln1 = new Line(pt0, new Vector3d(0, 1.0, 0), 1.0);
            Point3d pt1 = pt0 + new Vector3d(0, (double)(1.0 / 3.0), 0);
            Line ln2 = new Line(pt1, new Vector3d(0.625, (double)(2.0 / 3.0), 0), Math.Sqrt(Math.Pow(0.625, 2.0) + Math.Pow((double)(2.0 / 3.0), 2.0)));
            Point3d pt2 = pt0 + new Vector3d(0.625, 0, 0);
            Point3d pt3 = pt0 + new Vector3d(0.25, (0.25 / (0.625 / (double)(2.0 / 3.0))) + (double)(1.0 / 3.0), 0);
            Line ln3 = new Line(pt2, pt3);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterL(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 1.0, 0);
            Point3d pt2 = pt1 + new Vector3d(0, -1, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt2, new Vector3d(1.0, 0, 0), 0.5);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.5 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterM(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt0 = pt + new Vector3d(kerning, 0, 0);
            Line ln1 = new Line(pt0, new Vector3d(0, 1.0, 0), 1.0);
            Point3d pt1 = pt0 + new Vector3d(0, 1.0, 0);
            Line ln2 = new Line(pt1, new Vector3d(0.3125, -0.54126587736527415422732698172059, 0), 0.625);
            Point3d pt2 = pt1 + new Vector3d(0.3125, -0.54126587736527415422732698172059, 0);
            Line ln3 = new Line(pt2, new Vector3d(0.3125, 0.54126587736527415422732698172059, 0), 0.625);
            Point3d pt3 = pt2 + new Vector3d(0.3125, 0.54126587736527415422732698172059, 0);
            Line ln4 = new Line(pt3, new Vector3d(0, -1.0, 0), 1.0);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            letterCrvs.Add(ln4.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterN(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt0 = pt + new Vector3d(kerning, 0, 0);
            Line ln1 = new Line(pt0, new Vector3d(0, 1.0, 0), 1.0);
            Point3d pt1 = pt0 + new Vector3d(0, 1.0, 0);
            Line ln2 = new Line(pt1, new Vector3d(0.5625, -1.0, 0), Math.Sqrt(Math.Pow(0.5625, 2.0) + Math.Pow(1.0, 2.0)));
            Point3d pt2 = pt1 + new Vector3d(0.5625, -1.0, 0);
            Line ln3 = new Line(pt2, new Vector3d(0, 1.0, 0), 1.0);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.5625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterO(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.625 + kerning, 0.3125, 0);
            Point3d pt2a = pt1 + new Vector3d(0, 0.375, 0);
            Point3d pt2b = pt2a + new Vector3d(-0.3125, 0.3125, 0);
            Point3d pt2c = pt2b + new Vector3d(-0.3125, -0.3125, 0);
            Point3d pt3a = pt2c + new Vector3d(0, -0.375, 0);
            Point3d pt3b = pt3a + new Vector3d(0.3125, -0.3125, 0);
            Line ln1 = new Line(pt1, pt2a);
            Arc arc1 = new Arc(pt2a, pt2b, pt2c);
            Line ln2 = new Line(pt2c, pt3a);
            Arc arc2 = new Arc(pt3a, pt3b, pt1);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(arc1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(arc2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterP(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 0, 0);
            Point3d pt2 = pt1 + new Vector3d(0, 1.0, 0);
            Point3d pt3a = pt2 + new Vector3d(0.3125, 0, 0);
            Point3d pt3b = pt3a + new Vector3d(0.3125, -0.3125, 0);
            Point3d pt3c = pt3b + new Vector3d(-0.3125, -0.3125, 0);
            Point3d pt4 = pt3c + new Vector3d(-0.3125, 0, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt2, pt3a);
            Arc arc1 = new Arc(pt3a, pt3b, pt3c);
            Line ln3 = new Line(pt3c, pt4);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(arc1.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterQ(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.625 + kerning, 0.3125, 0);
            Point3d pt2a = pt1 + new Vector3d(0, 0.375, 0);
            Point3d pt2b = pt2a + new Vector3d(-0.3125, 0.3125, 0);
            Point3d pt2c = pt2b + new Vector3d(-0.3125, -0.3125, 0);
            Point3d pt3a = pt2c + new Vector3d(0, -0.375, 0);
            Point3d pt3b = pt3a + new Vector3d(0.3125, -0.3125, 0);
            Point3d pt4 = pt1 + new Vector3d(-0.3125, 0, 0);
            Point3d pt5 = pt1 + new Vector3d(0, -0.3125, 0);
            Line ln1 = new Line(pt1, pt2a);
            Arc arc1 = new Arc(pt2a, pt2b, pt2c);
            Line ln2 = new Line(pt2c, pt3a);
            Arc arc2 = new Arc(pt3a, pt3b, pt1);
            Line ln3 = new Line(pt4, pt5);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(arc1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(arc2.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterR(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 0, 0);
            Point3d pt2 = pt1 + new Vector3d(0, 1.0, 0);
            Point3d pt3a = pt2 + new Vector3d(0.3125, 0, 0);
            Point3d pt3b = pt3a + new Vector3d(0.3125, -0.3125, 0);
            Point3d pt3c = pt3b + new Vector3d(-0.3125, -0.3125, 0);
            Point3d pt4 = pt3c + new Vector3d(-0.3125, 0, 0);
            Point3d pt5 = pt1 + new Vector3d(0.625, 0, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt2, pt3a);
            Arc arc1 = new Arc(pt3a, pt3b, pt3c);
            Line ln3 = new Line(pt3c, pt4);
            Line ln4 = new Line(pt3c, pt5);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(arc1.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            letterCrvs.Add(ln4.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterS(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.375 + kerning, 0.75, 0);
            Point3d pt2 = pt1 + new Vector3d(0, 0.25, 0);
            Point3d pt3a = pt2 + new Vector3d(-0.125, 0, 0);
            Point3d pt3b = pt3a + new Vector3d(-0.25, -0.25, 0);
            Point3d pt3c = pt3b + new Vector3d(0.25, -0.25, 0);
            Point3d pt4a = pt3c + new Vector3d(0.125, 0, 0);
            Point3d pt4b = pt4a + new Vector3d(0.25, -0.25, 0);
            Point3d pt4c = pt4b + new Vector3d(-0.25, -0.25, 0);
            Point3d pt5a = pt4c + new Vector3d(-0.125, 0, 0);
            Point3d pt6 = pt5a + new Vector3d(0, 0.25, 0);
            Point3d pt5b = pt6 + new Vector3d(Math.Sin(Math.PI / 4) * -0.25, Math.Sin(Math.PI / 4) * -0.25, 0);
            Point3d pt5c = pt5a + new Vector3d(-0.25, 0.25, 0);
            Arc arc1 = new Arc(pt1, 0.25, Math.PI / 2);
            Line ln1 = new Line(pt2, pt3a);
            Arc arc2 = new Arc(pt3a, pt3b, pt3c);
            Line ln2 = new Line(pt3c, pt4a);
            Arc arc3 = new Arc(pt4a, pt4b, pt4c);
            Line ln3 = new Line(pt4c, pt5a);
            Arc arc4 = new Arc(pt5a, pt5b, pt5c);
            letterCrvs.Add(arc1.ToNurbsCurve());
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(arc2.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(arc3.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            letterCrvs.Add(arc4.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterT(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 1.0, 0);
            Line ln1 = new Line(pt1, new Vector3d(1.0, 0, 0), (double)(5.0 / 8.0));
            Point3d pt2 = pt1 + new Vector3d((double)(2.5 / 8.0), 0, 0);
            Line ln2 = new Line(pt2, new Vector3d(0, -1.0, 0), 1.0);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterU(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 1.0, 0);
            Point3d pt2a = pt1 + new Vector3d(0, -0.6875, 0);
            Point3d pt2b = pt2a + new Vector3d(0.3125, -0.3125, 0);
            Point3d pt2c = pt2b + new Vector3d(0.3125, 0.3125, 0);
            Point3d pt3 = pt2c + new Vector3d(0, 0.6875, 0);
            Line ln1 = new Line(pt1, pt2a);
            Arc arc1 = new Arc(pt2a, pt2b, pt2c);
            Line ln2 = new Line(pt2c, pt3);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(arc1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterV(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 1.0, 0);
            Point3d pt2 = pt1 + new Vector3d(0.3125, -1.0, 0);
            Point3d pt3 = pt2 + new Vector3d(0.3125, 1.0, 0);
            Line ln1 = new Line(pt1, pt2);
            Line ln2 = new Line(pt2, pt3);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterW(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt0 = pt + new Vector3d(kerning, 1.0, 0);
            Line ln1 = new Line(pt0, new Vector3d(0, -1.0, 0), 1.0);
            Point3d pt1 = pt0 + new Vector3d(0, -1.0, 0);
            Line ln2 = new Line(pt1, new Vector3d(0.3125, 0.54126587736527415422732698172059, 0), 0.625);
            Point3d pt2 = pt1 + new Vector3d(0.3125, 0.54126587736527415422732698172059, 0);
            Line ln3 = new Line(pt2, new Vector3d(0.3125, -0.54126587736527415422732698172059, 0), 0.625);
            Point3d pt3 = pt2 + new Vector3d(0.3125, -0.54126587736527415422732698172059, 0);
            Line ln4 = new Line(pt3, new Vector3d(0, 1.0, 0), 1.0);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            letterCrvs.Add(ln4.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterX(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1a = pt + new Vector3d(kerning, 0.0, 0);
            Point3d pt1b = pt1a + new Vector3d(0.625, 1.0, 0);
            Line ln1 = new Line(pt1a, pt1b);
            Point3d pt2a = pt1a + new Vector3d(0.0, 1.0, 0);
            Point3d pt2b = pt2a + new Vector3d(0.625, -1.0, 0);
            Line ln2 = new Line(pt2a, pt2b);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterY(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(0.3125 + kerning, 0, 0);
            Line ln1 = new Line(pt1, new Vector3d(0, 0.5, 0), 0.5);
            Point3d pt2 = pt1 + new Vector3d(0, 0.5, 0);
            Line ln2 = new Line(pt2, new Vector3d(-0.3125, 0.5, 0), Math.Sqrt(Math.Pow(0.3125, 2.0) + Math.Pow(0.5, 2.0)));
            Line ln3 = new Line(pt2, new Vector3d(0.3125, 0.5, 0), Math.Sqrt(Math.Pow(0.3125, 2.0) + Math.Pow(0.5, 2.0)));
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }

        private List<Curve> LetterZ(Point3d pt)
        {
            List<Curve> letterCrvs = new List<Curve>();
            Point3d pt1 = pt + new Vector3d(kerning, 1.0, 0);
            Line ln1 = new Line(pt1, new Vector3d(0.625, 0, 0), 0.625);
            Point3d pt2 = pt1 + new Vector3d(0.625, 0, 0);
            Line ln2 = new Line(pt2, new Vector3d(-0.625, -1.0, 0), 1.1792476415070754764150825472028);
            Point3d pt3 = pt2 + new Vector3d(-0.625, -1.0, 0);
            Line ln3 = new Line(pt3, new Vector3d(0.625, 0, 0), 0.625);
            letterCrvs.Add(ln1.ToNurbsCurve());
            letterCrvs.Add(ln2.ToNurbsCurve());
            letterCrvs.Add(ln3.ToNurbsCurve());
            currentPt = pt + new Vector3d(0.625 + (2 * kerning), 0, 0);
            return letterCrvs;
        }
    }
}
