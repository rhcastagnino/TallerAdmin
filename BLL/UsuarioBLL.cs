﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BE;
using Servicios;
using System.IO;
using Interfaces;
using DAL;
using System.Collections;
using System.Data;

namespace BLL
{
    public class UsuarioBLL : IUsuario
    {
        private Usuario Usuario;
        private UsuarioDAL UsuarioDAL;
        private Encriptador encriptador;
        private BitacoraBLL bitacoraBLL;

        public UsuarioBLL()
        {
            Usuario = new Usuario();
            UsuarioDAL = new UsuarioDAL();
            encriptador = new Encriptador();
            bitacoraBLL = new BitacoraBLL();
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
            catch (RegexMatchTimeoutException ex)
            {
                return false;
            }
            catch (ArgumentException ex)
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

        public void AltaUsario(Usuario usuario)
        {
            try
            {
                UsuarioBLL usuarioBLL = new UsuarioBLL();
                Usuario = usuarioBLL.GetUsuario(usuario.Email);
                string mailEncriptado = encriptador.Encriptar(usuario.Email);
                if (Usuario.Email == mailEncriptado)
                {
                    throw new Exception($"El mail {usuario.Email} ya se encuentra registrado");
                }
                if (ValidarEmail(usuario.Email) == false)
                {
                    throw new Exception("El email no puede estar vacío y debe respertar el formato");
                }
                if (usuario.Nombre.Length <= 2 || usuario.Apellido.Length <= 2)
                {
                    throw new Exception("Nombre y/o Apellido del usuario no pueden tener menos de 2 caracteres");
                }
                usuario.Email = encriptador.Encriptar(usuario.Email.ToLower());
                usuario.Password = GenerarContrasenia();
                string passtxt = usuario.Password;
                usuario.Password = encriptador.Hash(usuario.Password);
                UsuarioDAL.AltaUsaurio(usuario);
                GenerarArchivoContrasenia(usuario.Apellido,passtxt);
                bitacoraBLL.RegistrarBitacora($"Se dio de alta al usuario {encriptador.Desencriptar(usuario.Email)} {usuario.Apellido} {usuario.Nombre}","Alta",Usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GenerarContrasenia()
        {
            try
            {
                Random rdn = new Random();
                string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                int longitud = caracteres.Length;
                char letra;
                int longitudContrasenia = 10;
                string contraseniaAleatoria = string.Empty;
                for (int i = 0; i < longitudContrasenia; i++)
                {
                    letra = caracteres[rdn.Next(longitud)];
                    contraseniaAleatoria += letra.ToString();
                }
                return contraseniaAleatoria;
            }
            catch 
            {
                throw new Exception("Error generando password aleatoria");
            }

        }

        public void GenerarArchivoContrasenia(string apellido, string password)
        {
            try
            {
                
                StreamWriter sw = new StreamWriter("C:\\Users\\Public\\Desktop\\"+apellido+".txt");
                sw.WriteLine("Bienvenido a TallerAdmin, para ingresar al sistema ingrese la siguiente contraseña");
                sw.WriteLine(password);
                sw.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Excepcion: " + ex.Message);
            }

        }

        public Usuario GetUsuario(string email)
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

        public void Login(string email, string pass, IIdioma idioma)
        {
            try
            {
                if (ValidarEmail(email) == true)
                {
                    UsuarioBLL usuarioBLL = new UsuarioBLL();
                    Usuario = usuarioBLL.GetUsuario(email);
                    if (encriptador.Encriptar(email) == Usuario.Email)
                    {
                        if (Usuario.Contador <= 3)
                        {
                            if (encriptador.Hash(pass) == Usuario.Password)
                            {
                                if (Session.GetInstance == null)
                                {
                                    Session.IniciarSession(Usuario, idioma);
                                    if (Usuario.Contador > 0)
                                    {
                                        usuarioBLL.RestablecerContador(Usuario);
                                    }
                                }
                            }
                            else
                            {
                                usuarioBLL.IncrementarContador(Usuario);
                                bitacoraBLL.RegistrarBitacora($"Se ingreso incorrectamente la password del usuario {email}", "Baja", Usuario);
                                throw new Exception("Contraseña incorrecta");
                            }

                        }
                        else
                        {
                            bitacoraBLL.RegistrarBitacora($"Se bloquea el usuario {email}", "Alta", Usuario);
                            throw new Exception($"Su usuario {encriptador.Desencriptar(Usuario.Email)} se encuentra Bloqueado. Contacte al admnistrador.");
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

        public void IncrementarContador(Usuario usuario)
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

        public void RestablecerContador(Usuario usuario)
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

        public void GuardarPermisos(Usuario usr)
        {
            try
            {
                UsuarioDAL.GuardarPermisos(usr);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<Usuario> TraerUsuarios()
        {

                IList<Usuario> listaUsuarios = UsuarioDAL.TraerUsuarios();
                List<Usuario> listaUsuariosFinal = new List<Usuario>();
                foreach (var lu in listaUsuarios)
                {
                Usuario usr = new Usuario();
                    usr.Email = encriptador.Desencriptar(lu.Email);
                    usr.Nombre = lu.Nombre;
                    usr.Apellido = lu.Apellido;
                    usr.Id = lu.Id;
                    listaUsuariosFinal.Add(usr);
                }
                return listaUsuariosFinal;
        }
    }
}
