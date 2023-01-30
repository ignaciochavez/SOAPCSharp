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
    }

    public class ExampleServiceInsert
    {
        public MessageVO MessageVO { get; set; }
        public Example Example { get; set; }
    }

    public class ExampleServiceUpdate
    {
        public MessageVO MessageVO { get; set; }
        public bool Updated { get; set; }
    }

    public class ExampleServiceDelete
    {
        public MessageVO MessageVO { get; set; }
        public bool Delete { get; set; }
    }

    public class ExampleServiceList
    {
        public MessageVO MessageVO { get; set; }
        public List<Example> Examples { get; set; }
    }

    public class ExampleServiceTotalRecords
    {
        public MessageVO MessageVO { get; set; }
        public long TotalRecords { get; set; }
    }

    public class ExampleServiceExcel
    {
        public MessageVO MessageVO { get; set; }
        public ExampleExcelDTO Excel { get; set; }
    }

    public class ExampleServicePDF
    {
        public MessageVO MessageVO { get; set; }
        public ExamplePDFDTO PDF { get; set; }
    }
}