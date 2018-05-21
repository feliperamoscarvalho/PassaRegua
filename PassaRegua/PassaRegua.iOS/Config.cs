using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(PassaRegua.iOS.Config))]
namespace PassaRegua.iOS
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
                    var diretorio = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    _diretorioDB = System.IO.Path.Combine(diretorio, "..", "Library");
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
                if (_plataforma == null)
                {
                    _plataforma = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
                }
                return _plataforma;
            }
        }
    }
}