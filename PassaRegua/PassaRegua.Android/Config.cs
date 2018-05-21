using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(PassaRegua.Droid.Config))]
namespace PassaRegua.Droid
{
    class Config : IConfig
    {
        private string _diretorioDB;
        public string DiretorioDB
        {
            //Implementado o metodo get do atributo DiretorioDB da interface
            //Retorna o caminho do diretorio onde podera ser criado o banco de dados SQLite
            get
            {
                if (String.IsNullOrEmpty(_diretorioDB))
                {
                    _diretorioDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                return _diretorioDB;
            }
        }

        private ISQLitePlatform _plataforma;
        public ISQLitePlatform Plataforma
        {
            //Implemetado o metodo get do atributo Plataforma da interface
            get
            {
                if(_plataforma == null)
                {
                    _plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }
                return _plataforma;
            }
        }
    }
}