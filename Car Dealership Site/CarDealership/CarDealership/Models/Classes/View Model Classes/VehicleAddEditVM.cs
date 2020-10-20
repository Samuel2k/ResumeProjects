using CarDealership.UI.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.Models.Classes.View_Model_Classes
{
    public class VehicleAddEditVM
    {
        public Vehicle Vehicle { get; set; }
        public Color Color { get; set; }
        public Make Make { get; set; }
        public Model Model { get; set; }
        public BodyStyle BodyStyle { get; set; }
        public Interior Interior { get; set; }

        public List<SelectListItem> ColorList { get; set; }
        public List<SelectListItem> MakeList { get; set; }
        public List<SelectListItem> ModelList { get; set; }
        public List<SelectListItem> BodyStyleList { get; set; }
        public List<SelectListItem> InteriorList { get; set; }
        public List<SelectListItem> TransmissionList { get; set; }
        public List<SelectListItem> TypeList { get; set; }

        public VehicleAddEditVM()
        {
            ColorList = new List<SelectListItem>();
            MakeList = new List<SelectListItem>();
            ModelList = new List<SelectListItem>();
            BodyStyleList = new List<SelectListItem>();
            InteriorList = new List<SelectListItem>();
            TransmissionList = new List<SelectListItem>();
            TypeList = new List<SelectListItem>();
        }

        public void SetColorItems(IEnumerable<Color> colors)
        {
            foreach (var color in colors)
            {
                ColorList.Add(new SelectListItem()
                {
                    Value = color.ColorId.ToString(),
                    Text = color.ColorName
                });
            }
        }

        public void SetBodyStyleItems(IEnumerable<BodyStyle> bodyStyles)
        {
            foreach (var bodyStyle in bodyStyles)
            {
                BodyStyleList.Add(new SelectListItem()
                {
                    Value = bodyStyle.BodyStyleId.ToString(),
                    Text = bodyStyle.BodyStyleName
                });
            }
        }

        public void SetMakeItems(IEnumerable<Make> makes)
        {
            foreach (var make in makes)
            {
                MakeList.Add(new SelectListItem()
                {
                    Value = make.MakeId.ToString(),
                    Text = make.MakeName
                });
            }
        }

        public void SetModelItems(IEnumerable<Model> models)
        {
            foreach (var model in models)
            {
                ModelList.Add(new SelectListItem()
                {
                    Value = model.ModelId.ToString(),
                    Text = model.ModelName
                });
            }
        }

        public void SetInteriorItems(IEnumerable<Interior> interiors)
        {
            foreach (var interior in interiors)
            {
                InteriorList.Add(new SelectListItem()
                {
                    Value = interior.InteriorId.ToString(),
                    Text = interior.InteriorName
                });
            }
        }

        public void SetTransmissionItems(IEnumerable<string> transmissions)
        {
            foreach (var transmission in transmissions)
            {
                TransmissionList.Add(new SelectListItem()
                {
                    Value = transmission.ToString(),
                    Text = transmission.ToString()
                });
            }
        }

        public void SetTypeItems(IEnumerable<string> types)
        {
            foreach (var type in types)
            {
                TypeList.Add(new SelectListItem()
                {
                    Value = type.ToString(),
                    Text = type.ToString()
                });
            }
        }
    }
}