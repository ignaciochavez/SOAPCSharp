using Business.DTO;
using Business.Entity;
using Business.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ExampleServiceSelect
    {
        public MessageVO MessageVO { get; set; }
        public Example Example { get; set; }

        public ExampleServiceSelect()
        {

        }

        public ExampleServiceSelect(MessageVO messageVO, Example example)
        {
            MessageVO = messageVO;
            Example = example;
        }
    }

    public class ExampleServiceInsert
    {
        public MessageVO MessageVO { get; set; }
        public Example Example { get; set; }

        public ExampleServiceInsert()
        {

        }

        public ExampleServiceInsert(MessageVO messageVO, Example example)
        {
            MessageVO = messageVO;
            Example = example;
        }
    }

    public class ExampleServiceUpdate
    {
        public MessageVO MessageVO { get; set; }
        public bool Updated { get; set; }

        public ExampleServiceUpdate()
        {

        }

        public ExampleServiceUpdate(MessageVO messageVO, bool updated)
        {
            MessageVO = messageVO;
            Updated = updated;
        }
    }

    public class ExampleServiceDelete
    {
        public MessageVO MessageVO { get; set; }
        public bool Delete { get; set; }

        public ExampleServiceDelete()
        {

        }

        public ExampleServiceDelete(MessageVO messageVO, bool delete)
        {
            MessageVO = messageVO;
            Delete = delete;
        }
    }

    public class ExampleServiceList
    {
        public MessageVO MessageVO { get; set; }
        public List<Example> Examples { get; set; }

        public ExampleServiceList()
        {

        }

        public ExampleServiceList(MessageVO messageVO, List<Example> examples)
        {
            MessageVO = messageVO;
            Examples = examples;
        }
    }

    public class ExampleServiceTotalRecords
    {
        public MessageVO MessageVO { get; set; }
        public long TotalRecords { get; set; }

        public ExampleServiceTotalRecords()
        {

        }

        public ExampleServiceTotalRecords(MessageVO messageVO, long totalRecords)
        {
            MessageVO = messageVO;
            TotalRecords = totalRecords;
        }
    }

    public class ExampleServiceExcel
    {
        public MessageVO MessageVO { get; set; }
        public ExampleExcelDTO Excel { get; set; }

        public ExampleServiceExcel()
        {

        }

        public ExampleServiceExcel(MessageVO messageVO, ExampleExcelDTO excel)
        {
            MessageVO = messageVO;
            Excel = excel;
        }
    }

    public class ExampleServicePDF
    {
        public MessageVO MessageVO { get; set; }
        public ExamplePDFDTO PDF { get; set; }

        public ExampleServicePDF()
        {

        }

        public ExampleServicePDF(MessageVO messageVO, ExamplePDFDTO pdf)
        {
            MessageVO = messageVO;
            PDF = pdf;
        }
    }
}