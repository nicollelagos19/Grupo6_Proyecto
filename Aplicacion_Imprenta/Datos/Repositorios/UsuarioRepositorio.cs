﻿using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Datos.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private string CadenaConexion;
        public UsuarioRepositorio(string cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }
        //actualizar Usuario
        public async Task<bool> Actualizar(Usuario usuario)
        {
            bool result = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"UPDATE usuario SET Nombre = @Nombre, Clave = @Clave, Rol=@Rol, EstaActivo = @EstaActivo 
                                WHERE Codigo = @Codigo;";
                result = Convert.ToBoolean(await conexion.ExecuteAsync(sql, usuario));

            }
            catch (Exception ex)
            {
            }
            return result;
        }//Fin de la actualizacion

        //Eliminar Usuario
        public async Task<bool> Eliminar(Usuario usuario)
        {
            bool result = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"DELETE FROM usuario WHERE Codigo = @Codigo;";
                result = Convert.ToBoolean(await conexion.ExecuteAsync(sql, new { usuario.Codigo }));
            }
            catch (Exception ex)
            {
            }
            return result;
        }//Fin de eliminar

        //Lista de usuarios
        public async Task<IEnumerable<Usuario>> GetLista()
        {
            IEnumerable<Usuario> lista = new List<Usuario>();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"SELECT * FROM usuario;";
                lista = await conexion.QueryAsync<Usuario>(sql);
            }
            catch (Exception ex)
            {
            }
            return lista;
        }//fin de la lista

        //Usuario por codigo
        public async Task<Usuario> GetPorCodigo(string codigo)
        {
            Usuario user = new Usuario();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"SELECT * FROM usuario WHERE Codigo = @Codigo;";
                user = await conexion.QueryFirstAsync<Usuario>(sql, new { codigo });
            }
            catch (Exception ex)
            {
            }
            return user;
        }//Fin de usuario por codigo

        //Nuevo usuario
        public async Task<bool> Nuevo(Usuario usuario)
        {
            bool result = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"INSERT INTO usuario (Codigo, Nombre, Clave, Rol, EstaActivo) 
                                VALUES (@Codigo, @Nombre, @Clave, @Rol, @EstaActivo);";
                result = Convert.ToBoolean(await conexion.ExecuteAsync(sql, usuario));

            }
            catch (Exception ex)
            {
            }
            return result;
        }//Fin de usuario nuevo
    }
}
