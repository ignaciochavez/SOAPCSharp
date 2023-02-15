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

        public HeroeServiceSelect()
        {

        }

        public HeroeServiceSelect(MessageVO messageVO, Heroe heroe)
        {
            MessageVO = messageVO;
            Heroe = heroe;
        }
    }

    public class HeroeServiceInsert
    {
        public MessageVO MessageVO { get; set; }
        public Heroe Heroe { get; set; }

        public HeroeServiceInsert()
        {

        }

        public HeroeServiceInsert(MessageVO messageVO, Heroe heroe)
        {
            MessageVO = messageVO;
            Heroe = heroe;
        }
    }

    public class HeroeServiceUpdate
    {
        public MessageVO MessageVO { get; set; }
        public bool Update { get; set; }

        public HeroeServiceUpdate()
        {

        }

        public HeroeServiceUpdate(MessageVO messageVO, bool update)
        {
            MessageVO = messageVO;
            Update = update;
        }
    }

    public class HeroeServiceDelete
    {
        public MessageVO MessageVO { get; set; }
        public bool Delete { get; set; }

        public HeroeServiceDelete()
        {

        }

        public HeroeServiceDelete(MessageVO messageVO, bool delete)
        {
            MessageVO = messageVO;
            Delete = delete;
        }
    }

    public class HeroeServiceList
    {
        public MessageVO MessageVO { get; set; }
        public List<Heroe> Heroes { get; set; }

        public HeroeServiceList()
        {

        }

        public HeroeServiceList(MessageVO messageVO, List<Heroe> heroes)
        {
            MessageVO = messageVO;
            Heroes = heroes;
        }
    }

    public class HeroeServiceTotalRecords
    {
        public MessageVO MessageVO { get; set; }
        public long TotalRecords { get; set; }

        public HeroeServiceTotalRecords()
        {

        }

        public HeroeServiceTotalRecords(MessageVO messageVO, long totalRecords)
        {
            MessageVO = messageVO;
            TotalRecords = totalRecords;
        }
    }

    public class HeroeServiceExcel
    {
        public MessageVO MessageVO { get; set; }
        public HeroeExcelDTO Excel { get; set; }

        public HeroeServiceExcel()
        {

        }

        public HeroeServiceExcel(MessageVO messageVO, HeroeExcelDTO excel)
        {
            MessageVO = messageVO;
            Excel = excel;
        }
    }

    public class HeroeServicePDF
    {
        public MessageVO MessageVO { get; set; }
        public HeroePDFDTO PDF { get; set; }

        public HeroeServicePDF()
        {

        }

        public HeroeServicePDF(MessageVO messageVO, HeroePDFDTO pdf)
        {
            MessageVO = messageVO;
            PDF = pdf;
        }
    }
}