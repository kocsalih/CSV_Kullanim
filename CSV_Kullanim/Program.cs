using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;


namespace CSV_Kullanim
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Musteri> musterilerim = new List<Musteri>();
            for (int i = 0; i < 50; i++)
            {

                Musteri temp = new Musteri();
                temp.id = i.ToString();
                temp.isim = FakeData.NameData.GetFirstName();
                temp.soyisim = FakeData.NameData.GetSurname();
                temp.emailAdres = temp.isim + "." + temp.soyisim + "@" + FakeData.NetworkData.GetDomain();
                temp.telefonNumarasi = FakeData.PhoneNumberData.GetPhoneNumber();
                musterilerim.Add(temp);
                    
                
            }

            //---Okuma---//
            StreamReader SR = new StreamReader(@"c:\CSV\Musteriler.csv");
            CsvHelper.CsvReader Reader = new CsvHelper.CsvReader(SR, System.Globalization.CultureInfo.CurrentCulture);
            List<Musteri> OkunanData = Reader.GetRecords<Musteri>().ToList();
            


            //---yazma---//
            StreamWriter sw = new StreamWriter(@"c:\csv\musteriler.csv");
            CsvHelper.CsvWriter writer = new CsvHelper.CsvWriter(sw, System.Globalization.CultureInfo.CurrentCulture);

            writer.WriteHeader(typeof(Musteri));
            foreach (Musteri item in musterilerim)
            {

                writer.WriteRecord(item);
                writer.NextRecord();
            }
            sw.Close();

        }
    }
}
