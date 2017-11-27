using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;

namespace PharmacyApp.Droid
{
    //[Activity(Label = "PharmacyApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [Activity(Label = "Nearest Pharmacy",
        Icon = "@drawable/icon",
        Theme = "@style/MyTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);      
            Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

/*1.	Главная страница( при запуске приложения):
-	По всему экрану упрощенный список самых популярных товаров(Только имя, категория , цена и наличие).
-	Сверху поиск, с возможность выбора фильтров.
-	Слева раскрываемый список .
-	В правом нижнем углу корзина.

2.	 Раскрываемый список:            
-	Главная страница.
-	Профиль .
-	Заказы .
-	Информация.
-	Настройки.

3.	Поиск(Фильтры):
-	Категория товара.
-	Тип товара.
-	Цена.
-	Наличие.

4.	Профиль:
-	Данные пользователя.
-	Предоставляемая скидка(Формируется на основе общей суммы заказов пользователя).
-	Возможность редактировать некоторые свои данные.

5.	Заказы:
-	Вся информация о заказах пользователя

6.	Информация:
-	Краткая информация о способах доставки/ оплаты, и всё в таком роде.

7.	Настройки:
-	Версия приложения
-	Данные для связи с магазином
-	Возможность выйти из учётной записи.

8.	Окно товара:
-	Полная информация о товаре, включая описание и изображения.
-	Возможность добавления товара в корзину.

9.	Корзина:
-	Список всех добавленных пользователем товаров.
-	Кнопка оплатить, при нажатии на который, появляются всплывающие окна с возможность выбора из предложенных способы доставки и оплаты.
*/