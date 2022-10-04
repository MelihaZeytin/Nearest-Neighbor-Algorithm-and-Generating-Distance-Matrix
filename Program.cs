using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1
{
    class Program
    {

        static Random random = new Random(); // random nesnesi oluşturma

        static void Main(string[] args)
        {

            double[,] matris1 = RastgeleNoktaUretimi(20, 100, 100); // 20x2lik matris
            Console.WriteLine("{0} adet rastgele nokta üreten matris:", matris1.GetLength(0));
            MatrisYazdir(matris1); // n=20lik matrisin yazdırılması
            double[,] matris2 = RastgeleNoktaUretimi(50, 100, 100); // 50x2lik matris
            Console.WriteLine("{0} adet rastgele nokta üreten matris:", matris2.GetLength(0));
            MatrisYazdir(matris2); // n=50lik matrisin yazdırılması
            double[,] matris3 = UzaklikMatrisi(matris1); // n=20lik matrisin uzaklık matrisi
            Console.WriteLine("{0}'lik Uzaklık Matrisi:", matris1.GetLength(0));
            MatrisYazdir(matris3); // uzaklık matrisinin yazdırılması

            Console.WriteLine();
            EnYakinKomsuYontemi(matris3, 10); // n=20lik matrisin 10 farklı rastgele başlangıç noktası için en yakın komşu methodunun çağrılması
            Console.ReadLine();

        }

        static double[,] RastgeleNoktaUretimi(int n, int width, int height)

        {
            double[,] koordinatlarMatrisi = new double[n, 2]; //n'e 2lik matris oluşturma
            for (int i = 0; i < n; i++) // n sayısı kadar döngüye girilir
            {
                double randomWidth = random.Next(0, width + 1); // 0 ile width arasında random bir sayı üretilir
                double randomHeight = random.Next(0, height + 1); // 0 ile height arasında random bir sayı üretilir

                koordinatlarMatrisi[i, 0] = randomWidth; //matrise üretilen noktalar eklenir
                koordinatlarMatrisi[i, 1] = randomHeight; //matrise üretilen noktalar eklenir
            }

            return koordinatlarMatrisi; // matris döndürülür
        }

        static void MatrisYazdir(double[,] matris)

        {   //tablonun yazdırılması ve formatlanması
            for (int i = 0; i < matris.GetLength(1); i++)
            {
                Console.Write("{0,10}", i);
            }
            Console.WriteLine();
            Console.Write("        ");
            for (int i = 0; i < 10 * matris.GetLength(1); i++)
            {

                Console.Write("-");
            }
            Console.WriteLine();

            //matristeki her noktayı yazdırmak için 2 kere forda dönülür.
            for (int i = 0; i < matris.GetLength(0); i++) //matrisin genişliği kadar dönülür
            {
                Console.Write("{0,4}", i + "|");
                for (int j = 0; j < matris.GetLength(1); j++) // matrisin uzunluğu kadar dönülür
                {
                    Console.Write("{0,9}", matris[i, j]); //matristeki noktanın yazdırılması ve formatlanması
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        static double[,] UzaklikMatrisi(double[,] matris)
        {
            // nx2lik matrisin uzaklık matrisi nxnlik olacaktır.
            double[,] uzaklikMatris = new double[matris.GetLength(0), matris.GetLength(0)]; // nxnlik matrisin oluşturulması

            for (int i = 0; i < matris.GetLength(0); i++) //matrisin uzunluğu kadar dönülür
            {
                double dikeyX = matris[i, 0]; //uzaklığı hesaplanacak 2 noktadan ilkinin x değerinin tanımlanması
                double dikeyY = matris[i, 1]; //uzaklığı hesaplanacak 2 noktadan ilkinin y değerinin tanımlanması

                for (int j = 0; j < matris.GetLength(0); j++) //matrisin uzunluğu kadar dönülür
                {
                    double yatayX = matris[j, 0]; //uzaklığı hesaplanacak 2 noktadan diğerinin x değerinin tanımlanması
                    double yatayY = matris[j, 1]; //uzaklığı hesaplanacak 2 noktadan diğerinin y değerinin tanımlanması

                    double uzaklik = Math.Sqrt(Math.Pow((yatayX - dikeyX), 2) + Math.Pow((yatayY - dikeyY), 2)); // iki nokta arasındaki Öklid uzaklığının hesaplanması
                    uzaklik = Math.Round(uzaklik, 2); //uzaklık değeri virgülden sonra 2 basamağı olacak şekilde yuvarlanır

                    uzaklikMatris[i, j] = uzaklik; //uzaklık matrisine bulunan uzaklık değeri eklenir
                }
            }
            return uzaklikMatris; // uzaklıkMatrisi döndürülür
        }

        static void EnYakinKomsuYontemi(double[,] matris, int n)
        {
            List<int> turBaslangicNoktalari = new List<int>(); // Her turda başlangıç noktasının farklı olması için liste yaratıldı.
            for (int c = 0; c < n; c++) // tur sayısı kadar döngüye girilir
            {
                Console.WriteLine("{0}.TUR", c + 1); //tur numaralarının yazdırılması
                int index = random.Next(0, matris.GetLength(0)); // matristen random bir nokta için rastgele bir index seçilir(her turdaki ilk nokta için)

                while (turBaslangicNoktalari.Contains(index)) //random üretilen index daha önceden başlangıç noktası olduysa while girilir ve uygun index bulunana kadar dönülür.
                    index = random.Next(0, matris.GetLength(0));

                turBaslangicNoktalari.Add(index); // başlangıç noktası listeye eklenir
                int enYakinKomsuIndex = 0; // değişkenin tanımlanması

                // dolaşılan noktalardan birdaha geçmemesi için dolaştığımız noktaların indexi listede tutulur.
                List<int> dolasilanNoktaIndex = new List<int>(); // listenin oluşturulması
                dolasilanNoktaIndex.Add(index); // başlangıç noktası listeye eklenir
                double yolToplami = 0; // yol toplamı değişkeni tanımlanır ve ilk değer ataması yapılır 

                // başlangıç noktası bulunduğu için kalan noktalar kadar döngüye girilir.
                for (int i = 0; i < matris.GetLength(0) - 1; i++)
                {
                    double minUzaklik = 0; // minuzaklık değişkeni tanımlanır ve ilk değer ataması olarak 0 atanır
                    //en yakın noktanın hesaplanması için o satırdaki tüm noktaların kontrol edilmesi gerekir
                    for (int j = 0; j < matris.GetLength(0); j++)
                    {
                        if (!dolasilanNoktaIndex.Contains(j)) // daha önceden o noktadan geçildiyse birdaha geçmemesi için kontrol edilmez
                        {
                            // komşu olabilecek ilk uygun nokta min kabul edilir ve ife girilir
                            // İlk noktadan sonraki diğer uygun noktaların uzaklığı eğer minuzaklıktan küçükse ife girilir.(not: parametre olarak yollanan matris uzaklık matrisidir.)
                            if (minUzaklik >= matris[index, j] || minUzaklik == 0)
                            {
                                minUzaklik = matris[index, j]; //min uzaklık güncellenir
                                enYakinKomsuIndex = j;
                            }
                        }
                    }
                    yolToplami += matris[index, enYakinKomsuIndex]; // noktanın komşuya olan uzaklığı yol toplamına eklenir.
                    dolasilanNoktaIndex.Add(enYakinKomsuIndex); // en yakın komşunun indexi listeye eklenir.(dolaşılmış noktalardan birdaha geçmemek için listede tutulur)
                    index = enYakinKomsuIndex; // komşu, index olur.

                }
                Console.Write("Turda sırasıyla uğradığı noktalar: ");
                for (int i = 0; i < dolasilanNoktaIndex.Count; i++) //dolaşılanNoktaindex listesindeki eleman sayısı kadar döngüye girilir
                {
                    if (i == dolasilanNoktaIndex.Count - 1)
                    {
                        Console.Write(dolasilanNoktaIndex[i]); //son nokta yazdırıldıktan sonra döngüden çıkılır(son noktadan sonra "-" yazdırmaması için bu if bloğu açıldı)
                        break;
                    }
                    Console.Write(dolasilanNoktaIndex[i] + " - "); //dolaşılan noktalar sırasıyla yazdırılır
                }

                Console.WriteLine();
                Console.WriteLine("Turun toplam yol uzunluğu: " + yolToplami); // yol toplamı yazdırılır
                Console.WriteLine();
                Console.WriteLine();
            }
        } // EnYakinKomsuYontemi methodunun sonu
    }
}
