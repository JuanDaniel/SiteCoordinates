using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;

namespace BBI.JD
{
    public static class Core
    {
        public static Family LoadCoordinateFamily(Document document, string familyName = "ES-Coordenadas")
        {
            Family family = new FilteredElementCollector(document)
                .OfClass(typeof(Family))
                    .Cast<Family>()
                        .FirstOrDefault(x => x.Name == familyName);

            if (family != null)
            {
                return family;
            }

            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            string folder = new FileInfo(assemblyPath).Directory.FullName;

            Transaction transaction = null;

            try
            {
                transaction = new Transaction(document, "Load Coordinate family");

                transaction.Start();

                document.LoadFamily(string.Concat(folder, "/", familyName, ".rfa"), out family);

                transaction.Commit();
            }
            catch (Exception)
            {
                if (null != transaction)
                {
                    transaction.RollBack();
                }
            }

            return family;
        }

        public static bool isSurveyPointPined(Document document)
        {
            List<BasePoint> points = new FilteredElementCollector(document)
                .OfClass(typeof(BasePoint))
                    .Cast<BasePoint>()
                        .ToList();

            BasePoint surveyPoint = points[0].IsShared ? points[0] : points[1];

            Parameter parameterX = surveyPoint.get_Parameter(BuiltInParameter.BASEPOINT_EASTWEST_PARAM);

            return parameterX.IsReadOnly;
        }

        public static bool ExistCoordinate(DataGridViewRowCollection rows, XYZ coordinate, int index = -1)
        {
            foreach (DataGridViewRow row in rows)
            {
                if (index > -1 && index == row.Index)
                {
                    continue;
                }

                double valueX, valueY, valueZ;

                if (row.Cells["cX"].Value == null)
                {
                    continue;
                }
                else
                {
                    valueX = double.Parse(row.Cells["cX"].Value.ToString());
                }

                if (row.Cells["cY"].Value == null)
                {
                    continue;
                }
                else
                {
                    valueY = double.Parse(row.Cells["cY"].Value.ToString());
                }

                if (row.Cells["cZ"].Value == null)
                {
                    continue;
                }
                else
                {
                    valueZ = double.Parse(row.Cells["cZ"].Value.ToString());
                }

                if (valueX == coordinate.X && valueY == coordinate.Y && valueZ == coordinate.Z)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool ExistTag(DataGridViewRowCollection rows, string tag, int index = -1)
        {
            foreach (DataGridViewRow row in rows)
            {
                if (index > -1 && index == row.Index)
                {
                    continue;
                }

                if (row.Cells["cTag"].Value.ToString() == tag)
                {
                    return true;
                }
            }

            return false;
        }

        public static string GenerateTag(DataGridViewRowCollection rows)
        {
            List<string> tags = rows.Cast<DataGridViewRow>()
                                    .Select(row => row.Cells["cTag"].Value.ToString()).ToList();

            if (tags.Count == 0)
            {
                return "P-001";
            }

            string tag = tags.OrderByDescending(x => x).FirstOrDefault();
            string token = "";

            for (int i = 0; i < tag.Length; i++)
            {
                if (tag[i] >= '0' && tag[i] <= '9')
                {
                    token += tag[i];
                }
                else if (tag[i] == '-' || tag[i] == '_' || tag[i] == '/')
                {
                    token = "";
                }
            }

            int number;

            if (!string.IsNullOrEmpty(token) && int.TryParse(token, out number))
            {
                string tmp = tag.Substring(0, tag.Length - token.Length);

                tmp = tmp.PadRight(tag.Length, '0');

                token = (++number).ToString();

                char[] chars = tmp.ToCharArray();

                for (int i = 0, j = chars.Length - 1; i < token.Length; i++)
                {
                    chars[j--] = token[token.Length - i - 1];
                }

                return new string(chars);
            }

            return string.Empty;
        }

        public static void PlaceCoordinates(Document document, List<CP> coordinates, Family family, SurveyPointOption surveyPointOption = SurveyPointOption.NONE)
        {
            List<BasePoint> points = new FilteredElementCollector(document)
                .OfClass(typeof(BasePoint))
                    .Cast<BasePoint>()
                        .ToList();

            BasePoint basePoint = !points[0].IsShared ? points[0] : points[1];
            BasePoint surveyPoint = points[0].IsShared ? points[0] : points[1];

            Parameter surveyX = surveyPoint.get_Parameter(BuiltInParameter.BASEPOINT_EASTWEST_PARAM);
            Parameter surveyY = surveyPoint.get_Parameter(BuiltInParameter.BASEPOINT_NORTHSOUTH_PARAM);
            Parameter surveyZ = surveyPoint.get_Parameter(BuiltInParameter.BASEPOINT_ELEVATION_PARAM);

            Transaction transaction = null;

            try
            {
                transaction = new Transaction(document, "Place coordinates");

                transaction.Start();

                FamilySymbol familySymbol = null;

                foreach (ElementId fsid in family.GetFamilySymbolIds())
                {
                    familySymbol = document.GetElement(fsid) as FamilySymbol;
                }

                if (familySymbol != null)
                {
                    if (!familySymbol.IsActive)
                    {
                        familySymbol.Activate();
                    }
                }

                // Update survey point
                switch (surveyPointOption)
                {
                    case SurveyPointOption.CENTROID:
                        CurveLoop profileloop = new CurveLoop();

                        profileloop.

                        break;

                    case SurveyPointOption.POINT:
                        CP coordinate = coordinates.First();

                        surveyX.Set(coordinate.Coordinate.X);
                        surveyY.Set(coordinate.Coordinate.Y);
                        surveyZ.Set(coordinate.Coordinate.Z);

                        break;

                    default:
                        break;
                }

                // Place coordinates
                foreach (CP item in coordinates)
                {
                    // Create family instance
                    FamilyInstance familyInstance = document.Create.NewFamilyInstance(item.Coordinate, familySymbol, StructuralType.Column);
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (null != transaction)
                {
                    transaction.RollBack();

                    throw ex;
                }
            }
        }
    }

    public class CP
    {
        private XYZ coordinate;

        private string tag;

        public CP(XYZ coordinate, string tag)
        {
            this.coordinate = coordinate;
            this.tag = tag;
        }

        public XYZ Coordinate { get => coordinate; }

        public string Tag { get => tag; }
    }

    public enum SurveyPointOption
    {
        NONE = 0,
        CENTROID = 1,
        POINT = 2
    }
}
