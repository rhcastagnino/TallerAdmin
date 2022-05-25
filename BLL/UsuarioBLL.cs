using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BE;
using Servicios;

namespace BLL
{
    public class UsuarioBLL
    {
        private BE.Usuario Usuario;
        private DAL.UsuarioDAL UsuarioDAL;
        private Encriptador encriptador;

        public UsuarioBLL()
        {
            Usuario = new BE.Usuario();
            UsuarioDAL = new DAL.UsuarioDAL();
            encriptador = new Encriptador();
        }

        private bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));
                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();
                    string domainName = idn.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,@"^[^@\s]+@[^@\s]+\.[^@\s]+$",RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    

        public void AltaUsario(BE.Usuario usuario)
        {
            try
            {
                UsuarioBLL usuarioBLL = new UsuarioBLL();
                Usuario = usuarioBLL.GetUsuario(usuario.email);
                string mailEncriptado = encriptador.Encriptar(usuario.email);
                if (Usuario.email == mailEncriptado)
                {
                    throw new Exception($"El mail {usuario.email} ya se encuentra registrado");
                }
                if (ValidarEmail(usuario.email) == false)
                {
                    throw new Exception("El email no puede estar vacío y debe respertar el formato");
                }
                if (usuario.password.Length < 8 || usuario.password.Length > 15)
                {
                    throw new Exception("Password de usuario tiene que tener mas de 8 y 15 caracteres");
                }
                if (usuario.nombre.Length <= 2 || usuario.apellido.Length <= 2)
                {
                    throw new Exception("Nombre y/o Apellido del usuario no pueden tener menos de 2 caracteres");
                }
                usuario.email = encriptador.Encriptar(usuario.email.ToLower());
                usuario.password = encriptador.Hash(usuario.password);
                UsuarioDAL.AltaUsaurio(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public BE.Usuario GetUsuario(string email)
        {
            try
            {
                email = encriptador.Encriptar(email.ToLower());
                Usuario = UsuarioDAL.GetUsaurio(email);
                return Usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Login(string email, string pass)
        {
            try
            {
                if (ValidarEmail(email) == true)
                {
                    UsuarioBLL usuarioBLL = new UsuarioBLL();
                    Usuario = usuarioBLL.GetUsuario(email);
                    if (encriptador.Encriptar(email) == Usuario.email)
                    {
                        if (encriptador.Hash(pass) == Usuario.password)
                        {
                            if (Usuario.contador <= 2)
                            {
                                if (Session.GetInstance == null)
                                {
                                    Session.IniciarSession(Usuario);
                                    if (Usuario.contador > 0)
                                    {
                                        usuarioBLL.RestablecerContador(Usuario);
                                    }
                                }
                            }
                            else
                            {
                                throw new Exception($"Su usuario {encriptador.Desencriptar(Usuario.email)} se encuentra Bloqueado. Contacte al admnistrador.");
                            }

                        }
                        else
                        {
                            usuarioBLL.IncrementarContador(Usuario);
                            throw new Exception("Contraseña incorrecta");
                        }
                    }
                    else
                    {
                        throw new Exception($"El mail {email} no se encuentra registrado");
                    }
                }
                else
                {
                    throw new Exception($"El email {email} no es válido");
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message); 
            }
        }

        public void Logout()
        {
            Session.CerrarSession();
        }

        public void IncrementarContador(BE.Usuario usuario)
        {
            try
            {
                UsuarioDAL.IncrementarContador(usuario);
            }
            catch (Exception ex) 
            { 
                throw new Exception (ex.Message);
            }

        }

        public void RestablecerContador(BE.Usuario usuario)
        {
            try
            {
                UsuarioDAL.RestablecerContador(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
