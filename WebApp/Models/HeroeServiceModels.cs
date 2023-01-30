using Business.DTO;
using Business.Entity;
using Business.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class HeroeServiceSelect
    {
        public MessageVO MessageVO { get; set; }
        public Heroe Heroe { get; set; }
    }

    public class HeroeServiceInsert
    {
        public MessageVO MessageVO { get; set; }
        public Heroe Heroe { get; set; }
    }

    public class HeroeServiceUpdate
    {
        public MessageVO MessageVO { get; set; }
        public bool Update { get; set; }
    }

    public class HeroeServiceDelete
    {
        public MessageVO MessageVO { get; set; }
        public bool Delete { get; set; }
    }

    public class HeroeServiceList
    {
        public MessageVO MessageVO { get; set; }
        public List<Heroe> Heroes { get; set; }
    }

    public class HeroeServiceTotalRecords
    {
        public MessageVO MessageVO { get; set; }
        public long TotalRecordss { get; set; }
    }

    public class HeroeServiceExcel
    {
        public MessageVO MessageVO { get; set; }
        public HeroeExcelDTO Excel { get; set; }
    }

    public class HeroeServicePDF
    {
        public MessageVO MessageVO { get; set; }
        public HeroePDFDTO PDF { get; set; }
    }
}