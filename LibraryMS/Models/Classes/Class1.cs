using LibraryMS.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMS.Models.Classes
{
    public class Class1
    {
        /*
         * Bir index sayfasında birden fazla model kullanabilmek için IEnumerable ınterfacinden yararlanacağız.
         * Bununiçin controllerda bu değerlere atama yapacağız
         */ 


        public IEnumerable<tblBook> books { get; set; }
        public IEnumerable<tblAbout> about { get; set; } 
    }
}