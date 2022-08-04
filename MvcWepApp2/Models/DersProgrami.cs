using MvcWepApp2.DAL;
using MvcWepApp2.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcWepApp2.Models
{
    public class DersProgrami : ModelBase
    {
        SqlDataProcess data;
        public DersProgrami()
        {
            data = new SqlDataProcess();
        }
        public string SinifAdi { get; set; }
        public string DersAdi { get; set; }
        public string OgretmenKodu { get; set; }
        public int SinifId { get; set; }
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }


        public List<DersProgrami> ListeGetir()
        {
            DataTable dt = data.GetExecuteDataTable("DersProgrami_Getir", CommandType.StoredProcedure,
                new SqlParameter("@OgretmenCode", OgretmenKodu));
            List<DersProgrami> dersProgrami = new List<DersProgrami>();

            foreach (DataRow row in dt.Rows)
            {
                dersProgrami.Add(new DersProgrami
                {
                    Id = Convert.ToInt32(row["Id"]),
                    DersAdi = row.Field<string>("DersAdi"),
                    SinifAdi = row.Field<string>("SinifAdi"),
                    SinifId = row.Field<int>("SinifId"),
                    Baslangic = row.Field<DateTime>("Baslangic"),
                    Bitis = row.Field<DateTime>("Bitis"),
                });
            }
            return dersProgrami;
        }
    }
}