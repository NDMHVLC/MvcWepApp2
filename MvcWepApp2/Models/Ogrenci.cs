using MvcWepApp2.DAL;
using MvcWepApp2.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace MvcWepApp2.Models
{
    public class Ogrenci : ModelBase
    {
        SqlDataProcess data;
        public Ogrenci()
        {
            data = new SqlDataProcess();
        }


        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string No { get; set; }
        public int  SinifId { get; set; }
        public Sinif _Sinif { get; set; }


        public List<Ogrenci> OgrencileriGetir()
        {
            List<Ogrenci> ogrenciler = new List<Ogrenci>();


            DataTable dtogrenciler = data.GetExecuteDataTable("Ogrenci_ListeGetir", CommandType.StoredProcedure);


            foreach (DataRow dataRow in dtogrenciler.Rows)
            {
                ogrenciler.Add(new Ogrenci
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    Adi = dataRow["Adi"].ToString(),
                    Soyadi = dataRow["Soyadi"].ToString(),
                    No = dataRow["No"].ToString(),
                    _Sinif = new Sinif
                    {
                        Adi = dataRow["SinifAdi"].ToString(),
                        Kodu = dataRow["SinifKodu"].ToString()
                    }

                });
            }
            return ogrenciler;
        }
        public List<Ogrenci> OgrencileriGetirSinifId()
        {
            List<Ogrenci> ogrenciler = new List<Ogrenci>();


            DataTable dtogrenciler = data.GetExecuteDataTable("Ogrenci_ListeGetirSinifId", CommandType.StoredProcedure,
                new SqlParameter("@SinifId",SinifId));


            foreach (DataRow dataRow in dtogrenciler.Rows)
            {
                ogrenciler.Add(new Ogrenci
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    Adi = dataRow["Adi"].ToString(),
                    Soyadi = dataRow["Soyadi"].ToString(),
                    No = dataRow["No"].ToString()                   

                });
            }
            return ogrenciler;
        }
        public Ogrenci OgrenciGetirId()
        {
            DataTable dt = data.GetExecuteDataTable("Ogrenci_Getir", CommandType.StoredProcedure, new SqlParameter("@id", Id));
            Ogrenci _ogrenci = new Ogrenci();
            if (dt.Rows.Count > 0)
            {
                _ogrenci.Id = dt.Rows[0].Field<int>("Id");
                _ogrenci.Adi = dt.Rows[0].Field<string>("Adi");
                _ogrenci.Soyadi = dt.Rows[0].Field<string>("Soyadi");
                _ogrenci.No = dt.Rows[0].Field<string>("No");
                _ogrenci._Sinif = new Sinif { Adi = dt.Rows[0].Field<string>("SinifAdi") };
            }

            return _ogrenci;

        }
        public bool Ekle()
        {
            try
            {
                return data.SetExecuteNonQuery("Insert into Ogrenci (Adi,Soyadi,No,SinifId) values(@Adi, @Soyadi, @No, @sinifId)",
                    CommandType.Text,
                    new SqlParameter("@Adi", Adi),
                    new SqlParameter("@Soyadi", Soyadi),
                    new SqlParameter("@No", No),
                    new SqlParameter("@sinifId", _Sinif.Id)

                    );
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Sil()
        {
            try
            {
                return data.SetExecuteNonQuery("Delete from Ogrenci where Id=@id", CommandType.Text,
                    new SqlParameter("@id", Id));
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Duzenle()
        {
            return data.SetExecuteNonQuery("Update Ogrenci set SinifId=@sinifid where Id=@id",
                CommandType.Text,
                new SqlParameter("@sinifid", _Sinif.Id),
                new SqlParameter("@id", Id)
                );

        }
    }
}
