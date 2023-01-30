using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Business.DTO
{
    public class HeroeInsertDTO
    {
        public string Name { get; set; }
        public string Home { get; set; }

        [XmlElement("Appearance")]
        public string AppearanceForXml
        {
            get
            {
                return Appearance.ToString("o");
            }
            set
            {
                DateTimeOffset.TryParse(value, out Appearance);
            }
        }

        [XmlIgnore]
        public DateTimeOffset Appearance;
        public string Description { get; set; }
        public string ImgBase64String { get; set; }
    }

    public class HeroeListDTO
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }

    public class HeroeExistByNameAndNotSameEntityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class HeroeExcelDTO
    {
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
    }

    public class HeroePDFDTO
    {
        public string FileName { get; set; }        
        public byte[] FileContent { get; set; }
    }
}
