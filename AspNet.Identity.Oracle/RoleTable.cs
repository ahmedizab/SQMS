﻿using System;
using System.Collections.Generic;
using System.Linq;
using Oracle.DataAccess.Client;

namespace AspNet.Identity.Oracle
{
    /// <summary>
    /// Class that represents the Role table in the Oracle Database
    /// </summary>
    public class RoleTable 
    {
        private OracleDatabase _database;

        /// <summary>
        /// Constructor that takes a Oracle Database instance 
        /// </summary>
        /// <param name="database"></param>
        public RoleTable(OracleDatabase database)
        {
            _database = database;
        }

        /// <summary>
        /// Deltes a role from the Roles table
        /// </summary>
        /// <param name="roleId">The role Id</param>
        /// <returns></returns>
        public int Delete(string roleId)
        {
            const string commandText = @"DELETE FROM ASPNETROLES WHERE ID = :ID";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter {ParameterName = "ID", Value = roleId, OracleDbType = OracleDbType.Varchar2 },
            };

            return _database.Execute(commandText, parameters);
        }

        /// <summary>
        /// Inserts a new Role in the Roles table
        /// </summary>
        /// <param name="role">The role's name</param>
        /// <returns></returns>
        public int Insert(IdentityRole role)
        {
            const string commandText = @"INSERT INTO ASPNETROLES (ID, NAME) VALUES (:ID, :NAME)";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter {ParameterName = "ID", Value = role.Id, OracleDbType = OracleDbType.Varchar2 },
                new OracleParameter {ParameterName = "NAME", Value = role.Name, OracleDbType = OracleDbType.Varchar2 },
            };

            return _database.Execute(commandText, parameters);
        }

        /// <summary>
        /// Returns a role name given the roleId
        /// </summary>
        /// <param name="roleId">The role Id</param>
        /// <returns>Role name</returns>
        public string GetRoleName(string roleId)
        {
            const string commandText = @"SELECT NAME FROM ASPNETROLES WHERE ID = :ID";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter {ParameterName = "ID", Value = roleId, OracleDbType = OracleDbType.Varchar2 },
            };

            return _database.GetStrValue(commandText, parameters);
        }

        /// <summary>
        /// Returns the role Id given a role name
        /// </summary>
        /// <param name="roleName">Role's name</param>
        /// <returns>Role's Id</returns>
        public string GetRoleId(string roleName)
        {
            const string commandText = @"SELECT ID FROM ASPNETROLES WHERE NAME = :NAME";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter {ParameterName = "NAME", Value = roleName, OracleDbType = OracleDbType.Varchar2 },
            };

            var result = _database.QueryValue(commandText, parameters);
            return result != null ? Convert.ToString(result) : null;
        }

        /// <summary>
        /// Gets the IdentityRole given the role Id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public IdentityRole GetRoleById(string roleId)
        {
            var roleName = GetRoleName(roleId);
            IdentityRole role = null;

            if(roleName != null)
            {
                role = new IdentityRole(roleName, roleId);
            }

            return role;

        }

        /// <summary>
        /// Gets the IdentityRole given the role name
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public IdentityRole GetRoleByName(string roleName)
        {
            var roleId = GetRoleId(roleName);
            IdentityRole role = null;

            if (roleId != null)
            {
                role = new IdentityRole(roleName, roleId);
            }

            return role;
        }

        /// <summary>
        /// Update Role's attributes
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public int Update(IdentityRole role)
        {
            const string commandText = @"UPDATE ASPNETROLES SET NAME = :NAME WHERE ID = :ID";
            var parameters = new List<OracleParameter>
            {
                new OracleParameter {ParameterName = "NAME", Value = role.Name, OracleDbType = OracleDbType.Varchar2 },
                new OracleParameter {ParameterName = "ID", Value = role.Id, OracleDbType = OracleDbType.Varchar2 },
            };
            
            return _database.Execute(commandText, parameters);
        }

        /// <summary>
        /// Get the all Roles
        /// </summary>
        /// <returns>IdentityRole</returns>
        public IEnumerable<IdentityRole> GetRoles()
        {
            const string commandText = @"SELECT ID, NAME FROM ASPNETROLES";
            var results = _database.Query(commandText, null);

            return results.Select(result => new IdentityRole
            {
                Id = string.IsNullOrEmpty(result["ID"]) ? null : result["ID"],
                Name = string.IsNullOrEmpty(result["NAME"]) ? null : result["NAME"],
            }).ToList();
        }
    }
}
