using MvcWepApp2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWepApp2.Models
{
    public class Quiz
    {
        SqlDataProcess data;

        //constructor
        public Quiz()
        {
            AdSoyad = "";
            Tarih = Convert.ToDateTime("01.01.2000");
            //dependency injection
            data = new SqlDataProcess();
        }

        //proparty
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public string AdSoyad { get; set; }
        public string soyad { get; set; }


        //geri dönüş tipi olmayan metot
        public void Ornek()
        {

        }

        //geri dönüş tipi bool olan metot
        public bool Ornek2()
        {
            return true;
        }
    }
}