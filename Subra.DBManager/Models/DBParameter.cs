using Subra.DBManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Subra.DBManager
{
    public class DBParameter
    {
        private string _name;
        private object _value;
        private int _size;
        private DBType _dbType;
        private ParameterDirection _direction;
        private bool _isNullable;

        public DBParameter() { }
        public DBParameter(string name, object value) { }
        public DBParameter(string name, DBType dbType, object value=null) { }
        public DBParameter(string name, DBType dbType, int size, ParameterDirection direction, object value = null) { }
        public DBParameter(string name, DBType dbType, int size, ParameterDirection direction, bool IsNullable, object value = null) { }
        public DBParameter(string name, DBType dbType, int size, ParameterDirection direction) { }
        public DBParameter(string name, DBType dbType, int size, ParameterDirection direction, bool IsNullable) { }

        public string Name
        {
            set
            {
                _name = value;
            }
        }
        public object Value
        {
            set
            {
                _value = value;
            }
        }
        public DBType DbType
        {
            set
            {
                _dbType = value;
            }
        }
        public ParameterDirection Direction
        {
            set
            {
                _direction = value;
            }
        }
        public bool IsNullable
        {
            set
            {
                _isNullable= value;
            }
        }
    }
    
}