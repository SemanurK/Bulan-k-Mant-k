using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BulanıkMantık_153301046
{
    class TemelKural
    {
        public static string[,] kurallar = {
                             { "hassas", "küçük", "küçük", "hassas", "kısa", "çok az" },//1
                             { "hassas", "küçük", "orta", "normal hassas", "kısa", "az" },//2
                             { "hassas", "küçük", "büyük", "orta", "normal kısa", "orta" },//3
                             { "hassas", "orta", "küçük", "hassas", "kısa", "orta" },//4
                             { "hassas", "orta", "orta", "normal hassas", "normal kısa", "orta" },//5
                             { "hassas", "orta", "büyük", "orta", "orta", "fazla" },//6
                             { "hassas", "büyük", "küçük", "normal hassas", "normal kısa", "orta" },//7
                             { "hassas", "büyük", "orta", "normal hassas", "orta", "fazla" },//8
                             { "hassas", "büyük", "büyük", "orta", "normal uzun", "fazla" },//9

                             { "orta", "küçük", "küçük", "normal hassas", "normal kısa", "az" },//10
                             { "orta", "küçük", "orta", "orta", "kısa", "orta" },//11
                             { "orta", "küçük", "büyük", "normal güçlü", "orta", "fazla" },//12
                             { "orta", "orta", "küçük", "normal hassas", "normal kısa", "orta" },//13
                             { "orta", "orta", "orta", "orta", "orta", "orta" },//14
                             { "orta", "orta", "büyük", "hassas", "uzun", "fazla" },//15
                             { "orta", "büyük", "küçük", "hassas", "orta", "orta" },//16
                             { "orta", "büyük", "orta", "hassas", "normal uzun", "fazla" },//17
                             { "orta", "büyük", "büyük", "hassas", "uzun", "çok fazla" },//18

                             { "sağlam", "küçük", "küçük", "orta", "orta", "az" },//19
                             { "sağlam", "küçük", "orta", "normal güçlü", "orta", "orta" },//20
                             { "sağlam", "küçük", "büyük", "güçlü", "normal uzun", "fazla" },//21
                             { "sağlam", "orta", "küçük", "orta", "orta", "orta" },//22
                             { "sağlam", "orta", "orta", "normal güçlü", "normal uzun", "orta" },//23
                             { "sağlam", "orta", "büyük", "güçlü", "orta", "çok fazla" },//24
                             { "sağlam", "büyük", "küçük", "normal güçlü", "normal uzun", "fazla" },//25
                             { "sağlam", "büyük", "orta", "normal güçlü", "uzun", "fazla" },//26
                             { "sağlam", "büyük", "büyük", "güçlü", "uzun", "çok fazla" }}; //27
    }

    class BulanıkMantık
    {
       public  double hassaslik, miktar, kirlilik;
      
       public string[] uyeliktipi = { "yamuk1", "üçgen","yamuk2" };

        public  List<string> kirliligi = new List<string>();
        public  List<string> kir_uyelik = new List<string>();       
        public  List<string> miktari = new List<string>();
        public List<string> mik_uyelik = new List<string>();   
        public List<string> has_uyelik = new List<string>();   
        public List<string> hassasligi = new List<string>();

        


        public BulanıkMantık(double hassaslik, double miktar, double kirlilik)
        {
            this.hassaslik = hassaslik;
            this.kirlilik = kirlilik;
            this.miktar = miktar;
            Hassasiyet(hassaslik);
            Miktar(miktar);
            Kirlilik(kirlilik);
            
        }
        public void Hassasiyet(double h)
        {            
            if (h > 0 && h < 3)
                hassasligi.Add ("sağlam");
            else if (h > 4 && h < 5.5)
                hassasligi.Add( "orta");
            else if (h > 7 && h <= 10)
                hassasligi.Add( "hassas");
            else if (h >= 3 && h <= 4)
            {
                hassasligi.Add("sağlam");hassasligi.Add( "orta");
            }               
            else if (h >= 5.5 && h <= 7)
            {
                hassasligi.Add("orta"); hassasligi.Add( "hassas");
            }
            if (hassasligi.Count == 1)
            {
                if (hassasligi[0] == "sağlam")
                    has_uyelik.Add(uyeliktipi[0]);
                else if (hassasligi[0] == "hassas")
                    has_uyelik.Add(uyeliktipi[2]/*yamuk2*/);
                else if (hassasligi[0] == "orta")
                    has_uyelik.Add(uyeliktipi[1]);
            } else
            { 
             if (hassasligi[0] == "sağlam" && hassasligi[1] == "orta")
                {
                    has_uyelik.Add(uyeliktipi[0]); has_uyelik.Add(uyeliktipi[1]);
                }
                else
                {
                    has_uyelik.Add(uyeliktipi[1]); has_uyelik.Add(uyeliktipi[2]);
                }
            }

        }
        public void  Kirlilik(double k)
        {            
            if (k > 0 && k < 3)
                kirliligi.Add( "küçük");//bulanık küme 
            else if (k > 4.5 && k < 5.5)
                kirliligi.Add("orta");
            else if (k > 7 && k <= 10)
                kirliligi.Add("büyük");
            else if(k>=3 && k<=4.5)
            {
                kirliligi.Add( "küçük");kirliligi.Add("orta");
            }
            else if(k>=5.5 && k<=7)
            {
                kirliligi.Add( "orta"); kirliligi.Add( "büyük");
            }
            if (kirliligi.Count == 1)
            {
                if (kirliligi[0] == "küçük")
                    kir_uyelik.Add(uyeliktipi[0]);
                else if (kirliligi[0] == "büyük")
                    kir_uyelik.Add(uyeliktipi[2]);
                else if (kirliligi[0] == "orta")
                    kir_uyelik.Add(uyeliktipi[1]);
            }
            else
            { 
             if (kirliligi[0] == "küçük" && kirliligi[1] == "orta")
                {
                    kir_uyelik.Add(uyeliktipi[0]); kir_uyelik.Add(uyeliktipi[1]);
                }
                else
                {
                    kir_uyelik.Add(uyeliktipi[1]); kir_uyelik.Add(uyeliktipi[2]);
                }
            }

        }
        public   void Miktar(double m)
        {  
            if (m > 0 && m < 3)
                miktari.Add( "küçük");
            else if (m > 4 && m < 5.5)
                miktari.Add( "orta");
            else if (m > 7 && m <= 10)
                miktari.Add( "büyük");
            else if (m >= 3 && m <= 4)
            {
                miktari.Add( "küçük");miktari.Add( "orta");
            }
            else if (m >= 5.5 && m <= 7)
            {
                miktari.Add( "orta"); miktari.Add( "büyük");
            }
            if (miktari.Count == 1)
            {
                if (miktari[0] == "küçük")
                    mik_uyelik.Add(uyeliktipi[0]);
                else if (miktari[0] == "büyük")
                    mik_uyelik.Add(uyeliktipi[2]);
                else if (miktari[0] == "orta")
                    mik_uyelik.Add(uyeliktipi[1]);
            }
            else
            { 
                if (miktari[0] == "küçük" && miktari[1] == "orta")
                {
                    mik_uyelik.Add(uyeliktipi[0]); mik_uyelik.Add(uyeliktipi[1]);
                }
                else
                {
                    mik_uyelik.Add(uyeliktipi[1]); mik_uyelik.Add(uyeliktipi[2]);
                }
            }
        }
        public void Kume(Label bir, Label iki, Label uc)
        {
            if (hassasligi.Count > 1)
                bir.Text = hassasligi[0] + "," + hassasligi[1];
            else
                bir.Text = hassasligi[0];
            if (miktari.Count > 1)
                iki.Text = miktari[0] + "," + miktari[1];
            else
                iki.Text = miktari[0];
            if (kirliligi.Count > 1)
                uc.Text = kirliligi[0] + "," + kirliligi[1];
            else
                uc.Text=kirliligi[0];
            bir.BackColor = iki.BackColor = uc.BackColor = Color.DarkSeaGreen;

        }

        
        
        /// <summary>
        /// ////////////
        /// </summary>
        double[] h_aralik_yamuk1 = { -4, 1.5, 2, 4 };
        double[] h_aralik_ucgen = { 3, 5, 7 };
        double[] h_aralik_yamuk2 = { 5.5, 8, 12.5, 14 };

        double[] m_aralik_yamuk1 = { -4, 1.5, 2, 4 };
        double[] m_aralik_ucgen = { 3, 5, 7 };
        double[] m_aralik_yamuk2 = { 5.5, 8, 12.5, 14 };

        double[] k_aralik_yamuk1 = { -4.5, -2.5, 2, 4.5 };
        double[] k_aralik_ucgen = { 3, 5, 7 };
        double[] k_aralik_yamuk2 = { 5.5, 8, 12.5, 15 };
        double mamdani;

        /*  public void Mamdani()
          {
              if(has_uyelik.Count==1)
              {
                  if (has_uyelik.Contains("yamuk1"))
                  {
                      if (hassaslik >= h_aralik_yamuk1[0] && hassaslik <= h_aralik_yamuk1[1])
                      {
                          has_mamdani = (hassaslik - h_aralik_yamuk1[0]) / (h_aralik_yamuk1[1] - h_aralik_yamuk1[0]);
                      }
                      else if (hassaslik >= h_aralik_yamuk1[1] && hassaslik <= h_aralik_yamuk1[2])
                      {
                          has_mamdani = 1;
                      }
                      else if (hassaslik >= h_aralik_yamuk1[2] && hassaslik <= h_aralik_yamuk1[3])
                      {
                          has_mamdani = (h_aralik_yamuk1[3] - hassaslik) / (h_aralik_yamuk1[3] - h_aralik_yamuk1[2]);
                      }
                      else
                          has_mamdani = 0;
                  }
                  else if (has_uyelik.Contains("yamuk2"))
                  {
                      if (hassaslik >= h_aralik_yamuk1[0] && hassaslik <= h_aralik_yamuk1[1])
                      {
                          has_mamdani = (hassaslik - h_aralik_yamuk1[0]) / (h_aralik_yamuk1[1] - h_aralik_yamuk1[0]);
                      }
                      else if (hassaslik >= h_aralik_yamuk1[1] && hassaslik <= h_aralik_yamuk1[2])
                      {
                          has_mamdani = 1;
                      }
                      else if (hassaslik >= h_aralik_yamuk1[2] && hassaslik <= h_aralik_yamuk1[3])
                      {
                          has_mamdani = (h_aralik_yamuk1[3] - hassaslik) / (h_aralik_yamuk1[3] - h_aralik_yamuk1[2]);
                      }
                      else
                          has_mamdani = 0;
                  }
                  else//ucgen ise 
                  {
                      if (hassaslik >= h_aralik_ucgen[0] && hassaslik <= h_aralik_ucgen[1])
                      {
                          has_mamdani = (hassaslik - h_aralik_ucgen[0]) / (h_aralik_ucgen[1] - h_aralik_ucgen[0]);
                      }
                      else if (hassaslik >= h_aralik_ucgen[1] && hassaslik <= h_aralik_ucgen[2])
                      {
                          has_mamdani = (h_aralik_ucgen[0] - hassaslik) / (h_aralik_ucgen[2] - h_aralik_ucgen[1]);
                      }
                      else
                          has_mamdani = 0;
                  }
              }
          }*/
        public double Mamdani_Hesapla(string uyelik,double [] y1, double [] u , double []y2,double girilen_deger)
        {
            mamdani = 0;
            //uyelik tipi , aralıkları ve girilen değer (hassasiyet,miktar, kirlilik)
           // if (uyelik.Count == 1)
            {
                if (uyelik.Contains("yamuk1"))
                {
                    if (girilen_deger >= y1[0] && girilen_deger <= y1[1])
                    {
                        mamdani = (girilen_deger - y1[0]) / (y1[1] - y1[0]);
                    }
                    else if (girilen_deger >= y1[1] && girilen_deger <= y1[2])
                    {
                         mamdani = 1;
                    }
                    else if (girilen_deger >= y1[2] && girilen_deger <= y1[3])
                    {
                         mamdani = (y1[3] - girilen_deger) / (y1[3] - y1[2]);
                    }
                    else
                        mamdani = 0;
                }
                else if (uyelik.Contains("yamuk2"))
                {
                    if (girilen_deger >= y2[0] && girilen_deger <= y2[1])
                    {
                        mamdani = (girilen_deger - y2[0]) / (y2[1] - y2[0]);
                    }
                    else if (girilen_deger >= y2[1] && girilen_deger <= y2[2])
                    {
                        mamdani = 1;
                    }
                    else if (girilen_deger >= y2[2] && girilen_deger <= y2[3])
                    {
                        mamdani = (y2[3] - girilen_deger) / (y2[3] - y2[2]);
                    }
                    else
                        mamdani = 0;
                }
                else//ucgen ise 
                {
                    if (girilen_deger >= u[0] && girilen_deger <= u[1])
                    {
                        mamdani = (girilen_deger - u[0]) / (u[1] - u[0]);
                    }
                    else if (girilen_deger >= u[1] && girilen_deger <= u[2])
                    {
                        mamdani = (u[2] - girilen_deger) / (u[2] - u[1]);
                    }
                    else
                        mamdani = 0;
                }
            }
            return mamdani;
        }

          double has_mamdani;
          double mik_mamdani;
          double kir_mamdani;
        public List<double> Mamdani_Deger()
        {
            List<double> mamdani_sonuc = new List<double>();

            for (int h = 0; h < has_uyelik.Count; h++)
            {
                for (int m = 0; m < mik_uyelik.Count; m++)
                {
                    for (int k = 0; k < kir_uyelik.Count; k++)
                    {                       
                        has_mamdani = Mamdani_Hesapla(has_uyelik[h], h_aralik_yamuk1, h_aralik_ucgen, h_aralik_yamuk2, hassaslik);
                        mik_mamdani = Mamdani_Hesapla(mik_uyelik[m], m_aralik_yamuk1, m_aralik_ucgen, m_aralik_yamuk2, miktar);
                        kir_mamdani = Mamdani_Hesapla(kir_uyelik[k], k_aralik_yamuk1, k_aralik_ucgen, k_aralik_yamuk2, kirlilik);
                        double[] dizi = { has_mamdani, mik_mamdani, kir_mamdani };
                        mamdani_sonuc.Add(dizi.Min());
                    }
                }
            }
            return mamdani_sonuc;
        }
        List<int> numaralar = new List<int>();
        string[,] kural = TemelKural.kurallar;
        Dictionary<int, double> kural_deger = new Dictionary<int, double>();


        public Dictionary<int,double> NumaraBul()
        {
          //  numaralar.Clear();
            List<double> mamdani_sonuc = new List<double>();
            mamdani_sonuc = Mamdani_Deger();

            for (int k = 0; k < hassasligi.Count; k++)
            {
                for (int m = 0; m < miktari.Count; m++)
                {
                    for (int n = 0; n < kirliligi.Count; n++)
                    {
                        for (int i = 0; i < 27; i++)
                        {
                            if (kural[i, 0] == hassasligi[k] && kural[i, 1] == miktari[m] && kural[i, 2] == kirliligi[n])
                            {
                                numaralar.Add(i+1);
                                i++;                               
                            }
                        }
                    }
                }
            }
         
            for(int x=0; x<numaralar.Count(); x++)
            {
                kural_deger.Add(numaralar[x], mamdani_sonuc[x]);
            }
            return kural_deger;
        }

        double[] dh_hassas_aralik = { -5.8, -2.8, 0.5, 1.5 };
        double[] dh_normal_hassas_aralik = { 0.5, 2.75, 5 };
        double[] dh_orta_aralik = { 2.75, 5, 7.25 };
        double[] dh_normal_guclu_aralik = { 5, 7.25, 9.5};
        double[] dh_guclu_aralik = { 8.5, 9.5, 12.8, 15.2 };

        double[] s_kisa_aralik = { -46.5, -25.28, 22.3, 39.9 };
        double[] s_normal_kisa_aralik = { 22.3, 39.9, 57.5 };
        double[] s_orta_aralik = { 39.9, 57.5, 75.1 };
        double[] s_normal_uzun_aralik = { 57.5, 75.1, 92.7 };
        double[] s_uzun_aralik = { 75, 92.7, 111.6, 130 };
        

        public Dictionary<string,double> mamdami_max(int satir)

        {            
            List<string> sonuc_uyeliktipi= new List<string>();
            Dictionary<int,string> max_min = new Dictionary<int, string>();
            List<double> deneme = new List<double>();            
            double sonuc;
            Dictionary<string, double> deneme_sonuc = new Dictionary<string, double>();
       
         /*   for (int i=0; i<numaralar.Count(); i++)
            {
                if (!sonuc_uyeliktipi.Contains((kural[numaralar[i]-1, 3])))
                {
                    sonuc_uyeliktipi.Add((kural[numaralar[i]-1, 3]));
                }
            }*/
            for(int i=0; i<numaralar.Count(); i++)
            {
                max_min.Add(numaralar[i], (kural[numaralar[i] - 1, satir]));
                //11-orta(donus hızı)

            }
            foreach(var item in max_min)
            {
                if (!deneme_sonuc.Keys.Contains(item.Value))
                {
                    foreach (var item2 in max_min)
                    {
                        if (item.Value == item2.Value)
                        {
                            deneme.Add(kural_deger[item2.Key]);
                        }

                    }
                    sonuc = deneme.Max();
                    deneme_sonuc.Add(item.Value.ToString(), sonuc);
                
                    deneme.Clear();
                }
            }
            return deneme_sonuc;
        }
        public void cikis_fonksiyon_degerler(ListBox dh,ListBox s, ListBox d)
        {
            dh.Items.Clear();
            s.Items.Clear();
            d.Items.Clear();
            Dictionary<string, double> donus_hızı = new Dictionary<string, double>();
            Dictionary<string, double> sure = new Dictionary<string, double>();
            Dictionary<string, double> deterjan = new Dictionary<string, double>();
            donus_hızı = mamdami_max(3);
            foreach(var item in donus_hızı)
            {
                dh.Items.Add(item.Key + " = " + item.Value);
            }
            sure = mamdami_max(4);
            foreach (var item in sure)
            {
                s.Items.Add(item.Key + " = " + item.Value);
            }
            deterjan = mamdami_max(5);
            foreach (var item in deterjan)
            {
                d.Items.Add(item.Key + " = " + item.Value);
            }

        }



    }
}
