using System;

namespace Interfaces
{
    public interface IUsuario
    {
        public void Login(string email, string pass, IIdioma idioma) { }
    }
}
