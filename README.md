# GENERATING DISTANCE MATRIX FROM POINTS IN A 2D PLANE and TRAVELING POINTS USING NEAREST NEIGHBOR ALGORITHM

Projenin ilk bölümünde 2 boyutlu (2D) Öklid uzayında noktalar üretmeniz ve bu noktalar
üzerinde bazı hesaplamalar gerçekleştirmeniz istenmektedir. Şekil 1’de örnek bir 2D Öklid
düzlemi verilmiş olup düzlemin başlangıç noktası (0, 0) sol üst köşe olarak belirlenmiştir.

![image](https://user-images.githubusercontent.com/109876399/193858649-d86d64e8-0a77-487a-86c1-f318792602cd.png)

----------------------------------

- **a) Rastgele Nokta Üretimi**: Genişliği (width) ve yüksekliği (height) verilen 2 boyutlu
alan içerinde n adet rastgele nokta üreten ve döndüren metodu yazınız. Üretilen noktalar
n x 2 ‘lik bir matris içerisinde; her bir satır bir noktaya ve her bir sütun da sırasıyla x
ve y koordinat değerlerine karşılık gelecek biçimde saklanacak ve döndürülecektir.
Üretilecek koordinatlar double tipinde olmalıdır.
Bu metodu aşağıdaki parametreler ile ayrı ayrı test ediniz: Test sonucu döndürülen matrisin
bilgilerini (her bir nokta için x ve y koordinat değerleri) konsola yazdırınız.
1. n=20, width=100, height=100
2. n=50, width=100, height=100

## Çıktısı

![image](https://user-images.githubusercontent.com/109876399/193860706-565bb4c7-0abc-475b-b61e-bce173d5be18.png)
![image](https://user-images.githubusercontent.com/109876399/193860483-edf4858b-1fcd-4ae1-ac1f-3b03eb10f3e3.png)
![image](https://user-images.githubusercontent.com/109876399/193860571-47e320a5-fd57-4efb-8c7c-a1a7cd244564.png)

------------
- **b)  Matrisi (Distance Matrix-DM) Üretimi**: Kendisine verilen nx2 noktalar
matrisini (bir önceki maddede istenen metot kullanılarak üretilmiş) nxn’lik uzaklık
matrisine çeviren ve döndüren metodu yazınız. Uzaklık matrisi (DM) her bir nokta çifti
arasındaki uzaklık bilgisini içermektedir. Örneğin, DM[i,j] i ve j noktaları arasındaki
mesafeyi verecektir. Uzaklıklar simetrik olduğundan DM[i,j]=DM[j,i] eşitliği
sağlanacaktır (i’den j’ye uzaklık ile j’den i’ye uzaklık aynıdır). Tablo 1’de örnek bir
uzaklık matrisi yer almaktadır.
Bu metodu n=20, width=100, height=100 parametreleri ile test ediniz. Üretilen
DM’yi konsola yazdırınız.
Tablo 1: 6 adet nokta için örnek bir Uzaklık Matrisi (Distance Matrix – DM)

![image](https://user-images.githubusercontent.com/109876399/193861289-99d56151-5076-4b5a-bc2d-601c3b8740b9.png)

## Çıktısı

![image](https://user-images.githubusercontent.com/109876399/193878020-53d79aea-93a1-49a3-8aa1-6a2e8414acbf.png)

--------------------------------
- n = 20 için rastgele bir noktadan başlayarak tüm noktaları en yakın komşu
yöntemine (nearest neighbor) göre dolaşan metodu yazınız (En yakın komşu
yöntemi, Öklid uzaklığına göre başlangıç noktasına en yakın noktayı bularak
devam eder. Sonra, dolaşılmamış noktalar içinde bu yeni noktaya en yakın
noktaya gider. Tüm noktalar dolaşılana kadar bu işlem devam eder ve turu
tamamlar). Toplam yol uzunluğunu hesaplayınız. Bunu 10 farklı rastgele
başlangıç noktası için tekrarlayınız ve 10 farklı tur için aşağıdaki bilgileri konsolda
listeleyiniz:

- DM (uzaklık matrisi),

  Her bir tur için:
- Tur numarası (1’den 10’a kadar),
- İlgili turda sırayla hangi numaralı noktalara uğradığı, (5-2-0-1-3-4 gibi),
- Turun toplam yol uzunluğu (5-2-0-1-3-4 turu çıktıysa uzaklıklar toplamı).


## Çıktısı

![image](https://user-images.githubusercontent.com/109876399/193878370-cc1cd2a2-cbc4-4c95-9151-a01aaaa41e81.png)
