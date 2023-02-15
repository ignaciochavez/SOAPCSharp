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

        public HeroeInsertDTO()
        {

        }

        public HeroeInsertDTO(string name, string home, DateTimeOffset appearance, string description, string imgBase64String)
        {
            Name = name;
            Home = home;
            Appearance = appearance;
            Description = description;
            ImgBase64String = imgBase64String;
        }
    }

    public class HeroeListDTO
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public HeroeListDTO()
        {

        }

        public HeroeListDTO(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }

    public class HeroeExistByNameAndNotSameEntityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public HeroeExistByNameAndNotSameEntityDTO()
        {

        }

        public HeroeExistByNameAndNotSameEntityDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class HeroeExcelDTO
    {
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }

        public HeroeExcelDTO()
        {

        }

        public HeroeExcelDTO(string fileName, byte[] fileContent)
        {
            FileName = fileName;
            FileContent = fileContent;
        }
    }

    public class HeroePDFDTO
    {
        public string FileName { get; set; }        
        public byte[] FileContent { get; set; }

        public HeroePDFDTO()
        {

        }

        public HeroePDFDTO(string fileName, byte[] fileContent)
        {
            FileName = fileName;
            FileContent = fileContent;
        }
    }
}
