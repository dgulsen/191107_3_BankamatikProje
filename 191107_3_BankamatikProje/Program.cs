using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _191107_3_BankamatikProje
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DevoBank'a Hoşgeldiniz..");
            string secim;
            double bakiye = 250;
            Console.WriteLine("Kartlı İşlem 1\nKartsız İşlem 2\nGiriniz..");
            do
            {
                secim = Oku();
                if (secim != "1" && secim != "2")
                {
                    Console.WriteLine("Yanlış seçim yaptınız lütfen tekrar deneyiniz!");
                }
            } while (secim != "1" && secim != "2");
            
            if (secim == "1") 
            {
                Console.WriteLine(KartlıIslem(secim, bakiye));
            }
            if (secim == "2") 
            {
                Console.WriteLine(KartsızIslem(secim));
            }
        }
        static string Oku()
        {
            return Console.ReadLine();
        }
        static string KartlıIslem(string secim, double bakiye)
        {
            Console.WriteLine("**********Kartlı İşlem Bölümü**********");
            int hak = 0;
            string sifre = "";
            do
            {
                Console.Write("Şifrenizi giriniz: ");
                sifre = Oku();
                if (sifre == "ab18")
                {
                    return AnaMenu(bakiye, sifre);
                }
                else
                {
                    hak++;
                }
            } while (hak < 3);
            return "Şifrenizi 3 defa yanlış girdiğiniz için bloke edildiniz!";
        }
        static string KartsızIslem(string secim)
        {
            return "Kartsız İşlem";
        }
        static string AnaMenu(double bakiye,string sifre)
        {
            Console.WriteLine("**********Ana Menü**********");
            string secilen;
            Console.WriteLine("Para Çekme 1\nPara Yatırma 2\nPara Transferleri 3\nEğitim Ödemeleri 4\nÖdemeler 5\nBilgi Güncelleme 6\nGiriniz..");
            do
            {
                secilen = Oku();
                if (secilen == "1")
                {
                    return ParaCekme(bakiye, sifre);
                }
                if (secilen == "2")
                {
                    return ParaYatirma(bakiye,sifre);
                }
                if (secilen == "3")
                {
                    return ParaTrasferi(bakiye,sifre);
                }
                if (secilen == "4")
                {
                    return EgitimOdemeleri(bakiye,sifre);
                }
                if (secilen == "5")
                {
                    return Odemeler(bakiye,sifre);
                }
                if (secilen == "6")
                {
                    return BilgiGuncelle(bakiye, sifre);
                }
                Console.WriteLine("Yanlış seçim yaptınız lütfen tekrar deneyiniz!"); 
            } while (secilen != "1" && secilen != "2" && secilen != "3" && secilen != "4" && secilen != "5" && secilen != "6");
            return "";
        }
        static string ParaCekme(double bakiye,string sifre)
        {
            Console.WriteLine("**********Para Çekme**********");
            string secilen = "";
            double para = 0;
            Console.Write("Çekmek istediğiniz miktarı giriniz: ");
            para = double.Parse(Oku()); 
            if (bakiye >= para) 
            {
                bakiye = bakiye - para;
                Console.WriteLine("Para çekme işleminiz başarılı.\nKalan Bakiyeniz: " + bakiye); 
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye."); 
            }
            Console.WriteLine("Ana Menü 9\nÇıkış 0\nGiriniz..");
            do
            {
                secilen = Oku();
                if (secilen == "9")
                {
                    return AnaMenu(bakiye,sifre);
                }
                if (secilen == "0")
                {
                    return "Hoşça kalın.";
                }
                Console.WriteLine("Yanlış seçim yaptınız lütfen tekrar deneyiniz!");
            } while (secilen != "9" && secilen != "0");
            return "";
        }
        static string ParaYatirma(double bakiye, string sifre)
        {
            Console.WriteLine("**********Para Yatırma**********");
            string secilen = "";
            Console.WriteLine("Kredi Kartına 1\nKendi Hesabına 2\nAna Menü 9\nÇıkış 0\nGiriniz..");
            do
            {
                secilen = Oku();
                if (secilen == "1")
                {
                    return KrediKartı(bakiye, sifre);
                }
                if (secilen == "2")
                {
                    return KendiHesabına(bakiye, sifre);
                }
                if (secilen == "9")
                {
                    return AnaMenu(bakiye, sifre);
                }
                if (secilen == "0")
                {
                    return "Hoşça Kalın.";
                }
                Console.WriteLine("Yanlış seçim yaptınız lütfen tekrar deneyiniz!");
            } while (secilen != "1" && secilen != "2" && secilen != "9" && secilen != "0");
            return "";
        }
        static string KrediKartı(double bakiye,string sifre)
        {
            string secilen = "";
            double kkarti = 0, para = 0;
            int basamak = 0;
            Console.Write("Kredi kartı numaranızı giriniz: ");
            do
            {
                try
                {
                    kkarti = double.Parse(Oku());
                    while (kkarti >= 1)
                    {
                        kkarti /= 10;
                        basamak++;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Hatalı giriş yaptınız!");
                }
                if (basamak != 12)
                {
                    Console.WriteLine("Kredi kartı numaranız 12 haneli olmalıdır. Lütfen tekrar giriniz!");
                    basamak = 0;
                }
            } while (basamak != 12);
            Console.Write("Yatırmak istediğiniz miktarı giriniz: "); 
            try
            {
                para = double.Parse(Oku());
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı para miktarı girişi yaptınız!");
            }
            if (bakiye >= para) 
            {
                bakiye = bakiye - para;
                Console.WriteLine("Para yatırma işleminiz başarılı. Bakiyeniz: {0}", bakiye);
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye.");
            }
            Console.WriteLine("Ana Menü 9\nÇıkış 0\nGiriniz..");
            do
            {
                secilen = Oku();
                if (secilen == "9")
                {
                    return AnaMenu(bakiye,sifre);
                }
                if (secilen == "0")
                {
                    return "Hoşça Kalın.";
                }
                Console.WriteLine("Yanlış seçim yaptınız lütfen tekrar deneyiniz!");
            } while (secilen != "9" && secilen != "0");
            return "";
        }
        static string KendiHesabına(double bakiye, string sifre)
        {
            string secilen = "";
            double para = 0;
            Console.Write("Yatırmak istediğiniz miktarı giriniz: ");
            try
            {
                para = double.Parse(Oku());
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı para miktarı girişi yaptınız!");
            }
            bakiye = bakiye + para;
            Console.WriteLine("Para yatırma işleminiz başarılı. Bakiyeniz: {0}", bakiye);
            Console.WriteLine("Ana Menü 9\nÇıkış 0\nGiriniz..");
            do
            {
                secilen = Oku();
                if (secilen == "9")
                {
                    return AnaMenu(bakiye, sifre);
                }
                if (secilen == "0")
                {
                    return "Hoşça Kalın.";
                }
                Console.WriteLine("Yanlış seçim yaptınız lütfen tekrar deneyiniz!");
            } while (secilen != "9" && secilen != "0");
            return "";
        }
        static string ParaTrasferi(double bakiye, string sifre)
        {
            Console.WriteLine("**********Para Transferleri**********");
            string secilen = "";
            Console.WriteLine("Başka Hesaba EFT 1\nBaşka Hesaba Havale 2\nAna Menü 9\nÇıkış 0\nGiriniz..");
            do
            {
                secilen = Oku();
                if (secilen == "1")
                {
                    return EFT(bakiye,sifre);
                }
                if (secilen == "2")
                {
                    return Havale(bakiye,sifre);
                }
                if (secilen == "9")
                {
                    return AnaMenu(bakiye,sifre);
                }
                if (secilen == "0")
                {
                    return "Hoşça Kalın.";
                }
                Console.WriteLine("Yanlış seçim yaptınız lütfen tekrar deneyiniz!");
            } while (secilen != "1" && secilen != "2" && secilen != "9" && secilen != "0");
            return "";
        }
        static string EFT(double bakiye,string sifre)
        {
            string secilen = "";
            double iban = 0, para = 0;
            int basamak = 0;
            Console.Write("IBAN numaranızı giriniz: TR");
            do
            {
                try
                {
                    iban = double.Parse(Oku());
                    while (iban >= 1)
                    {
                        iban /= 10;
                        basamak++;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Hatalı giriş yaptınız!");
                }
                if (basamak != 12)
                {
                    Console.Write("IBAN numaranız 12 haneli olmalıdır. Lütfen tekrar giriniz!\nTR");
                    basamak = 0;
                }
            } while (basamak != 12);
            Console.Write("Yatırmak istediğiniz miktarı giriniz: ");
            try
            {
                para = double.Parse(Oku());
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı para miktarı girişi yaptınız!");
            }
            if (bakiye >= para)
            {
                bakiye = bakiye - para;
                Console.WriteLine("Para transfer işleminiz başarılı. Kalan Bakiyeniz: {0}", bakiye);
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye.");
            }
            Console.WriteLine("Ana Menü 9\nÇıkış 0\nGiriniz..");
            do
            {
                secilen = Oku();
                if (secilen == "9")
                {
                    return AnaMenu(bakiye,sifre);
                }
                if (secilen == "0")
                {
                    return "Hoşça Kalın.";
                }
                Console.WriteLine("Yanlış seçim yaptınız lütfen tekrar deneyiniz!");
            } while (secilen != "9" && secilen != "0");
            return "";
        }
        static string Havale(double bakiye,string sifre)
        {
            string secilen = "";
            double hesap = 0, para = 0;
            int basamak = 0;
            Console.Write("Hesap numaranızı giriniz: ");
            do
            {
                try
                {
                    hesap = double.Parse(Oku());
                    while (hesap >= 1)
                    {
                        hesap /= 10;
                        basamak++;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Hatalı giriş yaptınız!");
                }
                if (basamak != 11)
                {
                    Console.WriteLine("Hesap numaranız 11 haneli olmalıdır. Lütfen tekrar giriniz!");
                    basamak = 0;
                }
            } while (basamak != 11);
            Console.Write("Yatırmak istediğiniz miktarı giriniz: ");
            try
            {
                para = double.Parse(Oku());
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı para miktarı girişi yaptınız!");
            }
            if (bakiye >= para)
            {
                bakiye = bakiye - para;
                Console.WriteLine("Para transfer işleminiz başarılı. Kalan Bakiyeniz: {0}", bakiye);
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye.");
            }
            Console.WriteLine("Ana Menü 9\nÇıkış 0\nGiriniz..");
            do
            {
                secilen = Oku();
                if (secilen == "9")
                {
                    return AnaMenu(bakiye,sifre);
                }
                if (secilen == "0")
                {
                    return "Hoşça Kalın.";
                }
                Console.WriteLine("Yanlış seçim yaptınız lütfen tekrar deneyiniz!");
            } while (secilen != "9" && secilen != "0");
            return "";
        }
        static string EgitimOdemeleri(double bakiye,string sifre)
        {
            Console.WriteLine("**********Eğitim Ödemeleri**********");
            Console.WriteLine("Eğitim ödemeleri sayfası teknik bir arızadan dolayı kapalıdır.");
            string secilen = "";
            Console.WriteLine("Ana Menü 9\nÇıkış 0\nGiriniz..");
            do
            {
                secilen = Oku();
                if (secilen == "9")
                {
                    return AnaMenu(bakiye,sifre);
                }
                if (secilen == "0")
                {
                    return "Hoşça kalın.";
                }
                Console.WriteLine("Yanlış seçim yaptınız lütfen tekrar deneyiniz!");
            } while (secilen != "9" && secilen != "0");
            return "";
        }
        static string Odemeler(double bakiye,string sifre)
        {
            Console.WriteLine("**********Ödemeler**********");
            string secilen = "";
            Console.WriteLine("Elektrik Faturası 1\nTelefon Faturası 2\nİnternet Faturası 3\nSu Faturası 4\nOGS Ödemeleri 5\nGiriniz..");
            do
            {
                secilen = Oku();
                if (secilen == "1")
                {
                    return Elektrik(bakiye,sifre);
                }
                if (secilen == "2")
                {
                    return Telefon(bakiye,sifre);
                }
                if (secilen == "3")
                {
                    return Internet(bakiye,sifre);
                }
                if (secilen == "4")
                {
                    return Su(bakiye,sifre);
                }
                if (secilen == "5")
                {
                    return OGS(bakiye,sifre);
                }
                Console.WriteLine("Yanlış seçim yaptınız lütfen tekrar deneyiniz!");
            } while (secilen != "1" && secilen != "2" && secilen != "3" && secilen != "4" && secilen != "5");
            return "";
        }
        static string Elektrik(double bakiye,string sifre)
        {
            string secilen = "";
            double fatura = 0;
            Console.Write("Elektrik faturası tutarını giriniz: ");
            fatura = double.Parse(Oku());
            if (bakiye >= fatura)
            {
                bakiye = bakiye - fatura;
                Console.WriteLine("Fatura yatırma işlemi başarılı.\nKalan Bakiyeniz: " + bakiye);
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye.");
            }
            Console.WriteLine("Ana Menü 9\nÇıkış 0\nGiriniz..");
            do
            {
                secilen = Oku();
                if (secilen == "9")
                {
                    return AnaMenu(bakiye,sifre);
                }
                if (secilen == "0")
                {
                    return "Hoşça kalın.";
                }
                Console.WriteLine("Yanlış seçim yaptınız lütfen tekrar deneyiniz!");
            } while (secilen != "9" && secilen != "0");
            return "";
        }
        static string Telefon(double bakiye,string sifre)
        {
            string secilen = "";
            double fatura = 0;
            Console.Write("Telefon faturası tutarını giriniz: ");
            fatura = double.Parse(Oku());
            if (bakiye >= fatura)
            {
                bakiye = bakiye - fatura;
                Console.WriteLine("Fatura yatırma işlemi başarılı.\nKalan Bakiyeniz: " + bakiye);
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye.");
            }
            Console.WriteLine("Ana Menü 9\nÇıkış için 0\nGiriniz..");
            do
            {
                secilen = Oku();
                if (secilen == "9")
                {
                    return AnaMenu(bakiye,sifre);
                }
                if (secilen == "0")
                {
                    return "Hoşça kalın.";
                }
                Console.WriteLine("Yanlış seçim yaptınız lütfen tekrar deneyiniz!");
            } while (secilen != "9" && secilen != "0");
            return "";
        }
        static string Internet(double bakiye,string sifre)
        {
            string secilen = "";
            double fatura = 0;
            Console.Write("İnternet faturası tutarını giriniz: ");
            fatura = double.Parse(Oku());
            if (bakiye >= fatura)
            {
                bakiye = bakiye - fatura;
                Console.WriteLine("Fatura yatırma işlemi başarılı.\nKalan Bakiyeniz: " + bakiye);
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye.");
            }
            Console.WriteLine("Ana Menü 9\nÇıkış 0\nGiriniz..");
            do
            {
                secilen = Oku();
                if (secilen == "9")
                {
                    return AnaMenu(bakiye,sifre);
                }
                if (secilen == "0")
                {
                    return "Hoşça kalın.";
                }
                Console.WriteLine("Yanlış seçim yaptınız lütfen tekrar deneyiniz!");
            } while (secilen != "9" && secilen != "0");
            return "";
        }
        static string Su(double bakiye,string sifre)
        {
            string secilen = "";
            double fatura = 0;
            Console.Write("Su faturası tutarını giriniz: ");
            fatura = double.Parse(Oku());
            if (bakiye >= fatura)
            {
                bakiye = bakiye - fatura;
                Console.WriteLine("Fatura yatırma işlemi başarılı.\nKalan Bakiyeniz: " + bakiye);
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye.");
            }
            Console.WriteLine("Ana Menü 9\nÇıkış için 0\nGiriniz..");
            do
            {
                secilen = Oku();
                if (secilen == "9")
                {
                    return AnaMenu(bakiye,sifre);
                }
                if (secilen == "0")
                {
                    return "Hoşça kalın.";
                }
                Console.WriteLine("Yanlış seçim yaptınız lütfen tekrar deneyiniz!");
            } while (secilen != "9" && secilen != "0");
            return "";
        }
        static string OGS(double bakiye,string sifre)
        {
            string secilen = "";
            double fatura = 0;
            Console.Write("OGS tutarını giriniz: ");
            fatura = double.Parse(Oku());
            if (bakiye >= fatura)
            {
                bakiye = bakiye - fatura;
                Console.WriteLine("Fatura yatırma işlemi başarılı.\nKalan Bakiyeniz: " + bakiye);
            }
            else
            {
                Console.WriteLine("Yetersiz bakiye.");
            }
            Console.WriteLine("Ana Menü 9\nÇıkış 0\nGiriniz..");
            do
            {
                secilen = Oku();
                if (secilen == "9")
                {
                    return AnaMenu(bakiye,sifre);
                }
                if (secilen == "0")
                {
                    return "Hoşça kalın.";
                }
                Console.WriteLine("Yanlış seçim yaptınız lütfen tekrar deneyiniz!");
            } while (secilen != "9" && secilen != "0");
            return "";
        }
        static string BilgiGuncelle(double bakiye, string sifre)
        {
            Console.WriteLine("**********Bilgi Güncelleme**********");
            string secilen = "";
            Console.WriteLine("Şifre Değiştirme 1\nAna Menü 9\nÇıkış 0\nGiriniz..");
            do
            {
                secilen = Oku();
                if (secilen == "1")
                {
                    return SifreDegistirme(sifre);
                }
                if (secilen == "9")
                {
                    return AnaMenu(bakiye, sifre);
                }
                if (secilen == "0")
                {
                    return "Hoşça kalın.";
                }
                Console.WriteLine("Yanlış seçim yaptınız lütfen tekrar deneyiniz!");
            } while (secilen != "1" && secilen != "9" && secilen != "0");
            return "";
        }
        static string SifreDegistirme(string sifre)
        {
            Console.Write("Yeni şifrenizi giriniz: ");
            sifre = Oku();
            Console.WriteLine("Şifre değiştirme işlemi başarıyla gerçekleştirildi.");
            Console.WriteLine("Yeni Şifreniz: {0}", sifre);
            return "";
        }
        //System.Threading.Thread.Sleep(3000);//bekletme kodu
        //Environment.Exit(0);//Console çıkış kodu.parametre int değer alır, bu değeri işletim sistemine gönderir.
    }
}
